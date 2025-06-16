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
            var jsonText = File.ReadAllText("appsettings.json");

            var apiKey = JObject.Parse(jsonText).GetValue("key").ToString();
            
            Console.WriteLine("Enter Zip:");
            var zip = Console.ReadLine();

            var url = $"https://api.openweathermap.org/data/2.5/weather?zip={zip}&appid={apiKey}&units=imperial";
            
            var client = new HttpClient();

            var response = client.GetStringAsync(url).Result;
            
            var weatherObject = JObject.Parse(response);

            Console.WriteLine(
                $"Current Temp: {weatherObject["main"]["temp"]}\nFeels_Like: {weatherObject["main"]["feels_like"]}");
        }
    }
}
