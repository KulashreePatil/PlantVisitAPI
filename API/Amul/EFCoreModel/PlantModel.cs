﻿using System.ComponentModel.DataAnnotations;

namespace PlantVisit.EFCoreModel
{
    public class PlantModel
    {
        [Key]
        public int PlantID { get; set; }
        public string? PlantName { get; set; }
        public string?  PlantDescription { get; set; }

        public string?    PlantLocation { get; set; }
         public string?   PlantNumber { get; set; }
           public string? PlantEmail { get; set; }

    }
}
