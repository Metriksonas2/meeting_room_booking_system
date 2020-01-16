using System.Collections.Generic;

namespace Meeting_Room_Booking_System
{
    public class TimeLine
    {
        public bool IsTaken { get; set; }
        public List<Employee> Employees { get; set; }

        public TimeLine()
        {
            
        }
    }
}