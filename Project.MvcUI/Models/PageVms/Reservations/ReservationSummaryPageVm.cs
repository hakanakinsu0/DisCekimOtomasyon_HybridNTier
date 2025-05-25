using Project.BLL.DtoClasses;

namespace Project.MvcUI.Models.PageVms.Reservations
{
    public class ReservationSummaryPageVm
    {
        public ReservationDto Reservation { get; set; }
        public List<PaymentDto> Payments { get; set; } = new();

        public string CustomerName { get; set; }
        public string LocationName { get; set; }
        public string ServiceCategoryName { get; set; }
        public string PackageOptionName { get; set; }

        // Paket fiyatını buraya alıyoruz:
        public decimal BaseAmount { get; set; }

        // Ekstra hizmetlerin toplamı
        public decimal ExtrasTotal { get; set; }

        // Son toplam = paket + ekstra
        public decimal TotalWithExtras => BaseAmount + ExtrasTotal;

    }
}
