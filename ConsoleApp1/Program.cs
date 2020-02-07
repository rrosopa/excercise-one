using ConsoleApp1.Models.Businesses;
using ConsoleApp1.Services.Businesses;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var databaseBusinesses = new List<Business>
            {
                new Business
                {
                    PartnerId = "ABC",
                    Address = "32 Sir John Young Crescent, Sydney NSW",
                    AbnNumber = "123",
                    Name = "Awesome Coffee House, Sydney",
                    Longitude = 24,
                    Latitude = 24
                },
                new Business
                {
                    PartnerId = "CDE",
                    Address = "32 Sir John Young Crescent, Sydney NSW",
                    AbnNumber = "123",
                    Name = "Entry 2",
                    Longitude = 45,
                    Latitude = 23
                },
                new Business
                {
                    PartnerId = "ABC",
                    Address = "32 Sir John Young Crescent, Sydney NSW",
                    AbnNumber = "123",
                    Name = "The best coffe house",
                    Longitude = 24,
                    Latitude = 24
                }
            };

            var businesses = new List<Business>
            {
                new Business
                {
                    PartnerId = "ABC",
                    Address = "32 Sir John-Young Crescent, Sydney, NSW.",
                    AbnNumber = "123",
                    Name = "*Awesome*-Coffee! House (Sydney)",
                    Longitude = 24m,
                    Latitude = 27m
                },
                new Business
                {
                    PartnerId = "CDE",
                    Address = "Address 2",
                    AbnNumber = "123",
                    Name = "Awesome Coffee House, Sydney",
                    Longitude = 45m,
                    Latitude = 23.0001m
                },
                new Business
                {
                    PartnerId = "ABC",
                    Address = "Address 3",
                    AbnNumber = "123",
                    Name = "House Coffe Best The",
                    Longitude = 24m,
                    Latitude = 27m
                }
            };

            var businessMatcher = new BusinessMatcher();
            foreach(var business in businesses)
            {
                int matchCounter = 0;
                foreach(var dbBusiness in databaseBusinesses)
                {
                    if (businessMatcher.IsMatch(business, dbBusiness))
                    {
                        matchCounter++;
                    }
                }
                
                if(matchCounter == 0)
                {
                    Console.WriteLine($"No match found for {business.Name} in {business.Address}");
                }
                else
                {
                    Console.WriteLine($"{matchCounter} match(es) found for {business.Name} in {business.Address}");
                }

                Console.WriteLine();                
            }

            Console.ReadLine();
        }
    }
}
