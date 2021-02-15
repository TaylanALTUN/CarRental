using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {

        #region Brand

        public static string BrandAdded = "Marka Eklendi";
        public static string BrandCantAdd = "Marka Eklenemedi";
        public static string BrandUpdated = "Marka Güncellendi";
        public static string BrandCantUpdate = "Marka Güncellenemedi";
        public static string BrandDeleted = "Marka Silindi";
        public static string BrandCantDelete = "Marka Silinemedi";
        public static string BrandListed = "Markalar listelendi";
        public static string BrandCantList = "Markalar listelenemdi";

        #endregion

        #region Color

        public static string ColorAdded = "Renk Eklendi";
        public static string ColorCantAdd = "Renk Eklenemedi";
        public static string ColorUpdated = "Renk Güncellendi";
        public static string ColorCantUpdate = "Renk Güncellenemedi";
        public static string ColorDeleted = "Renk Silindi";
        public static string ColorCantDelete = "Renk Silinemedi";
        public static string ColorListed = "Renkler listelendi";
        public static string ColorCantList = "Renkler listelenemdi";

        #endregion

        #region Car

        public static string CarAdded = "Araba Eklendi";
        public static string CarCantAdd = "Araba Eklenemedi";
        public static string CarUpdated = "Araba Güncellendi";
        public static string CarCantUpdate = "Araba Güncellenemedi";
        public static string CarDeleted = "Araba Silindi";
        public static string CardCantDelete = "Araba Silinemedi";
        public static string CarListed = "Arabalar listelendi";
        public static string CarCantList = "Arabalar listelenemdi";
        public static string CarNameLengthMustBeMinimumTwo = "Araba ismi minimum 2 karakter olmalıdır";
        public static string CarDailyPriceMustBeMoreThanZero = "Araba günlük fiyatı 0'dan büyük olmalıdır";

        #endregion

        #region Customer

        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerCantAdd = "Müşteri Eklenemedi";
        public static string CustomerUpdated = "Müşteri Güncellendi";
        public static string CustomerCantUpdate = "Müşteri Güncellenemedi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string CustomerCantDelete = "Müşteri Silinemedi";
        public static string CustomerListed = "Müşteriler listelendi";
        public static string CustomerCantList = "Müşteriler listelenemdi";

        #endregion

        #region User

        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserCantAdd = "Kullanıcı Eklenemedi";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string UserCantUpdate = "Kullanıcı Güncellenemedi";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UserCantDelete = "Kullanıcı Silinemedi";
        public static string UserListed = "Kullanıcılar listelendi";
        public static string UserCantList = "Kullanıcılar listelenemdi";

        #endregion

        #region Rental

        public static string RentalAdded = "Araç Kiralandı";
        public static string RentalCantAdd = "Araç Kiralanamadı";
        public static string RentalUpdated = "Araç Teslim Edildi";
        public static string RentalCantUpdate = "Araç Teslim Edilemedi";
        public static string RentalDeleted = "Araç Kiralama  Bilgisi Silindi";
        public static string RentalCantDelete = "Araç Kiralama Bilgisi Silinemedi";
        public static string RentalListed = "Kiralamalar listelendi";
        public static string RentalCantList = "Kiralamalar listelenemdi";
        public static string RentalCarRented = "Araç zaten kiralanmış";
        public static string RentalReturnDateNotNull = "Teslim Tarihi Dolu Olan Kayıt Kiralanamaz";
        public static string RentalReturnDateIsNull = "Teslim Tarihi Boş Olan Kayıt Teslim Edilemez";
        public static string RentalCarNotFound = "Kiralanmış Araç Bulunamadı";

        #endregion
    }
}
