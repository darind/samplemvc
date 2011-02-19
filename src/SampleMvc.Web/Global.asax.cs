namespace SampleMvc.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using FluentValidation.Attributes;
    using FluentValidation.Mvc;
    using SampleMvc.Web.Mvc;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Users", action = "Index", id = UrlParameter.Optional }
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new SpringControllerFactory());

            DataAnnotationsModelValidatorProvider
                .AddImplicitRequiredAttributeForValueTypes = false;

            DefaultModelBinder.ResourceClassKey = "Messages";

            ModelValidatorProviders.Providers.Clear();
            ModelValidatorProviders.Providers.Add(
                    new FluentValidationModelValidatorProvider(new AttributedValidatorFactory()));
        }
    }
}