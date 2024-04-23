using Demon.Application.Common.DTO;
using Demon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demon.Application.Common.Utility
{
    public static class SD
    {
        public const string Role_Admin = "Admin";
        public const string Role_Customer = "Customer";

        public const string StatusPending = "Pending";
        public const string StatusApproved = "Approved";
        public const string StatusCheckedIn = "CheckedIn";
        public const string StatusCompleted = "Completed";
        public const string StatusCancelled = "Cancelled";
        public const string StatusRefunded = "Refunded";

        public static int VillaRoomsAvailable_Count(
            int villaId, List<VillaNumber> villaNumberList, DateOnly checkInDate,
            int nights, List<Booking> bookings)
        {
            List<int> bookingInDate = new();
            int finalAvailableRoomForAllNights = int.MaxValue;
            var roomInVilla = villaNumberList.Where(v => v.VillaId == villaId).Count();
            for (int i = 0; i < nights; i++)
            {
                var villaBooked = bookings.Where(b => b.CheckInDate <= checkInDate.AddDays(i) &&
                b.CheckOutDate > checkInDate.AddDays(i) && b.VillaId == villaId);
                foreach (var booking in villaBooked)
                {
                    if (!bookingInDate.Contains(booking.Id))
                    {
                        bookingInDate.Add(booking.Id);
                    }
                }
                var toltalAvailableRooms = roomInVilla - bookingInDate.Count;
                if (toltalAvailableRooms == 0)
                {
                    return 0;
                }
                else
                {
                    if (finalAvailableRoomForAllNights > toltalAvailableRooms)
                    {
                        finalAvailableRoomForAllNights = toltalAvailableRooms;
                    }
                }
            }
            return finalAvailableRoomForAllNights;

        }
        public static RadialBarChartDto GetRadialCartDataModel(int totalCount, double currentMonthCount, double prevMonthCount)
        {
            RadialBarChartDto radialBarChart = new();
            int increaseDecreaseRatio = 100;

            if (prevMonthCount != 0)
            {
                increaseDecreaseRatio = Convert.ToInt32((currentMonthCount - prevMonthCount) / prevMonthCount * 100);
            }
            radialBarChart.TotalCount = totalCount;
            radialBarChart.CountInCurrentMonth = Convert.ToInt32(currentMonthCount);
            radialBarChart.HasRatioIncreased = currentMonthCount > prevMonthCount;
            radialBarChart.Series = new int[] { increaseDecreaseRatio };

            return radialBarChart;
        }

    }
}
