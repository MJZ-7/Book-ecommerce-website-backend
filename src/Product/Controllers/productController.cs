using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
    public class ProductController : ControllerTemplate
    {

        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ProductReadDto>> FindAll
        ([FromQuery(Name = "searchBy")] string? searchBy, [FromQuery(Name = "limit")] int limit, [FromQuery(Name = "offset")] int offset)
        {
            return Ok(_productService.FindAll(searchBy, limit, offset));
        }
        [HttpGet("{productId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProductReadDto?> FindOne(Guid productId)
        {

            var foundProduct = _productService.FindOne(productId);
            if (foundProduct is not null)
            {
                return CreatedAtAction(nameof(FindOne), foundProduct);
            }
            return BadRequest();
        }
        [HttpGet("search")]
        //This action method gives user the capability to search by keywords.
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<ProductReadDto>> Search(string keyword)
        {
            List<ProductReadDto> foundProduct = _productService.Search(keyword);
            if (foundProduct.Count == 0)
                return NotFound();

            return Ok(foundProduct);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<ProductReadDto> CreateOne([FromBody] ProductCreateDto product)
        {
            if (product is not null)
            {
                var createdProduct = _productService.CreateOne(product);
                return CreatedAtAction(nameof(CreateOne), createdProduct);
            }
            return BadRequest();
        }

        [HttpPatch("{productId}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ProductReadDto> UpdateOne(Guid productId, [FromBody] ProductUpdateDto updatedProduct)
        {
            ProductReadDto product = _productService.UpdateOne(productId, updatedProduct);
            return Accepted(product);
        }



        [HttpDelete("{productId}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public ActionResult DeleteOne(Guid productId)
        {

            return Accepted(_productService.DeleteOne(productId));

        }
    }
}
