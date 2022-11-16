using Microsoft.AspNetCore.Mvc;
using PaymentIntegration.Models;
using PayStack.Net;

namespace PaymentIntegration.Controllers
{
    public class DonateController : Controller
    {
        private PayStackApi Paystack { get; set; }
        private readonly string token;
        private readonly IConfiguration _configuration;

        public DonateController(IConfiguration configuration)
        {
            _configuration = configuration;
            token = _configuration["Payment:PaystackSK"];
            Paystack = new PayStackApi(token);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(DonateViewModel donate)
        {
            TransactionInitializeRequest request = new()
            {
                AmountInKobo = donate.Amount * 100,
                Email = donate.Email,
                Reference = Generate().ToString(),
                Currency ="NGN",
                CallbackUrl = "http://localhost:55927/donate/verify"

            };

            TransactionInitializeResponse = Paystack.Transactions.Initialize(requst);
            if (Response.Status)
             return View();
        }
      
        public static int Generate()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            return rand.Next(100000000, 99999999);
        }
        [HttpGet]
        public IActionResult Donations()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Verify()
        {
            return View();
        }
    }
}
