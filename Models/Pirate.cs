namespace strawhats_api.Models {
    using System;

    public class Pirate {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }        
        public string CrewName { get; set; }
        public string Position { get; set; }
        public decimal Bounty { get; set; }
    }
}