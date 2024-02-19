using System;
using System.ComponentModel.DataAnnotations;

namespace Cars.DTOs
{
    public class CarDTO
    {
        [Required(ErrorMessage = "the field {0} es Required.")]
        public string plate { get; set; } = null!;
        [Required(ErrorMessage = "the field {0} es Required.")]
        public string vin { get; set; }
        [Required(ErrorMessage = "the field {0} es Required.")]
        public string brand { get; set; }
        [Required(ErrorMessage = "the field {0} es Required.")]
        public string serie { get; set; }
        [Required]
        [Range(2000, 2025, ErrorMessage = "the field {0} is not valid.")]
        public int year { get; set; }
        [Required(ErrorMessage = "the field {0} es Required.")]
        public string color { get; set; }
        [Required(ErrorMessage = "the field {0} es Required.")]
        [Range(1, 4, ErrorMessage = "the field {0} is not valid.")]
        public int doors { get; set; }

    
		public CarDTO()
		{
		}
	}
}

