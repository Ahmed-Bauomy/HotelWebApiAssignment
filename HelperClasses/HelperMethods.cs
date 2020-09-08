using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace HotelWebApi.HelperClasses
{
    public static class HelperMethods
    {
        public static string SaveFile(HttpPostedFileBase file, string folderPath)
        {
            if (file != null)
            {
                string[] splitedImageName = file.FileName.Split('.');
                string imageName = Guid.NewGuid() + "." + splitedImageName[splitedImageName.Length - 1];
                file.SaveAs(HostingEnvironment.MapPath(folderPath) + imageName);
                return imageName;
            }
            return "";
        }
    }
}