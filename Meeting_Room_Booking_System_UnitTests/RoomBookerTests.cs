using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Meeting_Room_Booking_System;
using Meeting_Room_Booking_System.Booking_actions;
using Meeting_Room_Booking_System.Exceptions;
using Meeting_Room_Booking_System.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace Meeting_Room_Booking_System_UnitTests
{
    [TestFixture]
    public class BookingClassTests
    {
        [Test]
        public void BookingObjectCreation_WhenMeetingRoomNameIsInvalid_ThrowBookingPropertyIsInvalidException()
        {
            #region Booking attributes

            string roomName = "Vilnius";
            Employee author = new Employee() { Email = "email", Name = "John" };
            DateTime startTime = new DateTime(2019, 12, 6, 15, 30, 0);
            DateTime endTime = new DateTime(2019, 12, 6, 16, 30, 0);
            Employee[] employees = new Employee[] { new Employee() { Email = "email", Name = "John" }, new Employee() { Email = "email", Name = "John" }, new Employee() { Email = "email", Name = "John" } };
            string description = "For business meeting.";

            #endregion

            Assert.Throws<BookingPropertyIsInvalidException>(() => new Booking(roomName, author, startTime, endTime, employees, description));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void BookingObjectCreation_WhenMeetingRoomNameIsNullOrEmpty_ThrowBookingPropertyIsInvalidException
                    (string name)
        {
            #region Booking attributes

            string roomName = name;
            Employee author = new Employee() { Email = "email", Name = "John" };
            DateTime startTime = new DateTime(2019, 12, 6, 15, 30, 0);
            DateTime endTime = new DateTime(2019, 12, 6, 16, 30, 0);
            Employee[] employees = { new Employee() { Email = "email", Name = "John" }, new Employee() { Email = "email", Name = "John" }, new Employee() { Email = "email", Name = "John" } };
            string description = "For business meeting.";

            #endregion

            Assert.Throws<BookingPropertyIsInvalidException>(() => new Booking(roomName, author, startTime, endTime, employees, description));
        }

        [Test]
        [TestCase("", "Eric")]
        [TestCase(null, "Eric")]
        [TestCase("email", "")]
        [TestCase("email", null)]
        [TestCase("", "")]
        [TestCase(null, null)]
        public void BookingObjectCreation_WhenAuthorEmployeePropertiesAreNullOrInvalid_ThrowEmployeePropertyIsInvalidException
                    (string email, string name)
        {
            #region Booking attributes

            string roomName = "Kaunas";
            Employee author = new Employee() { Email = email, Name = name };
            DateTime startTime = new DateTime(2019, 12, 6, 15, 30, 0);
            DateTime endTime = new DateTime(2019, 12, 6, 16, 30, 0);
            Employee[] employees = new Employee[] { new Employee() { Email = "email", Name = "John" }, new Employee() { Email = "email", Name = "John" }, new Employee() { Email = "email", Name = "John" } };
            string description = "For business meeting.";

            #endregion

            Assert.Throws<EmployeePropertyException>(() => new Booking(roomName, author, startTime, endTime, employees, description));
        }

        [Test]
        public void BookingObjectCreation_WhenStartDateTimeIsNull_ThrowBookingPropertyIsInvalidException()
        {
            #region Booking attributes

            string roomName = "Kaunas";
            Employee author = new Employee() { Email = "email", Name = "John" };
            DateTime startTime = new DateTime();
            DateTime endTime = new DateTime(2019, 12, 6, 16, 30, 0);
            Employee[] employees = new Employee[] { new Employee() { Email = "email", Name = "John" }, new Employee() { Email = "email", Name = "John" }, new Employee() { Email = "email", Name = "John" } };
            string description = "For business meeting.";

            #endregion

            Assert.Throws<BookingPropertyIsInvalidException>(() => new Booking(roomName, author, startTime, endTime, employees, description));
        }

        [Test]
        public void BookingObjectCreation_WhenEndDateTimeIsNull_ThrowBookingPropertyIsInvalidException()
        {
            #region Booking attributes

            string roomName = "Kaunas";
            Employee author = new Employee() { Email = "email", Name = "John" };
            DateTime startTime = new DateTime(2019, 12, 6, 16, 30, 0);
            DateTime endTime = new DateTime();
            Employee[] employees = new Employee[] { new Employee() { Email = "email", Name = "John" }, new Employee() { Email = "email", Name = "John" }, new Employee() { Email = "email", Name = "John" } };
            string description = "For business meeting.";

            #endregion

            Assert.Throws<BookingPropertyIsInvalidException>(() => new Booking(roomName, author, startTime, endTime, employees, description));
        }

        [Test]
        [TestCase(15, 48)]
        [TestCase(48, 15)]
        public void BookingObjectCreation_WhenStartOrEndTimeMinutesAreNot15Iterative_ThrowBookingPropertyIsInvalidException
            (int startMinutes, int endMinutes)
        {
            #region Booking attributes

            string roomName = "Kaunas";
            Employee author = new Employee() { Email = "email", Name = "John" };
            DateTime startTime = new DateTime(2019, 12, 6, 15, startMinutes, 0);
            DateTime endTime = new DateTime(2019, 12, 6, 16, endMinutes, 0);
            Employee[] employees = new Employee[] { new Employee() { Email = "email", Name = "John" }, new Employee() { Email = "email", Name = "John" }, new Employee() { Email = "email", Name = "John" } };
            string description = "For business meeting.";

            #endregion

            Assert.Throws<BookingPropertyIsInvalidException>(() => new Booking(roomName, author, startTime, endTime, employees, description));
        }

        [Test]
        public void BookingObjectCreation_WhenStartTimeIsLaterThanEndTime_ThrowBookingPropertyIsInvalidException()
        {
            #region Booking attributes

            string roomName = "Kaunas";
            Employee author = new Employee() { Email = "email", Name = "John" };
            DateTime startTime = new DateTime(2019, 12, 6, 15, 30, 0);
            DateTime endTime = new DateTime(2019, 12, 6, 14, 30, 0);
            Employee[] employees = new Employee[] { new Employee() { Email = "email", Name = "John" }, new Employee() { Email = "email", Name = "John" }, new Employee() { Email = "email", Name = "John" } };
            string description = "For business meeting.";

            #endregion

            Assert.Throws<BookingPropertyIsInvalidException>(() => new Booking(roomName, author, startTime, endTime, employees, description));
        }

        [Test]
        public void BookingObjectCreation_WhenEmployeesCountIsLessThanOne_ThrowBookingPropertyIsInvalidException()
        {
            #region Booking attributes

            string roomName = "Kaunas";
            Employee author = new Employee() { Email = "email", Name = "John" };
            DateTime startTime = new DateTime(2019, 12, 6, 15, 30, 0);
            DateTime endTime = new DateTime(2019, 12, 6, 16, 30, 0);
            Employee[] employees = new Employee[] {};
            string description = "For business meeting.";

            #endregion

            Assert.Throws<BookingPropertyIsInvalidException>(() => new Booking(roomName, author, startTime, endTime, employees, description));
        }

        [Test]
        [TestCase("", "Tom")]
        [TestCase(null, "Tom")]
        [TestCase("email", "")]
        [TestCase("email", null)]
        [TestCase("", "")]
        [TestCase(null, null)]
        public void BookingObjectCreation_WhenSomeEmployeesPropertiesAreNotDefinedOrNull_ThrowEmployeePropertyIsInvalidException
                    (string email, string name)
        {
            #region Booking attributes

            string roomName = "Kaunas";
            Employee author = new Employee() { Email = "email", Name = "John" };
            DateTime startTime = new DateTime(2019, 12, 6, 15, 30, 0);
            DateTime endTime = new DateTime(2019, 12, 6, 16, 30, 0);
            Employee[] employees = new Employee[] { new Employee() { Email = "email", Name = "Eric"}, new Employee() { Email = email, Name = name}};
            string description = "For business meeting.";

            #endregion

            Assert.Throws<EmployeePropertyException>(() => new Booking(roomName, author, startTime, endTime, employees, description));
        }
    }

    [TestFixture]
    public class RoomBookerTests
    {
        private IRoomChecker roomChecker;
        private IEmployeeChecker employeeChecker;
        private RoomBookerService roomBooker;
        private Booking booking;

        [SetUp]
        public void SetUp()
        {
            roomChecker = Substitute.For<IRoomChecker>();
            //employeeChecker = Substitute.For<IEmployeeChecker>();

            roomBooker = new RoomBookerService(roomChecker, employeeChecker);

            #region Booking attributes

            string roomName = "Kaunas";
            Employee author = new Employee() { Email = "email", Name = "John" };
            DateTime startTime = new DateTime(2019, 12, 6, 15, 45, 0);
            DateTime endTime = new DateTime(2019, 12, 6, 16, 30, 0);
            Employee[] employees = new Employee[] { new Employee() { Email = "email", Name = "John" }, new Employee() { Email = "email", Name = "John" }, new Employee() { Email = "email", Name = "John" } };
            string description = "For business meeting.";

            #endregion

            booking = new Booking(roomName, author, startTime, endTime, employees, description);
        }

        #region BookRoom Tests

        [Test]
        public void BookRoom_TimeLineIsEmpty_ReturnTrue()
        {
            roomChecker.TimeLineIsEmpty(booking).Returns(true);
            roomChecker.RoomIsEmpty(booking).Returns(true);

            var result = roomBooker.BookRoom(booking);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void BookRoom_TimeLineIsNotEmptyButWantedRoomIsEmpty_ReturnTrue()
        {
            roomChecker.TimeLineIsEmpty(booking).Returns(false);
            roomChecker.RoomIsEmpty(booking).Returns(true);

            var result = roomBooker.BookRoom(booking);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void BookRoom_TimeLineIsNotEmptyAndWantedRoomIsNotEmpty_ReturnFalse()
        {
            roomChecker.TimeLineIsEmpty(booking).Returns(false);
            roomChecker.RoomIsEmpty(booking).Returns(false);

            var result = roomBooker.BookRoom(booking);

            Assert.That(result, Is.EqualTo(false));
        }

        #endregion

        #region EditBooking Tests

        [Test]
        [TestCase("2019.12.06 15:00:00", "2019.12.06 16:30:00")] // NewStartTime different
        [TestCase("2019.12.06 15:45:00", "2019.12.06 17:00:00")] // NewEndTime different
        [TestCase("2019.12.06 15:00:00", "2019.12.06 17:00:00")] // NewStartTime and NewEndTime are different
        public void EditBooking_WhenNewBookingTimesAreChangedAndTimeLinesAreNotAvailable_ReturnFalse
                    (string newStartTimeString, string newEndTimeString) 
        {
            #region New booking attributes

            string format = "yyyy.MM.dd HH:mm:ss";
            string roomName = booking.MeetingRoomName;
            Employee author = booking.AuthorEmployee;
            Employee[] employees = new Employee[] { new Employee() { Email = "email", Name = "John" }, new Employee() { Email = "email", Name = "John" }, new Employee() { Email = "email", Name = "John" } };
            string description = booking.Description;
            DateTime newStartTime = DateTime.ParseExact(newStartTimeString, format, CultureInfo.InvariantCulture);
            DateTime newEndTime = DateTime.ParseExact(newEndTimeString, format, CultureInfo.InvariantCulture);

            #endregion

            Booking newBooking = new Booking(roomName, author, newStartTime, newEndTime, employees, description);

            roomChecker.TimeLineIsEmpty(newBooking).Returns(false);
            roomChecker.RoomIsEmpty(newBooking).Returns(false);

            var result = roomBooker.EditBooking(booking, newBooking);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        [TestCase("2019.12.06 15:00:00", "2019.12.06 16:30:00")] // NewStartTime different
        [TestCase("2019.12.06 15:45:00", "2019.12.06 17:00:00")] // NewEndTime different
        [TestCase("2019.12.06 15:00:00", "2019.12.06 17:00:00")] // NewStartTime and NewEndTime are different
        public void EditBooking_WhenNewBookingTimesAreChangedAndTimeLinesAreAvailable_ReturnTrue
            (string newStartTimeString, string newEndTimeString)
        {
            #region New booking attributes

            string format = "yyyy.MM.dd HH:mm:ss";
            string roomName = booking.MeetingRoomName;
            Employee author = booking.AuthorEmployee;
            Employee[] employees = new Employee[] { new Employee() { Email = "email", Name = "John" }, new Employee() { Email = "email", Name = "John" }, new Employee() { Email = "email", Name = "John" } };
            string description = booking.Description;
            DateTime newStartTime = DateTime.ParseExact(newStartTimeString, format, CultureInfo.InvariantCulture);
            DateTime newEndTime = DateTime.ParseExact(newEndTimeString, format, CultureInfo.InvariantCulture);

            #endregion

            Booking newBooking = new Booking(roomName, author, newStartTime, newEndTime, employees, description);

            roomChecker.TimeLineIsEmpty(newBooking).Returns(true);
            roomChecker.RoomIsEmpty(newBooking).Returns(true);

            var result = roomBooker.EditBooking(booking, newBooking);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        [TestCase("2019.12.06 15:00:00", "2019.12.06 16:30:00")] // NewStartTime different
        [TestCase("2019.12.06 15:45:00", "2019.12.06 17:00:00")] // NewEndTime different
        [TestCase("2019.12.06 15:00:00", "2019.12.06 17:00:00")] // NewStartTime and NewEndTime are different
        public void EditBooking_WhenNewBookingTimesAreChangedAndRoomIsAvailable_ReturnTrue
                    (string newStartTimeString, string newEndTimeString)
        {
            #region New booking attributes

            string format = "yyyy.MM.dd HH:mm:ss";
            string roomName = booking.MeetingRoomName;
            Employee author = booking.AuthorEmployee;
            Employee[] employees = new Employee[] { new Employee() { Email = "email", Name = "John" }, new Employee() { Email = "email", Name = "John" }, new Employee() { Email = "email", Name = "John" } };
            string description = booking.Description;
            DateTime newStartTime = DateTime.ParseExact(newStartTimeString, format, CultureInfo.InvariantCulture);
            DateTime newEndTime = DateTime.ParseExact(newEndTimeString, format, CultureInfo.InvariantCulture);

            #endregion

            Booking newBooking = new Booking(roomName, author, newStartTime, newEndTime, employees, description);

            roomChecker.TimeLineIsEmpty(newBooking).Returns(false);
            roomChecker.RoomIsEmpty(newBooking).Returns(true);

            var result = roomBooker.EditBooking(booking, newBooking);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void EditBooking_WhenNewBookingTimesNotChanged_ReturnFalse()
        {
            #region New booking attributes

            string format = "yyyy.MM.dd HH:mm:ss";
            string roomName = booking.MeetingRoomName;
            Employee author = booking.AuthorEmployee;
            Employee[] employees = new Employee[] { new Employee() { Email = "email", Name = "John" }, new Employee() { Email = "email", Name = "John" }, new Employee() { Email = "email", Name = "John" } };
            string description = booking.Description;
            DateTime newStartTime = DateTime.ParseExact("2019.12.06 15:45:00", format, CultureInfo.InvariantCulture);
            DateTime newEndTime = DateTime.ParseExact("2019.12.06 16:30:00", format, CultureInfo.InvariantCulture);

            #endregion

            Booking newBooking = new Booking(roomName, author, newStartTime, newEndTime, employees, description);

            var result = roomBooker.EditBooking(booking, newBooking);

            Assert.That(result, Is.EqualTo(true));
        }

        #endregion

        #region CancelBooking Tests

        [Test]
        public void CancelBooking_WhenBookingExists_ReturnTrue()
        {
            roomChecker.BookingExists(booking).Returns(true);

            var result = roomBooker.CancelBooking(booking);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void CancelBooking_WhenBookingDoesNotExist_ReturnFalse()
        {
            roomChecker.BookingExists(booking).Returns(false);

            var result = roomBooker.CancelBooking(booking);

            Assert.That(result, Is.EqualTo(false));
        }

        #endregion
    }
}