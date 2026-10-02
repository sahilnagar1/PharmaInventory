using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PharmaInventory.Models
{

    public class Drug : IValidatableObject
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Drug Name is strictly required.")]
        [StringLength(100)]
        [Display(Name = "Drug Name")]
        public string DrugName { get; set; }

        [Required(ErrorMessage = "Batch Number is required for tracking.")]
        [StringLength(50)]
        [Display(Name = "Batch Number")]
        public string BatchNumber { get; set; }

   
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Manufacture Date")]
        public DateTime ManufactureDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Expiry Date")]
        public DateTime ExpiryDate { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity cannot be negative.")]
        public int Quantity { get; set; }

        [Required]
        [StringLength(100)]
        public string Supplier { get; set; }

        public string ExpiryStatus
        {
            get
            {
                var daysLeft = (ExpiryDate - DateTime.Now).TotalDays;
                if (daysLeft < 0)
                {
                    return "Expired";       
                }
                else if (daysLeft <= 60)
                {
                    return "Expiring Soon"; 
                }
                else
                {
                    return "Safe";        
                }
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ExpiryDate <= ManufactureDate)
            {
                yield return new ValidationResult(
                    "Expiry Date cannot be on or before the Manufacture Date.",
                    new[] { nameof(ExpiryDate) });
            }
        }
    }
}