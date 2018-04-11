using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Service.API.ERP.Common
{
    public static class Helper
    {
        public static string GetPriceWithCommand(this decimal? price)
        {
            var value = "0";

            if (price != null)
            {
                return price.Value.ToString("F2", CultureInfo.InvariantCulture);
            }

            return value;
        }
    }
}
