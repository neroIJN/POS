using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client11.Models;

namespace Client11.Services
{
    public interface IMultipleFileUploadServices
    {
        Task<int> AddImage(MultipleFileUploadModel multipleFileUploadModel);
        Task<List<MultipleFileUploadModel>> GetAllImages();
        Task DeleteImage(string fileId);

    }
}
