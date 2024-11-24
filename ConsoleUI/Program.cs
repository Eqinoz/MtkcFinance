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

            UserManager userManager = new UserManager(new EfUserDal());
            foreach (var user in userManager.GetUserDetails())
            {
                Console.WriteLine(user.UserName+ " "+user.UserSurname+"/"+user.Title+"/"+ user.CompanyName);

            }

        }

        private static void CompanyGet()
        {
            CompanyManager companyManager = new CompanyManager(new EfCompanyDal());
            foreach (var company in companyManager.GetAll())
            {
                Console.WriteLine(company.CompanyName);
            }
        }

        private static void UserGet()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            foreach (var user in userManager.GetAll())
            {
                Console.WriteLine(user.UserName + " " + user.UserSurname);
            }
        }
    }
}
