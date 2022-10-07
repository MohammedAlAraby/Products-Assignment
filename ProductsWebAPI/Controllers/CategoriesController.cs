using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductsWebAPI.Models;
using ProductsWebAPI.Services;

namespace ProductsWebAPI.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly IProductLibraryRepository _productLibraryRepository;
        private readonly IMapper _mapper;

        public CategoriesController(IProductLibraryRepository productLibraryRepository,
            IMapper mapper)
        {
            _productLibraryRepository = productLibraryRepository ?? 
                throw new ArgumentNullException(nameof(productLibraryRepository));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> GetCategories()
        {
            APIResponse response = new APIResponse();
            var categoriesFromRepo = _productLibraryRepository.GetCategories();
            response.Success = true;
            response.Results = _mapper.Map<IEnumerable<CategoryDto>>(categoriesFromRepo);
            return Ok(response);
        }        
    }
}