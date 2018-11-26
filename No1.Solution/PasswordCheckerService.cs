using System;
using System.Collections.Generic;

namespace No1
{
    public delegate Tuple<bool, string> ValidationDelegate(string password);

    public class PasswordCheckerService
    {
        private readonly SqlRepository repository;
        private List<ValidationDelegate> list;

        public PasswordCheckerService(List<ValidationDelegate> _list)
        {
            list = _list;

            repository = new SqlRepository();

            if (list == null)
            {
                throw new ArgumentNullException("Conditions of validation must be defined!");
            }
        }

        public Tuple<bool, string> AddPasword(string password)
        {
            List<Tuple<bool, string>> result = VerifyPassword(password);

            foreach (Tuple<bool, string> tuple in result)
            {
                if (tuple.Item1 == false)
                {
                    return tuple;
                }
            }

            return Tuple.Create(true, $"{password} is correct");
        }

        private List<Tuple<bool, string>> VerifyPassword(string password)
        {
            List<Tuple<bool, string>> result = new List<Tuple<bool, string>>();

            if (password == null)
            {
                throw new ArgumentException($"{password} is null argument");
            }

            foreach (ValidationDelegate validate in list)
            {
                if (validate == null)
                {
                    throw new ArgumentNullException("Error: validation function is not defined");
                }
                else
                {
                    result.Add(validate(password));
                }
            }

            return result;
        }
    }
}
