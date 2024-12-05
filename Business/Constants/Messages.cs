using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string UsersAdd = "Kullanıcı Eklendi.";
        public static string UsersList = "Kullanıcılar Listelendi";
        public static string UssersPswError = "Şifre 8 Karakterden Küçük Olduğundan Kullanıcı Ekelenemedi!";
        internal static string PaymentInTıme = "Sisteme Ödeme Kaydetme Süreniz Doldu";

        public static string CompanyList = "Şirketler Listelendi";
        public static string CompanyNameError = "Şirket İsmi 5 Karakterden Az Olamaz";
        public static string UserNameAlreadyExists = "Bu Kullanıcı Zaten Ekli";
    }
}
