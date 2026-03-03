using ECommerce.Catalog.DTOs.CategoryDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Repositories.CategoryRepositories;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryRepository _categoryRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var values = await _categoryRepository.GetAllAsync();
            return Ok(values.Adapt<List<ResultCategoryDto>>());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            var value = await _categoryRepository.GetByIdAsync(id);
            if(value is null)
            {
                return BadRequest("Kategori Bulunamadı");
            }
            return Ok(value.Adapt<ResultCategoryDto>());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto createDto)
        {
            var value = createDto.Adapt<Category>();
            await _categoryRepository.CreateAsync(value);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDto updateDto)
        {
            var value = await _categoryRepository.GetByIdAsync(updateDto.Id);
            if (value is null)
            {
                return BadRequest("Kategori Bulunamadı");
            }
            value = updateDto.Adapt<Category>();
            await _categoryRepository.UpdateAsync(value);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var value = await _categoryRepository.GetByIdAsync(id);
            if (value is null)
            {
                return BadRequest("Kategori Bulunamadı");
            }
            await _categoryRepository.DeleteAsync(id);
            return Ok();
        }

    }
}
