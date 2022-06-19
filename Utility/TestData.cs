using SeleniumDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemo.Utility
{
    public static class TestData
    {
        public static Address Address { get; } = new Address
        {
            PostalCode = "",
            Country = "",
            CountryAbbreviation = "",
            PlaceName = "",
            Longitude = "",
            State = "",
            StateAbbreviation = "",
            Latitude = ""
        };
    }
}
