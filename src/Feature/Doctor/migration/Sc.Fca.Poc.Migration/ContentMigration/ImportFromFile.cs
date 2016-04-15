using Sc.Fca.Poc.Migration.Helpers;
using Sitecore.Data.Items;
using Sitecore.SecurityModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Feature.Doctor.Models;
using Sitecore.Feature.Doctor;
using Sitecore.Data;
using Sitecore.Resources.Media;

namespace Sc.Fca.Poc.Migration.ContentMigration
{
    class ImportFromFile
    {
        public string StartImport(string filePath)
        {
            string[] allLines = File.ReadAllLines(filePath);
            
            int increment = 1;
            
            foreach (string line in allLines.Skip(1)) //as line one just has all the 
            {
                createItem(line, increment);
                increment++;
            }

            return increment.ToString();
        }

        private void createItem(string data, int increment)
        {
            string[] dataArray = data.Split(';');

            Item parentItem = ScConstants.SitecoreDatabases.MasterDb.GetItem(Templates.DoctorList.ID); //Set the parent item

            using (new SecurityDisabler())
            {
                string itemName = dataArray[0]; //or set appropriate item name
                Item addedItem = parentItem.Add(itemName, new TemplateID(Templates.Doctor.IDPageType));
                addedItem.Editing.BeginEdit();
                addedItem[Templates.Person.Fields.Name] = dataArray[1];
                addedItem[Templates.Person.Fields.Title] = dataArray[2];

                Sitecore.Data.Items.MediaItem image = ScConstants.SitecoreDatabases.MasterDb.GetItem("/sitecore/media library/Cemedi/FotoMedici/" + (dataArray[4].Split('.'))[0]);
                if (image != null)
                {
                    Sitecore.Data.Fields.ImageField imagefield = addedItem.Fields[Templates.Person.Fields.Picture];
                    imagefield.Alt = image.Alt;
                    imagefield.MediaID = image.ID;
                   
                }
                addedItem[Templates.Person.Fields.Summary] = dataArray[5];
                addedItem[Templates.Person.Fields.Surname] = dataArray[0];
                 addedItem[Templates.Doctor.Fields.Specialist] = dataArray[3];
                 addedItem[Templates.Doctor.Fields.Activities] = dataArray[6];
                 addedItem[Templates.Doctor.Fields.Hospital] = dataArray[7];

                addedItem.Editing.EndEdit();
            }
        }
    }
}
