using ShifaaAPI.DbContext;
using ShifaaAPI.Enums;
using ShifaaAPI.Helper;
using ShifaaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;
using Swashbuckle.AspNetCore.Annotations;

namespace ShifaaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly StripeModel _stripeModel;
        private readonly ChargeService _chargeService;
        private readonly TokenService _tokenService;
        private readonly CustomerService _customerService;

        public PaymentController(ApplicationDbContext context,
                                 IOptions<StripeModel> stripeModel,
                                 ChargeService chargeService,
                                 TokenService tokenService,
                                 CustomerService customerService)
        {
            _context = context;
            _stripeModel = stripeModel.Value;
            _chargeService = chargeService;
            _tokenService = tokenService;
            _customerService = customerService;
        }

        [HttpPost("Pay")]
        public async Task<IActionResult> Pay([FromForm] int doctorId, [FromForm] int bookingId)
        {
            var bookingExist = await _context.Bookings.FindAsync(bookingId);
            if (bookingExist == null)
                return NotFound("This Booking is not found");
            var doctor = await _context.Doctors
                .Where(d => d.Id == doctorId)
                .FirstOrDefaultAsync();
            if (doctor == null)
                return NotFound("Doctor not found");
            var doctorPrice = await _context.DoctorSchedules
                .Where(d => d.DoctorId == doctorId)
                .Select(p => p.Price)
                .FirstOrDefaultAsync();

            float price = doctorPrice;

            StripeConfiguration.ApiKey = _stripeModel.Secretkey;

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = "usd",
                            UnitAmountDecimal = (decimal)price ,
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = $"Consultation",

                            }
                        },
                        Quantity = 1,
                    },
                },
                Mode = "payment",
                SuccessUrl = $"http://localhost:5282/success?bookingId={bookingId}",
                CancelUrl = "http://localhost:5282/",

            };

            var service = new SessionService();
            Session session = await service.CreateAsync(options);


            Payment newPayment = new()
            {
                BookingId = bookingId,
                Amount = price,
                Status = PaymentStatus.Paid,
            };

            await _context.Payments.AddAsync(newPayment);
            await _context.SaveChangesAsync();

            return Ok(new { PaymentUrl = session.Url, BookingId = bookingId });
        }

        [HttpGet("payment-success")]
        [SwaggerOperation(
        Description = "This endpoint is used to confirm that a payment has been successfully completed. It updates the booking status to 'Completed'."
)]
        [SwaggerResponse(200, "Payment successful and booking confirmed!", typeof(string))]
        [SwaggerResponse(404, "Booking not found", typeof(string))]
        public async Task<IActionResult> PaymentSuccess([FromQuery] int bookingId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking == null)
            {
                return NotFound("Booking not found");
            }

            booking.Status = BookingStatus.Completed;
            await _context.SaveChangesAsync();

            return Ok("Payment successful, booking confirmed!");
        }
    }
}
