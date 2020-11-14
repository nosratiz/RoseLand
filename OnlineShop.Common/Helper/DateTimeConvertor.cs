using System;
using DNTPersianUtils.Core;

namespace OnlineShop.Common.Helper
{
    public class DateTimeConvertor
    {

        public static string PersianDateTime(DateTime dateTime) => dateTime.ToLongPersianDateString();


        public static string PersianDate(DateTime? dateTime)
        {
            if (dateTime.HasValue)
                return dateTime.Value.ToPersianDateTextify();

            return "";
        }

        public static int PersianDay(DateTime dateTime) => dateTime.GetPersianDayOfMonth();


        public static string LongPersianDate(DateTime dateTime) => dateTime.ToPersianDateTextify();


        public static PersianYear GetLastPersianYearDate(DateTime dateTime) => dateTime.GetPersianYearStartAndEndDates();


        public static string ShortPersianDay(DateTime date) => date.ToShortPersianDateString();

        public static string ShortPersianDay(DateTime? date) => date.HasValue ? date.ToShortPersianDateString() : string.Empty;


        public static DateTime ToGregorianDateTime(string persianDate) => global::PersianDateTime.Parse(persianDate).ToDateTime();

    }
}