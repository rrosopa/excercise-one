using ConsoleApp1.Models.Businesses;

namespace ConsoleApp1.Services.Businesses
{
    public interface IBusinessMatcher
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="business"></param>
        /// <param name="databaseBusiness">ideally this parameter should have a different name eg. BusinessEntity</param>
        /// <returns></returns>
        bool IsMatch(Business business, Business databaseBusiness);
    }
}
