﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ApiWithWebToken.Domain
{
    public partial class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
    }
}
