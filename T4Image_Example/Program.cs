using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace T4Image_Example
{
    class Program
    {
        static readonly string folderCurrent = AppDomain.CurrentDomain.BaseDirectory;// Folder images orign
        static readonly string folderExport = Path.Combine(folderCurrent, "__export__");// Folder images result
        static readonly string fileName = "";//get default file name orign
        static readonly string fileExtension = "";//get default file name orign
        static readonly string searchPattern = "*.png|*.jpg";//get extension file image
        static readonly int quality = 80;//default
        static readonly int width = 800;//default
        static readonly int height = 900;//default

        static void Main(string[] args)
        {
            ConcurrentBag<InfoFile> lstFileExported = new ConcurrentBag<InfoFile>();
            string folderFile = string.Empty;
            Console.WriteLine("Start...");
            Console.WriteLine("Find list image in folder:\n{0}", folderCurrent);

            while (true)
            {
                ConcurrentBag<InfoFile> lstFile = new ConcurrentBag<InfoFile>();
                string[] lstFiles = searchPattern.Split('|')
                    .SelectMany(filter => Directory.GetFiles(folderCurrent, filter, SearchOption.AllDirectories))
                    .Where(x => x.IndexOf(folderExport) != 0)
                    .ToArray();
                Task[] tasks = new Task[lstFiles.Length];
                int index = 0;
                foreach (string item in lstFiles)
                {
                    tasks[index] = Task.Factory.StartNew(() =>
                    {
                        InfoFile getFileInfo = lstFileExported.FirstOrDefault(x => x.PathFile.Equals(item, StringComparison.OrdinalIgnoreCase));
                        if (getFileInfo == null)
                        {
                            getFileInfo = new InfoFile()
                            {
                                PathFile = item,
                                DateTimeModify = File.GetLastWriteTime(item),
                            };
                            lstFileExported.Add(getFileInfo);
                            lstFile.Add(getFileInfo);
                        }
                        else
                        {
                            lstFile.Add(getFileInfo);
                            if (getFileInfo.DateTimeModify == File.GetLastWriteTime(item))
                            {
                                return;
                            }
                            else
                            {
                                getFileInfo.DateTimeModify = File.GetLastWriteTime(item);
                            }
                        }
                        try
                        {
                            folderFile = item.Substring(0, item.LastIndexOf(Path.GetFileName(item))).Replace(folderCurrent, string.Empty);// set folder export

                            //Setting input
                            T4Image.IInput readImg = new T4Image.Input(item);
                            readImg.File();// read file

                            //Setting output
                            T4Image.IOutput writeImg = new T4Image.Output(quality, GetFolderExport(folderFile), fileName, fileExtension);

                            //Resize
                            T4Image.IResize resizeImg = new T4Image.Resize(readImg.ImageFile, width, height, T4Image.Resize.Priority.Auto);

                            //Process
                            T4Image.Optimizer op = new T4Image.Optimizer(readImg, writeImg, resizeImg);
                            op.ExportFile();//export file
                            Console.WriteLine("Succes:\n{0}\n\n", item);
                        }
                        catch (Exception ex)
                        {
                        }
                        finally
                        {
                        }
                    });
                    index++;
                }
                Task.WaitAll(tasks);
                lstFileExported.Intersect(lstFile);
                Thread.Sleep(1000);
            }
            Console.WriteLine("\n\nSuccess!");
        }

        static string GetFolderExport(string pathFile)
        {
            return Path.Combine(folderExport, pathFile);
        }
    }

    class InfoFile
    {
        public string PathFile { get; set; }
        public DateTime DateTimeModify { get; set; }
    }
}
