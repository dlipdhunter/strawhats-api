namespace strawhats_api.Models
{
    using System;
    using System.Collections.Generic;

    public class PirateCrew
    {
        public int PirateCrewID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Pirate> Pirates { get; set; }
    }
}