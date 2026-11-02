using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MembershipSystem
{
    public class PersonalRecord
    {
        public static int IndexCounter = 0;
        public static int IdCounter = 1;


        public static string[] StudentID = new string[100];
        public static string[] FName = new string[100];
        public static string[] MName = new string[100];
        public static string[] LName = new string[100];
        public static string[] Gender = new string[100];
        public static string[] BirthDate = new string[100];
        public static string[] MobileNumber = new string[100];
        public static string[] Email = new string[100];
        public static string[] Status = new string[100];
        public static string[] Password = new string[100];
    }
}
