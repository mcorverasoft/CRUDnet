using System;
using System.ComponentModel.DataAnnotations;
namespace Cars.Models
{
	public class Car
	{
        [Key]
        public long id { get; set; }
        public string plate { get; set; }
        public string vin { get; set; }
        public string brand { get; set; }
        public string serie { get; set; }
        public int year { get; set; }
        public string color { get; set; }
        public int doors { get; set; }

    }
}

