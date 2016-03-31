namespace Sitecore.Feature.Doctor.Indexing
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;
    using Sitecore.Foundation.Indexing.Infrastructure;
    using Sitecore.Foundation.Indexing.Models;
    using Sitecore.Foundation.SitecoreExtensions.Repositories;
    using Sitecore.ContentSearch.SearchTypes;
    using Sitecore.Data;
    using Sitecore.Web.UI.WebControls;
    using Doctor;
    public class DoctorIndexContentProvider : IndexContentProviderBase
  {
    public override string ContentType => DictionaryRepository.Get("/doctors/search/contenttype", "Doctor");

    public override IEnumerable<ID> SupportedTemplates => new[]
    {
      Templates.Person.ID
    };

    public override Expression<Func<SearchResultItem, bool>> GetQueryPredicate(IQuery query)
    {
      var fieldNames = new[]
      {
        Templates.Person.Fields.Title_FieldName, Templates.Person.Fields.Summary_FieldName, Templates.Person.Fields.Name_FieldName, Templates.Doctor.Fields.Biography_FieldName
      };
      return this.GetFreeTextPredicate(fieldNames, query);
    }

    public override void FormatResult(SearchResultItem item, ISearchResult formattedResult)
    {
      var contentItem = item.GetItem();
      formattedResult.Title = FieldRenderer.Render(contentItem, Templates.Person.Fields.Name.ToString());
      formattedResult.Description = FieldRenderer.Render(contentItem, Templates.Person.Fields.Summary.ToString());
    }
  }
}