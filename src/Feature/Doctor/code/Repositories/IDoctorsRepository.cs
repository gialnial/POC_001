namespace Sitecore.Feature.Doctor.Repositories
{
  using System.Collections.Generic;
  using Sitecore.Data.Items;

  public interface IDoctorsRepository
  {
    IEnumerable<Models.Doctor> Get();
    IEnumerable<Models.Doctor> searchByLetter(string letter);
  }
}