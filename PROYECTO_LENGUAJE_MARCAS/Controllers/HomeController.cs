using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PROYECTO.Models;
using Newtonsoft.Json;

namespace PROYECTO.Controllers;

public class HomeController : Controller
{

    private readonly ILogger<HomeController> _logger;
    private readonly HttpClient _httpClient;

    public HomeController(ILogger<HomeController> logger, HttpClient httpClient)
    {
        _logger = logger; 
        _httpClient= httpClient;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Weather(string id="625144")
    {
        var urlApiCountry = $"http://api.geonames.org/getJSON?geonameId={id}&username=nagasa";
        HttpResponseMessage responseWeather = _httpClient.GetAsync(urlApiCountry).Result;
        
        string jsonResponseWeather = responseWeather.Content.ReadAsStringAsync().Result;
        Country informationCountry = JsonConvert.DeserializeObject<Country> (jsonResponse);

        List<string> geocode = new List<string>();
        string latitud=informationCountry.lat;
        string longitud=informationCountry.lng;
        string name=informationCountry.countryName;
        geocode.Add(latitud);
        geocode.Add(longitud);
        geocode.Add(name);

        HttpClient client=new HttpClient();
        HttpResponseMessage response = client.GetAsync($"https://www.meteosource.com/api/v1/free/point?lat={geocode[0]}&lon={geocode[1]}&sections=current%2Chourly&language=en&units=auto&key=v68hqhyj2ams6xe0uxv7s8wkn2386rtg963o2ye8").Result;

        string jsonResponse = response.Content.ReadAsStringAsync().Result;

        Weather informationWeather = JsonConvert.DeserializeObject<Weather> (jsonResponse);

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
