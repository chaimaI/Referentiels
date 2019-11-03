using BusinessContracts.Business.Contracts;
using BusinessContracts.Business.Contracts.Monitoring;
using BusinessDomain.Business.Domain.Contracts;
using BusinessDomain.Business.Domain.Contracts.Monitoring;
using InfrastructureBusiness.Infrasctructure.Business;
using InfrastructureBusiness.Infrasctructure.Business.Monitoring;
using InfrastructureDataAccess.Infrastructure.DataAccess;
using InfrastructureDataAccess.Infrastructure.DataAccess.Service;
using InfrastructureDataAccess.Infrastructure.DataAccess.Service.Monitoring;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Referentiels.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Services.Description;
using Unity;
using Unity.Mvc5;

namespace Referentiels
{
    public class MvcApplication : System.Web.HttpApplication
    {


        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            UnityConfiguration();

        }


        public void UnityConfiguration()
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType<IClasseListeService, ClasseListeService>();
            container.RegisterType<IClasseListeDataService, ClasseListeDataService>();

            container.RegisterType<IAbsenceListeService, AbsenceListeService>();
            container.RegisterType<IAbsenceListeDataService, AbsenceListeDataService>();

            container.RegisterType<IQueryService, QueryService>();
            container.RegisterType<IQueryDataService, QueryDataService>();

            container.RegisterType<ILoginService, LoginService>();
            container.RegisterType<ILoginDataService, LoginDataService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            
        }

    }
    }
