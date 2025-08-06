using Jcf.Control.Api.Applications.UserApp.Models.DTOs;
using Jcf.Control.Api.Core.Models.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jcf.Control.Api.Applications.ClientApp.Models.DTOs
{
    public class ClientDTO : EntityBaseDTO
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(200)]
        public string? Email { get; set; }

        [StringLength(20)]
        public string? Phone { get; set; }

        [ForeignKey(nameof(AddressId))]
        public AddressDTO? Address { get; set; }

        public Guid? AddressId { get; set; }

        public ClientDTO(string name, string? email, string? phone, AddressDTO address, Guid? userCreateId) : base(userCreateId)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
        }

        public ClientDTO(string name, string? email, string? phone, Guid? addressId, Guid? userCreateId) : base(userCreateId)
        {
            Name = name;
            Email = email;
            Phone = phone;
            AddressId = addressId;
        }

        public ClientDTO() { }

        public ClientDTO(string name, string? email, string? phone, Guid? addressId, AddressDTO address, Guid id, bool isActive, DateTime createAt, UserDTO? userCreate, Guid? userCreateId, DateTime? updateAt, UserDTO? userUpdate, Guid? userUpdateId) : base(id, isActive, createAt, userCreate, userCreateId, updateAt, userUpdate, userUpdateId)
        {
            AddressId = addressId;
            Address = address;
            Name = name;
            Email = email;
            Phone = phone;
        }
    }
}
