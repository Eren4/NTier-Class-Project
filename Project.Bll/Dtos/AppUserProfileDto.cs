using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Bll.Dtos
{
    public class AppUserProfileDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
