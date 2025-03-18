using HtmlAgilityPack;
using PersonalFinancials.DataAccess;
using PF_ClassLibrary.Model;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PF_ClassLibrary.Services
{
    public class MetalServices
    {
        private static readonly HttpClient _httpClient = new HttpClient(); // Singleton HttpClient
        private readonly AssetTypeDataAccess _assetTypeDataAccess;

        public MetalServices()
        {
            _assetTypeDataAccess = new AssetTypeDataAccess();
        }

        public static async Task Main()
        {
            MetalServices metalService = new MetalServices();
            await metalService.UpdateMetalRatesAsync();
        }

        public async Task<MetalPriceModel> FetchGoldPricesAsync()
        {
            try
            {
                string url = "https://bullions.co.in/location/pune/";
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var htmlContent = await response.Content.ReadAsStringAsync();

                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(htmlContent);

                // Extract gold prices
                var gold24KText = document.DocumentNode.SelectSingleNode("//table//tr[td[contains(text(), 'Gold 24 Karat')]]/td[2]")?.InnerText?.Trim();
                var gold22KText = document.DocumentNode.SelectSingleNode("//table//tr[td[contains(text(), 'Gold 22 Karat')]]/td[2]")?.InnerText?.Trim();

                if (decimal.TryParse(gold24KText?.Replace(",", ""), out decimal gold24KPrice) &&
                    decimal.TryParse(gold22KText?.Replace(",", ""), out decimal gold22KPrice))
                {
                    return new MetalPriceModel
                    {
                        MetalType = "Gold",
                        Gold24K = gold24KPrice,
                        Gold22K = gold22KPrice
                    };
                }
                else
                {
                    throw new Exception("Gold price information is missing or in an unexpected format.");
                }
            }
            catch (HttpRequestException httpEx)
            {
                throw new Exception($"HTTP Request Error: {httpEx.Message}", httpEx);
            }
            catch (Exception ex)
            {
                throw new Exception($"General Error: {ex.Message}", ex);
            }
        }

        public async Task UpdateMetalRatesAsync()
        {
            try
            {
                MetalPriceModel prices = await FetchGoldPricesAsync();

                _assetTypeDataAccess.UpdateAssetTypeRatePerUnit(CreateAssetTypeModel(2, "Gold 24 CR - 995", prices.Gold24K));
                _assetTypeDataAccess.UpdateAssetTypeRatePerUnit(CreateAssetTypeModel(1, "Gold 22 Carat", prices.Gold22K));
            }
            catch (Exception ex)
            {
                throw ex;
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
