using MateriaGris.Ecommerce.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MateriaGris.Ecommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerApplication _customerApplication;

        public CustomerController(ICustomerApplication customerApplication)
        {
            _customerApplication = customerApplication;
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetAllAsync() 
        {
            var response = await _customerApplication.GetAllAsync();
            return response.IsSuccess ? Ok(response) : BadRequest(response);
            /*
            if (response.IsSuccess) 
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }*/
        }

        [HttpGet("GetAllAsync/{customerId}")]
        public async Task<IActionResult> GetAsync(string customerId)
        {
            var response = await _customerApplication.GetAsync(customerId);
            return response.IsSuccess ? Ok(response) : BadRequest(response);

            /*if (response.IsSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }*/
        }
    }
}
