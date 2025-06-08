using Jcf.Control.Api.Applications.UserApp.Entities;
using Jcf.Control.Api.Core.Constants;
using Jcf.Control.Api.Core.Uteis;
using Microsoft.EntityFrameworkCore;

namespace Jcf.Control.Api.Core.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                    new User
                    (
                        Guid.Parse("08dbd59a-2683-4c67-8e16-689ba2648545"),
                        "Administrador Usuário",
                        "admin@email.com",
                        PasswordUtil.CreateHashMD5("10203040"),
                        "admin@email.com",
                        RolesConstants.ADMIN,
                        null
                    ),
                    new User
                    (
                        Guid.Parse("08dbdc08-56e1-4e90-805f-db29361e075e"),
                        "Básico Usuário",
                        "basico@email.com",
                        PasswordUtil.CreateHashMD5("10203040"),
                        "basico@email.com",
                        RolesConstants.BASIC,
                        null
                    )
                );
        }
    }
}
