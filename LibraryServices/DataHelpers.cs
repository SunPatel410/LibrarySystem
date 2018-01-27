using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryData.Domain;

namespace LibraryServices
{
    public class DataHelpers
    {
        public IEnumerable<string> HumanizeBizHours(IEnumerable<BranchHours> branchHours)
        {
            var hours = new List<string>();

            foreach (var time in branchHours)
            {
                var day = HumanizeDay(time.DayOfWeek);
                var openTime = HumanizeTime(time.OpenTime);
                var closeTime = HumanizeCloseTime(time.CloseTime);

                var timeEntry = $"{day} {openTime} to {closeTime}";
                hours.Add(timeEntry);
            }

            return hours;
        }

        private string HumanizeCloseTime(int timeCloseTime)
        {
            throw new NotImplementedException();
        }

        private string HumanizeTime(int timeOpenTime)
        {
            throw new NotImplementedException();
        }

        private string HumanizeDay(int timeDayOfWeek)
        {
            throw new NotImplementedException();
        }
    }
}
