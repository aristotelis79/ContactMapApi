using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactMapApi.Models
{
    public class ContactViewModel
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [MaxLength(14)]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }
        
        public string Title { get; set; }

        public string Company{ get; set; }

        public List<AddressViewModel> Addresses { get; set; }
    }
}