using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    internal static class RonVSKanyeAPI
    {
        public static void Convo()
        {
            var client = new HttpClient();

            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine($"Kanye says:\n{GetKanyeQuote(client)}\n");
                Thread.Sleep(2000);
                Console.WriteLine($"Ron says:\n{GetRonQuote(client)}\n");
                Thread.Sleep(2000);
            }
        }
        private static string GetRonQuote(HttpClient client)
        {
            var jsonText = client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;
            
            //var quote = jsonText.Replace('[', ' ').Replace(']', ' ').Replace('"', ' ').Trim();
            
            var ronArray = JArray.Parse(jsonText);

            return ronArray[0].ToString();
        }
        private static string GetKanyeQuote(HttpClient client)
        {
            var jsonText = client.GetStringAsync("https://api.kanye.rest/").Result;

            return JObject.Parse(jsonText)["quote"].ToString();
        }
    }
}
