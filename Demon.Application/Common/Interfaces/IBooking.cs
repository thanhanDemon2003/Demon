using Demon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demon.Application.Common.Interfaces
{
    public interface IBooking : IRepository<Booking>
    {
        public void Update(Booking booking);
        public void UpdateStatus(int bookingId, string orderStatus, int villaNumber);
        public void UpdateStripePaymentId(int bookingId, string sessionId, string paymentIntentId);
    }
}
