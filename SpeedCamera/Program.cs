using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using SpeedCamera;

namespace SpeedCamera
{
    class Program
    {
        static void Main(string[] args)
        {
            var camera = new PointsCalculator();
            //list used to act as driving record
            var pointsOnRecord = new List<int>();

            //Continuously ask user for limit and speed until 12 points on record
            while (pointsOnRecord.Sum() <= 12)
            {
                //ask user for limit
                Console.WriteLine("Please enter a speed limit?");

                var limit = Convert.ToInt32(Console.ReadLine());
                
                //ask user for speed
                Console.WriteLine("Okay, the speed limit is set at: {0}", limit);
                Console.WriteLine("What is the speed of the car?");
                var speed = Convert.ToInt32(Console.ReadLine());

                //determine how much over
                var milesOverLimit = camera.DetermineSpeedOver(limit, speed);
                
                Console.WriteLine("You are over the limit by {0} miles", milesOverLimit);
                
                //determine how many points added to record
                var points = camera.CalculateDemeritPoints(milesOverLimit);
                
                Console.WriteLine("Whelp, you got {0} point(s) added to your record.", points);
                
                pointsOnRecord.Add(points);
                
                Console.WriteLine("You're total points on your record is: {0}.", pointsOnRecord.Sum());
                
                //check to see if license still valid
                if (pointsOnRecord.Sum() > 12)
                {
                    Console.WriteLine("License Suspended!");
                    break;
                }

            }


        }

    }
}
