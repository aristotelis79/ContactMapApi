namespace ContactMapApi.App_Data.Entities
{
    public class Address : BaseEntity
    {
        public string RoadName { get; set; }

        public string RoadNumber { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string Area { get; set; }

        public string Country { get; set; }

        public virtual int ContactId { get; set; }

        public virtual Contact Contact { get; set; }
    }
}