using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Meeting_Room_Booking_System.Exceptions;
using Meeting_Room_Booking_System.Week_classes;

namespace Meeting_Room_Booking_System
{
    public class Calendar
    {
        private GregorianCalendar calendar = new GregorianCalendar();
        private const int year = 2019;
        private Day[][] CalendarCells = new Day[12][];
        private Booking[] bookings;

        public Calendar()
        {
            //Fills Calendar with all days for each month specifically
            for (int i = 0; i < 12; i++)
            {
                CalendarCells[i] = new Day[calendar.GetDaysInMonth(year, i + 1)];
            }

            // Fills every day of the year with free to reserve timelines
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < calendar.GetDaysInMonth(year, i + 1); j++)
                {
                    CalendarCells[i][j] = new Day();
                }
            }
        }
    }
}
