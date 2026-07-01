using System;
using Microsoft.EntityFrameworkCore;
using Publicis_Sapient.Data;
using Publicis_Sapient.Interface;
using Publicis_Sapient.Models;

namespace Publicis_Sapient.Service
{
    public class MedicineService : IMedicineService
    {
        private readonly ApplicationDbContext _context;

        public MedicineService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Medicine> AddMedicine(Medicine medicine)
        {
            try
            {
                await _context.Medicines.AddAsync(medicine);
                await _context.SaveChangesAsync();

                return medicine;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public async Task<List<Medicine>> GetAllMedicines()
        {
            try
            {
                List<Medicine> _output = null;
                _output = await _context.Medicines.ToListAsync();
                return _output;
            }
            catch (Exception ex)
            {
                throw new Exception( ex.Message);
            }
        }

    }
}

