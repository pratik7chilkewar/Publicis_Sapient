using System;
using System.ComponentModel.DataAnnotations;

namespace Publicis_Sapient.Models
{
	public class Medicine
	{
        [Key]
		public int MedicineId { get; set; }
        [Required]
        [MaxLength(100)]
        public string ?  MedicineName { get; set; }
        [MaxLength(1000)]
        public string ? MedicineNotes { get; set; }
        [Required]
        public DateOnly MedicineExpireDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Required]
        public int MedicineQuantity { get; set; }
        [Required]
        public decimal MedicinePrice { get; set; }
        [Required]
        [MaxLength(100)]
        public string ? MedicineBrand { get; set; }
    }
}

