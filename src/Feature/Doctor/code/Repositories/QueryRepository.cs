namespace Sitecore.Feature.Doctor.Repositories
{
    using Sitecore.Feature.Doctor.Models;
    using Sitecore.Foundation.Indexing.Models;

    public class QueryRepository
    {
        public static IQuery Get(string query)
        {
            return new Query
            {
                QueryText = query,
                IndexOfFirstResult = 0,
                NoOfResults = 0
            };
        }
    }

    public class Query : IQuery
    {
        public string QueryText { get; set; }
        public int IndexOfFirstResult { get; set; }
        public int NoOfResults { get; set; }
    }
}