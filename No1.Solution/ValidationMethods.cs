using System;
using System.Linq;

namespace No1
{
    public static class ValidationMethods
    {
        public static Tuple<bool, string> EmptyPassword(string password)
        {
            if (password == string.Empty)
                return Tuple.Create(false, $"{password} is empty ");

            return Tuple.Create(true, $"{password} is not empty");
        }

        public static Tuple<bool, string> LengthLessThanSeven(string password)
        {
            // check if length more than 7 chars 
            if (password.Length <= 7)
                return Tuple.Create(false, $"{password} length too short");

            return Tuple.Create(true, $"{password} length is more than 7");
        }

        public static Tuple<bool, string> LengthMoreThanFifteen(string password)
        {
            // check if length more than 10 chars for admins
            if (password.Length >= 15)
                return Tuple.Create(false, $"{password} length too long");

            return Tuple.Create(true, $"{password} length is less than 15");
        }

        public static Tuple<bool, string> IsContainsChars(string password)
        {
            /// check if password contains at least one alphabetical character 
            if (!password.Any(char.IsLetter))
                return Tuple.Create(false, $"{password} hasn't alphanumerical chars");

            return Tuple.Create(true, $"{password} has alphanumerical chars");
        }

        public static Tuple<bool, string> IsContainsDigits(string password)
        {
            // check if password contains at least one digit character 
            if (!password.Any(char.IsNumber))
                return Tuple.Create(false, $"{password} hasn't digits");

            return Tuple.Create(true, $"{password} contains digits");
        }

        public static Tuple<bool, string> IsContainsUpperChar(string password)
        {
            /// check if password contains at least one uper symbol 
            if (!password.Any(char.IsUpper))
                return Tuple.Create(false, $"{password} hasn't upper chars");

            return Tuple.Create(true, $"{password} has upper chars");
        }

        public static Tuple<bool, string> IsContainsChar(string password)
        {
            /// check if password contains at least one lower symbol
            if (!password.Any(char.IsLower))
                return Tuple.Create(false, $"{password} hasn't lower chars");

            return Tuple.Create(true, $"{password} has lower chars");
        }
    }
}
