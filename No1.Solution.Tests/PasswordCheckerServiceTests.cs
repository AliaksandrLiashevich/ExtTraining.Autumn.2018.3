using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace No1.Solution.Tests
{
    [TestFixture]
    public class PasswordCheckerServiceTests
    {
        static private List<ValidationDelegate> list1 = new List<ValidationDelegate>() { ValidationMethods.EmptyPassword,
        ValidationMethods.IsContainsChar, ValidationMethods.LengthLessThanSeven};

        static private List<ValidationDelegate> list2 = new List<ValidationDelegate>() { ValidationMethods.EmptyPassword,
        ValidationMethods.IsContainsChar, ValidationMethods.LengthLessThanSeven, ValidationMethods.IsContainsUpperChar};

        static private List<ValidationDelegate> list3 = new List<ValidationDelegate>() { ValidationMethods.EmptyPassword,
        ValidationMethods.IsContainsChar, ValidationMethods.IsContainsDigits, ValidationMethods.LengthLessThanSeven,
        ValidationMethods.IsContainsUpperChar};

        [TestCase("1234", false)]
        [TestCase("123Jack00", true)]

        public void AddPasword_List1_BoolResult(string password, bool result)
        {
            PasswordCheckerService service = new PasswordCheckerService(list1);

            Assert.AreEqual(result, service.AddPasword(password).Item1);
        }

        [TestCase("1234", false)]
        [TestCase("123lack00", false)]
        [TestCase("123Jack00", true)]

        public void AddPasword_List2_BoolResult(string password, bool result)
        {
            PasswordCheckerService service = new PasswordCheckerService(list2);

            Assert.AreEqual(result, service.AddPasword(password).Item1);
        }

        [TestCase("1234", false)]
        [TestCase("GoodLuck", false)]
        [TestCase("Learning120", true)]

        public void AddPasword_List3_BoolResult(string password, bool result)
        {
            PasswordCheckerService service = new PasswordCheckerService(list3);

            Assert.AreEqual(result, service.AddPasword(password).Item1);
        }
    }
}
