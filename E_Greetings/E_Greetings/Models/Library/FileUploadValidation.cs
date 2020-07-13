using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Greetings.Models.Library
{
    public class FileUploadValidation
    {
        public string[] supportedTypes { get; set; }
        public string ErrorMessage { get; set; }
        public decimal filesize { get; set; }
        public string UploadUserFile(HttpPostedFileBase file)
        {
            try
            {
                var fileExt = System.IO.Path.GetExtension(file.FileName).Substring(1);
                if (!supportedTypes.Contains(fileExt))
                {
                    ErrorMessage = "File Extension Is InValid";
                    return ErrorMessage;
                }
                else if (file.ContentLength > (filesize*1024*1024))
                {
                    ErrorMessage = "File size Should Be UpTo " + filesize + "MB";
                    return ErrorMessage;
                }
                else
                {
                    return ErrorMessage = null;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = null;
                return ErrorMessage;
            }
        }
    }
}