using Bloomberglp.Blpapi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bloomberglp.Blpapi.Event;

namespace SGTUtils
{
    public static class BbgStrings
    {
        public static class Services
        {
            public static string REF_DATA_SERVICE = "//blp/refdata";
        }

        public static class Requests
        {
            public static string HISTORICAL_DATA = "HistoricalDataRequest";
        }

        public static class Elements
        {
            public static string SECURITIES = "securities";
            public static string FIELD = "fields";
            public static string OVERRIDES = "overrides";
            
            public static string REASON = "reason";
        }

        public static class FieldNames
        {
            public static string PX_LAST = "PX_LAST";
            public static string PX_OPEN = "PX_OPEN";
            public static string PX_CLOSE = "PX_CLOSE";
            public static string FUND_NET_ASSET_VAL = "FUND_NET_ASSET_VAL";
            public static string TOT_RETURN_INDEX_NET_DVDS = "TOT_RETURN_INDEX_NET_DVDS";
        }

        public static class QueryParams
        {
            public static string START_DATE = "startDate";
            public static string END_DATE = "endDate";
            public static string MAX_DATA_POINTS = "maxDataPoints";
            public static string RETURN_EIDS = "returnEids";
            public static string PERIODICITY_ADJUSTMENT = "periodicityAdjustment";
            public static string PERIODICITY_SELECTION = "periodicitySelection";
            public static string NON_TRADING_DAY_FILL_OPTION = "nonTradingDayFillOption";
            public static string NON_TRADING_DAY_FILL_METHOD = "nonTradingDayFillMethod";
        }
    }

    public class FldNameToFldVal : Dictionary<string, double> { };
    public class DateToFldNameToFldVal : Dictionary<DateTime, FldNameToFldVal> { };
    public class SecurityToDateToFldNameToFldVal : Dictionary<string, DateToFldNameToFldVal> { };

    public class BbgSession
    {
        private static readonly Name SecurityData = new Name("securityData");
        private static readonly Name Security = new Name("security");
        private static readonly Name FieldData = new Name("fieldData");
        private static readonly Name Date = new Name("date");
        private static readonly Name ResponseError = new Name("responseError");
        private static readonly Name SecurityError = new Name("securityError");
        private static readonly Name FieldExceptions = new Name("fieldExceptions");
        private static readonly Name FieldId = new Name("fieldId");
        private static readonly Name ErrorInfo = new Name("errorInfo");
        private static readonly Name Category = new Name("category");
        private static readonly Name Message = new Name("message");

        private Session session;

        public BbgSession()
        {
           
        }

        private static void CheckFailures(Session session)
        {
            while (true)
            {
                Event @event = session.TryNextEvent();
                if (@event == null)
                {
                    break;
                }

                if (ProcessGenericEvent(@event))
                {
                    break;
                }
            }

        }
        public SecurityToDateToFldNameToFldVal PerformRequest(DateTime fromDate, DateTime toDate, List<string> tickers, List<string> fieldNames, Dictionary<string,string> optionalParams, Dictionary<string, string> overrideParams)
        {
            string serverHost = "localhost";
            int serverPort = 8194;

            SessionOptions sessionOptions = new SessionOptions();
            sessionOptions.ServerHost = serverHost;
            sessionOptions.ServerPort = serverPort;

            System.Console.WriteLine("Connecting to " + serverHost + ":" + serverPort);
            session = new Session(sessionOptions);
            bool sessionStarted = session.Start();
            if (!sessionStarted)
            {
                System.Console.Error.WriteLine("Failed to start session.");
                CheckFailures(session);
                return null;
            }
            if (!session.OpenService(BbgStrings.Services.REF_DATA_SERVICE))
            {
                System.Console.Error.WriteLine("Failed to open " + BbgStrings.Services.REF_DATA_SERVICE);
                CheckFailures(session);
                return null;
            }

            Service refDataService = session.GetService(BbgStrings.Services.REF_DATA_SERVICE);
            Request request = refDataService.CreateRequest(BbgStrings.Requests.HISTORICAL_DATA);
            Element securities = request.GetElement(BbgStrings.Elements.SECURITIES);
            foreach(string s in tickers)
            {
                securities.AppendValue(s);
            }
            
            Element fields = request.GetElement(BbgStrings.Elements.FIELD);
            foreach(string f in fieldNames)
            {
                fields.AppendValue(f);
            }

            Element overrides = request.GetElement(BbgStrings.Elements.OVERRIDES);
            foreach (KeyValuePair<string, string> e in overrideParams)
            {
                Element o = overrides.AppendElement();
                o.SetElement("fieldId", e.Key);
                o.SetElement("value", e.Value);
            }

            foreach (KeyValuePair<string, string> e in optionalParams)
            {
                request.Set(e.Key, e.Value);
            }

            request.Set(BbgStrings.QueryParams.START_DATE, fromDate.ToString("yyyyMMdd"));
            request.Set(BbgStrings.QueryParams.END_DATE, toDate.ToString("yyyyMMdd"));

            System.Console.WriteLine("Sending Request: " + request);

            session.SendRequest(request, null);

            SecurityToDateToFldNameToFldVal result = new SecurityToDateToFldNameToFldVal();

            bool isDone = false;
            while (!isDone)
            {
                Event eventObj = session.NextEvent();
                foreach (Message msg in eventObj)
                {
                    System.Console.WriteLine(msg.AsElement);
                }

                switch (eventObj.Type)
                {
                    case Event.EventType.PARTIAL_RESPONSE:
                        ProcessResponseEvent(eventObj, result);
                        break;
                    case Event.EventType.RESPONSE:
                        ProcessResponseEvent(eventObj, result);
                        isDone = true;
                        break;
                    default:
                        ProcessGenericEvent(eventObj);
                        break;
                }
           
            }

            session.Stop();

            return result;
        }

        private static void PrintContactSupportMessage(Message message)
        {
            string requestId = message.RequestId;
            if (requestId != null)
            {
                Console.Error.WriteLine("When contacting support, " + $"please provide RequestId {requestId}.");
            }
        }

        private static void PrintErrorInfo(Message message, string leadingStr, Element errorInfo)
        {
            Console.Error.WriteLine($"{leadingStr}{errorInfo.GetElementAsString(Category)}" +
                $" ({errorInfo.GetElementAsString(Message)})");
            PrintContactSupportMessage(message);
        }

        private static void ProcessResponseEvent(Event eventObj, SecurityToDateToFldNameToFldVal result)
        {
            foreach (Message msg in eventObj)
            {
                Console.WriteLine($"Received response to request {msg.RequestId}");

                if (msg.HasElement(ResponseError))
                {
                    PrintErrorInfo(
                        msg,
                        "REQUEST FAILED: ",
                        msg.GetElement(ResponseError));
                    continue;
                }

                Element secData = msg.GetElement(SecurityData);

                for (int i = 0; i < secData.NumValues; ++i)
                {
                    string ticker = secData.GetElement(Security).GetValueAsString();
                    Element fieldDataArray = secData.GetElement(FieldData);

                    if (!result.ContainsKey(ticker))
                    {
                        result[ticker] = new DateToFldNameToFldVal();
                    }
                    for(int j = 0; j < fieldDataArray.NumValues; ++j)
                    {
                        Element field = fieldDataArray.GetValueAsElement(j);
                        DateTime dt = field.GetElementAsDate(Date).ToSystemDateTime();
                        string fieldName = field.GetElement(1).ElementDefinition.Name.ToString();
                        double val = (double) field.GetElement(1).GetValue();

                        if (!result[ticker].ContainsKey(dt))
                        {
                            result[ticker][dt] = new FldNameToFldVal();
                        }

                        result[ticker][dt][fieldName] = val;
                    }
                }
            }
        }

        private static bool ProcessGenericEvent(Event e)
        {
            foreach(Message m in e)
            {
                foreach (Message msg in e)
                {
                    Console.WriteLine(msg);

                    if (e.Type == EventType.SESSION_STATUS)
                    {
                        if (msg.MessageType.Equals(Names.SessionTerminated)
                            || msg.MessageType.Equals(Names.SessionStartupFailure))
                        {
                            string error = msg.GetElement("reason")
                                .GetElementAsString("description");
                            Console.Error.WriteLine($"Failed to start session: {error}");
                            PrintContactSupportMessage(msg);
                            return true;
                        }
                    }
                    else if (e.Type == EventType.SERVICE_STATUS)
                    {
                        if (msg.MessageType.Equals(Names.ServiceOpenFailure))
                        {
                            string serviceName = msg.GetElementAsString("serviceName");
                            string error = msg.GetElement("reason")
                                .GetElementAsString("description");
                            Console.Error.WriteLine($"Failed to open {serviceName}: {error}");
                            PrintContactSupportMessage(msg);
                        }
                    }
                }
            }
            return false;
        }
    }

}
