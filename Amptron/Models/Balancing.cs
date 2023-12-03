using System;
namespace Amptron.Models
{
    public class Balancing
    {
        public int Id { get; set; }

        public double Voltage { get; set; }

        public Color BalancingStatusColor => Voltage < 5 ? Color.FromArgb("#FF0000") : Voltage >= 12 ? Color.FromArgb("#00FC19") : Color.FromArgb("#FF9100");
    }
}

