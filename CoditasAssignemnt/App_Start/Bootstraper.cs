using CoditasAssignemnt.Mappings;
using System.Web.Http;

namespace CoditasAssignment.App_Start
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            //Configure AutoFac  
            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);
            AutoMapperConfiguration.Configure();
        }
    }
}