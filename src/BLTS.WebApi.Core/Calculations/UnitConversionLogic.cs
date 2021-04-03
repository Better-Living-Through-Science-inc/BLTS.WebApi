using BLTS.WebApi.Configurations;
using System;

namespace BLTS.WebApi.Calculations
{
    /// <summary>
    /// helper class to assist with unit conversions
    /// </summary>
    public class UnitConversionLogic
    {
        private readonly ConfigurationManager _configurationManager;

        public UnitConversionLogic(ConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
        }

        /// <summary>
        /// returns true if the app is set to run in metric mode for UI output
        /// </summary>
        /// <returns></returns>
        public bool IsMetricSystem()
        {
            if (_configurationManager.GetValue("MeasurementSystem") == "Metric")
                return true;
            else
                return false;
        }

        /// <summary>
        /// converts unsigned int8 value stored in hex 2's complement format into a signed int32
        /// </summary>
        /// <param name="hexValue"></param>
        /// <returns></returns>
        public int ConvertInt8FromHex2Complement(string hexValue)
        {
            byte returnObject = Convert.ToByte(hexValue, 16);

            if (returnObject > byte.MaxValue / 2)
                return ((byte)(~returnObject + 1)) * -1;

            return returnObject;
        }

        #region Distance
        /// <summary>
        /// outputs correct format for user selected UI setting
        /// </summary>
        /// <param name="value"></param>
        /// <returns>meters or inches</returns>
        public double ConvertLengthToUserSetting(double value)
        {
            if (IsMetricSystem())
                return value;
            else
                return MetersToInches(value);
        }

        /// <summary>
        /// outputs correct format for database based on user selected UI setting
        /// </summary>
        /// <param name="value"></param>
        /// <returns>meters</returns>
        public double ConvertLengthFromUserSetting(double value)
        {
            if (IsMetricSystem())
                return value;
            else
                return InchesToMeters(value);
        }

        public double MetersToFeet(double value)
        {
            return MetersToInches(value / 12.000);
        }

        public double FeetToMeter(double value)
        {
            return InchesToMeters(value * 12.000);
        }

        public double MetersToInches(double value)
        {
            return value / 0.0254;
        }

        public double InchesToMeters(double value)
        {
            return value * 0.0254;
        }

        #endregion

        #region Weight
        /// <summary>
        /// outputs correct format for user selected UI setting
        /// </summary>
        /// <param name="value"></param>
        /// <returns>kg or lbs</returns>
        public double ConvertWeightToUserSetting(double value)
        {
            if (IsMetricSystem())
                return value;
            else
                return MetricTonsToUSTons(value);
        }

        /// <summary>
        /// outputs correct format for database based on user selected UI setting
        /// </summary>
        /// <param name="value"></param>
        /// <returns>kg</returns>
        public double ConvertWeightFromUserSetting(double value)
        {
            if (IsMetricSystem())
                return value;
            else
                return USTonsToMetricTons(value);
        }

        public double USTonsToMetricTons(double value)
        {
            return value / 1.10231131;
        }

        public double MetricTonsToUSTons(double value)
        {
            return value * 1.10231131;
        }
        #endregion

        #region Temperature
        /// <summary>
        /// outputs correct format for user selected UI setting
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Celsius or Fahrenhiet</returns>
        public double ConvertTemperatureToUserSetting(double value)
        {
            if (IsMetricSystem())
                return value;
            else
                return CelsiusToFahrenhiet(value);
        }

        /// <summary>
        /// outputs correct format for database based on user selected UI setting
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Celsius</returns>
        public double ConvertTemperatureFromUserSetting(double value)
        {
            if (IsMetricSystem())
                return value;
            else
                return FahrenhietToCelsius(value);
        }

        public double CelsiusToFahrenhiet(double value)
        {
            return value * 9 / 5 + 32;
        }

        public double FahrenhietToCelsius(double value)
        {
            return (value - 32) * 5 / 9;
        }
        #endregion

        #region Pressure
        /// <summary>
        /// outputs correct format for user selected UI setting
        /// </summary>
        /// <param name="value"></param>
        /// <returns>mmHg, kPa or inHg</returns>
        public double ConvertPressureToUserSetting(double value)
        {
            switch (_configurationManager.GetValue("PressureMeasurement"))
            {
                case "inHg":
                    return MmHgToInHg(value);
                case "kPa":
                    return MmHgToKpa(value);
                case "mmHg":
                default:
                    return value;
            }
        }

        /// <summary>
        /// outputs correct format for database based on user selected UI setting
        /// </summary>
        /// <param name="value"></param>
        /// <returns>mmHg</returns>
        public double ConvertPressureFromUserSetting(double value)
        {
            switch (_configurationManager.GetValue("PressureMeasurement"))
            {
                case "inHg":
                    return InHgToMmHg(value);
                case "kPa":
                    return KpaToMmHg(value);
                case "mmHg":
                default:
                    return value;
            }
        }

        public double MmHgToKpa(double value)
        {
            return value * 0.1333223684;
        }

        public double MmHgToInHg(double value)
        {
            return value / 25.400000197459;
        }

        public double KpaToMmHg(double value)
        {
            return value / 0.1333223684;
        }

        public double InHgToMmHg(double value)
        {
            return value * 25.400000197459;
        }

        #endregion
    }
}
