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
    }
}
