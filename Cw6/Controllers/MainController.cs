using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cw6.Controllers
{
    [ApiController]
    [Route("/")]
    public class MainController : ControllerBase
    {
        private DataContext _dataContext;
        
        public MainController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        [HttpGet]
        public IActionResult getPatient()
        {
            return Ok();
        }
    }
}