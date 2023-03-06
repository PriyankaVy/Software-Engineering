using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages
{

    /// <summary>
    /// Class for IndexModel
    /// </summary>
    public class Index1Model : PageModel
    {

        // Initialize logger variable
        private readonly ILogger<Index1Model> _logger;

        /// <summary>
        /// Constructor for IndexModel
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public Index1Model(ILogger<Index1Model> logger,
            JsonFileProductService productService)
        {
            // Assign logger variable
            _logger = logger;
            // Assign ProductService
            ProductService = productService;
        }

        /// <summary>
        /// Getter method for JsonFileProductService
        /// </summary>
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Getter for Iterative Products
        /// </summary>
        public IEnumerable<ProductModel> Products { get; private set; }

        /// <summary>
        /// OnGet method for indexpage
        /// </summary>
        public void OnGet()
        {
            // Assign products list to a variable
            Products = ProductService.GetAllData();
        }
    }
}