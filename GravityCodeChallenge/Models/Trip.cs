using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GravityCodeChallenge.Models
{
    public class Trip
    {
        public string Driver { get; set; }
        public TimeSpan Duration { get; set; }
        public double Distance { get; set; }
        private double _speed;
        public double Speed { get { return Distance / Duration.TotalHours;  }  private set {} }

    }
}
