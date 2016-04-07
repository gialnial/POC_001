namespace Sitecore.Feature.Doctor
{
  using Sitecore.Data;

    public struct Templates
    {
        public struct DoctorList
        {
            public static readonly ID ID = new ID("{31F5AD8E-EBA3-4376-868D-6BB3C51E4DB0}");

        }
    public struct Doctor
        {
            public static readonly ID ID = new ID("{42C2F85B-DEB8-4E7A-A7C7-2282F3979FD5}");
            public static readonly ID IDPageType = new ID("{A3E5EEEA-C2DF-40B8-B228-738C60194C6D}");
            
       
        public struct Fields
            {
                public static readonly ID Biography = new ID("{62620B2F-C2FB-40C7-A2E9-D2CB6E2DD908}");
                public static readonly ID Specialist = new ID("{8BF213FD-9EA2-4E8C-B191-A6678E3C3478}");
                public static readonly ID Activities = new ID("{41252090-9448-4BE1-A45B-782ED1427E70}");
                public static readonly ID Hospital = new ID("{3CADBB1A-E9C9-4EEA-B9ED-3C2E0B25DDBB}");

                public static string Biography_FieldName = "Biography";
                public static string Specialist_FieldName = "Specialist";
                public static string Activities_FieldName = "Activities";
                public static string Hospital_FieldName = "Hospital";
            }
        }
        public struct Person
        {
            public static readonly ID ID = new ID("{ECE23A9F-26E0-42E4-8201-5F51EE5C26DD}");

            public struct Fields
            {
                public static readonly ID Name = new ID("{8B3B608F-7585-4C4D-A1B3-5FB21A7FC5DA}");
                public static readonly ID Title = new ID("{FD3FD49A-C19E-4D20-BB53-F7C452ED5388}");
                public static readonly ID Picture = new ID("{9C9DA77E-D4C9-4E99-A5CF-B3C2A71C3A05}");
                public static readonly ID Summary = new ID("{0CFD2522-74AD-478C-818B-C3B339837B56}");
                public static readonly ID Surname = new ID("{E2AC4158-1DB0-47CA-96AD-C62515552BC3}");
                public static string Title_FieldName = "Title";
                public static string Summary_FieldName = "Summary";
                public static string Name_FieldName = "Name";
                public static string Surname_FieldName = "Surname";
            }
        }

    }
  }
