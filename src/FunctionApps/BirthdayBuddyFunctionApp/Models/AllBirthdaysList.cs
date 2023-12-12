namespace birthdayBuddyFunctionApp
{
    public class AllBirthdaysList
    {

        public IEnumerable<Birthday> Birthdays { get; set; }
        public AllBirthdaysList(IEnumerable<Birthday> birthdays){
            Birthdays = birthdays;
        }
    }

}