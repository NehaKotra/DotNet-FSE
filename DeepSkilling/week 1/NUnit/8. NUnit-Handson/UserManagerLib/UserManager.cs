using System;

namespace UserManagerLib
{
    public class UserManager
    {
        public string CreateUser(User user)
        {
            if (user == null ||
                string.IsNullOrWhiteSpace(user.PANCardNo))
            {
                throw new NullReferenceException("PAN Card Number is required.");
            }

            if (user.PANCardNo.Length != 10)
            {
                throw new FormatException("PAN Card Number should contain exactly 10 characters.");
            }

            return "User Created Successfully";
        }
    }
}