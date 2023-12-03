using Microsoft.AspNetCore.Http;

namespace Dogs.Helpers
{
    public class FileUploadHelper
    {
        static public async Task<string> UploadAsync(IFormFile formFile)
        {
            if (formFile != null)
            {

                //Path.GetExtension(Image.FileName);
                //Console.WriteLine(Image.Length/1024);
                var filename = $"{Guid.NewGuid()}{Path.GetExtension(formFile.FileName)}";
                using var fs = new FileStream(@$"wwwroot/uploads/{filename}", FileMode.Create);
                await formFile.CopyToAsync(fs);
                return @$"/uploads/{filename}";

            }

            throw new Exception("File was not upload");
        }

    }
}
