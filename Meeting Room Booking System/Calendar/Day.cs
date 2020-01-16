using Meeting_Room_Booking_System.Week_classes;

namespace Meeting_Room_Booking_System
{
    public class Day
    {
        public MeetingRoom[] MeetingRooms { get; set; }

        public Day()
        {
            MeetingRooms = new MeetingRoom[3]
            {
                new MeetingRoom()
                {
                    Name = "Kaunas",
                    Seats = 8
                },
                new MeetingRoom()
                {
                    Name = "Delft",
                    Seats = 3
                },
                new MeetingRoom()
                {
                    Name = "Hamburg",
                    Seats = 4
                }
            };
        }
    }
}