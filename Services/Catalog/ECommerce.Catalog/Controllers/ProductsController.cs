using ECommerce.Catalog.DTOs.ProductDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Repositories.ProductRepositories;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductRepository _productRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _productRepository.GetAllAsync();
            return Ok(values.Adapt<List<ResultProductDto>>());

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _productRepository.GetByIdAsync(id);
            if(value is null)
            {
                return BadRequest("Product not found");
            }
            return Ok(value.Adapt<ResultProductDto>());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto createDto)
        {
            var value = createDto.Adapt<Product>();
            await _productRepository.CreateAsync(value);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDto updateDto)
        {
            var value = await _productRepository.GetByIdAsync(updateDto.Id);

            if(value is null)
            {
                return BadRequest("Product not found");
            }

            value=updateDto.Adapt<Product>();
            await _productRepository.UpdateAsync(value);
            return NoContent();
            
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var value = await _productRepository.GetByIdAsync(id);

            if (value is null)
            {
                return BadRequest("Product not found");
            }
            await _productRepository.DeleteAsync(value.Id);
            return Ok();
        }

    }
}
