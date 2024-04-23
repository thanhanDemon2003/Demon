using Demon.Application.Common.Interfaces;
using Demon.Application.Common.Utility;
using Demon.Domain.Entities;
using Demon.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demon.Infrastructure.Reponsitory
{
    public class BookingReponsitory : Repository<Booking>, IBooking
    {
        private readonly ApplicationDbContext _db;
        public BookingReponsitory(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Booking booking)
        {
            throw new NotImplementedException();
        }

        public void UpdateStatus(int bookingId, string bookingStatus, int villaNumber = 0)
        {
            var bookingFormDb = _db.Bookings.FirstOrDefault(u => u.Id == bookingId);
            if (bookingStatus != null)
            {
                bookingFormDb.VillaNumber = villaNumber;
                bookingFormDb.Status = bookingStatus;
                if (bookingStatus == SD.StatusCheckedIn)
                {
                    bookingFormDb.ActualCheckInDate = DateTime.Now;
                }
                if (bookingStatus == SD.StatusCompleted)
                {
                    bookingFormDb.ActualCheckOutDate = DateTime.Now;
                }
            }

        }

        public void UpdateStripePaymentId(int bookingId, string sessionId, string paymentIntentId)
        {
            var bookingFormDb = _db.Bookings.FirstOrDefault(u => u.Id == bookingId);
            if (bookingFormDb != null)
            {
                if (!string.IsNullOrEmpty(sessionId))
                {
                    bookingFormDb.StripeSessionId = sessionId;

                }
                if (!string.IsNullOrEmpty(paymentIntentId))
                {
                    bookingFormDb.StripePaymentIntentId = paymentIntentId;
                    bookingFormDb.PaymentDate = DateTime.Now;
                    bookingFormDb.IsPaymentSuccessful = true;
                }
            }

        }
    }
}
