using PlantVisit.EFCoreModel;

namespace PlantVisit.Service.UserDta;

public interface IUserData
{

    List<UserDatamodel> GetAll();
    Task<int> Add(UserDatamodel objuser);
    Task<int> Update(UserDatamodel objuser);
}

