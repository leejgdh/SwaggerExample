﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DHDashBoardSDK.Models.DTO.Users
{
    public class RequestAuthenticate
    {
        public RequestAuthenticate()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <example>test</example>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <example>test</example>
        [Required]
        public string Password { get; set; }
    }
}
