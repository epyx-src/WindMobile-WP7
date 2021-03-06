﻿
using System;
using System.Collections.Generic;
namespace Ch.Epyx.WindMobile.WP7.Model.Design
{
    public class StationData : IStationData
    {
        public string StationId
        {
            get { return "Id"; }
        }

        public MaintenanceStatus Status
        {
            get { return MaintenanceStatus.Green; }
        }

        public DateTime ExpirationDate
        {
            get { return DateTime.MaxValue; }
        }

        public DateTime LastUpdate
        {
            get { return DateTime.Now; }
        }

        public double WindAverage
        {
            get { return 1.123; }
        }

        public double WindMax
        {
            get { return 10.12; }
        }

        public int WindTrend
        {
            get { return 25; }
        }

        public double WindHistoryMin
        {
            get { return 0; }
        }

        public double WindHistoryAverage
        {
            get { return 12; }
        }

        public double WindHistoryMax
        {
            get { return 28; }
        }

        public double AirTemperature
        {
            get { return 20; }
        }

        public double AirHumidity
        {
            get { return 35; }
        }


        public List<IChartPoint> DirectionChartPoints
        {
            get { return new List<IChartPoint>(); }
        }


        public int DirectionChartDuration
        {
            get { return 3600; }
        }
    }
}
