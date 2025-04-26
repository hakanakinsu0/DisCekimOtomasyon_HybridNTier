using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Enums
{
    /// <summary>
    /// Rezervasyonun iş akışı aşamaları.
    /// </summary>
    public enum ReservationStatus
    {
        Created = 1, // Rezervasyon Oluşturuldu
        PhotographerAssigned = 2, // Fotoğrafçı Atandı
        ShootCompleted = 3, // Çekim Yapıldı
        SentToPrint = 4, // Baskıya Gönderildi
        AlbumReceived = 5, // Albüm Teslim Alındı
        DeliveredToCustomer = 6  // Müşteriye Teslim Edildi
    }
}
