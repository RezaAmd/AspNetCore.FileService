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
        void Upload(IFormFile file, string path, string fileName = null);
        /// <summary>
        /// Upload a specific file.
        /// </summary>
        /// <param name="file">The file you want to upload.</param>
        /// <param name="path">The path where you want the file to be saved.</param>
        /// <param name="fileName">File name with extension.</param>
        Task UploadAsync(IFormFile file, string path, string fileName = null, CancellationToken cancellationToken = default);
        /// <summary>
        /// Upload list of files in diffrent path.
        /// </summary>
        /// <param name="uploadFiles">List of upload parameter model object.</param>
        void Upload(List<UploadParameter> uploadFiles);

        /// <summary>
        /// Upload list of files in diffrent path.
        /// </summary>
        /// <param name="uploadFiles">List of upload parameter model object.</param>
        Task UploadAsync(List<UploadParameter> uploadFiles, CancellationToken cancellationToken = default);
    }
}