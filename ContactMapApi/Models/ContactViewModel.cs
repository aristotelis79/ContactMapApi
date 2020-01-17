using System.Collections.Generic;

namespace ContactMapApi.Models
{
    public class ContactViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
        
        public string Title { get; set; }

        public string Company{ get; set; }

        public List<AddressViewModel> Addresses { get; set; }
    }
}