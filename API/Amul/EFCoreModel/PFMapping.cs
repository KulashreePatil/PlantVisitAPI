using System.ComponentModel.DataAnnotations;

namespace PlantVisit.EFCoreModel
{
    public class PFMapping
    {

        [Key]
        public int PFId { get; set; }
        public int PlantID { get; set; }
        public string FaciltiesID { get; set; }
    }
}
