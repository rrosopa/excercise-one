using ConsoleApp1.Extensions;
using ConsoleApp1.Models.Businesses;
using GeoCoordinatePortable;
using System;

namespace ConsoleApp1.Services.Businesses
{
    public class BusinessMatcher : IBusinessMatcher
    {
        public bool IsMatch(Business business, Business databaseBusiness)
        {
            if(business == null || databaseBusiness == null)
            {
                return false;
            }

            // Scenario 1
            // A business is considered to be a match if both the business name and address match when punctuation is excluded
            // For example, the business “*Awesome*-Coffee! House (Sydney)” located at “32 Sir John - Young Crescent, Sydney, NSW.” would be a match 
            // for a business called “Awesome Coffee House, Sydney”” located at “32 Sir John Young Crescent, Sydney NSW”
            // -- Clean up name and address then check if match
            if(business.Name.ReplacePunctuations().CleanSpacesInBetween().Equals(databaseBusiness.Name.ReplacePunctuations().CleanSpacesInBetween(), StringComparison.InvariantCultureIgnoreCase)
               && business.Address.ReplacePunctuations().CleanSpacesInBetween().Equals(databaseBusiness.Address.ReplacePunctuations().CleanSpacesInBetween(), StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }

            // Scenario 2
            // a match if the partner code is the same and the business is within 200 metres or less of the actual business location
            // For the sake of simplicity, assume that 1 degree of latitude or longitude is equal to 111km
            // note: 1km = 1000m       
            if(business.PartnerId.Equals(databaseBusiness.PartnerId)) // not sure if partner id should be case sensitive....                   
            {
                var businessCoordinates = new GeoCoordinate(Decimal.ToDouble(business.Latitude), Decimal.ToDouble(business.Longitude)); 
                var dataBusinessCoordinates = new GeoCoordinate(Decimal.ToDouble(databaseBusiness.Latitude), Decimal.ToDouble(databaseBusiness.Longitude));

                // i used a package because i have no idea on how to compute this properly
                // read the document of the package and GetDistanceTo should return the distance in meters
                if (businessCoordinates.GetDistanceTo(dataBusinessCoordinates) <= 200) 
                {
                    return true;
                }                
            }

            // Scenario 3
            // A business is considered a match if the names match when the words in the name of the business are reversed
            // eg. “House Coffe Best The” is a match for a business with the name “The best coffe house”
            if(business.Name.ReverseSentence().Equals(databaseBusiness.Name, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }

            return false;
        }
    }
}
