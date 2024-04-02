using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer.Request_Model
{
    public class BookCreationReq
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(255, ErrorMessage = "Title must not exceed 255 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        [StringLength(255, ErrorMessage = "Author name must not exceed 255 characters")]
        public string Author { get; set; }

        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5")]
        public decimal? Rating { get; set; }

        public int? RatingCount { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number")]
        public decimal Price { get; set; }

        public decimal? DiscountedPrice { get; set; }

        [Url(ErrorMessage = "Cover URL must be a valid URL")]
        public string CoverUrl { get; set; }

        [Required(ErrorMessage = "Stocks are required")]
        [Range(0, int.MaxValue, ErrorMessage = "Stocks must be a non-negative number")]
        public int Stocks { get; set; }

        [MaxLength(4000, ErrorMessage = "Details must not exceed 4000 characters")]
        public string Details { get; set; }
    }
}
