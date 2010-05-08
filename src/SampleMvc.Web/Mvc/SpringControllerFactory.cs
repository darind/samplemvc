namespace SampleMvc.Web.Mvc
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Web.Mvc;
    using Spring.Context;
    using Spring.Context.Support;

    public class SpringControllerFactory : DefaultControllerFactory
    {
        private static readonly IApplicationContext _springContext = ContextRegistry.GetContext();

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            if (controllerType != null)
            {
                var objectsOfType = _springContext.GetObjectsOfType(controllerType);
                if (objectsOfType.Count > 0)
                {
                    return (IController)objectsOfType.Cast<DictionaryEntry>().First<DictionaryEntry>().Value;
                }
            }
            return base.GetControllerInstance(requestContext, controllerType);
        }

    }
}