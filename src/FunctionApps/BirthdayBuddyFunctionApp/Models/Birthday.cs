
namespace birthdayBuddyFunctionApp
{
    public class Birthday
    {

        public DateTime Date;
        public IEnumerable<string> PeopleBornOnThisDate { get; set; }

        public Birthday(DateTime date, IEnumerable<string> peopleBornOnThisDate){
            Date = date;
            PeopleBornOnThisDate = peopleBornOnThisDate;

        }
    }

}