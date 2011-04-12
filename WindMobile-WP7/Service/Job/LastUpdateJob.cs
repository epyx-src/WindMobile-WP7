﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Ch.Epix.WindMobile.WP7.Service.Job
{
    public class LastUpdateJob : JobBase
    {
        public LastUpdateJob(string stationId) : base() 
        {
            StationId = stationId;
        }

        public string StationId {get;set;}

        protected override Uri GetUrl()
        {
            return new Uri(baseUrl + "lastupdate/" + StationId);
        }
    }
}