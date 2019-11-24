using AutoMapper;
using Contoso.Data;
using Contoso.Domain;
using Contoso.Repositories;
using LogicBuilder.Expressions.Utils.DataSource;
using System.Linq;

namespace Contoso.Web.Flow.Flow
{
    public static class CrudOperations<TModel, TData> where TModel : BaseModelClass where TData : BaseDataClass
    {
        public static TModel GetModel(Angular.Settings.FilterGroup filterGroup, ISchoolRepository repository, IMapper mapper)
        {
            FilterGroup fg = mapper.Map<FilterGroup>(filterGroup);
            return repository.GetItemsAsync<TModel, TData>(fg.GetFilterExpression<TModel>()).Result.SingleOrDefault();
        }
    }
}
