using Project.Common.Tools;
using System;
using System.Threading.Tasks;

namespace Project.Common.Tester
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                Console.WriteLine("Test mail gönderiliyor...");
                await MailService.SendAsync(
                    receiver: "hakanakinsu@outlook.com",    
                    subject: "Test Konusu",
                    body: "<h3>Merhaba!</h3><p>Bu bir test mesajıdır.</p>"
                );
                Console.WriteLine("Başarıyla gönderildi.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Gönderme hatası: {ex.Message}");
            }

            Console.WriteLine("Test tamamlandı, bir tuşa basın.");
            Console.ReadKey();
        }
    }
}
