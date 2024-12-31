using Finance.Domain.Enums;
using Finance.Domain.Reports;

namespace Finance.Domain.Extensions;
public static class PaymentTypeExtensions
{
    public static string PaymentTypeToString(this PaymentType paymentType)
    {
        return paymentType switch
        {
            PaymentType.Cash => ResourceReportGenerationMessages.CASH,
            PaymentType.CreditCard => ResourceReportGenerationMessages.CREDIT_CARD,
            PaymentType.DebitCard => ResourceReportGenerationMessages.DEBIT_CARD,
            PaymentType.EletronicTransfer => ResourceReportGenerationMessages.ELETRONIC_TRANSFER,
            _ => string.Empty
        };
    }
}
