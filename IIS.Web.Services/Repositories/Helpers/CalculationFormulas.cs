using IIS.Web.Services.Services.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IIS.Web.Services.Repositories.Helpers
{
    public static class CalculationFormulas
    {

        private static SpaceStationData ConvertDegreesToRadians(SpaceStationData spaceStation)
        {
            SpaceStationData spaceStationInRadians = new SpaceStationData()
            {
                LatitudeFirstRequest = spaceStation.LatitudeFirstRequest * Math.PI / 180,
                LongitudeFirstRequest = spaceStation.LongitudeFirstRequest * Math.PI / 180,
                LatitudeSecondRequest = spaceStation.LatitudeSecondRequest * Math.PI / 180,
                LongitudeSecondRequest = spaceStation.LongitudeSecondRequest * Math.PI / 180
            };

            return spaceStationInRadians;
        }

        private static double HaversineFormula(SpaceStationData spaceStation)
        {
            SpaceStationData radianValues = ConvertDegreesToRadians(spaceStation);

            double twoPointsChordLength =
                Math.Pow(Math.Sin((radianValues.LatitudeSecondRequest - radianValues.LatitudeFirstRequest) / 2), 2) +
                Math.Cos(radianValues.LatitudeFirstRequest) * Math.Cos(radianValues.LatitudeFirstRequest) *
                Math.Pow(Math.Sin((radianValues.LongitudeSecondRequest - radianValues.LongitudeFirstRequest) / 2), 2);

            double angularDistance = 2 * Math.Atan2(Math.Pow(twoPointsChordLength, 0.5), Math.Pow(1 - twoPointsChordLength, 0.5));

            return angularDistance; 
        }

        private static double CalculateDistanceFromHaversine(double eRadius, SpaceStationData spaceStation)
        {
            double haversine = HaversineFormula(spaceStation);
            double distance = eRadius * haversine;

            return distance;
        }

        private static double CalculateDistance(SpaceStationData spaceStation, double eRadius)
        {
            double distance = CalculateDistanceFromHaversine(eRadius, spaceStation);
            return distance;
        }

        private static double CalculateIISSpeedInKmh(SpaceStationData spaceStation, double distance)
        {
            
            double time = (spaceStation.TimestampSecondRequest - spaceStation.TimestampFirstRequest)/3600;
            double speed = (distance/1000) / time;

            return speed;
        }

        public static CalculatedSpaceStation CalculateVelocityAndDistance(double eRadius, SpaceStationData spaceSation)
        {
            double distance = CalculateDistance(spaceSation, eRadius);
            double velocity = CalculateIISSpeedInKmh(spaceSation, distance);

            return new CalculatedSpaceStation()
            {
                Distance = distance,
                Velocity = velocity
            };
        }



    }
}

