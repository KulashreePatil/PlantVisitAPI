using Microsoft.EntityFrameworkCore;
using PlantVisit.EFCoreModel;

namespace PlantVisit.Service.User
{
    public class User : IUser
    {
        readonly PlantVisitDBContext dbContext;
        public User(PlantVisitDBContext PlantVisitDBContext)
        {
            dbContext = PlantVisitDBContext;
        }
        public async Task<List<UserModel>> GetAll()
        {
            List<UserModel> lstdata = new List<UserModel>();
            using (var connection = dbContext)
            {
                lstdata = await dbContext.User.ToListAsync();
            }
            return lstdata;
        }
        public async Task<UserModel> GetByID(int id)
        {
            return await dbContext.Set<UserModel>().FindAsync(id);
        }

        public async Task<int> Add(UserModel objuser)
        {
            var existingUser = new UserModel
            {
               UserNumber = objuser.UserNumber,
            };

            dbContext.User.Add(existingUser);
            await dbContext.SaveChangesAsync();
            return existingUser.UserID;
        }
        public async Task<bool> Update(UserModel objuser)
        {

            UserModel? existinguser = await GetByID(objuser.UserID);
            if (existinguser != null)
            {
               existinguser.UserNumber = objuser.UserNumber;

                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
