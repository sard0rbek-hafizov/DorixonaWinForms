namespace Dorixona.Infrastructure.External.Payment;

public interface IPaymentGatewayService
{
    bool ProcessPayment(string paymentMethodId, decimal amount);
}

public class PaymentGatewayService : IPaymentGatewayService
{
    // API kalitlar, konfiguratsiyalar uchun konstruktor qo'shing

    public bool ProcessPayment(string paymentMethodId, decimal amount)
    {
        // Tashqi to'lov provayderiga bog'lanish va to'lovni amalga oshirish logikasi
        return true; // muvaffaqiyatli deb faraz qilinadi
    }
}
