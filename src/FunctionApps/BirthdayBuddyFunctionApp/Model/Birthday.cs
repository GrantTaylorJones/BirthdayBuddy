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
            stringBuilder.Append($"Date: {Date}");
            foreach (string person in People)
            {
                stringBuilder.AppendLine(person);
            }
            return stringBuilder.ToString();
        }
    }
}