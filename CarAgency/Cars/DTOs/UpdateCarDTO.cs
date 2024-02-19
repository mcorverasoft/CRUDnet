using System;
namespace Cars.DTOs
{
	public class UpdateCarDTO
	{
        public string id { get; set; }
        public string plate { get; set; }
        public string vin { get; set; }
        public string brand { get; set; }
        public string serie { get; set; }
        public int year { get; set; }
        public string color { get; set; }
        public int doors { get; set; }


        public UpdateCarDTO()
        {
        }
    }
}

