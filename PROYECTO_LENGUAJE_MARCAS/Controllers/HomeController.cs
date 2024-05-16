using System.Diagnostics;
using System.Text.Json;

using Microsoft.AspNetCore.Mvc;
using PROYECTO.Models;
using PROYECTO_LENGUAJE_MARCAS.Models;

namespace PROYECTO_LENGUAJE_MARCAS.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(string id="6252001")
    {
        

        var urlApiCountry = $"http://api.geonames.org/getJSON?geonameId=6252001&username=nagasa";
        var clientCountry = new HttpClient();
        var responseCountry = clientCountry.GetAsync(urlApiCountry).Result;
        var contentCountry=responseCountry.Content.ReadAsStringAsync().Result;
        var informationCountry = JsonSerializer.Deserialize<ApiCountry.Country>(contentCountry);
        
        var countryList = new List<ApiCountry.Country>{informationCountry};
        // double longitude=Convert.ToDouble(countryList[0].lat);
        // double latitude=Convert.ToDouble(countryList[0].lng);
        // double longitude2=-78.63861;
        // double latitude2=35.7721;


        var urlApiWeather=$"https://api.weatherbit.io/v2.0/current?lat={countryList[0].lat}&lon={countryList[0].lng}&key=b594f4848b42479cb1d61d4283ff8793&include=minutely";
        var clientWeather= new HttpClient();
        var responseWeather=clientWeather.GetAsync(urlApiWeather).Result;
        var contentWeather=responseWeather.Content.ReadAsStringAsync().Result;
        
        var informationWeather = JsonSerializer.Deserialize<ApiWeather.Root>(contentWeather);

        var listInformationWeather = new List<ApiWeather.Root>{informationWeather};

        
        
        
        if (listInformationWeather != null)
        {
            return View(listInformationWeather);
        }
        else
        {
            return View("no hay datos");
        }

       
        


        // List <CountriesID> countriesIDs= new List <CountriesID> ()
        // {
        // new CountriesID {countryName="Albania",capitalCountry="Tirana",urlImagen="",id=3183875},
        // new CountriesID {countryName="Alemania",capitalCountry="Berlín",urlImagen="",id=2950159},
        // new CountriesID {countryName="Andorra",capitalCountry="Andorra la vieja",urlImagen="",id=7730819},
        // new CountriesID {countryName="Austria",capitalCountry="Viena",urlImagen="",id=2761369},
        // new CountriesID {countryName="Bélgica",capitalCountry="Bruselas ",urlImagen="",id=2800866},
        // new CountriesID {countryName="Bielorussia",capitalCountry="Minsk ",urlImagen="",id=625144},
        // new CountriesID {countryName="Bosnia y Herzegovina",capitalCountry="Sarajevo",urlImagen="",id=3191281},
        // new CountriesID {countryName="Chipre",capitalCountry="Nicosia",urlImagen="",id=146268},
        
        // };
        //  return View(countriesIDs);
    }
    public struct CountriesID{
        public string countryName;
        public string capitalCountry;

        public string urlImagen;
        public int id;
    }

    // public IActionResult WeatherInformation(string id="3183875"){

    //     var urlApiCountry = $"http://api.geonames.org/getJSON?geonameId={id}&username=nagasa";
    //     var clientCountry = new HttpClient();
    //     var responseCountry = clientCountry.GetAsync(urlApiCountry).Result;
    //     var contentCountry=responseCountry.Content.ReadAsStringAsync().Result;
    //     List<ApiCountry.Country> informationCountry = JsonSerializer.Deserialize<List<ApiCountry.Country>>(contentCountry);
        
    //     return View(informationCountry);

        // var geocode = new List<string>();
        // string latitud=informationCountry[0].lat;
        // string longitud=informationCountry[0].lng;
        // string name=informationCountry[0].countryName;
        // geocode.Add(latitud);
        // geocode.Add(longitud);
        // geocode.Add(name);

        // var urlApiWeather=$"https://www.meteosource.com/api/v1/free/point?lat={geocode[0]}&lon={geocode[1]}&sections=current%2Chourly&language=en&units=auto&key=v68hqhyj2ams6xe0uxv7s8wkn2386rtg963o2ye8";
        // var clientWeather= new HttpClient();
        // var responseWeather=clientWeather.GetAsync(urlApiWeather).Result;
        // var contentWeather=responseWeather.Content.ReadAsStringAsync().Result;
        // List<ApiWeather.Weather> informationWeather = JsonSerializer.Deserialize<List<ApiWeather.Weather>>(contentWeather);

        // informationWeather[0].countryName=geocode[2];

        
        // return View(informationCountry);
    
    

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
