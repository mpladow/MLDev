﻿namespace MLDev.AuthSystem.DTOs
{
    public class RegisterUserResult
    {
        public bool Succeeded { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
