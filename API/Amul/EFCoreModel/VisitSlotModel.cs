using System.ComponentModel.DataAnnotations;

namespace PlantVisit.EFCoreModel
{
    public class VisitSlotModel
    {
      [Key]
      public int VisitID { get; set; }
      public int PlantID { get; set; }
	  public TimeOnly VisitTime { get; set; }
	  public int Capacity { get; set; }
    }
}
