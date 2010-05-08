namespace SampleMvc.Web.Controllers
{
    using SampleMvc.Web.Mappers;

    public interface IModelMapperController
    {
        IMapper ModelMapper { get; }
    }
}