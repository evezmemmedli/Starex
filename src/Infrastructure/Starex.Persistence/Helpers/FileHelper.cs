﻿using Microsoft.AspNetCore.Http;
public static class FileHelpers
{
    private const string _fileUrl = ApiRoutes.File.GetFileByName;
    public static async Task<string> FileCreate(this IFormFile file, string root, string folder)
    {
        string filename = $"{Guid.NewGuid()}.jpg";
        string path = Path.Combine(root, folder);
        string filePath = Path.Combine(path, filename);
        try
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }
        catch (Exception)
        {
            throw new FileLoadException();
        }
        return filename;
    }
    public static void FileDelete(string root, string folder, string image)
    {
        string filePath = Path.Combine(root, folder, image);

        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
    public static bool IsImageOkay(this IFormFile file, int mb)
    {
        return file.Length / 1024 / 1024 < mb && file.ContentType.Contains("image/");
    }
}

