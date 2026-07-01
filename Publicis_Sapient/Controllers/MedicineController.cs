using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Publicis_Sapient.Models;
using Publicis_Sapient.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Publicis_Sapient.Controllers
{
    [Route("api/[controller]")]
    public class MedicineController : Controller
    {
        private readonly IMedicineService _medicineService;
        public MedicineController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }
      
        [HttpGet]
        public async Task<IActionResult> GetAllMedicine()
        {
            try
            {
                List<Medicine> _output = null;
                _output = await _medicineService.GetAllMedicines();
                return Ok(_output);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error GetAllMedicine", error = ex.Message });
            }
        }

     
        [HttpPost]
        public async Task<IActionResult> AddMedicine (Medicine medicine)
        {
            try
            {
                if (medicine == null)
                {
                    return BadRequest(ModelState);
                }
                  
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }


                if (medicine.MedicineExpireDate <= DateOnly.FromDateTime(DateTime.Now.Date))
                {
                    return BadRequest(new { message = "Expiry date must be in the future" });
                }

                if (medicine.MedicineQuantity <= 0)
                {
                    return BadRequest(new { message = "Quantity cannot be Zero or Negative" });
                }

                await _medicineService.AddMedicine(medicine);
                return Created($"api/medicines/{medicine.MedicineId}", medicine);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error adding medicine", error = ex.Message });
            }
        }


    }
}

