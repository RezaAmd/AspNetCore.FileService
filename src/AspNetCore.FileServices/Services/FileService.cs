using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCore.FileServices
{
    internal class FileService : IFileService
    {
        #region Private methods
        private string GetFullPath(IFormFile file, string path, string fileName = null)
        {
            return Path.Combine(
                            path1: path,
                            path2: (fileName == null ?
                                    DateTime.Now.ToString("yyyy_MM_yy-HH_mm_ss_ffffff") :
                                    fileName) + Path.GetExtension(file.FileName));
        }

        private void _CopyToPath(IFormFile file, string path, string fileName)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                using (var stream = File.Create(GetFullPath(file, path, fileName)))
                {
                    file.CopyTo(stream);
                }
            }
        }

        private async Task _CopyToPathAsync(IFormFile file, string path, string fileName, CancellationToken cancellationToken = default)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                using (var stream = File.Create(GetFullPath(file, path, fileName)))
                {
                    await file.CopyToAsync(stream, cancellationToken);
                }
            }
        }
        #endregion

        #region Copy
        /// <summary>
        /// Upload a specific file.
        /// </summary>
        /// <param name="file">The file you want to upload.</param>
        /// <param name="path">The path where you want the file to be saved.</param>
        /// <param name="fileName">File name with extension.</param>
        public void CopyToPath(IFormFile file, string path, string fileName)
        {
            try
            {
                _CopyToPath(file, path, fileName);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Upload a specific file in custom path and custom name.
        /// </summary>
        /// <param name="file">The file you want to upload.</param>
        /// <param name="path">The path where you want the file to be saved.</param>
        /// <param name="fileName">File name with extension.</param>
        public async Task CopyToPathAsync(IFormFile file, string path, string fileName, CancellationToken cancellationToken = default)
        {
            try
            {
                await _CopyToPathAsync(file, path, fileName);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Upload list of files in diffrent path.
        /// </summary>
        /// <param name="uploadFiles">List of upload parameter model object.</param>
        public void CopyToPath(List<UploadParameter> uploadFiles)
        {
            try
            {
                foreach (var uploadFile in uploadFiles)
                {
                    _CopyToPath(uploadFile.File, uploadFile.Path, uploadFile.FileName);
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Upload list of files in diffrent path.
        /// </summary>
        /// <param name="uploadFiles">List of upload parameter model object.</param>
        public async Task CopyToPathAsync(List<UploadParameter> uploadFiles, CancellationToken cancellationToken = default)
        {
            try
            {
                foreach (var uploadFile in uploadFiles)
                {
                    await _CopyToPathAsync(uploadFile.File, uploadFile.Path, uploadFile.FileName);
                }
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete a specific file.
        /// </summary>
        /// <param name="path">File full path you want delete.</param>
        /// <returns>The command is run or not? true/false</returns>
        public bool DeleteFromFullPath(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    return true;
                }
            }
            catch
            {
                throw;
            }
            return false;
        }

        /// <summary>
        /// Delete a specific file.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task<bool> DeleteFromFullPathAsync(string path, CancellationToken cancellationToken = default)
        {
            try
            {
                if (File.Exists(path))
                {
                    await Task.Run(() => { File.Delete(path); }, cancellationToken);
                    return true;
                }
            }
            catch
            {
                throw;
            }
            return false;
        }
        #endregion
    }
    #region Models
    public class UploadParameter
    {
        #region Constructor
        /// <summary>
        /// Upload file parameter.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="path"></param>
        /// <param name="fileName"></param>
        public UploadParameter(IFormFile file, string path, string fileName = null)
        {
            File = file;
            Path = path;
            FileName = fileName;
        }
        #endregion

        /// <summary>
        /// The file you want to upload.
        /// </summary>
        public IFormFile File { get; set; }

        /// <summary>
        /// The path where you want the file to be saved.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// File name with extension.
        /// </summary>
        public string FileName { get; set; }
    }
    #endregion
}