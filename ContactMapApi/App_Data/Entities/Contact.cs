using System.Collections.Generic;

namespace ContactMapApi.App_Data.Entities
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