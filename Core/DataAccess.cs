using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class DataAccess
    {
        private static CasinoEntities Casino = new CasinoEntities();

        public static List<User> GetUsers() => Casino.GetContext().Users.ToList();
        public static User GetUser(string login, string password) => GetUsers().FirstOrDefault(x => x.Login == login && x.Password == password);
        public static bool SaveUser(User user)
        {
            try
            {
                if (user.Id == 0)
                    Casino.GetContext().Users.Add(user);

                return Convert.ToBoolean(Casino.GetContext().SaveChanges());
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
