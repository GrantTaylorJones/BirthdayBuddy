
namespace birthdayBuddyFunctionApp
{
    public class Birthday
    {

        public IEnumerable<string> PeopleBornOnThisDate { get; set; }
        public DateTime TodaysDate;
        public Birthday(DateTime TodaysDate, IEnumerable<string> PeopleBornOnThisDate){
            this.TodaysDate = TodaysDate;
            this.PeopleBornOnThisDate = PeopleBornOnThisDate;

        }
    }

}