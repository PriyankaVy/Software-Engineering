using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ContosoCrafts.WebSite.Models
{

    /// <summary>
    /// Model class for Product
    /// </summary>
    public class ProductModel
    {
        //get or set the Event ID
        public string Id { get; set; }

        //get or set the maker of the product
        public string Maker { get; set; }

        //get or set the image URL to JSON
        [JsonPropertyName("img")]
        public string Image { get; set; }

        //get or set the URL
        public string Url { get; set; }

        //Validating the string length of the title to be less than 100 characters
        [StringLength(maximumLength: 33, MinimumLength = 1, ErrorMessage = "The Title should have a length of more than {2} and less than {1}")]
        public string Title { get; set; }

        //get or set the Event Decription
        public string Description { get; set; }

        //get or set the Rating of the event
        public int[] Ratings { get; set; }

        //get or set the ProductTypeEnum of the event
        public ProductTypeEnum ProductType { get; set; } = ProductTypeEnum.Undefined;

        //get or set the quantity of the product
        public string Quantity { get; set; }

        // Validating the price of the product to be between -1 and 100
        [Range(-1, 100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Price { get; set; }

        // Store the Comments entered by the users on this product
        public List<CommentModel> CommentList { get; set; } = new List<CommentModel>();

        //JsonSerializer to serialize ProductModel
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);
    }
}