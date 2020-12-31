using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SwaggerExample.Models.DAO
{
    public class User
    {
        public User()
        {

        }

        [Display(Name = "아이디")]
        public int Id { get; set; }

        [Display(Name ="이름")]
        public string FirstName { get; set; }

        [Display(Name = "성")]
        public string LastName { get; set; }

        [Display(Name = "사용자명")]
        public string Username { get; set; }


        [Display(Name = "비밀번호")]
        [JsonIgnore]
        public string Password { get; set; }
    }
}
