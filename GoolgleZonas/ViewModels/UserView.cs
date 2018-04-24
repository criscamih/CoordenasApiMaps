using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoolgleZonas.ViewModels
{
    public class UserView
    {
        public string id_user { get; set; }
        public string name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        public RoleView role { get; set; }
        public List<RoleView> roles { get; set; }
    }
}