using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FluentValidation.Mvc;
using FluentValidation.Attributes;

namespace SampleMvc.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Users", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);

            DataAnnotationsModelValidatorProvider
                .AddImplicitRequiredAttributeForValueTypes = false;

            //DefaultModelBinder.ResourceClassKey = "Messages";

            ModelValidatorProviders.Providers.Clear();
            ModelValidatorProviders.Providers.Add(
                    new FluentValidationModelValidatorProvider(new AttributedValidatorFactory()));

            ModelMetadataProviders.Current = new FluentValidationModelMetadataProvider(
                new AttributedValidatorFactory());
        }
    }
}