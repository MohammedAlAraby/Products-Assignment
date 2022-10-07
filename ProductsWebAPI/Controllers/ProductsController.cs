using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProductsWebAPI.DbContexts;
using ProductsWebAPI.Entities;
using ProductsWebAPI.Models;
using ProductsWebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsWebAPI.Controllers
{
    [ApiController]
    [Route("api/Products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductLibraryRepository _productLibraryRepository;
        private readonly IMapper _mapper;

        public ProductsController(IProductLibraryRepository productLibraryRepository,
            IMapper mapper)
        {
            _productLibraryRepository = productLibraryRepository ??
                throw new ArgumentNullException(nameof(productLibraryRepository));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetProducts([FromQuery(Name = "categoryID")] Guid categoryID)
        {
            APIResponse response = new APIResponse();
            IEnumerable<Product> productsFromRepo;

            if (categoryID == Guid.Empty)
            {                
                productsFromRepo = _productLibraryRepository.GetProducts();                
            }
            else
            {
                productsFromRepo = _productLibraryRepository.GetProductsByCategory(categoryID);                
            }

            response.Success = true;
            response.Results = _mapper.Map<IEnumerable<ProductDto>>(productsFromRepo);
            return Ok(response);
        }

        [HttpGet("{productId}", Name = "GetProduct")]
        public ActionResult<ProductDto> GetProduct(Guid productId)
        {
            APIResponse response = new APIResponse();
            var productFromRepo = _productLibraryRepository.GetProduct(productId);

            if (productFromRepo == null)
                return NotFound();

            response.Success = true;
            response.Results = _mapper.Map<ProductDto>(productFromRepo);
            return Ok(response);
        }        

        [HttpPost]
        public ActionResult<ProductDto> CreateProduct(ProductForManipulationDto product)
        {
            APIResponse response = new APIResponse();

            if (!ModelState.IsValid)
            {                
                response.Messages = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToArray<string>();                
                return BadRequest(response);
            }                

            var productToAdd = _mapper.Map<Product>(product);
            _productLibraryRepository.AddProduct(productToAdd);
            _productLibraryRepository.Save();

            var productToReturn = _mapper.Map<ProductDto>(productToAdd);
            response.Success = true;
            response.Results = productToReturn;

            return CreatedAtRoute("GetProduct",
                new { productId = productToReturn.ID },
                response);
        }

        [HttpPut("{productId}")]
        public ActionResult UpdateProduct(Guid productId, ProductForManipulationDto product)
        {
            APIResponse response = new APIResponse();            

            var productFromRepo = _productLibraryRepository.GetProduct(productId);

            if (productFromRepo == null)
                return NotFound();

            if (!ModelState.IsValid)
            {
                response.Messages = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToArray<string>();
                return BadRequest(response);
            }

            var productToUpdate = _mapper.Map<Product>(product);            
            _productLibraryRepository.UpdateProduct(productToUpdate);
            _productLibraryRepository.Save();

            return NoContent();
        }
    }
}
