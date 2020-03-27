T4 Image is library compress images on the .net platform.
T4 Image use core SkiaSharp.
- Upgrade image compression algorithm compared to older versions. For more optimal compression results.
- Support image compression with the quality selected in the range (from-to), instead of fixing a value like the old version.
- Support compression level (Quality, Balance and Storage):
   + Quality: High file size, quality and speed
   + Balance: Normal file size, quality and speed
   + Storage: Low file size, quality and speed

### T4Image.IInput: T4Image.IInput readImg = new T4Image.Input(fileImage)
- Input image with: Url, Uri, File, String Base64, Bytes.
- Details: 
   + Url: readImg.Url()
   + Uri format data:[media type][;base64],data (EX: data:image/jpeg;base64,iVBORw0KGgoAAAANSUhEUgAAAAUA): readImg.Url()
   + File: readImg.File()
   + String Base64: readImg.Base64()
   + Bytes: readImg.Bytes(byte[] bytesInput)
   + ImageFile: Type Image after read
   + StreamFile: Type Stream after read
   + FileName: File name after read
   + FileExtension: File extension after read (default png)

### T4Image.IOutput (Option): T4Image.IOutput writeImg = new T4Image.Output(T4Image.Output.LevelOptimal.Storage, (100), "/_t4", "", "")
- Output image with: Quality, Level Optimal, FolderExport, FileName, FileExtension
- Details:
   + Level Optimal: Priority level optimal (Quality, Balance, Storage).
   + Quality: (int, int) => (From, To). Default (25, 80).
   + FolderExport: Default (string.Empty) get folder import.
   + FileName: Rename file export. Default (string.Empty) is get default 
   + FileExtension: Change extension. Default (string.Empty) is get default

### T4Image.IResize (Option): new T4Image.Resize(readImg.ImageFile, 800, 900, T4Image.Resize.Priority.Auto);
- Resize image with: Image, Width, Height, Priority
- Details:
   + Image: Type Image from T4Image.IInput
   + Width: Resize Width
   + Height: Resize Height
   + Priority:
      ++ None: Not priority, set width, height width resize.
      ++ Auto: Auto Width or Height priority (size image width > height => Width, else Height)
      ++ Width: Lock Width, change Height
      ++ Height: Lock Height, change Width

### T4Image.Optimizer: T4Image.Optimizer op = new T4Image.Optimizer(readImg, writeImg, resizeImg)
- Process compress image with ExportMemoryStream, ExportFile or ExportImage
- Details:
   + IInput: T4Image.IInput
   + IOutput: T4Image.IOutput
   + IResize (Option): T4Image.IResize
   + ExportStream: Export result type Stream
   + ExportImage: Export result type Image
   + ExportFile: Export result file with folder from T4Image.IOutput