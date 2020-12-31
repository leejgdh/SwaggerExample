using System;
using SwaggerExample.Models.DAO;

namespace SwaggerExample.Models.DTO.Users
{
    public class ResponseAuthenticate
    {
        public ResponseAuthenticate()
        {
        }

        public ResponseAuthenticate(User user, string token)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
            Token = token;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Token { get; set; }


    }
}
