using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    internal static class OpenWeatherMapAPI
    {
        public static void GetUserTemp()
        {
            var client = new HttpClient();
            var appsettingsText = File.ReadAllText("appsettings.json");

            var apiKey = "d230c0619c81262007a55421f21d88"; 
            
            Console.WriteLine("Enter Zip:");
            var zip = Console.ReadLine();

            var url = $"https://api.openweathermap.org/data/2.5/weather?zip={zip}&appid={apiKey}";
            

            var response = client.GetStringAsync(url).Result;
            
            var weatherObject = JObject.Parse(response);

            Console.WriteLine(
                $"Current Temp: {weatherObject["main"]["temp"]}\nFeels_Like: {weatherObject["main"]["feels_like"]}");
        }
    }
}
