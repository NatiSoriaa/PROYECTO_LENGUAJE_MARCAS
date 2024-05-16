namespace PROYECTO.Models;

public class ApiWeather
{
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
        public string countryName {get; set;}
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
}
