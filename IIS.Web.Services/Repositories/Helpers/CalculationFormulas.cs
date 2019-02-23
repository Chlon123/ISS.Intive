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

        private static IDictionary<string, double> ConvertDegreesToRadians(double lat1, double lat2, double lon1, double lon2)
        {
            double lat1rad = lat1 * Math.PI / 180;
            double lon1rad = lon1 * Math.PI / 180;

            double lat2rad = lat2 * Math.PI / 180;
            double lon2rad = lon2 * Math.PI / 180;

            IDictionary<string, double> dataDict = new Dictionary<string, double>
            {
                {"Latitude1", lat1rad },
                {"Longitude1", lon1rad },
                {"Longitude2", lat2rad },
                {"Longitude2", lon2rad }
            };
            return dataDict;
        }

        private static IDictionary<string, double> FirstCoordinatesCalc(double eRadius, IDictionary<string, double> dict)
        {
            double rho = eRadius * Math.Cos(dict["Latitude1"]);

            IDictionary<string, double> firstCoordinatesDict = new Dictionary<string, double>
            {
                {"x1", rho*Math.Cos(dict["Longitute1"])},
                {"y1", rho*Math.Sin(dict["Longitute1"]) },
                {"z1", rho*Math.Sin(dict["Latitude1"]) }
            };

            return firstCoordinatesDict;
        }

        private static IDictionary<string, double> SecondCoordinatesCalc(double eRadius, IDictionary<string, double> dict)
        {
            double rho = eRadius * Math.Cos(dict["Latitude2"]);

            IDictionary<string, double> secondCoordinatesDict = new Dictionary<string, double>
            {
                {"x1", rho*Math.Cos(dict["Longitute2"])},
                {"y1", rho*Math.Sin(dict["Longitute2"]) },
                {"z1", rho*Math.Sin(dict["Latitude2"]) }
            };

            return secondCoordinatesDict;
        }

        private static double CalculateThetaValue(IDictionary<string, double> coordinates1, IDictionary<string, double> coordinates2, double eRadius)
        {
            double corSum = coordinates1["x1"] + coordinates1["y1"] + coordinates1["z1"]
                          + coordinates2["x2"] + coordinates2["y2"] + coordinates2["z2"];
            double cosTheta = corSum / (eRadius * eRadius);

            double theta = Math.Acos(cosTheta);

            return theta;
        }

        public static double CaculateDistanceInMeters(double lat1, double lat2, double lon1, double lon2, double eRadius)
        {
            IDictionary<string, double> radianValues = ConvertDegreesToRadians(lat1, lat2, lon1, lon2);
            IDictionary<string, double> firstCoordinates = FirstCoordinatesCalc(eRadius, radianValues);
            IDictionary<string, double> secondCoordinates = SecondCoordinatesCalc(eRadius, radianValues);
            double theta = CalculateThetaValue(firstCoordinates, secondCoordinates, eRadius);
            double distance = eRadius * theta;

            return distance;
        }
    }
}

