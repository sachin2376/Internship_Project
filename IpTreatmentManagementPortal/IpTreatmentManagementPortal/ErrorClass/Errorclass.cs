using System;
namespace IpTreatmentManagementPortal.ErrorClass
{
    public class Errorclass
    {
        public string controllername { get; set; }
        public string ActionName { get; set; }
        public string ErrorMessage { get; set; }

        public Errorclass(string controllername, string ActionName, string ErrorMessage)
        {
            this.controllername = controllername;
            this.ActionName = ActionName;
            this.ErrorMessage = ErrorMessage;
        }

        public Errorclass()
        {
            
        }
    }
}
