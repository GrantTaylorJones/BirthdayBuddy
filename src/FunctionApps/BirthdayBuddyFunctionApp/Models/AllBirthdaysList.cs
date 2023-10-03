namespace birthdayBuddyFunctionApp
{
    public class AllBirthdaysList
    {

        public IEnumerable<Birthday> Birthdays { get; set; }
        public Birthday(IEnumerable<Birthday> birthdays){
            Birthdays = birthdays;
        }
    }

}