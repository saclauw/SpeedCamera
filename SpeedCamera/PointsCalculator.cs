namespace SpeedCamera
{
    public class PointsCalculator
    {
        public int DetermineSpeedOver(int speedLimit, int speed)
        {
            var milesOverLimit = speed - speedLimit;
            return milesOverLimit;
        }

        public int CalculateDemeritPoints(int milesOverLimit)
        {
            int demeritPoints = 0;
            for (var i = milesOverLimit; i > 0; i--)
                if (i % 5 == 0)
                {
                    demeritPoints++;
                }
            return demeritPoints;

        }
    }
}