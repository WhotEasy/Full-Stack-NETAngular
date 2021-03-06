
using AutoMapper;
using ECommerceAPI.DataAcces.Repositories;
using ECommerceAPI.Entities;
using ECommerceAPI.Services.Interfaces;
using ECommercerAPI.Dto.Request;
using ECommercerAPI.Dto.Response;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<ProductService> _logger;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository,
            ILogger<ProductService> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<BaseResponse<string>> CreateAsync(ProductDtoRequest request)
        {
            var response = new BaseResponse<string>();

            try
            {

                var product = _mapper.Map<Product>(request);

                response.result = await _repository.CreateAsync(product);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.result = null;
                response.ErrorMessage = ex.Message;
                _logger.LogCritical(ex.Message);
            }

            return response;
        }

        public async Task<BaseResponse<string>> DeleteAsync(string id)
        {
            var response = new BaseResponse<string>();

            try
            {
                await _repository.DeleteAsync(id);
                response.result = id;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.result = null;
                response.ErrorMessage = ex.Message;
                _logger.LogCritical(ex.Message);
            }

            return response;
        }

        public async Task<BaseResponse<ProductSingleDto>> GetAsync(string id)
        {
            var response = new BaseResponse<ProductSingleDto>();

            try
            {
                var product = await _repository.GetItemAsync(id);

                if (product == null)
                {
                    response.Success = false;
                    return response;
                }

                response.result = _mapper.Map<ProductSingleDto>(product);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.result = null;
                response.ErrorMessage = ex.Message;
                _logger.LogCritical(ex.Message);
            }


            return response;
        }

        public async Task<ProductDtoCollectionResponse> ListAsync(string filter, int page, int rows)
        {
            var response = new ProductDtoCollectionResponse();

            try
            {
                var tupla = await _repository
                    .GetCollectionAsync(filter ?? string.Empty, page, rows);

                response.Collection = tupla.collection
                    .Select(p => _mapper.Map<ProductDto>(p))
                    .ToList();

                var totalPages = tupla.total / rows;
                if (tupla.total % rows > 0)
                    totalPages++;

                response.TotalPages = totalPages;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
                _logger.LogCritical(ex.Message);
            }

            return response;
        }

        public async Task<BaseResponse<string>> UpdateAsync(string id, ProductDtoRequest request)
        {
            var response = new BaseResponse<string>();

            try
            {
                var product = _mapper.Map<Product>(request);
                product.Id = id;

                if (!string.IsNullOrEmpty(request.FileName))

                await _repository.UpdateAsync(product);

                response.Success = true;
                response.result = id;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.result = null;
                response.ErrorMessage = ex.Message;
                _logger.LogCritical(ex.Message);
            }

            return response;
        }
    }
}
