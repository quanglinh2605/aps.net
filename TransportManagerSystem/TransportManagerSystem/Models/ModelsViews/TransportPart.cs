using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransportManagerSystem.Models.ModelsViews
{
    public class TransportPart
    {
        public Nullable<int> Id { get; set; }
        public string Name { get; set; }
        public int TwoWheelNumber { get; set; }
        public int fourWheelNumber { get; set; }
    }
}