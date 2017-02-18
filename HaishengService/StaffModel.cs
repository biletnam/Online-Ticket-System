using System;

namespace HaishengService
{
    public class StaffRootObject
    {
        public StaffModel key { get; set; }
    }

    public class StaffModel
    {
        public Name name { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public String spot { get; set; }
    }

    public class Name
    {
        public String first { get; set; }
        public String last { get; set; }
    }
}