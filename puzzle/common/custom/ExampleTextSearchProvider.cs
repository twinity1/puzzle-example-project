using System.Linq.Expressions;
using Core.Data.Entities;
using Modules.Abstraction.TextSearch;
using Microsoft.EntityFrameworkCore;

namespace Core.Admin.UseCases.Examples;

public class ExampleTextSearchProvider : LikeTextSearchProviderBase<Example>
{
    public override IEnumerable<Expression<Func<Example, bool>>> GetLikeExpressions(string likeExp)
    {
        yield return x => EF.Functions.ILike(EF.Functions.Unaccent(x.Name), EF.Functions.Unaccent(likeExp));
        yield return x => x.Address != null && EF.Functions.ILike(EF.Functions.Unaccent(x.Address), EF.Functions.Unaccent(likeExp));
        yield return x => x.ContactName != null && EF.Functions.ILike(EF.Functions.Unaccent(x.ContactName), EF.Functions.Unaccent(likeExp));
        yield return x => x.ContactEmail != null && EF.Functions.ILike(EF.Functions.Unaccent(x.ContactEmail), EF.Functions.Unaccent(likeExp));
        yield return x => x.ContactPhone != null && EF.Functions.ILike(EF.Functions.Unaccent(x.ContactPhone), EF.Functions.Unaccent(likeExp));
    }
}
