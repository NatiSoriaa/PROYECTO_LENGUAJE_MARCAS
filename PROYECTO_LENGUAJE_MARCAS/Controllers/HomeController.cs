using System.Diagnostics;
using System.Text.Json.Serialization;
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

    public IActionResult Index()
    {
        List <CountriesID> countriesIDs= new List <CountriesID> ()
        {
        new CountriesID {countryName="Albania",capitalCountry="Tirana",urlImagen="",id=3183875},
        new CountriesID {countryName="Alemania",capitalCountry="Berlín",urlImagen="",id=2950159},
        new CountriesID {countryName="Andorra",capitalCountry="Andorra la vieja",urlImagen="",id=7730819},
        new CountriesID {countryName="Austria",capitalCountry="Viena",urlImagen="",id=2761369},
        new CountriesID {countryName="Bélgica",capitalCountry="Bruselas ",urlImagen="",id=2800866},
        new CountriesID {countryName="Bielorussia",capitalCountry="Minsk ",urlImagen="",id=625144},
        new CountriesID {countryName="Bosnia y Herzegovina",capitalCountry="Sarajevo",urlImagen="",id=3191281},
        new CountriesID {countryName="Chipre",capitalCountry="Nicosia",urlImagen="",id=146268},
        
        };
        return View(countriesIDs);
    }
    public struct CountriesID{
            public string countryName;
            public string capitalCountry;

            public string urlImagen;
            public int id;
        }

    public IActionResult WeatherInformation(string id="625144"){

        var urlApiCountry = $"http://api.geonames.org/getJSON?geonameId={id}&username=nagasa";
        var clientCountry = new HttpClient();
        var responseCountry = clientCountry.GetAsync(urlApiCountry).Result;
        var contentCountry=responseCountry.Content.ReadAsStringAsync().Result;
        List<apiGeolocalization> informationCountry = JsonConverter.DeserializeObject<List<apiGeolocalization>>(contentCountry);
        

        List<string> geocode = new List<string>();
        string latitud=informationCountry.lat;
        string longitud=informationCountry.lng;
        string name=informationCountry.countryName;
        geocode.Add(latitud);
        geocode.Add(longitud);
        geocode.Add(name);

        var urlApiWeather=$"https://www.meteosource.com/api/v1/free/point?lat={geocode[0]}&lon={geocode[1]}&sections=current%2Chourly&language=en&units=auto&key=v68hqhyj2ams6xe0uxv7s8wkn2386rtg963o2ye8";
        var clientWeather= new HttpClient();
        var responseWeather=clientWeather.GetAsync(urlApiWeather).Result;
        var contentWeather=responseWeather.Content.ReadAsStringAsync().Result;
        List<ApiWeather> informationWeather = JsonConverter.DeserializeObject<List<ApiWeather>>(informationWeather):

        informationWeather.countryName=geocode[2];

        
        return View(informationWeather);
    
    }

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
