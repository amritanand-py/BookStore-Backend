using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Entity
{
    public class BookEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Required]
        [StringLength(255)] // Consider a suitable length for your titles
        public string Title { get; set; }

        [Required]
        [StringLength(255)] // Consider a suitable length for author names
        public string Author { get; set; }

        [Range(0, 5)] // Assuming a rating between 0 and 5
        public decimal Rating { get; set; }

        public int RatingCount { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DataType(DataType.Currency)]
        public decimal DiscountedPrice { get; set; }

        [Url] // Validates the format of the URL
        public string CoverUrl { get; set; }

        public int Stocks { get; set; }

        [MaxLength(4000)] // Consider a suitable length for book details
        public string Details { get; set; }

        // Added properties for timestamps
        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        

    }
}
