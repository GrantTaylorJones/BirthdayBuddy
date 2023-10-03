
namespace birthdayBuddyFunctionApp
{
    public class Birthday
    {

        public DateTime TodaysDate;
        public IEnumerable<string> PeopleBornOnThisDate { get; set; }

        public Birthday(DateTime todaysDate, IEnumerable<string> peopleBornOnThisDate){
            TodaysDate = todaysDate;
            PeopleBornOnThisDate = peopleBornOnThisDate;

        }
    }

}