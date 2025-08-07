using System.ComponentModel.DataAnnotations; // Required for data annotations

namespace PriceQuotationApp.Models;

public class PriceQuote
{
    /// <summary>
    /// The subtotal amount for the quota in US dollars.
    /// </summary>
    [Range(.01, double.MaxValue, ErrorMessage = "Subtotal must be greater than zero.")]
    public decimal Subtotal { get; set; }

    /// <summary>
    /// The discount percentage applied to the quota (0 - 100, not 0.01 - 1).
    /// </summary>
    [Range(0, 100, ErrorMessage = "Discount must be between 0 and 100.")]
    public decimal Discount { get; set; }

    /// <summary>
    /// The amount of the discount applied to the subtotal
    /// </summary>
    [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
    public decimal DiscountAmount => Subtotal * (Discount / 100);

    /// <summary>
    /// The total amount after applying the discount to the subtotal.
    /// </summary>
    [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
    public decimal Total => Subtotal - DiscountAmount;
}