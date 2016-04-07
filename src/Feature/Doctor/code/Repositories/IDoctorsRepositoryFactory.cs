using Sitecore.Data.Items;

namespace Sitecore.Feature.Doctor.Repositories
{
  public interface IDoctorsRepositoryFactory
  {
    IDoctorsRepository Create(Item contextItem);
  }
}