public class idPaises: ApplicationException
{
        
    List <CountriesID> countriesIDs= new List <CountriesID> ()
    {
        new CountriesID {countryName="Albania",capitalCountry="Tirana",id=3183875},
        new CountriesID {countryName="Alemania",capitalCountry="Berlín ",id=2950159},
        new CountriesID {countryName="Andorra",capitalCountry="Andorra la vieja",id=7730819},
        new CountriesID {countryName="Austria",capitalCountry="Viena",id=2761369},
        new CountriesID {countryName="Bélgica",capitalCountry="Bruselas ",id=2800866},
        new CountriesID {countryName="Bielorussia",capitalCountry="Minsk ",id=625144},
        new CountriesID {countryName="Bosnia y Herzegovina",capitalCountry="Sarajevo ",id=3191281},
        new CountriesID {countryName="Chipre",capitalCountry="Nicosia ",id=146268},
    };
        
    
    
}

public class CountriesID{
    public string countryName;
    public string capitalCountry;
    public int id;
}
