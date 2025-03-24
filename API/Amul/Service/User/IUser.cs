using System.Threading.Tasks;
using PlantVisit.EFCoreModel;
using PlantVisit.EFCoreModel.Common;

namespace PlantVisit.Service.User;

public interface IUser
{

    Task<APIResponseModel> GetAll();
    Task<APIResponseModel> Add(UserModel objuser);
    Task<APIResponseModel> Update(UserModel objuser);
    Task<UserModel> GetByID(int id);
    Task<APIResponseModel> ValidateCredential(int number, int OTP);
}

