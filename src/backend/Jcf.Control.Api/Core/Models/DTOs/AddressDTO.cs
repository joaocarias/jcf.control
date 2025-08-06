using Jcf.Control.Api.Applications.UserApp.Models.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Jcf.Control.Api.Core.Models.DTOs
{
    public class AddressDTO : EntityBaseDTO
    {
        [StringLength(100)]
        public string? Place { get; set; }

        [StringLength(10)]
        public string? Number { get; set; }

        [StringLength(100)]
        public string? Neighborhood { get; set; }

        [StringLength(100)]
        public string? Complement { get; set; }

        [StringLength(20)]
        public string? ZipCode { get; set; }

        [StringLength(100)]
        public string? City { get; set; }

        [StringLength(2)]
        public string? State { get; set; }

        public AddressDTO(string? place, string? number, string? neighborhood, string? complement, string? zipCode, string? city, string? state, Guid? userCreateId) : base(userCreateId)
        {
            Place = place;
            Number = number;
            Neighborhood = neighborhood;
            Complement = complement;
            ZipCode = zipCode;
            City = city;
            State = state;
        }

        public AddressDTO(string? place, string? number, string? neighborhood, string? complement, string? zipCode, string? city, string? state, Guid id, bool isActive, DateTime createAt, UserDTO? userCreate, Guid? userCreateId, DateTime? updateAt, UserDTO? userUpdate, Guid? userUpdateId) : base(id, isActive, createAt, userCreate, userCreateId, updateAt, userUpdate, userUpdateId)
        {
            Place = place;
            Number = number;
            Neighborhood = neighborhood;
            Complement = complement;
            ZipCode = zipCode;
            City = city;
            State = state;
        }

        public AddressDTO()
        {

        }        
    }
}
