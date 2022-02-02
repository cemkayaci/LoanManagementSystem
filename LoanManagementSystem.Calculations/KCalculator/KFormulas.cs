namespace LoanManagementSystem.Calculations.KCalculator
{
    internal class KFormulas
    {
        private readonly double interestPercentage;
        private readonly int term;

        public KFormulas(double interestPercentage, int term)
        {
            this.interestPercentage = interestPercentage;
            this.term = term;
        }
        public double GetK1Calculated => this.interestPercentage/100/ 12;
        public double GetK2Calculated => Math.Pow((1 + GetK1Calculated), this.term) - 1;
        public double GetK3Calculated => GetK1Calculated + (GetK1Calculated / GetK2Calculated);
    }
}
