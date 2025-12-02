using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes
{
    public class EndMeetingDto
    {
        public int meetingId;
        public List<GetMeetingItemsDto> previousMeetingItemsList;
        public List<GetMeetingItemsDto> currentMeetingItemsList;

        public EndMeetingDto(int meetingId, List<GetMeetingItemsDto> previousMeetingItemsList, List<GetMeetingItemsDto> currentMeetingItemsList)
        {
            this.meetingId = meetingId;
            this.previousMeetingItemsList = previousMeetingItemsList;
            this.currentMeetingItemsList = currentMeetingItemsList;
        }
    }
}
