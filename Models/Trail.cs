using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace lost_in_the_woods.Models
{
    public class Trail : BaseEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [DisplayName("Trail Name")]
        public string Name { get; set; }
        
        [Required]
        [MinLength(10)]
        [DisplayName("Description")]
        public string Description { get; set; }
        
        
        [Required]
        [DisplayName("Elevation Change")]
        public int Elevation { get; set; }

        
        [Required]
        [DisplayName("Trail Length")]
        public float Length { get; set; }


        [Required]
        [RegularExpression(@"^[+-]([1-3]?\d(\.\d+)?|180(\.0+)?)$", ErrorMessage = "Must use format: '+/-180.0000'")]
        [DisplayName("Longitude: +/-180.0000")]
        public float Longitude { get; set; }
        
        
        [Required]
        [RegularExpression(@"^[+-]([1-3]?\d(\.\d+)?|180(\.0+)?)$", ErrorMessage = "Must use format: '+/-180.0000'")]
        [DisplayName("Latitude: +/-180.0000")]
        public float Latitude { get; set; }
        
        public Trail()
        {
            
        }
    }
}