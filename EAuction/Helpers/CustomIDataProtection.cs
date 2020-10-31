using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EAuction.Helpers
{
    public class CustomIDataProtection
    {
        
            private readonly IDataProtector protector;
            public CustomIDataProtection(IDataProtectionProvider dataProtectionProvider, UniqueCode uniqueCode)
            {
                protector = dataProtectionProvider.CreateProtector(uniqueCode.UserIdRouteValue);
            }
            public string Decode(string data)
            {
                return protector.Unprotect(data);
            }
            public string Encode(string data)
            {
                return protector.Protect(data);
            }
        
        public class UniqueCode
        {
            public readonly string UserIdRouteValue = "UserIdRouteValue";
        }
    }
}
