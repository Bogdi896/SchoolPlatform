using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolPlatform.Models;

namespace SchoolPlatform.Service
{
    public static class LoggedIn
    {
        public static Professor Professor { get; set; }
        public static Student Student { get; set; }  
    }
}
