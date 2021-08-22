using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace sistema_de_ventas.Controllers
{
    [RoutePrefix("api/Index")] // Prefijo para llamar al controlador
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class IndexController : ApiController
    {
        conexionSql.Conexion bd = new conexionSql.Conexion();
        // GET: api/Index
        [HttpGet]
        [Route("getProducts")]
        public IEnumerable<Models.Productos> getProducts()
        {
            var productos = bd.listarProductos();
            //return new string[] { "value1", "value2" };
            return productos;
        }
        // GET: api/Index
        [HttpGet]
        [Route("getCategory")] 
        public IEnumerable<Models.Categorias> getCategory()
        {
            var categorias = bd.listarCategorias();
            //return new string[] { "value1", "value2" };
            return categorias;
        }
        [HttpGet]
        [Route("getMarks/{id}")]
        public IEnumerable<Models.Marcas> getMarks(int id)
        {
            var marcas = bd.listarMarcasDependiente(id);
            //return new string[] { "value1", "value2" };
            return marcas;
        }
        // GET: api/Index/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Index
        [HttpPost]
        [Route("insertProduct")]
        public void Post([FromBody] Models.Productos pto)
        {
            bd.agregarProducto(pto.producto, pto.precios, pto.idCat, pto.idMarca, pto.stock);
        }

        // PUT: api/Index/5
        [HttpPut]
        public void Put(int id, [FromBody]Models.Productos value)
        {
            bd.actualizarProductos(value.producto, (int)value.precios, (int)value.id, (int)value.idCat, (int)value.idMarca, (int)value.stock);
        }

        // DELETE: api/Index/5
         
        public void Delete(int id)
        {
            bd.eliminarProducto(id);
        }
    }
}
