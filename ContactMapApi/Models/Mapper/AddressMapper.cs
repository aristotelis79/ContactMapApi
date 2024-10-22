﻿using System.Collections.Generic;
using System.Linq;
using ContactMapApi.App_Data.Entities;

namespace ContactMapApi.Models.Mapper
{
    public static class AddressMapper
    {
        public static Address ToEntity(this AddressViewModel model)
        {
            return new Address
            {
                ContactId = model.ContactId,
                RoadName = model.RoadName,
                RoadNumber = model.RoadNumber,
                ZipCode = model.ZipCode,
                Area = model.Area,
                Country = model.Country,
                City = model.City
            };
        }

        public static List<Address> ToEntities(this IEnumerable<AddressViewModel> models)
        {
            return models.Select(m => m.ToEntity()).ToList();
        }

        public static AddressViewModel ToViewModel(this Address entity)
        {
            return new AddressViewModel
            {
                ContactId = entity.ContactId,
                RoadName = entity.RoadName,
                RoadNumber = entity.RoadNumber,
                ZipCode = entity.ZipCode,
                Area = entity.Area,
                Country = entity.Country,
                City = entity.City
            };
        }

        public static List<AddressViewModel> ToViewModel(this IEnumerable<Address> entities)
        {
            return entities.Select(m => m.ToViewModel()).ToList();
        }
    }
}