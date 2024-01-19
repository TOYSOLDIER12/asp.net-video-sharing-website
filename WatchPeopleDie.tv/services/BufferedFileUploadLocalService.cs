public interface IBufferedFileUploadService
{ 
    Task<string> UploadFile(IFormFile file);
}

public class BufferedFileUploadLocalService : IBufferedFileUploadService
{
    public async Task<string> UploadFile(IFormFile file)
    {
        try
        {
            if (file.Length > 0)
            {
                string relativePath = "wwwroot/video/" + file.FileName;

                string fullpath = Path.Combine(Environment.CurrentDirectory, relativePath);
                using (var fileStream = new FileStream(fullpath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                return relativePath = "video/" + file.FileName; //the file path? 
            }
            else
            {
                return null; // Return null if no file is uploaded
            }
        }
        catch (Exception ex)
        {
            throw new Exception("File Copy Failed", ex);
        }
    }
}
public class BufferedFileUploadLocalServiceProfile : IBufferedFileUploadService
{
    public async Task<string> UploadFile(IFormFile file)
    {
        try
        {
            if (file.Length > 0)
            {
                string relativePath = "wwwroot/profiles/" + file.FileName;

                string fullpath = Path.Combine(Environment.CurrentDirectory, relativePath);
                using (var fileStream = new FileStream(fullpath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                return relativePath = "profiles/" + file.FileName; //the file path
            }
            else
            {
                return null; // Return null if no file is uploaded
            }
        }
        catch (Exception ex)
        {
            throw new Exception("File Copy Failed", ex);
        }
    }
}