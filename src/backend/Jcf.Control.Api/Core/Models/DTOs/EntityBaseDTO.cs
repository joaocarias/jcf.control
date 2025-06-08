using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jcf.Control.Api.Core.Models.DTOs
{
    public class EntityBaseDTO
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public DateTime CreateAt { get; set; } = DateTime.Now;

        [ForeignKey(nameof(UserCreateId))]
        public UserDTO? UserCreate { get; set; }
        public Guid? UserCreateId { get; set; }

        public DateTime? UpdateAt { get; set; }

        [ForeignKey(nameof(UserUpdateId))]
        public UserDTO? UserUpdate { get; set; }
        public Guid? UserUpdateId { get; set; }

        public EntityBaseDTO() { }

        public EntityBaseDTO(Guid? userCreateId)
        {
            UserCreateId = userCreateId;
        }

        public EntityBaseDTO(Guid id, Guid? userCreateId)
        {
            Id = id;
            UserCreateId = userCreateId;
        }

        public EntityBaseDTO(Guid id, bool isActive, DateTime createAt, UserDTO? userCreate, Guid? userCreateId, DateTime? updateAt, UserDTO? userUpdate, Guid? userUpdateId)
        {
            Id = id;
            IsActive = isActive;
            CreateAt = createAt;
            UserCreate = userCreate;
            UserCreateId = userCreateId;
            UpdateAt = updateAt;
            UserUpdate = userUpdate;
            UserUpdateId = userUpdateId;
        }
    }
}
