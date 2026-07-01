using System;
using Publicis_Sapient.Models;

namespace Publicis_Sapient.Interface
{
	public interface IMedicineService
	{
        Task<List<Medicine>> GetAllMedicines();
        Task<Medicine> AddMedicine(Medicine medicine);
    }
}

