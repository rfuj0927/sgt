using System;
using System.Windows.Threading;
using System.Collections.Generic;
using System.Text;
using ThomsonReuters.Desktop.SDK.DataAccess;
using ThomsonReuters.Desktop.SDK.DataAccess.TimeSeries;

namespace SGT_Utils.SgtTrUtils
{
    public class SgtTrQuerier
    {
        private static readonly DispatcherFrame Frame = new DispatcherFrame(); //the object is required in order to release the Windows message pump while executing asynchronous calls.
        public static IDataServices Services { get; private set; }
        private static ITimeSeriesDataService timeSeries;

        public static void InitializeDataServices(string appName)
        {
            Services = DataServices.Instance;

            Services.Initialize(appName);
            InitializeTimeseries();
            Dispatcher.PushFrame(Frame);
        }

        public static void StopMessagePump()
        {
            Frame.Continue = false;
        }

        private static void InitializeTimeseries()
        {
            timeSeries = DataServices.Instance.TimeSeries;
            timeSeries.ServiceInformationChanged += timeSeries_ServiceInformationChanged;
        }

        private static void timeSeries_ServiceInformationChanged(object sender, ServiceInformationChangedEventArgs e)
        {
            (new TimeSeriesRequestExample(timeSeries)).Launch();
        }

        public class TimeSeriesRequestExample
        {
            private readonly ITimeSeriesDataService timeSeries;
            private ITimeSeriesDataRequest request;

            public TimeSeriesRequestExample(ITimeSeriesDataService timeSeries)
            {
                this.timeSeries = timeSeries;
            }

            public void Launch()
            {
                Console.WriteLine("[2] Time series request example");
                Console.WriteLine("");

                request = timeSeries.SetupDataRequest("EUR=")
                    .WithView("BID")
                    .WithAllFields()
                    .WithInterval(CommonInterval.Daily)
                    .WithNumberOfPoints(10)
                    .OnDataReceived(DataReceivedCallback)
                    .CreateAndSend();
            }

            private void DataReceivedCallback(DataChunk chunk)
            {
                foreach (IBarData bar in chunk.Records.ToBarRecords())
                {
                    if (bar.Open.HasValue && bar.High.HasValue && bar.Low.HasValue && bar.Close.HasValue && bar.Timestamp.HasValue)
                    {
                        Console.WriteLine(
                            "{0}: EUR= OHLC {1} {2} {3} {4}",
                            bar.Timestamp.Value.ToShortDateString(),
                            bar.Open.Value.ToString("##.0000"),
                            bar.High.Value.ToString("##.0000"),
                            bar.Low.Value.ToString("##.0000"),
                            bar.Close.Value.ToString("##.0000")
                        );
                    };
                }

                if (!chunk.IsLast) return;

                request = null;
                SgtTrQuerier.StopMessagePump();
            }
        }
    }
}
