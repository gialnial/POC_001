using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Feature.Doctor.Repositories
{
  using Sitecore.ContentSearch;
  using Sitecore.Data;
  using Sitecore.Foundation.Indexing.Models;
  using Sitecore.Foundation.Indexing.Repositories;

  public class DoctorsSearchSettingsRepository : SearchSettingsRepositoryBase
  {
    public override ISearchSettings Get()
    {
      var settings = new SearchSettingsBase();
      settings.Templates = new List<ID>
      {
        Templates.Doctor.IDPageType
      };

      return settings;
    }
  }
}