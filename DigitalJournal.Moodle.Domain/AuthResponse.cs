using System;

namespace DigitalJournal.Moodle.Domain
{
    public class AuthResponse
    {
        public string Token { get; set; }
        public string PrivateToken { get; set; }
    }
}