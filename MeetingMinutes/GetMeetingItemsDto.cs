using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes
{
    public class GetMeetingItemsDto
    {
        public GetMeetingItemsDto()
        {
        }

        public GetMeetingItemsDto(string comment, int meetingItem_id, string meetingItem_item, DateTime? meetingItem_dueDate, DateTime? meetingItem_completedDate, string person_username, string status_status)
        {
            this.comment = comment;
            this.meetingItem_id = meetingItem_id;
            this.meetingItem_item = meetingItem_item;
            this.meetingItem_dueDate = meetingItem_dueDate;
            this.meetingItem_completedDate = meetingItem_completedDate;
            this.person_username = person_username;
            this.status_status = status_status;
        }

        public string comment {  get; set; }
        public int? meetingItem_id { get; set; }
        public string meetingItem_item {  get; set; }
        public DateTime? meetingItem_dueDate { get; set; }
        public DateTime? meetingItem_completedDate { get; set; }
        public string person_username { get; set; }
        public string status_status { get; set; }
    }
}
