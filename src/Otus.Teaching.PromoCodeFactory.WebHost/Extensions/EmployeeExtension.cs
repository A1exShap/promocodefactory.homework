using Otus.Teaching.PromoCodeFactory.Core.Domain.Administration;
using Otus.Teaching.PromoCodeFactory.WebHost.Models.RequestModels;
using Otus.Teaching.PromoCodeFactory.WebHost.Models.ResponseModels;
using System.Linq;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Extensions
{
    public static class EmployeeExtension
    {
        public static Employee ToEmployee(this EmployeeRequest apiModel)
        {
            var names = apiModel.FullName.Split(' ');

            return new Employee
            {
                FirstName = names[0],
                LastName = names[1],
                Email = apiModel.Email,
                AppliedPromocodesCount = apiModel.AppliedPromocodesCount,
                Roles = apiModel.Roles.Select(r => r.ToRole()).ToList()
            };
        }

        public static EmployeeResponse ToEmployeeResponse(this Employee employee)
            => new()
            {
                Id = employee.Id,
                FullName = employee.FullName,
                Email = employee.Email,
                AppliedPromocodesCount = employee.AppliedPromocodesCount,
                Roles = employee.Roles.Select(r => r.ToRoleItemResponse()).ToList()
            };
    }
}
