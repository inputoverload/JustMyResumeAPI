using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustMyResumeApi.Models
{
    public class LoginModel
    {
        public static string EncodingKey 
        {
            get
            {
                return "a0a3b103803b4ef99a3b759c9d63504b";
            }
        }

        [Key]
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public string Email { get; set; }
    }
}
