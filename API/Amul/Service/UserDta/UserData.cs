using PlantVisit.EFCoreModel;

namespace PlantVisit.Service.UserDta
{
    public class UserData : IUserData
    {
        readonly PlantVisitDBContext dbContext;
        public UserData(PlantVisitDBContext PlantVisitDBContext)
        {
            dbContext = PlantVisitDBContext;
        }
        public async Task<int> Add(UserDatamodel objuser)
        {
            using (var connection = dbContext)
            {
                await dbContext.UserDatamodel.AddAsync(objuser);
                dbContext.SaveChanges();
            }
            return (int)objuser.UserID;
        }
        public async Task<int> Update(UserDatamodel objuser)
        {
            var facility = dbContext.UserDatamodel.Find(objuser.UserNumber);
            

            await dbContext.SaveChangesAsync();
            return (int)objuser.UserNumber;
        }



        public List<UserDatamodel> GetAll()
        {
            List<UserDatamodel> lstdata = new List<UserDatamodel>();
            using (var connection = dbContext)
            {
                lstdata = dbContext.UserDatamodel.ToList();
            }
            return lstdata;
        }
    }
}
