
using Newtonsoft.Json;
import idPaises;



internal partial class Program
{
    static void Main(string[] args)
    {
    
        
        List<string> geocode=ConsultInformationCountry("625144");
        
       WeatherInformation(geocode);
       

    }

    // // ESTRUCTURA API TIEMPO
      public class CurrentConditions
    {
        public string datetime { get; set; }
        public long datetimeEpoch { get; set; }
        public double temp { get; set; }
        public double feelslike { get; set; }
        public double humidity { get; set; }
        public double dew { get; set; }
        public object precip { get; set; }
        public double precipprob { get; set; }
        public double snow { get; set; }
        public double snowdepth { get; set; }
        public object preciptype { get; set; }
        public object windgust { get; set; }
        public double windspeed { get; set; }
        public double winddir { get; set; }
        public double pressure { get; set; }
        public double visibility { get; set; }
        public double cloudcover { get; set; }
        public double solarradiation { get; set; }
        public double solarenergy { get; set; }
        public double uvindex { get; set; }
        public string conditions { get; set; }
        public string icon { get; set; }
        public List<string> stations { get; set; }
        public string source { get; set; }
        public string sunrise { get; set; }
        public double sunriseEpoch { get; set; }
        public string sunset { get; set; }
        public double sunsetEpoch { get; set; }
        public double moonphase { get; set; }
    }

    public class Day
    {
        public string datetime { get; set; }
        public long datetimeEpoch { get; set; }
        public double tempmax { get; set; }
        public double tempmin { get; set; }
        public double temp { get; set; }
        public double feelslikemax { get; set; }
        public double feelslikemin { get; set; }
        public double feelslike { get; set; }
        public double dew { get; set; }
        public double humidity { get; set; }
        public double precip { get; set; }
        public double precipprob { get; set; }
        public double precipcover { get; set; }
        public List<string> preciptype { get; set; }
        public double snow { get; set; }
        public double snowdepth { get; set; }
        public double windgust { get; set; }
        public double windspeed { get; set; }
        public double winddir { get; set; }
        public double pressure { get; set; }
        public double cloudcover { get; set; }
        public double visibility { get; set; }
        public double solarradiation { get; set; }
        public double solarenergy { get; set; }
        public double uvindex { get; set; }
        public double severerisk { get; set; }
        public string sunrise { get; set; }
        public double sunriseEpoch { get; set; }
        public string sunset { get; set; }
        public double sunsetEpoch { get; set; }
        public double moonphase { get; set; }
        public string conditions { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
        public List<string> stations { get; set; }
        public string source { get; set; }
        public List<Hour> hours { get; set; }
    }

    public class Hour
    {
        public string datetime { get; set; }
        public long datetimeEpoch { get; set; }
        public double temp { get; set; }
        public double feelslike { get; set; }
        public double humidity { get; set; }
        public double dew { get; set; }
        public double precip { get; set; }
        public double precipprob { get; set; }
        public double snow { get; set; }
        public double snowdepth { get; set; }
        public List<string> preciptype { get; set; }
        public double windgust { get; set; }
        public double windspeed { get; set; }
        public double winddir { get; set; }
        public double pressure { get; set; }
        public double visibility { get; set; }
        public double cloudcover { get; set; }
        public double solarradiation { get; set; }
        public double solarenergy { get; set; }
        public double uvindex { get; set; }
        public double severerisk { get; set; }
        public string conditions { get; set; }
        public string icon { get; set; }
        public object stations { get; set; }
        public string source { get; set; }
    }

    public class LATI
    {
        public double distance { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double useCount { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public double quality { get; set; }
        public int contribution { get; set; }
    }

    public class LWOH
    {
        public int distance { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public double useCount { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public double quality { get; set; }
        public double contribution { get; set; }
    }
     public class Stations
    {
        public LATI LATI { get; set; }
        public LWOH LWOH { get; set; }
    }

    public class Weather
    {
    
        public double queryCost { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string resolvedAddress { get; set; }
        public string address { get; set; }
        public string timezone { get; set; }
        public double tzoffset { get; set; }
        public string description { get; set; }
        public List<Day> days { get; set; }
        public List<object> alerts { get; set; }
        public Stations stations { get; set; }
        public CurrentConditions currentConditions { get; set; }
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
        //VIEWBACK(pasa parametros del controlador a la vista)
        
    }

    static void WeatherInformation(List<string> geocode){
        HttpClient client=new HttpClient();
        HttpResponseMessage response = client.GetAsync($"https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/{geocode[0]}%2C{geocode[1]}?unitGroup=metric&key=YVCJTVDMWHRJA62SDCUWP6GZQ&contentType=json").Result;

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