using System.Collections.Generic;
using ContactMapApi.Models;

namespace ContactMapApi.Data.Entities
{
    public class Contact : BaseEntity
    {
        public string FullName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
        
        public string Title { get; set; }

        public string Company{ get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}