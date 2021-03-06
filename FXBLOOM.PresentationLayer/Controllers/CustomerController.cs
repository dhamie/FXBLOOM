using FXBLOOM.DataLayer.Interface;
using FXBLOOM.SharedKernel;
using FXBLOOM.SharedKernel.Logging.NlogFile;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FXBLOOM.PresentationLayer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController
    {
        private ILog _logger;
        private ICustomerRepository _customerRepository;
        public CustomerController(ILog logger, ICustomerRepository customerRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _customerRepository = customerRepository;
        }




        [HttpGet]
        [Produces(typeof(ResponseWrapper<string>))]
        public IActionResult Get()
        {
            //return Ok("Hello World");

            return Ok(_customerRepository.GetCustomers());
        }
    }
}
