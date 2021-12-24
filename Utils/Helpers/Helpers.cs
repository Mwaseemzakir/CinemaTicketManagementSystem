using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace CinemaTicketManagementSystem.Utils.Helpers
{
    public static class Helpers
    {
        public static string AddFile(string fileName)
        {
            

            string imagesFolderPath = "Files/Images";

            //If Folder does not exists then create it
            if (!File.Exists(imagesFolderPath))
            {
                Directory.CreateDirectory(imagesFolderPath);
            }

            // To avoid files name replication I have used GUID
            string imageUrl = Guid.NewGuid().ToString() + Path.GetExtension(fileName);

            //Below two lines are responsible to copy image in our images folder
            byte[] imageBytes = Convert.FromBase64String(fileName);
            File.WriteAllBytes(imagesFolderPath, imageBytes);
            return imageUrl;



        }

        public static void RemoveFile(string fileName)
        {

        }


    }
}
