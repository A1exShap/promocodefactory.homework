using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using Otus.Teaching.PromoCodeFactory.WebHost.Models.ResponseModels;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Extensions
{
    public static class RoleExtension
    {
        public static Role ToRole(this RoleItemResponse apiModel)
            => new()
            {
                Id = apiModel.Id,
                Name = apiModel.Name,
                Description = apiModel.Description
            };

        public static RoleItemResponse ToRoleItemResponse(this Role role)
            => new()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
    }
}
