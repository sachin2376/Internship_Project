using System;
using System.Threading.Tasks;

namespace IpTreatmentManagementPortal.Repository.Interfaces
{
    public interface IUserLog
    {
        public Task<Boolean> Login(UserModel userModel);
        public bool Logout();
    }
}
