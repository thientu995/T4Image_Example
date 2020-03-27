using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace T4Image_ASPNETMVC_v1._1._0.Controllers
{
    public class ImageController : Controller
    {
        const int quality = 100, widthMax = 800, heightMax = 900;
        string pathFile, fileName, contentType;

        [Route("Images/{*url}")]
        public ActionResult Index(string url)
        {
            pathFile = Server.MapPath(HttpContext.Request.Path);
            fileName = url;
            contentType = MimeMapping.GetMimeMapping(pathFile);
            string cacheImage = Create();
            if (!string.IsNullOrWhiteSpace(cacheImage))//Not create file
            {
                pathFile = cacheImage;
            }
            if (string.IsNullOrWhiteSpace(pathFile))
            {
                return HttpNotFound();
            }
            if (System.IO.File.Exists(pathFile))
            {
                return File(pathFile, contentType);
            }
            return HttpNotFound();
        }

        private string Create()
        {
            if (!System.IO.File.Exists(pathFile))
            {
                return string.Empty;
            }
            string fileCacheImage = GetFolderCache();
            T4Image.IInput readImg = new T4Image.Input(pathFile);
            readImg.File();

            T4Image.IOutput writeImg = new T4Image.Output(T4Image.Output.LevelOptimal.Storage, quality, fileCacheImage, "", "");

            T4Image.IResize resizeImg = new T4Image.Resize(readImg.ImageFile, widthMax, heightMax, T4Image.Resize.Priority.Auto);
            new T4Image.Optimizer(readImg, writeImg, resizeImg).ExportFile();
            return GetFileCache();
        }

        private string GetFileCache()
        {
            string file = Path.Combine(GetFolderCache(), fileName);
            if (System.IO.File.Exists(file))
            {
                return file.Replace(Path.Combine(Directory.GetCurrentDirectory(), "cache"), string.Empty);
            }
            else
            {
                return string.Empty;
            }
        }

        private string GetFolderCache()
        {
            return Path.Combine(GetFolder(), "cache");
        }

        private string GetFolder()
        {
            return pathFile.Replace(fileName, string.Empty);
        }
    }
}