using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_ClassLibrary.Model
{
    public class User
    {
        public long UserId { get; set; }
        public string UserName { get; set; } = "";
        public DateTime UserDOB { get; set; }

        // Navigation Property
        public List<Asset> Assets { get; set; } = new List<Asset>();
    }
}
