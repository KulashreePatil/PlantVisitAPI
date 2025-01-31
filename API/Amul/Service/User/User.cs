using Microsoft.EntityFrameworkCore;
using PlantVisit.EFCoreModel;
using PlantVisit.EFCoreModel.Common;

namespace PlantVisit.Service.User
{
    public class User : IUser
    {
        readonly PlantVisitDBContext dbContext;
        public User(PlantVisitDBContext PlantVisitDBContext)
        {
            dbContext = PlantVisitDBContext;
        }
        public async Task<APIResponseModel> GetAll()
        {
            APIResponseModel response = new APIResponseModel();
            try
            {
                response.Data = await dbContext.User.ToListAsync();
                response.Message = "record fetched successfully";
                response.IsSuccess = true;
            }
            catch (Exception)
            {
                response.Data = null;
                response.Message = "Something went wrong";
                response.IsSuccess = false;
            }
            return response;
        }
        public async Task<UserModel> GetByID(int id)
        {
            var user = await dbContext.Set<UserModel>().FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }
            return user;
        }

        public async Task<APIResponseModel> Add(UserModel objuser)
        {
            APIResponseModel response = new APIResponseModel();

            try
            {
                var existingUser = new UserModel
                {
                    UserNumber = objuser.UserNumber,
                };

                dbContext.User.Add(existingUser);
                await dbContext.SaveChangesAsync();
                response.Data = (int)objuser.UserID;
                response.Message = "record added successfully";
                response.IsSuccess = true;

            }
            catch (Exception)
            {

                response.Data = null;
                response.Message = "Something went wrong";
                response.IsSuccess = false;
            }
            return response;
        }
        public async Task<APIResponseModel> Update(UserModel objuser)
        {
            APIResponseModel response = new APIResponseModel();
            try
            {
                UserModel? existinguser = await GetByID(objuser.UserID);
                if (existinguser != null)
                {
                    existinguser.UserNumber = objuser.UserNumber;

                    await dbContext.SaveChangesAsync();
                    response.Data = (int)objuser.UserID;
                    response.Message = "record updated successfully";
                    response.IsSuccess = true;
                }
            }
            catch (Exception)
            {

                response.Data = null;
                response.Message = "Something went wrong";
                response.IsSuccess = false;
            }
            return response;
        }
    }
}
