namespace HairPro.Application.Models.BarberService
{
    public class BarberServiceCreateModel
    {
        public Guid BarberId { get; set; }
        public Guid ServiceId { get; set; }
        public decimal Price { get; set; }
    }

}
