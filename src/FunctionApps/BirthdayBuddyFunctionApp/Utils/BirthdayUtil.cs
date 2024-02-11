namespace birthday_buddy_functionapp
{
    public class BirthdayUtil
    {
        public BirthdayUtil(){}
        
        public static Birthday GetTodaysBirthdays(BirthdayList birthdayList){
            string todaysDate = GetTodaysDateAsMMYY();
            return GetBirthdaysOnDate(todaysDate, birthdayList);
        }

        private static string GetTodaysDateAsMMYY(){
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