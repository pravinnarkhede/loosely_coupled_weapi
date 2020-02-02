using Autofac;
using Autofac.Integration.WebApi;
using CoditasAssignment.Data.Infrastructure;
using CoditasAssignment.Data.Repositories;
using CoditasAssignment.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace CoditasAssignment.App_Start
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            //Configure AutoFac  
            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);
        }
    }
}