using Newtonsoft.Json.Linq;
using PersonalFinancials.DataAccess;
using PF_ClassLibrary.Model;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PF_ClassLibrary.Services
{
    public class StockService
    {
        private const string ApiKey = "7USSV13M8CEI8YUH";
        private const string ApiUrl = "https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={0}&apikey=" + ApiKey;
        private AssetTypeDataAccess _assetTypeDataAccess;
        private async Task<StockModel> GetStockPriceAsync(string stockSymbol)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = string.Format(ApiUrl, stockSymbol);
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string jsonData = await response.Content.ReadAsStringAsync();
                    JObject data = JObject.Parse(jsonData);
                    JObject quote = (JObject)data["Global Quote"];

                    if (quote != null)
                    {
                        return new StockModel
                        {
                            Symbol = quote["01. symbol"]?.ToString(),
                            Open = Convert.ToDecimal(quote["02. open"]),
                            High = Convert.ToDecimal(quote["03. high"]),
                            Low = Convert.ToDecimal(quote["04. low"]),
                            Price = Convert.ToDecimal(quote["05. price"]),
                            Volume = Convert.ToInt64(quote["06. volume"]),
                            LatestTradingDay = DateTime.Parse(quote["07. latest trading day"]?.ToString()),
                            PreviousClose = Convert.ToDecimal(quote["08. previous close"]),
                            Change = Convert.ToDecimal(quote["09. change"]),
                            ChangePercent = quote["10. change percent"]?.ToString()
                        };
                    }
                    throw new Exception("Invalid response format or stock symbol not found.");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"HTTP Request Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching stock data: {ex.Message}");
            }
        }

        public async Task UpdateCIL()
        {
            try
            {
                _assetTypeDataAccess = new AssetTypeDataAccess();
                StockModel stock = await GetStockPriceAsync("COALINDIA.BSE");
                _assetTypeDataAccess.UpdateAssetTypeRatePerUnit(CreateAssetTypeModel(7, "Stocks - CIL", stock.Price));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating metal rates: {ex.Message}");
            }
        }

        private AssetType CreateAssetTypeModel(int assetTypeId, string assetTypeName, decimal metalRate)
        {
            return new AssetType
            {
                AssetTypeId = assetTypeId,
                AssetTypeName = assetTypeName,
                AssetTypeCurrentValuePerUnit = metalRate
            };
        }
    }
}
