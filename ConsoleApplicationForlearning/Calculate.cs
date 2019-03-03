namespace ConsoleApplicationForlearning
{
    public class Calculate
    {
        public int Add(int firstValue, int secondValue)
        {
            return firstValue + secondValue;
        }

        public double Add(double firstValue, double secondValue)
        {
            return firstValue + secondValue;
        }

        public int Sub(int firstValue, int secondValue)
        {
            return firstValue - secondValue;
        }

        public double Sub(double firstValue, double secondValue)
        {
            return firstValue - secondValue;
        }

        public int Multi(int firstValue, int secondValue)
        {
            return firstValue * secondValue;
        }

        public double Multi(double firstValue, double secondValue)
        {
            return firstValue * secondValue;
        }


        public int Devide(int firstValue, int secondValue)
        {
            if (secondValue != 0)
                return firstValue / secondValue;
            return firstValue;
        }

        public double Devide(double firstValue, double secondValue)
        {
            if (secondValue != 0.00D)
                return firstValue / secondValue;
            return firstValue;
        }
    }
}
