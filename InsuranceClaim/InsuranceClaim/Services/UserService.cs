using System.Collections.Generic;
using System.Linq;
using InsuranceClaim.Entities;
using Microsoft.Data.SqlClient;

namespace InsuranceClaim.Services
{

    public interface IUserService
    {
        UserModel GetByUsername(string username);
    }

    public class UserService : IUserService
    {
        private readonly PatientDBContext dBContext;
        private readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(UserService));


        public UserService(PatientDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public UserModel GetByUsername(string username)
        {
            try
            {
                List<UserModel> userModels = dBContext.UserModels.ToList();
            }
            catch (SqlException e)
            {
                logger.Error(e.Message);
                return null;
            }
            UserModel model = dBContext.UserModels.First(x => x.Username == username);
            return model;
        }
    }
}
