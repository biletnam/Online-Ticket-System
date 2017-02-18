using System;
using System.Collections.Generic;

namespace HaishengService
{
    public class SpotRootObject
    {
        public SpotModel key { get; set; }
        public List<SpotModel> list { get; set; }
    }

    public class SpotModel
    {
        public SpotLocation location { get; set; }
        public byte[] imgBytes { get; set; }
        public String name { get; set; }
        public String introduction { get; set; }
        public String price { get; set; }
    }

    public class SpotLocation
    {
        public String state { get; set; }
        public String city { get; set; }
        public String zipcode { get; set; }
    }
}