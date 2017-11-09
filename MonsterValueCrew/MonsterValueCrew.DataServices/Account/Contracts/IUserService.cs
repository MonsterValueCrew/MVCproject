using MonsterValueCrew.Data.Models;
using System.Collections.Generic;

public interface IUserService
{
    void UpdateUserInfoByUser(string id, string firstName, string lastName, string phone);

    ApplicationUser GetById(string id);

    IEnumerable<ApplicationUser> GetAllUsers();
   

    IEnumerable<ApplicationUser> GetUsersByCourse(string query, int courseId);

    void UpdateUserInfo(string id, string username, string email, string firstName, string lastName, string phone, bool isDeleted);

    void DeactivateAccount(string userId);

    void ActivateAccount(string userId);
}