using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Constants
{
    public static class CoinGecoAPIEndPoints
    {
        public static Uri ApiEndPoint = new("https://api.coingecko.com/api/v3/");

        public static string AddCoinsId(string id) => "coins/" + id;
    }
}
