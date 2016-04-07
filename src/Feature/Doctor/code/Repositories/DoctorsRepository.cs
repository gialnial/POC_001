namespace Sitecore.Feature.Doctor.Repositories
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using Sitecore.Data;
  using Sitecore.Data.Items;
  using Sitecore.Foundation.Indexing;
  using Sitecore.Foundation.Indexing.Repositories;
  using Sitecore.Foundation.SitecoreExtensions.Extensions;

    public class DoctorsRepository : IDoctorsRepository
    {
        public Item ContextItem { get; set; }

        private readonly ISearchServiceRepository searchServiceRepository;

        public DoctorsRepository(Item contextItem) : this(contextItem, new SearchServiceRepository(new DoctorsSearchSettingsRepository())) { }

        public DoctorsRepository(Item contextItem, ISearchServiceRepository searchServiceRepository)
        {
            if (contextItem == null)
            {
                throw new ArgumentNullException(nameof(contextItem));
            }
            this.ContextItem = contextItem;

            this.searchServiceRepository = searchServiceRepository;
        }

        public IEnumerable<Models.Doctor> Get()
        {
            var searchService = this.searchServiceRepository.Get();
            searchService.Settings.Root = this.ContextItem;
            var results = searchService.FindAll();
            return results.Results.Select(x => new Models.Doctor( x.Item));
        }

        public IEnumerable<Models.Doctor> searchByLetter(string letter)
        {
            var searchService = this.searchServiceRepository.Get();
            searchService.Settings.Root = this.ContextItem;
            //IQuery query = new Que
            var results = searchService.FindAll();
            return results.Results.Select(x => new Models.Doctor(x.Item));
        }
    }
}