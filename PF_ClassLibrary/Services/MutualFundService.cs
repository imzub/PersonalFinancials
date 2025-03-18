using PersonalFinancials.DataAccess;
using PF_ClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PF_ClassLibrary.Services
{
    public class MutualFundService
    {
        private AssetTypeDataAccess _assetTypeDataAccess;
        private const string AMFI_URL = "https://www.amfiindia.com/spages/NAVAll.txt";

        public async Task<MutualFundModel> GetMutualFundNavAsync(string schemeCode)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync(AMFI_URL);
                    var lines = response.Split('\n');

                    foreach (var line in lines)
                    {
                        var columns = line.Split(';');
                        if (columns.Length >= 5 && columns[0].Trim() == schemeCode)
                        {
                            return new MutualFundModel
                            {
                                SchemeCode = columns[0].Trim(),
                                SchemeName = columns[1].Trim(),
                                NAV = Convert.ToDecimal(columns[4].Trim()),
                                LastUpdated = columns[5].Trim()
                            };
                        }
                    }

                    throw new Exception("Mutual fund NAV not found.");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"HTTP Request Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching mutual fund NAV: {ex.Message}");
            }
        }

        public async Task UpdateMFRates()
        {
            try
            {
                _assetTypeDataAccess = new AssetTypeDataAccess();

                // Mutual Fund Records (Example IDs & Names)
                var mutualFunds = new List<(int Id, string Name, string SchemeCode)>
                {
                    (8, "MF-Tata Ethical Fund", "119172"),
                    (9, "MF-Taurus Ethical Fund", "118876"),
                    (10, "MF-Quantum Ethical Fund", "153094")
                };

                foreach (var fund in mutualFunds)
                {
                    MutualFundModel mfNav = await GetMutualFundNavAsync(fund.SchemeCode);

                    if (mfNav != null)
                    {
                        _assetTypeDataAccess.UpdateAssetTypeRatePerUnit(
                            CreateAssetTypeModel(fund.Id, fund.Name, mfNav.NAV)
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating mutual fund rates: {ex.Message}");
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
