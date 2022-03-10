using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCore.FileServices
{
    public interface IFileService
    {
        /// <summary>
        /// Upload a specific file.
        /// </summary>
        /// <param name="file">The file you want to upload.</param>
        /// <param name="path">The path where you want the file to be saved.</param>
        /// <param name="fileName">File name with extension.</param>
        void CopyToPath(IFormFile file, string path, string fileName = null);
        /// <summary>
        /// Upload a specific file.
        /// </summary>
        /// <param name="file">The file you want to upload.</param>
        /// <param name="path">The path where you want the file to be saved.</param>
        /// <param name="fileName">File name with extension.</param>
        Task CopyToPathAsync(IFormFile file, string path, string fileName = null, CancellationToken cancellationToken = default);
        /// <summary>
        /// Upload list of files in diffrent path.
        /// </summary>
        /// <param name="uploadFiles">List of upload parameter model object.</param>
        void CopyToPath(List<UploadParameter> uploadFiles);

        /// <summary>
        /// Upload list of files in diffrent path.
        /// </summary>
        /// <param name="uploadFiles">List of upload parameter model object.</param>
        Task CopyToPathAsync(List<UploadParameter> uploadFiles, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete a specific file.
        /// </summary>
        /// <param name="path">File full path you want delete.</param>
        /// <returns>The command is run or not? true/false</returns>
        bool DeleteFromFullPath(string path);

        /// <summary>
        /// Delete a specific file.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        Task<bool> DeleteFromFullPathAsync(string path);
    }
}