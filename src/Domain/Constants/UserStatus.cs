using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Constants
{
    public class UserStatus
    {
        public const string ACTIVE = nameof(ACTIVE);
        public const string REQUIRE_CHANGE_PASSWORD = "REQUIRE_CHANGE_PWD";
    }
}
