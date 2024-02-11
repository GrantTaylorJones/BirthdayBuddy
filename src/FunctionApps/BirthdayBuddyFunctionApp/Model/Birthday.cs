using System.Text;

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

        override
        public string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string person in People)
            {
                stringBuilder.AppendLine(person);
            }
            stringBuilder.AppendLine($"\nDate: {Date}");
            return stringBuilder.ToString();
        }
    }
}