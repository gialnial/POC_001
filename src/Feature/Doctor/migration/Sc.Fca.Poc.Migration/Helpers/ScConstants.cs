using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sc.Fca.Poc.Migration.Helpers
{
    class ScConstants
    {
        public struct SitecoreDatabases
        {
            public static readonly Database MasterDb = Database.GetDatabase("master");
            public static readonly Database WebDb = Database.GetDatabase("web");
            public static readonly Database ContextDb = Sitecore.Context.Database;
        }

        //public struct SitecoreIDs
        //{
        //    public static readonly string ParentItemId = "REPLACE WITH ITEM ID";
        //}
        //public struct SitecoreTemplates
        //{
        //    //public static readonly TemplateID TemplateName = new TemplateID(new ID("Id of the template"));
        //    public static readonly TemplateID ContentTemplateId = new TemplateID(new ID("REPLACE WITH TEMPLATE ID"));

        //}
    }
}
