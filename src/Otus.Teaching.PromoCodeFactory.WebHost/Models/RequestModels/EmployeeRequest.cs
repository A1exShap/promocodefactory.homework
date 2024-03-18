﻿using Otus.Teaching.PromoCodeFactory.WebHost.Models.ResponseModels;
using System.Collections.Generic;

namespace Otus.Teaching.PromoCodeFactory.WebHost.Models.RequestModels
{
    public class EmployeeRequest
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public List<RoleItemResponse> Roles { get; set; }

        public int AppliedPromocodesCount { get; set; }
    }
}
