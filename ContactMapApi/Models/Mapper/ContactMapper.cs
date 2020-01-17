using System.Collections.Generic;
using System.Linq;
using ContactMapApi.App_Data.Entities;

namespace ContactMapApi.Models.Mapper
{
    public static class ContactMapper
    {
        public static Contact ToEntity(this ContactViewModel model)
        {
            return new Contact
            {
                Id = model.Id,
                FullName = model.FullName,
                Email = model.Email,
                Phone = model.Phone,
                Company = model.Company,
                Title = model.Title,
                Addresses = model.Addresses.ToEntities()
            };
        }

        public static ContactViewModel ToViewModel(this Contact entity)
        {
            return new ContactViewModel
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Email = entity.Email,
                Phone = entity.Phone,
                Company = entity.Company,
                Title = entity.Title,
                Addresses = entity.Addresses.ToViewModel()
            };
        }


        public static List<ContactViewModel> ToViewModels(this IEnumerable<Contact> entities)
        {
            return entities.Select(s => s.ToViewModel()).ToList();
        }
    }
}