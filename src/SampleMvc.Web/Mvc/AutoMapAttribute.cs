namespace SampleMvc.Web.Mvc
{
    using System;
    using System.Web.Mvc;
    using SampleMvc.Web.Controllers;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AutoMapAttribute : ActionFilterAttribute
    {
        public Type SourceType { get; private set; }
        public Type DestType { get; private set; }

        public AutoMapAttribute(Type sourceType, Type destType)
        {
            SourceType = sourceType;
            DestType = destType;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            var controller = filterContext.Controller as IModelMapperController;
            if (controller == null)
            {
                return;
            }
            var model = filterContext.Controller.ViewData.Model;
            if (model != null)
            {
                var viewModel = controller.ModelMapper.Map(model, SourceType, DestType);
                filterContext.Controller.ViewData.Model = viewModel;
            }
        }
    }
}