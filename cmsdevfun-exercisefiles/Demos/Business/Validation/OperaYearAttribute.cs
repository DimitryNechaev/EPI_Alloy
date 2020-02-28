using System.ComponentModel.DataAnnotations;

namespace AlloyTraining.Business.Validation
{
    public class OperaYearAttribute : ValidationAttribute
    {
        public OperaYearAttribute()
        {
            ErrorMessage = "The first opera ever written was performed in 1597 in Florence in Italy. It was called Dafne and the composer was Jacopo Peri.";
        }

        public override bool IsValid(object value)
        {
            if (!(value is int)) return false;
            return ((int)value) > 1597;
        }
    }
}