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

        //private static IDictionary<string, double> ConvertDegreesToRadians(double latFirst, double latSecond, double lonFirst, double lonSecond)
        //{
        //    double lat1rad = latFirst * Math.PI / 180;
        //    double lon1rad = lonFirst * Math.PI / 180;

        //    double lat2rad = latSecond * Math.PI / 180;
        //    double lon2rad = lonSecond * Math.PI / 180;


        //    IDictionary<string, double> dataDict = new Dictionary<string, double>
        //    {
        //        {"Latitude1rad", lat1rad },
        //        {"Longitude1rad", lon1rad },
        //        {"Latitude2rad", lat2rad },
        //        {"Longitude2rad", lon2rad }
        //    };
        //    return dataDict;
        //}

        //private static IDictionary<string, double> FirstCoordinatesCalc(double eRadius, IDictionary<string, double> radianDataDict)
        //{
        //    double rho = eRadius * Math.Cos(radianDataDict["Latitude1rad"]);

        //    IDictionary<string, double> firstCoordinatesDict = new Dictionary<string, double>
        //    {
        //        {"x1", rho*Math.Cos(radianDataDict["Longitude1rad"])},
        //        {"y1", rho*Math.Sin(radianDataDict["Longitude1rad"]) },
        //        {"z1", rho*Math.Sin(radianDataDict["Latitude1rad"]) }
        //    };

        //    return firstCoordinatesDict;
        //}

        //private static IDictionary<string, double> SecondCoordinatesCalc(double eRadius, IDictionary<string, double> radianDataDict)
        //{
        //    double rho = eRadius * Math.Cos(radianDataDict["Latitude2rad"]);

        //    IDictionary<string, double> secondCoordinatesDict = new Dictionary<string, double>
        //    {
        //        {"x2", rho*Math.Cos(radianDataDict["Longitude2rad"])},
        //        {"y2", rho*Math.Sin(radianDataDict["Longitude2rad"]) },
        //        {"z2", rho*Math.Sin(radianDataDict["Latitude2rad"]) }
        //    };

        //    return secondCoordinatesDict;
        //}

        //private static double CalculateThetaValue(IDictionary<string, double> coordinatesFirst, IDictionary<string, double> coordinatesSecond, double eRadius)
        //{
        //    double coorSum = coordinatesFirst["x1"] + coordinatesFirst["y1"] + coordinatesFirst["z1"]
        //                  + coordinatesSecond["x2"] + coordinatesSecond["y2"] + coordinatesSecond["z2"];
        //    double cosTheta = coorSum / (eRadius * eRadius);

        //    double theta = Math.Acos(cosTheta);

        //    return theta;
        //}

        //private static double CalculateDistanceInMeters(double latFirst, double latSecond, double lonFirst, double lonSecond, double eRadius)
        //{
        //    IDictionary<string, double> radianValues = ConvertDegreesToRadians(latFirst, latSecond, lonFirst, lonSecond);
        //    IDictionary<string, double> firstCoordinates = FirstCoordinatesCalc(eRadius, radianValues);
        //    IDictionary<string, double> secondCoordinates = SecondCoordinatesCalc(eRadius, radianValues);
        //    double theta = CalculateThetaValue(firstCoordinates, secondCoordinates, eRadius);
        //    double distance = eRadius * theta;

        //    return distance;
        //}


        //private static double CalculateIISSpeedInKmh( double timestamp1, double timestamp2, double distance)
        //{
        //    double timeInSeconds = (timestamp2 - timestamp1) / 1000;
        //    double speed = distance / timeInSeconds * 1.609344;

        //    return speed;
        //}

        //private static double GetTotalDistance (double latInitial, double latCurrent, double lonInitial, double lonCurrent, double eRadius)
        //{
        //    IDictionary<string, double> radianValues = ConvertDegreesToRadians(latInitial, latCurrent, lonInitial, lonCurrent);
        //    IDictionary<string, double> firstCoordinates = FirstCoordinatesCalc(eRadius, radianValues);
        //    IDictionary<string, double> secondCoordinates = SecondCoordinatesCalc(eRadius, radianValues);
        //    double theta = CalculateThetaValue(firstCoordinates, secondCoordinates, eRadius);
        //    double distance = eRadius * theta;

        //    return distance;
        //}

        //public static double CalculateVelocity(double latFirst, double latSecond, double lonFirst, double lonSecond, double eRadius, double timeStampFirst, double timeStampSecond)
        //{
        //    double distance = CalculateDistanceInMeters(latFirst, latSecond, lonFirst, lonSecond, eRadius);
        //    double velocity = CalculateIISSpeedInKmh(timeStampFirst, timeStampSecond, distance);

        //    return velocity;
        //}

        private static SpaceStationData ConvertDegreesToRadians(SpaceStationData spaceStation)
        {
            SpaceStationData spaceStationInRadians = new SpaceStationData()
            {
                LatitudeJsonRequest = spaceStation.LatitudeJsonRequest * Math.PI / 180,
                LongitudeJsonRequest = spaceStation.LongitudeJsonRequest * Math.PI / 180,
                LatitudeSecondRequired = spaceStation.LatitudeSecondRequired * Math.PI / 180,
                LongitudeSecondRequired = spaceStation.LongitudeSecondRequired * Math.PI / 180
            };

            return spaceStationInRadians;
        }

        private static SpaceStationData FirstCoordinatesCalc(double eRadius, SpaceStationData spaceStationInRadians)
        {
            double rho = eRadius * Math.Cos(spaceStationInRadians.LatitudeJsonRequest);

            SpaceStationData firstSpaceStationCoordinates = new SpaceStationData()
            {
                CoordinateX1 = rho*Math.Cos(spaceStationInRadians.LongitudeJsonRequest),
                CoordinateY1 = rho*Math.Sin(spaceStationInRadians.LongitudeJsonRequest),
                CoordinateZ1 = rho*Math.Sin(spaceStationInRadians.LatitudeJsonRequest)
            };

            return firstSpaceStationCoordinates;
        }

        private static SpaceStationData SecondCoordinatesCalc(double eRadius, SpaceStationData spaceStationInRadians)
        {
            double rho = eRadius * Math.Cos(spaceStationInRadians.LatitudeSecondRequired);

            SpaceStationData secondSpaceStationCoordinates = new SpaceStationData()
            {
                CoordinateX2 = rho * Math.Cos(spaceStationInRadians.LongitudeSecondRequired),
                CoordinateY2 = rho * Math.Sin(spaceStationInRadians.LongitudeSecondRequired),
                CoordinateZ2 = rho * Math.Sin(spaceStationInRadians.LatitudeSecondRequired)
            };

            return secondSpaceStationCoordinates;
        }

        private static double CalculateThetaValue(SpaceStationData firstSpaceStationCoordinates, SpaceStationData secondSpaceStationCoordinates, double eRadius)
        {
            double coorSum = firstSpaceStationCoordinates.CoordinateX1 + firstSpaceStationCoordinates.CoordinateY1 + firstSpaceStationCoordinates.CoordinateZ1
                          + secondSpaceStationCoordinates.CoordinateX2 + secondSpaceStationCoordinates.CoordinateY2 + secondSpaceStationCoordinates.CoordinateZ2;

            double cosTheta = coorSum / (eRadius * eRadius);

            double theta = Math.Acos(cosTheta);

            return theta;
        }

        private static double CalculateDistanceInMeters(SpaceStationData spaceStation, double eRadius)
        {
            SpaceStationData radianValues = ConvertDegreesToRadians(spaceStation);
            SpaceStationData firstCoordinates = FirstCoordinatesCalc(eRadius, radianValues);
            SpaceStationData secondCoordinates = SecondCoordinatesCalc(eRadius, radianValues);
            double theta = CalculateThetaValue(firstCoordinates, secondCoordinates, eRadius);
            double distance = eRadius * theta;

            return distance;
        }


        private static double CalculateIISSpeedInKmh(SpaceStationData spaceStation, double distance)
        {
            double timeInSeconds = (spaceStation.TimestampSecondRequired - spaceStation.TimestampJsonRequest) / 1000;
            double speed = distance / timeInSeconds * 1.609344;

            return speed;
        }

        public static double GetTotalDistance(SpaceStationData spaceStation, double eRadius)
        {
            SpaceStationData radianValues = ConvertDegreesToRadians(spaceStation);
            SpaceStationData initialCoordinates = FirstCoordinatesCalc(eRadius, radianValues);
            SpaceStationData currentCoordinates = SecondCoordinatesCalc(eRadius, radianValues);
            double theta = CalculateThetaValue(initialCoordinates, currentCoordinates, eRadius);
            double distance = eRadius * theta;

            return distance;
        }

        public static double CalculateVelocity(double eRadius, SpaceStationData spaceSation)
        {
            double distance = CalculateDistanceInMeters(spaceSation, eRadius);
            double velocity = CalculateIISSpeedInKmh(spaceSation, distance);

            return velocity;
        }

    }
}

