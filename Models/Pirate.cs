namespace strawhats_api.Models
{
    using System;

    public class Pirate
    {
        public int PirateID { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public int PirateCrewID { get; set; }
        public string Position { get; set; }
        public double Bounty { get; set; }

        public virtual PirateCrew PirateCrew { get; set; }
    }
}