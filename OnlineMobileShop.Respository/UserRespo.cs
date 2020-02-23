using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineMobileShop.Entity;
using System.Configuration;
using System.Data.SqlClient;

namespace OnlineMobileShop.Respository
{
    public class UserRespo
    {
        public static List<Account> userList = new List<Account>();
        static UserRespo()
        {
            userList.Add(new Account { UserID = 1, Name = "Mathan", PhoneNumber = 7845122356, MailID = "mathankumarn@gmail.com", Password="mathan" });
            userList.Add(new Account { UserID = 2, Name = "Barathi", PhoneNumber = 4564122356, MailID = "kumarn@gmail.com", Password = "Barathi" });
            userList.Add(new Account { UserID = 3, Name = "Kannan", PhoneNumber = 7863122356, MailID = "mathan@gmail.com", Password = "Kannan" });

        }
        public static IEnumerable<Account> GetDetails()
        {
            return userList;
        }
        public static void Add(Account user)
        {
            userList.Add(user);
        }
        public static void Delete(int userID)
        {
            Account user = GetuserID(userID);
            if (user != null)
                userList.Remove(user);
        }
        public static void Update(Account user)
        {
            Account userValue = userList.Find(id => id.UserID == user.UserID);
            userValue.UserID = user.UserID;
            userValue.Name = user.Name;
            userValue.PhoneNumber = user.PhoneNumber;
            userValue.MailID = user.MailID;
        }
        public static Account GetuserID(int userID)
        {
            return userList.Find(id => id.UserID == userID);
        }
        public static bool Login(string mailId, string Password)
        {
            foreach(Account account in userList)
            {
                if(account.MailID == mailId && account.Password == Password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
