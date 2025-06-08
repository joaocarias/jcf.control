using Jcf.Control.Api.Applications.UserApp.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jcf.Control.Api.Core.Entities
{
    public abstract class EntityBase
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        [Required]
        public bool IsActive { get; private set; } = true;

        [Required]
        public DateTime CreateAt { get; private set; } = DateTime.Now;

        [ForeignKey(nameof(UserCreateId))]
        public User? UserCreate { get; private set; }
        public Guid? UserCreateId { get; private set; }

        public DateTime? UpdateAt { get; private set; }

        [ForeignKey(nameof(UserUpdateId))]
        public User? UserUpdate { get; private set; }
        public Guid? UserUpdateId { get; private set; }

        public EntityBase() { }

        public EntityBase(Guid? userCreateId)
        {
            UserCreateId = userCreateId;
        }

        public EntityBase(Guid id, Guid? userCreateId)
        {
            Id = id;
            UserCreateId = userCreateId;
        }

        public void Delete(Guid? userUpdateId = null)
        {
            UpdateAt = DateTime.UtcNow;
            IsActive = false;
            UserUpdateId = userUpdateId;
        }
    }
}
