﻿using System;

namespace DHDashBoardSDK.Models.DTO.Users
{
    public class ResponseAuthenticate
    {
        public ResponseAuthenticate()
        {
        }

        public ResponseAuthenticate(string User, string Token)
        {
            Username = User;
            this.Token = Token;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Token { get; set; }


    }
}
