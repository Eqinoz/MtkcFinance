using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //UserGet();
            //CompanyGet();

            UserTest();

        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetUserDetails();
            if (result.Success == true)
            {
                foreach (var user in result.Data)
                {
                    Console.WriteLine(user.FirstName + " " + user.LastName + "/" + user.Title + "/" + user.CompanyName + "/");

                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CompanyGet()
        {
            //CompanyManager companyManager = new CompanyManager(new EfCompanyDal());
            //foreach (var company in companyManager.GetAll())
            //{
            //    Console.WriteLine();
            //}
        }

        //private static void UserGet()
        //{
        //    UserManager userManager = new UserManager(new EfUserDal());

        //    foreach (var user in userManager.GetAll().Data)
        //    {
        //        Console.WriteLine(user.UserName + " " + user.UserSurname);
        //    }
        //}
    }
}
