using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessDomain.Business.Domain.Models.Monitoring
{
    public class StatusAlert
    {
        public string ClassAlert { get; set; }

        public int OrderAlert { get; set; }

        public enum AlertClass { AlertRed, AlertOrange, AlertGreen }

        public static StatusAlert GetGreenAlert()
        {
            StatusAlert s = new StatusAlert();
            s.ClassAlert = AlertClass.AlertGreen.ToString();
            s.OrderAlert = 3;
            return s;
        }

        public static StatusAlert GetOrangeAlert()
        {
            StatusAlert s = new StatusAlert();
            s.ClassAlert = AlertClass.AlertOrange.ToString();
            s.OrderAlert = 2;
            return s;
        }

        public static StatusAlert GetRedAlert()
        {
            StatusAlert s = new StatusAlert();
            s.ClassAlert = AlertClass.AlertRed.ToString();
            s.OrderAlert = 1;
            return s;
        }

        public static StatusAlert FindStatusAlert(string v)
        {
            if (string.IsNullOrEmpty(v))
            {
                return StatusAlert.GetGreenAlert();
            }

            if (v.Equals(StatusAlert.GetGreenAlert().ClassAlert.ToString())) { return StatusAlert.GetGreenAlert(); }
            if (v.Equals(StatusAlert.GetOrangeAlert().ClassAlert.ToString())) { return StatusAlert.GetOrangeAlert(); }
            if (v.Equals(StatusAlert.GetRedAlert().ClassAlert.ToString())) { return StatusAlert.GetRedAlert(); }

            return StatusAlert.GetGreenAlert();
        }
    }
}
