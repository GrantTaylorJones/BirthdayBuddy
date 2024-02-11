namespace birthday_buddy_functionapp
{
    public class BirthdayUtil
    {
        public BirthdayUtil() { }

        public static Birthday GetTodaysBirthdays(BirthdayList birthdayList)
        {
            string todaysDate = GetTodaysDateAsMMDD();
            return GetBirthdaysOnDate("02/11", birthdayList);
        }

        private static string GetTodaysDateAsMMDD()
        {
            return DateTime.Now.ToString("MM/dd");
        }

        public static Birthday GetBirthdaysOnDate(string dateAsMMYY, BirthdayList birthdayList)
        {
            foreach (Birthday birthday in birthdayList.Birthdays)
            {
                if (birthday.Date == dateAsMMYY) return birthday;
            }
            return new Birthday();
        }
    }
}