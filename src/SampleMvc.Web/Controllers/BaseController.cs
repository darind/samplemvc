namespace SampleMvc.Web.Controllers
{
    using System.Web.Mvc;
    using SampleMvc.Web.Mappers;

    public abstract class BaseController<TRepository> : Controller, IModelMapperController
    {
        protected BaseController(TRepository repository, IMapper mapper)
        {
            Repository = repository;
            ModelMapper = mapper;
        }

        public TRepository Repository { get; private set; }
        public IMapper ModelMapper { get; private set; }
    }
}