using ShifaaAPI.DbContext;
using ShifaaAPI.Enums;
using ShifaaAPI.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;

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
        public async Task<IActionResult> Pay([FromForm] int doctorId)
        {
            var doctor = await _context.DoctorSchedules
                .Where(d => d.DoctorId == doctorId)
                .Select(d => new { d.Price })
                .FirstOrDefaultAsync();

            if (doctor == null)
                return NotFound("Doctor not found");

            float price = doctor.Price;

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
                                Name = $"Consultation with Doctor {doctorId}"
                            }
                        },
                        Quantity = 1,
                    },
                },
                Mode = "payment",
                SuccessUrl = "http://localhost:5282/success",
                CancelUrl = "http://localhost:5282/",

            };

            var service = new SessionService();
            Session session = await service.CreateAsync(options);
            return Ok(new { PaymentUrl = session.Url });
        }

        [HttpGet("payment-success")]
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
