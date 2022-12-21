using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVC.BL.Helper
{
    public static class FileUploader
    {
        public static string UploadeFile(string FolderName ,IFormFile fileUrl)  {
            try
            {
                // 1 ) Get Directory

                string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/" , FolderName)   ;


                //2) Get File Name

                string FileName = Guid.NewGuid() + Path.GetFileName(fileUrl.FileName);


                // 3) Merge Path with File Name

                string FinalPath = Path.Combine(FolderPath, FileName);


                //4) Save File As Streams "Data Overtime"

                using (var Stream = new FileStream(FinalPath, FileMode.Create))

                {

                    fileUrl.CopyTo(Stream);

                }
                return FileName;    
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
        public static string RemoveFile(string FolderName, string FileName)
        {
            try
            {
                string directory = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/Files" ,FolderName, FileName);
                if (File.Exists(directory))
                {
                    File.Delete(directory);
                }

                return "file deleted";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}
