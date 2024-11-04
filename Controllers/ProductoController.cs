using AutoMapper;
using LabSoft.Data;
using LabSoft.Data.Negocio.Servicios;
using LabSoft.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LabSoft.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;
        private readonly IMapper _mapper;

        public ProductoController(IProductoService productoService, IMapper mapper){
            _productoService = productoService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<ProductoResponseDTO>> Get(){
            try {
                var productos = _productoService.GetProductos();
                var productosResponse = _mapper.Map<List<Producto>, List<ProductoResponseDTO>>(productos);
                return Ok(productosResponse);

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //return BadRequest(ex.Message);
                return StatusCode(500, 
                    new {
                            mensaje = "Ocurrio un error interno en el servidor", 
                            detalles = ex.Message
                        }
                );
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Producto> Get(string id){
            try
            {
                var producto = _productoService.GetProductoById(id);

                if(producto == null)
                {
                    return NotFound();
                }
                return Ok(producto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //return BadRequest(ex.Message);
                return StatusCode(500, 
                    new {
                            mensaje = "Ocurrio un error interno en el servidor", 
                            detalles = ex.Message
                        }
                );
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProductoRequestDTO producto) 
        {
            try
            {
                if(producto == null){
                    return  BadRequest("El producto no puede ser nulo");
                }

                var productoMapeado = _mapper.Map<ProductoRequestDTO, Producto>(producto);

                _productoService.AddProducto(productoMapeado);
                return CreatedAtAction(nameof(Get), new {id = productoMapeado.Id}, producto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //return BadRequest(ex.Message);
                return StatusCode(500, 
                    new {
                            mensaje = "Ocurrio un error interno en el servidor", 
                            detalles = ex.Message
                        }
                );
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Producto producto)
        {
            if(producto == null || producto.Id != id) {
                return BadRequest();
            }

            var productoExistente = _productoService.GetProductoById(id);

            if(productoExistente == null){
                return NotFound();
            }

            _productoService.UpdateProducto(producto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id){
            var producto = _productoService.GetProductoById(id);

            if(producto == null){
                return NotFound();
            }

            _productoService.DeleteProducto(id);
            return NoContent();
        }
    }
}