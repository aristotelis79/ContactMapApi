using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ContactMapApi.Models
{
    public class AddressViewModel
    {
        [Required]
        public int ContactId { get; set; }

        [Required]
        public string RoadName { get; set; }
        
        [Required]
        public string RoadNumber { get; set; }
        [Required]
        public string ZipCode { get; set; }

        public string Area { get; set; }
        
        [Required]
        public string Country { get; set; }
    }
}