using System.Text;
using Microsoft.AspNetCore.Builder.Extensions;

namespace birthday_buddy_functionapp{
    public class DateUtility{

        private DateTime _dateTime = new DateTime();

        public string getTodaysDateAsString(){
            StringBuilder dateStringBuilder = new StringBuilder();
            return  DateTime.Now.ToString("MM/dd");
  
        }

    }
}