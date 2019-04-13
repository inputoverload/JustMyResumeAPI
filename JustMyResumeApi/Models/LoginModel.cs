using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustMyResumeApi.Models
{
    public class LoginModel
    {
        public static string EncodingKey 
        {
            get
            {
                return "thissecretkey!912";
            }
        }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
