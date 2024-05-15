
using Newtonsoft.Json;


internal partial class Program
{
    static void Main(string[] args)
    {
        
        List<string> geocode=ConsultInformationCountry("625144");
        
       WeatherInformation(geocode);
       

    }

    // // ESTRUCTURA API TIEMPO
    public class CloudCover
    {
        public int total { get; set; }
    }

    public class Current
    {
        public string icon { get; set; }
        public int icon_num { get; set; }
        public string summary { get; set; } 
        public double temperature { get; set; }
        public Wind wind { get; set; }
        public Precipitation precipitation { get; set; }
        public int cloud_cover { get; set; }
    }

    public class Datum
    {
        public DateTime date { get; set; }
        public string weather { get; set; }
        public int icon { get; set; }
        public string summary { get; set; }
        public double temperature { get; set; }
        public Wind wind { get; set; }
        public CloudCover cloud_cover { get; set; }
        public Precipitation precipitation { get; set; }
    }

    public class Hourly
    {
        public List<Datum> data { get; set; }
    }

    public class Precipitation
    {
        public double total { get; set; }
        public string type { get; set; }
    }

    public class Weather
    {
        public string lat { get; set; }
        public string lon { get; set; }
        public int elevation { get; set; }
        public string timezone { get; set; }
        public string units { get; set; } 
        public Current current { get; set; }
        public Hourly hourly { get; set; } 
        public object daily { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public int angle { get; set; }
        public string dir { get; set; }
    }

    // // ESTRUCTURA API COUNTRY
    public class AdminCodes1
    {
        public string ISO3166_2 { get; set; }
    }

    public class Bbox
    {
        public double east { get; set; }
        public double south { get; set; }
        public double north { get; set; }
        public double west { get; set; }
        public int accuracyLevel { get; set; }
    }

    public class Timezone
    {
        public int gmtOffset { get; set; }
        public string timeZoneId { get; set; }
        public int dstOffset { get; set; }
    }


    public class AlternateName
    {
        public string name { get; set; }
        public string lang { get; set; }
        public bool? isShortName { get; set; }
        public bool? isPreferredName { get; set; }
    }

    

    public class Country
    {
        public Timezone timezone { get; set; }
        public Bbox bbox { get; set; }
        public string asciiName { get; set; }
        public int astergdem { get; set; }
        public string countryId { get; set; }
        public string fcl { get; set; }
        public int srtm3 { get; set; }
        public string adminId2 { get; set; }
        public string adminId3 { get; set; }
        public string countryCode { get; set; }
        public AdminCodes1 adminCodes1 { get; set; }
        public string adminId1 { get; set; }
        public string lat { get; set; }
        public string fcode { get; set; }
        public string continentCode { get; set; }
        public string adminCode2 { get; set; }
        public string adminCode3 { get; set; }
        public string adminCode1 { get; set; }
        public string lng { get; set; }
        public int geonameId { get; set; }
        public string toponymName { get; set; }
        public int population { get; set; }
        public string wikipediaURL { get; set; }
        public string adminName5 { get; set; }
        public string adminName4 { get; set; }
        public string adminName3 { get; set; }
        public List<AlternateName> alternateNames { get; set; }
        public string adminName2 { get; set; }
        public string name { get; set; }
        public string fclName { get; set; }
        public string countryName { get; set; }
        public string fcodeName { get; set; }
        public string adminName1 { get; set; }
    }

    


    static List<string> ConsultInformationCountry(string id){
        
        HttpClient client=new HttpClient();
        HttpResponseMessage response = client.GetAsync($"http://api.geonames.org/getJSON?geonameId={id}&username=nagasa").Result;
        
        string jsonResponse = response.Content.ReadAsStringAsync().Result;
        Country informationCountry = JsonConvert.DeserializeObject<Country> (jsonResponse);

        List<string> geocode = new List<string>();
        string latitud=informationCountry.lat;
        string longitud=informationCountry.lng;
        string name=informationCountry.countryName;
        geocode.Add(latitud);
        geocode.Add(longitud);
        geocode.Add(name);

        return geocode;
        
        
    }

    static void WeatherInformation(List<string> geocode){
        HttpClient client=new HttpClient();
        HttpResponseMessage response = client.GetAsync($"https://www.meteosource.com/api/v1/free/point?lat={geocode[0]}&lon={geocode[1]}&sections=current%2Chourly&language=en&units=auto&key=v68hqhyj2ams6xe0uxv7s8wkn2386rtg963o2ye8").Result;

        string jsonResponse = response.Content.ReadAsStringAsync().Result;

        Console.WriteLine(geocode[2]);

        Weather weather = JsonConvert.DeserializeObject<Weather> (jsonResponse);
        Console.WriteLine("Franja Horaria: "+weather.timezone);
        Console.WriteLine("Actual Temperature: "+weather.current.temperature);
        Console.WriteLine("Precipitation: "+weather.current.precipitation.total+"%");
        Console.WriteLine("Clime: "+weather.current.summary);
        Console.WriteLine("----------------------------------------\n\n");

        Console.WriteLine("CLIME NEXT 24 HOUR:\n");
        foreach(Datum hour in weather.hourly.data) {
            Console.WriteLine("Date: "+hour.date+"\n");
            Console.WriteLine("Clime: "+hour.summary);
            Console.WriteLine("Temperature: "+hour.temperature);
            Console.WriteLine("Precipitation: "+hour.precipitation.total+"%");
            Console.WriteLine("Cloud sky cover: "+hour.cloud_cover.total+"%");
            Console.WriteLine("-------------------------------");
        }
    }

}