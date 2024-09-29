using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

//Напишите приложение, конвертирующее произвольный JSON в XML

namespace Serialization
{
    public class Weather
    {
        public DateTime Time { get; set; }
        public double Temp { get; set; }
        public int WeatherCode { get; set; }
        public double WindSpeed { get; set; }

        public int WindDirection { get; set; }

    }

    public class WeatherFull
    {
        public Weather Actual { get; set; }
        public List<Weather> History { get; set; }
    }
    internal class Program
    {
        static void ConvertJsonToXml(string jsonStr)
        {
            var weatherFull = JsonSerializer.Deserialize<WeatherFull>(jsonStr);
            var serializer = new XmlSerializer(typeof(WeatherFull));

            serializer.Serialize(Console.Out, weatherFull);

        }


        static void Main(string[] args)
        {

            var JsonStr = """{"Actual":{"Time":"2024-09-29T20:07:06.722127+03:00","Temperature":22,"WeatherCode":1,"WindSpeed":2.1,"WindDirection":1},"History":[{"Time":"2024-09-28T20:07:06.77707+03:00","Temperature":24,"WeatherCode":2,"WindSpeed":2.4,"WindDirection":1},{"Time":"2024-09-27T20:07:06.777081+03:00","Temperature":17,"WeatherCode":2,"WindSpeed":2.4,"WindDirection":1},{"Time":"2024-09-26T20:07:06.777082+03:00","Temperature":19,"WeatherCode":4,"WindSpeed":2.2,"WindDirection":1}]}""";

            ConvertJsonToXml(JsonStr);
        }
    }
}