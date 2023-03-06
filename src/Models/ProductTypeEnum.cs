using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoCrafts.WebSite.Models
{

    /// <summary>
    /// Enum class for Product type
    /// </summary>
    public enum ProductTypeEnum
    {
        //Initializing the Enum of product types
        Undefined = 0,
        Amature = 1,
        Antique = 5,
        Collectable = 130,
        Commercial = 55,
    }

    /// <summary>
    /// Class for ProductTypeEnum
    /// </summary>
    public static class ProductTypeEnumExtensions
    {

        /// <summary>
        /// Get the producttype Status
        /// </summary>
        /// <param name="data"></param>
        /// <returns>ProductType</returns>
        public static string DisplayName(this ProductTypeEnum data)
        {
            return data switch
            {
                //Getting and assigning the data of different types of products
                ProductTypeEnum.Amature => "Hand Made Items",
                ProductTypeEnum.Antique => "Antiques",
                ProductTypeEnum.Collectable => "Collectables",
                ProductTypeEnum.Commercial => "Commercial goods",

                //Default,Unknown
                _ => "",
            };
        }
    }
}