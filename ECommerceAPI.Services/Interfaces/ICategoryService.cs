using ECommerceAPI.Dto.Request;
using ECommercerAPI.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDtoCollectionResponse> ListAsync(string filter, int page, int rows);

        Task<BaseResponse<CategoryDto>> GetAsync(string id);

        Task<BaseResponse<string>> CreateAsync(CategoryRequest request);

        Task<BaseResponse<string>> UpdateAsync(string id, CategoryRequest request);

        Task<BaseResponse<string>> DeleteAsync(string id);
    }
}
