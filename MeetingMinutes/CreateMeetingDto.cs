using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingMinutes
{
    public class CreateMeetingDto
    {
        public CreateMeetingDto(int id, int meetingNumber, int meetingType_id, string meetingType_meetingType, string meetingType_typeAcronym, DateTime meetingDatetime)
        {
            this.id = id;
            this.meetingNumber = meetingNumber;
            this.meetingType_id = meetingType_id;
            this.meetingType_meetingType = meetingType_meetingType;
            this.meetingType_typeAcronym = meetingType_typeAcronym;
            this.meetingDatetime = meetingDatetime;
        }

        public int id {  get; set; }
        public int meetingNumber { get; set; }
        public int meetingType_id { get; set; }
        public string meetingType_meetingType {  get; set; }
        public string meetingType_typeAcronym { get; set; }
        public DateTime meetingDatetime { get; set; }
    }
}
