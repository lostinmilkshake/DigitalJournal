using System;
using System.Collections;
using System.Collections.Generic;

namespace DigitalJournal.Moodle.Domain
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public string PrivateToken { get; set; }
    }
}