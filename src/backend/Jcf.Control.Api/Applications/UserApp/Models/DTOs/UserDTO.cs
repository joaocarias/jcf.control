using Jcf.Control.Api.Core.Constants;
using Jcf.Control.Api.Core.Models.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Jcf.Control.Api.Applications.UserApp.Models.DTOs
{
    public class UserDTO : EntityBaseDTO
    {
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 3)]
        public string Email { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Login { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Role { get; set; } = RolesConstants.BASIC;

        public UserDTO(string name, string email, string login, string role) : base()
        {
            Name = name;
            Email = email;
            Login = login;
            Role = role;
        }

        public UserDTO(string name, string email, string login, string role, Guid? userCreateId) : base(userCreateId)
        {
            Name = name;
            Email = email;
            Login = login;
            Role = role;
        }

        public UserDTO(Guid id, string name, string email, string login, string role, Guid? userCreateId) : base(id, userCreateId)
        {
            Name = name;
            Email = email;
            Login = login;
            Role = role;
        }

        public UserDTO(string name, string email, string login, string role, Guid id, bool isActive, DateTime createAt, UserDTO? userCreate, Guid? userCreateId, DateTime? updateAt, UserDTO? userUpdate, Guid? userUpdateId) : base(id, isActive, createAt, userCreate, userCreateId, updateAt, userUpdate, userUpdateId)
        {
            Name = name;
            Email = email;
            Login = login;
            Role = role;
        }
    }
}
