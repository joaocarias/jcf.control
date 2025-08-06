using Jcf.Control.Api.Applications.ClientApp.Models.DTOs;
using Jcf.Control.Api.Applications.UserApp.Models.DTOs;
using Jcf.Control.Api.Core.Entities;
using Jcf.Control.Api.Core.Models.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jcf.Control.Api.Applications.ClientApp.Entities
{
    public class Client : EntityBase
    {
        [Required]
        [StringLength(200)]
        public string Name { get; private set; }

        [StringLength(200)]
        public string? Email { get; private set; }

        [StringLength(20)]
        public string? Phone { get; private set; }

        [ForeignKey(nameof(AddressId))]
        public Address? Address { get; private set; }

        public Guid? AddressId { get; private set; }

        public Client(string name, string? email, string? phone, Guid? addressId, Guid? userCreateId) : base(userCreateId)
        {
            Name = name;
            Email = email;
            Phone = phone;
            AddressId = addressId;
        }

        public Client(string name, string? email, string? phone, Address address, Guid? userCreateId) : base(userCreateId)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
        }

        private Client() : base()
        {
            Name = string.Empty;
            Email = null;
            Phone = null;
            AddressId = null;
            Address = null;
        }

        public void Edit(string name, string? email, string? phone, Guid? userUpdateId)
        {
            Name = name;
            Email = email;
            Phone = phone;
            base.Edit(userUpdateId);
        }

        public ClientDTO ToDTO()
        {
            return new ClientDTO(
               
                Name,
                Email,
                Phone,
                AddressId,
                Address != null ? new AddressDTO(Address.Place, Address.Number, Address.Neighborhood, Address.Complement, Address.ZipCode, Address.City, Address.State, Address.UserCreateId) : null,
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
