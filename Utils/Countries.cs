using CountryData.Standard;
using System.Collections.Generic;

namespace CinemaTicketManagementSystem.Utils
{
    public static class Countries
    {
       public static List<string> GetAll()
        {
            var helper = new CountryHelper();
            var countries = helper.GetCountries();
            return countries;
         }
    }
}
