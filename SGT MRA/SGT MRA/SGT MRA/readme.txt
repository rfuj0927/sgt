Multiple Regression Analysis (MRA)

Brute force regresses y output timeseries against x basket of time series.
Returns lowest standard error combination of inputs for each degree of freedom.SGTUtils.SgtMathUtils

Series Types:
NavTr - ETF Closing NAVs + Divs
PriceTr - Closing Prices + Divs
Price - Closing Prices

Return Types:
Simple - P2/P1 - 1
Log - Log(p2/p1)

By default requests specified timeseries by RIC from EikonData API. Can use custom time series or override by loading from CSV (see ExampleData.csv). 

Example RICs and appropriate series types:
IOZ.AX (NavTr), .AXJOA (Price), YTTc1 (Price), CBA.AX (PriceTr), AUD= (Price).