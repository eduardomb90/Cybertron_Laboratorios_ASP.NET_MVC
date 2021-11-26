using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Movie
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        //[StringLength(40, MinimumLength = 5, ErrorMessage = "Length between 5 and 40")]
        public string Title { get; set; }
        
        [Required]
        [StringLength(40, MinimumLength = 5, ErrorMessage = "Length between 5 and 40")]
        public string Director { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime ReleaseDate { get; set; }
        
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal Gross { get; set; }
        
        [Range(0,10, ErrorMessage = "Rating must be between 0 and 10")]
        public double Rating { get; set; }
        
        //Foreign Key
        public int GenreID { get; set; }
        public virtual Genre Genre { get; set; }
    }
}