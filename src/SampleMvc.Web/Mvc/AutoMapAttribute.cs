namespace SampleMvc.Web.Mvc
{
    using System;
    using System.Web.Mvc;
    using AutoMapper;

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
            var model = filterContext.Controller.ViewData.Model;
            if (model != null && model.GetType() == SourceType)
            {
                var viewModel = Mapper.Map(model, SourceType, DestType);
                filterContext.Controller.ViewData.Model = viewModel;
            }
        }
    }
}