using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace offApp
{
    class SystemSwitch
    {
        private DateTime day;
        private String hour;
        private String minutes;

       public SystemSwitch()
        {

        }
    
        public void addShutdown(DateTime day,String hour,String minutes)
        {
            this.day = day;
            this.hour = hour;
            this.minutes = minutes;
            this.day = this.day.AddHours(Double.Parse(hour));
            this.day = this.day.AddMinutes(Double.Parse(minutes));

            getCommandShutdown(calculateSecunds());
        }

        public String getShutdownDate()
        {
            return day.ToString();
        }

        private void getCommandShutdown(uint secunds)
        {
            String args = "/s /t " + secunds.ToString();
            Process.Start("shutdown",args);
        }

        private uint calculateSecunds()
        {
            DateTime now = DateTime.Now;
            TimeSpan discr = day-now;
            double secunds = discr.TotalSeconds;
            return Convert.ToUInt32(secunds);
        }
    }
}
