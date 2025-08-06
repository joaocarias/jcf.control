using Jcf.Control.Api.Applications.UserApp.Models.DTOs;
using Jcf.Control.Api.Core.Models.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Jcf.Control.Api.Core.Entities
{
    public class Address : EntityBase
    {
        [StringLength(100)]
        public string? Place { get; private set; }

        [StringLength(10)]
        public string? Number { get; private set; }

        [StringLength(100)]
        public string? Neighborhood { get; private set; }

        [StringLength(100)]
        public string? Complement { get; private set; }

        [StringLength(20)]
        public string? ZipCode { get; private set; }

        [StringLength(100)]
        public string? City { get; private set; }

        [StringLength(2)]
        public string? State { get; private set; }

        public Address(string? place, string? number, string? neighborhood, string? complement, string? zipCode, string? city, string? state, Guid? userCreateId) : base(userCreateId)
        {
            Place = place;
            Number = number;
            Neighborhood = neighborhood;
            Complement = complement;
            ZipCode = zipCode;
            City = city;
            State = state;
        }

        private Address() : base()
        {
            Place = null;
            Number = null;
            Neighborhood = null;
            Complement = null;
            ZipCode = null;
            City = null;
            State = null;
        }

        public void Edit(string? place, string? number, string? neighborhood, string? complement, string? zipCode, string? city, string? state, Guid? userUpdateId)
        {
            Place = place;
            Number = number;
            Neighborhood = neighborhood;
            Complement = complement;
            ZipCode = zipCode;
            City = city;
            State = state;
            base.Edit(userUpdateId);
        }

        public AddressDTO ToDTO()
        {
            return new AddressDTO(
                    Place,
                    Number,
                    Neighborhood,
                    Complement,
                    ZipCode,
                    City,
                    State,
                    Id,
                    IsActive,
                    CreateAt,
                    UserCreate != null ? new UserDTO(UserCreate.Id, UserCreate.Name, UserCreate.Email, UserCreate.Login, UserCreate.Role, UserCreateId) : null,
                    UserCreateId,
                    UpdateAt,
                    UserUpdate != null ? new UserDTO(UserUpdate.Id, UserUpdate.Name, UserUpdate.Email, UserUpdate.Login, UserUpdate.Role, UserCreateId) : null,
                    UserUpdateId
                );
        }
    }
}
