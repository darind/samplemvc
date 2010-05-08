namespace SampleMvc.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using FluentValidation.Attributes;
    using FluentValidation.Mvc;
    using SampleMvc.Web.Mvc;

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

            ControllerBuilder.Current.SetControllerFactory(new SpringControllerFactory());

            DataAnnotationsModelValidatorProvider
                .AddImplicitRequiredAttributeForValueTypes = false;

            DefaultModelBinder.ResourceClassKey = "Messages";

            ModelValidatorProviders.Providers.Clear();
            ModelValidatorProviders.Providers.Add(
                    new FluentValidationModelValidatorProvider(new AttributedValidatorFactory()));

            ModelMetadataProviders.Current = new FluentValidationModelMetadataProvider(
                new AttributedValidatorFactory());
        }
    }
}