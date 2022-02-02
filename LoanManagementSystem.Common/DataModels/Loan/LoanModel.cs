using LoanManagementSystem.Common.DataModels.LoanDetails;
using System.ComponentModel.DataAnnotations;

namespace LoanManagementSystem.Common.DataModels.Loan
{
    public class LoanModel : BaseDataModel, IValidatableObject
    {
        [Required]         
        public string Customer { get; set; }
        [Required]
        public double Sum { get; set; }
        public double InterestPercentage { get; set; }
        [Required]
        public LoanCalculationType LoanCalculationType { get; set; }
        [Required]
        public int Months { get; set; }
        public List<LoanDetailModel> LoanDetails { get; set; }

        public LoanModel()
        {
            LoanDetails = new List<LoanDetailModel>();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (LoanCalculationType == LoanCalculationType.FloatingRate && (Months < 36 || InterestPercentage < 5))
            {
                yield return new ValidationResult("When FloatingRate type selected term cannot be lesser than 36 and interest cannot be lesser than 5%");
            }
            if (Customer.Length < 5)
            {
                yield return new ValidationResult("Customer name length need to be minimum 5.");
            }
            if (Months < 1)
            {
                yield return new ValidationResult("Term cannot be less than 1");
            }
            if (Sum == 0)
            {
                yield return new ValidationResult("Sum cannot be 0");
            }
            if (InterestPercentage == 0)
            {
                yield return new ValidationResult("Interest cannot be 0");
            }
        }
    }
}
