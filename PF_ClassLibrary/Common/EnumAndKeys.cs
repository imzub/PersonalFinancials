using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PF_ClassLibrary.Common
{
    public static class EnumAndKeys
    {
        public enum ExportFileFormat
        {
            Select,
            JSON,
            XML,
            CSV
        }
    }

    public static class AppKey
    {
        public const string KeyUpdateAssetZakat = "KeyUpdateAssetZakat";
        public const string KeyUpdateZakatDues = "KeyUpdateZakatDues";
        public const string KeyUpdateMetalRate = "KeyUpdateMetalRate";
        public const string KeyUpdateStockRate = "KeyUpdateStockRate";
        public const string KeyUpdateMFRate = "KeyUpdateMFRate";
    }
}
