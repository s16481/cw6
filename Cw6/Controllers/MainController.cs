using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult getDoctor()
        {
            return Ok(_dataContext.Doctors.ToList());
        }
        
        [HttpPost]
        public async Task<IActionResult> addDoctor(Doctor doctor)
        {
            _dataContext.Doctors.Add(doctor);
            await _dataContext.SaveChangesAsync();
            return Created("doctor", doctor);
        }
        
        [HttpPut("{IdDoctor}")]
        public async Task<IActionResult> EditDoctor(int IdDoctor, Doctor doctor)
        {
            if (IdDoctor != doctor.IdDoctor)
            {
                return BadRequest();
            }

            _dataContext.Entry(doctor).State = EntityState.Modified;

            try
            {
                await _dataContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dataContext.Doctors.Any(e => doctor.IdDoctor == e.IdDoctor))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        
        [HttpDelete("{IdDoctor}")]
        public async Task<ActionResult<Doctor>> DeleteStudent(int IdDoctor)
        {
            var doctor = await _dataContext.Doctors.FindAsync(IdDoctor);
            if (doctor == null)
            {
                return NotFound();
            }

            _dataContext.Doctors.Remove(doctor);
            await _dataContext.SaveChangesAsync();

            return NoContent();
        }
    }
}