using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using Sitecore.Mvc.Presentation;

namespace Sitecore.Feature.Doctor.Models
{
     public class Doctor 
    {
        public Doctor()
        {

        }
        public Doctor(Data.Items.Item item)
        {
            Name = item[Templates.Person.Fields.Name];
            Title = item[Templates.Person.Fields.Title];
            Picture = item[Templates.Person.Fields.Picture];
            Summary = item[Templates.Person.Fields.Summary];
            Surname = item[Templates.Person.Fields.Surname];
            Specialist = item[Templates.Doctor.Fields.Specialist];
            Activities = item[Templates.Doctor.Fields.Activities]; 
            Hospital = item[Templates.Doctor.Fields.Hospital];
            ItemURL = item.GetUrl();
    }

        public string Name { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }
        public string Summary { get; set; }
        public string Surname { get; set; }
        public string Specialist { get; set; }
        public string Activities { get; set; }
        public string Hospital { get; set; }
        public string ItemURL { get; set; }
    }
}