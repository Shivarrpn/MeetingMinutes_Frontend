using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes
{
    public class MeetingItemHistoryDto
    {
        public MeetingItemHistoryDto() { }

        public MeetingItemHistoryDto(string meetingItem, string comment, string meetingType, string meetingNumberFull, DateTime? meetingDatetime, DateTime? addedDatetime, DateTime? dueDate, DateTime? completedDate, string personResponsible, string status)
        {
            this.meetingItem = meetingItem;
            this.comment = comment;
            this.meetingType = meetingType;
            this.meetingNumberFull = meetingNumberFull;
            this.meetingDatetime = meetingDatetime;
            this.addedDatetime = addedDatetime;
            this.dueDate = dueDate;
            this.completedDate = completedDate;
            this.personResponsible = personResponsible;
            this.status = status;
        }

        public string meetingItem {  get; set; }
        public string comment {  get; set; }
        public string meetingType { get; set; }
        public string meetingNumberFull { get; set; }
        public DateTime? meetingDatetime { get; set; }
        public DateTime? addedDatetime { get; set; }
        public DateTime? dueDate { get; set; }
        public DateTime? completedDate { get; set; }
        public string personResponsible { get; set; }
        public string status { get; set; }
    }
}
