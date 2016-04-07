using System;
using Sitecore.Data.Items;
using Sitecore.Foundation.Alerts;
using Sitecore.Foundation.Alerts.Exceptions;

namespace Sitecore.Feature.Doctor.Repositories
{
  public class DoctorsRepositoryFactory : IDoctorsRepositoryFactory
  {
    public IDoctorsRepository Create(Item contextItem)
    {
      try
      {
        return new DoctorsRepository(contextItem);
      }
      catch (ArgumentException ex)
      {
        throw new InvalidDataSourceItemException($"{AlertTexts.InvalidDataSource}", ex);
      }
    }
  }
}