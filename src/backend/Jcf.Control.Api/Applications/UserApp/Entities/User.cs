using Jcf.Control.Api.Applications.UserApp.Models.DTOs;
using Jcf.Control.Api.Core.Constants;
using Jcf.Control.Api.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Jcf.Control.Api.Applications.UserApp.Entities
{
    public class User : EntityBase
    {
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Name { get; private set; }

        [Required]
        [StringLength(256, MinimumLength = 3)]
        public string Email { get; private set; }

        [Required]
        [StringLength(256, MinimumLength = 6)]
        public string Password { get; private set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Login { get; private set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Role { get; set; } = RolesConstants.BASIC;

        public User(string name, string email, string password, string login, string role) : base()
        {
            Name = name;
            Email = email;
            Password = password;
            Login = login;
            Role = role;
        }

        public User(string name, string email, string password, string login, string role, Guid? userCreateId) : base(userCreateId)
        {
            Name = name;
            Email = email;
            Password = password;
            Login = login;
            Role = role;
        }

        public User(Guid id, string name, string email, string password, string login, string role, Guid? userCreateId) : base(id, userCreateId)
        {
            Name = name;
            Email = email;
            Password = password;
            Login = login;
            Role = role;
        }

        private User() : base()
        {
            Name = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            Login = string.Empty;
        }

        public UserDTO ToDTO()
        {
            return new UserDTO(
                Name,
                Email,
                Login,
                Role,
                Id,
                IsActive,
                CreateAt,
                UserCreate != null ? new UserDTO(UserCreate.Id, UserCreate.Name, UserCreate.Email, UserCreate.Login, UserCreate.Role, UserCreateId) : null,
                UserCreateId,
                UpdateAt,
                null,
                UserUpdateId
            );
        }

        public void Edit(string name, string email, string password, string login, Guid? userUpdate) 
        {
            Name = name ?? string.Empty;
            Email = email ?? string.Empty;
            Password = password ?? string.Empty;
            Login = login ?? string.Empty;           
            base.Edit(userUpdate);
        }
    }
}
