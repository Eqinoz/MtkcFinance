using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        #region Users

        public static string UsersAdd = "Kullanıcı Eklendi.";
        public static string UsersList = "Kullanıcılar Listelendi";
        public static string UssersPswError = "Şifre 8 Karakterden Küçük Olduğundan Kullanıcı Ekelenemedi!";
        public static string PaymentInTıme = "Sisteme Ödeme Kaydetme Süreniz Doldu";
        public static string UserNameAlreadyExists = "Bu Kullanıcı Zaten Ekli";
        public static string UsersDeleted = "Kullanıcı Silindi.";
        public static string UsersNotDeleted = "Kullanıcı Silinemedi!";

        #endregion


        #region Company

        public static string CompanyList = "Şirketler Listelendi";
        public static string CompanyNameError = "Şirket İsmi 5 Karakterden Az Olamaz";
        public static string CompanyAdd = "Şirket Eklendi";
        public static string CompanyDeleted = "Şirket Başarı İle Silindi";
        public static string CompanyNotDeleted = "Şirket Silinemedi";

        #endregion

        #region Payment

        public static string PaymentList = "Ödeme Şekli Listelendi";
        public static string PaymentTypeAdd = "Ödeme Şekli Eklendi";
        public static string SuccessPaymentList = "Ödeme Eklendi";
        public static string PaymentDeleted = "Ödeme Sİlindi";
        public static string PaymentNotDeleted = "Ödeme Silinemedi";
        public static string PaymentTypeDeleted = "Ödeme Tipi Silindi";
        public static string PaymentTypeNotDeleted = "Ödeme Tipi Silinemedi!";

        #endregion

        #region Title

        public static string TitleList = "Ünvanlar Listelendi";
        public static string TitleAdd = "Ünvan Eklendi";

        #endregion



        public static string AuthorizationDenied = "Yetkiniz Yok.";

        #region AuthService

        public static string UserRegistered = "Kullanıc Kayıtlı";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Şifre Hatalı ";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserAlreadyExists = "Kullanıcı Zaten Var";
        public static string AccessTokenCreated = "Token  Oluşturuldu";

        #endregion


        
    }

}
