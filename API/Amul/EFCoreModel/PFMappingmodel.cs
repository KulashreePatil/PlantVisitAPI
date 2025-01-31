using System.ComponentModel.DataAnnotations;

namespace PlantVisit.EFCoreModel
{
    public class PFMappingmodel
    {

        [Key]
        public int PFId { get; set; }
        public int? PlantID { get; set; }
        public int? FacilitiesID { get; set; }
      
    }
}
