using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPattern.Domain.Commands
{
    public class UpdateUserPassword
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
