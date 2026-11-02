using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MembershipSystem
{
    public class Member
    {
        public static int indexCounter = 0;
        public static int idCounter = 1;

        public static string[] id = new string[100];
        public static string[] FirstName = new string[100];
        public static string[] MiddleName = new string[100];
        public static string[] LastName = new string[100];
        public static string[] MobileNumber = new string[100];
        public static string[] Email = new string[100];
        public static string[] Gender = new string[100];    // Change from int to string
        public static string[] BirthDate = new string[100];
        public static string[] Status = new string[100];
        public static string[] Password = new string[100];
        public static string[] ImagePath = new string[100];
    }
}
