namespace birthday_buddy_functionapp
{
    public class BirthdayList
    {
        public IEnumerable<Birthday> Birthdays { get; set; } 

        public BirthdayList(){
            this.Birthdays = Enumerable.Empty<Birthday>();
        }

    }
}