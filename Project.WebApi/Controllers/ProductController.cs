using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.Dtos;
using Project.Bll.Managers.Abstracts;
using Project.Bll.Managers.Concretes;
using Project.WebApi.Models.RequestModels.AppUsers;
using Project.WebApi.Models.RequestModels.Categories;
using Project.WebApi.Models.RequestModels.Orders;
using Project.WebApi.Models.RequestModels.Products;
using Project.WebApi.Models.ResponseModels.AppUsers;
using Project.WebApi.Models.ResponseModels.Categories;
using Project.WebApi.Models.ResponseModels.Orders;
using Project.WebApi.Models.ResponseModels.Products;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;
        private readonly IMapper _mapper;

        public ProductController(IProductManager productManager, IMapper mapper)
        {
            _productManager = productManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ProductsList()
        {
            List<ProductDto> values = await _productManager.GetAllAsync();
            List<ProductResponseModel> responseModel = _mapper.Map<List<ProductResponseModel>>(values);
            return Ok(responseModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            ProductDto value = await _productManager.GetByIdAsync(id);
            return Ok(_mapper.Map<ProductResponseModel>(value));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductRequestModel model)
        {
            ProductDto product = _mapper.Map<ProductDto>(model);
            await _productManager.CreateAsync(product);
            return Ok("Veri ekleme basarılıdır");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductRequestModel model)
        {
            ProductDto product = _mapper.Map<ProductDto>(model);
            await _productManager.UpdateAsync(product);
            return Ok("Veri güncelleme basarılıdır");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PacifyProduct(int id)
        {
            string mesaj = await _productManager.SoftDeleteAsync(id);
            return Ok(mesaj);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            string mesaj = await _productManager.HardDeleteAsync(id);
            return Ok(mesaj);
        }
    }
}
