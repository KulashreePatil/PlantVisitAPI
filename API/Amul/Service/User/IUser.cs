using System.Threading.Tasks;
using PlantVisit.EFCoreModel;

namespace PlantVisit.Service.User;

public interface IUser
{

    Task<List<UserModel>> GetAll();
    Task<int> Add(UserModel objuser);
    Task<bool> Update(UserModel objuser);
    Task<UserModel> GetByID(int id);
}

