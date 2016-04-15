namespace Sitecore.Feature.Doctor.Indexing
{
  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;
  using Sitecore.ContentSearch.SearchTypes;
  using Sitecore.Data;
  using Sitecore.Foundation.Indexing.Infrastructure;
  using Sitecore.Foundation.Indexing.Models;
  using Sitecore.Foundation.SitecoreExtensions.Repositories;

  public class DoctorIndexContentProvider : IndexContentProviderBase
  {
    public override string ContentType => DictionaryRepository.Get("/doctor/search/contenttype", "doctor");

    public override IEnumerable<ID> SupportedTemplates => new[]
    {
      Templates.Doctor.IDPageType
    };

    public override Expression<Func<SearchResultItem, bool>> GetQueryPredicate(IQuery query)
    {
      var fieldNames = new[]
      {
        Templates.Person.Fields.Name_FieldName, Templates.Person.Fields.Surname_FieldName, Templates.Person.Fields.Summary_FieldName
      };
      return this.GetFreeTextPredicate(fieldNames, query);
    }

        public override void FormatResult(SearchResultItem item, ISearchResult formattedResult)
        {
            var contentItem = item.GetItem();
        }
    }
}