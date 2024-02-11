namespace birthday_buddy_functionapp
{
    public class BirthdayList
    {
        public IEnumerable<Birthday> Birthdays { get; set; }

        public BirthdayList()
        {
            // Default constructor creates empty enumerable, that can be added to
            Birthdays = Enumerable.Empty<Birthday>();
        }

    }
}