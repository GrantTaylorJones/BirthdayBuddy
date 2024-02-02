namespace birthday_buddy_functionapp
{
    public class Birthday
    {
        public string Date { get; set; }

        public IEnumerable<String> People { get; set; }

        public Birthday()
        {
            this.Date = "";
            this.People = Enumerable.Empty<string>();
        }
    }

}