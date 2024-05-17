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

    public IActionResult Index()
    {
        
        List<CountriesID> countriesIDs=CreateCountrysList();
        
        return View(countriesIDs);
    }

    public struct CountriesID{
        public string countryName;
        public string capitalCountry;

        public string urlImagen;
        public string urlCityImage;
        public int id;
    }
    static List <CountriesID> CreateCountrysList(){
        List <CountriesID> countriesIDs= new List <CountriesID> ()
        {
        new CountriesID {countryName="Albania",capitalCountry="Tirana",urlImagen="", urlCityImage="", id=3183875},
        new CountriesID {countryName="Germany",capitalCountry="Berlín",urlImagen="",urlCityImage="",id=2950159},
        new CountriesID {countryName="Andorra",capitalCountry="Andorra la vieja",urlImagen="",urlCityImage="",id=7730819},
        new CountriesID {countryName="Austria",capitalCountry="Vienna",urlImagen="",urlCityImage="",id=2761369},
        new CountriesID {countryName="Azerbaijan",capitalCountry="Baku",urlImagen="",urlCityImage="",id=587084},
        new CountriesID {countryName="Belgium",capitalCountry="Brussels ",urlImagen="",urlCityImage="",id=2800866},
        new CountriesID {countryName="Belarus",capitalCountry="Minsk ",urlImagen="",urlCityImage="",id=625144},
        new CountriesID {countryName="Bosnia and Herzegovina",capitalCountry="Sarajevo",urlImagen="",urlCityImage="",id=3191281},
        new CountriesID {countryName="Bulgaria",capitalCountry="Sofia",urlImagen="",urlCityImage="",id=727011},
        new CountriesID {countryName="Croatia",capitalCountry="Zagreb",urlImagen="",urlCityImage="",id=3186886},
        new CountriesID {countryName="Cyprus",capitalCountry="Nicosia",urlImagen="",urlCityImage="",id=146268},
        new CountriesID {countryName="Chezchia",capitalCountry="Prague",urlImagen="",urlCityImage="",id=3067696},
        new CountriesID {countryName="Denmark",capitalCountry="Copenhagen",urlImagen="",urlCityImage="",id=2618425},
        new CountriesID {countryName="Estonia",capitalCountry="Tallinn",urlImagen="",urlCityImage="",id=588409},
        new CountriesID {countryName="Finland",capitalCountry="Helsinki",urlImagen="",urlCityImage="",id=658225},
        new CountriesID {countryName="France",capitalCountry="Paris",urlImagen="",urlCityImage="",id=2988507},
        new CountriesID {countryName="Georgia",capitalCountry="Tbilisi",urlImagen="",urlCityImage="",id=611717},
        new CountriesID {countryName="Greece",capitalCountry="Athens",urlImagen="",urlCityImage="",id=264371},
        new CountriesID {countryName="Hungary",capitalCountry="Budapest",urlImagen="",urlCityImage="",id=3054643},
        new CountriesID {countryName="Iceland",capitalCountry="Reykjavik",urlImagen="",urlCityImage="",id=3413829},
        new CountriesID {countryName="Ireland",capitalCountry="Dublin",urlImagen="",urlCityImage="",id=2964574},
        new CountriesID {countryName="Italy",capitalCountry="Rome",urlImagen="",urlCityImage="",id=3169070},
        new CountriesID {countryName="Kazakhstan",capitalCountry="Astana",urlImagen="",urlCityImage="",id=1526273},
        new CountriesID {countryName="Kosovo",capitalCountry="Pristina",urlImagen="",urlCityImage="",id=786714},
        new CountriesID {countryName="Latvia",capitalCountry="Riga",urlImagen="",urlCityImage="",id=456172},
        new CountriesID {countryName="Liechtenstein",capitalCountry="Vaduz",urlImagen="",urlCityImage="",id=3042030},
        new CountriesID {countryName="Lithuania",capitalCountry="Vilnius",urlImagen="",urlCityImage="",id=593116},
        new CountriesID {countryName="Luzembourg",capitalCountry="Luxembourg(City)",urlImagen="",urlCityImage="",id=2960316},
        new CountriesID {countryName="Malta",capitalCountry="Valletta",urlImagen="",urlCityImage="",id=2562305},
        new CountriesID {countryName="Moldava",capitalCountry="Chisinau",urlImagen="",urlCityImage="",id=618426},
        new CountriesID {countryName="Monaco",capitalCountry="Monaco",urlImagen="",urlCityImage="",id=2993458},
        new CountriesID {countryName="Montenegro",capitalCountry="Podgorica",urlImagen="",urlCityImage="",id=3193044},
        new CountriesID {countryName="Netherlands",capitalCountry="Amsterdam",urlImagen="",urlCityImage="",id=2749794},
        new CountriesID {countryName="North Macedonia",capitalCountry="Skopje",urlImagen="",urlCityImage="",id=785842},
        new CountriesID {countryName="Norway",capitalCountry="Oslo",urlImagen="",urlCityImage="",id=3143244},
        new CountriesID {countryName="Poland",capitalCountry="Warsaw",urlImagen="",urlCityImage="",id=756135},
        new CountriesID {countryName="Portugal",capitalCountry="Lisbon",urlImagen="",urlCityImage="",id=2267057},
        new CountriesID {countryName="Romania",capitalCountry="Bucharest",urlImagen="",urlCityImage="",id=6835056},
        new CountriesID {countryName="Russia",capitalCountry="Moscow",urlImagen="",urlCityImage="",id=524901},
        new CountriesID {countryName="San Marino",capitalCountry="San Marino",urlImagen="",urlCityImage="",id=3168070},
        new CountriesID {countryName="Serbia",capitalCountry="Belgrade",urlImagen="",urlCityImage="",id=792680},
        new CountriesID {countryName="Slovakia",capitalCountry="Bratislava",urlImagen="",urlCityImage="",id=3060972},
        new CountriesID {countryName="Stovenia",capitalCountry="Ljubljana",urlImagen="",urlCityImage="",id=3196359},
        new CountriesID {countryName="Spain",capitalCountry="Madrid",urlImagen="",urlCityImage="",id=3117735},
        new CountriesID {countryName="Sweden",capitalCountry="Stockholm",urlImagen="",urlCityImage="",id=2673730},
        new CountriesID {countryName="Switzerland",capitalCountry="Bern",urlImagen="",urlCityImage="",id=2661552},
        new CountriesID {countryName="Turkey",capitalCountry="Ankara",urlImagen="",urlCityImage="",id=323786},
        new CountriesID {countryName="Ukraine",capitalCountry="Kyiv",urlImagen="",urlCityImage="",id=703448},
        new CountriesID {countryName="United Kingdom",capitalCountry="London",urlImagen="",urlCityImage="",id=2643743},
        new CountriesID {countryName="Vatican City",capitalCountry="Vatican City",urlImagen="",urlCityImage="",id=6691831}
        };

        return countriesIDs;

    }

    public IActionResult WeatherInformation(string id){

        
        var urlApiCountry = $"http://api.geonames.org/getJSON?geonameId={id}&username=nagasa";
        var clientCountry = new HttpClient();
        var responseCountry = clientCountry.GetAsync(urlApiCountry).Result;
        var contentCountry=responseCountry.Content.ReadAsStringAsync().Result;
        var informationCountry = JsonSerializer.Deserialize<ApiCountry.Country>(contentCountry);
        
        var countryList = new List<ApiCountry.Country>{informationCountry};



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
