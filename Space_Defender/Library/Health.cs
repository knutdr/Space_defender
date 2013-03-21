namespace Space_Defender.Library
{
    public class Health
    {
        public static Health Default100 { get { return new Health(100.0);}}

        public double Max { get; private set; }
        public double Current { get; private set; }
        public double Percent { get; private set; }

        public Health(double maxHealth) : this(maxHealth, maxHealth){}

        public Health(double max, double current)
        {
            if (max < 1)
                max = 1;
            
            Max = max;

            Current = getValidCurrent(current);
            updatePercent();
        }

        private void updatePercent()
        {
            Percent = Current/Max;
        }

        public void ApplyHealing(double amount)
        {
            Current = getValidCurrent(Current + amount);
            updatePercent();
        }

        public void ApplyDamage(double amount)
        {
            Current = getValidCurrent(Current - amount);
            updatePercent();
        }

        private double getValidCurrent(double current)
        {
            if (current > Max)
                current = Max;

            //if (current < 0)
            //    current = 0;
            return current;
        }
    }
}
