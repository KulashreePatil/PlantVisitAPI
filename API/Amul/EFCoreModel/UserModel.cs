using System.ComponentModel.DataAnnotations;

namespace PlantVisit.EFCoreModel
{
    public class UserModel
    {
        [Key]
       public int UserID { get; set; }
       public int UserNumber { get; set; }

        public int OTP { get; set; }

    }
}
