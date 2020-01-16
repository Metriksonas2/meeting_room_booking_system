using System;
using System.Collections.Generic;
using System.Text;

namespace Meeting_Room_Booking_System.Week_classes
{
    public class MeetingRoom
    {
        public string Name { get; set; }
        public int Seats { get; set; }
        public TimeLine[] TimeLines { get; set; } // 1 object represents 15 minutes of 24 hours day

        public MeetingRoom()
        {
            TimeLines = new TimeLine[96];

            for (int i = 0; i < TimeLines.Length; i++)
            {
                TimeLines[i] = new TimeLine() { IsTaken = false };
            }
        }
    }
}
