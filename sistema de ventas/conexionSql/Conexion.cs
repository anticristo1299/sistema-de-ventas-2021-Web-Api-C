using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace sistema_de_ventas.conexionSql
{
    public class Conexion
    {
        SqlConnection conexionBD = new SqlConnection("server=JOSE\\JOSE; database=sistema de ventas; integrated security = true;user=jose666;password=jose666");
        public List<Models.Productos> listarProductos()
        {
            string sql = "select c.id idCat,m.id idMarca, p.id,c.categoria,m.marca,p.producto,p.precios,p.stock from categorias c inner join productos p on p.idCat=c.id inner join marcas m on m.id=p.idmarcas";
            SqlCommand cmd = new SqlCommand(sql, conexionBD);

            var model = new List<Models.Productos>();

            conexionBD.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var productos = new Models.Productos();
                productos.producto = rdr["producto"].ToString();
                productos.precios = Convert.ToInt32(rdr["precios"]);
                productos.id = Convert.ToInt32(rdr["id"]);
                productos.categoria = rdr["categoria"].ToString();
                productos.marca = rdr["marca"].ToString();
                productos.idCat = Convert.ToInt32(rdr["idCat"]);
                productos.idMarca = Convert.ToInt32(rdr["idMarca"]);
                productos.stock = Convert.ToInt32(rdr["stock"]);
                model.Add(productos);
            }
            conexionBD.Close();

            return model;

        }
        public List<Models.Productos> agregarProducto(string producto, int precios, int idCat, int idMarcas, int stock)
        {
            string sql = "insert into productos values ('" + producto + "'," + precios + "," + idCat + "," + idMarcas + "," + stock + ")";
            SqlCommand cmd = new SqlCommand(sql, conexionBD);

            var model = new List<Models.Productos>();

            conexionBD.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var productos = new Models.Productos();
                productos.producto = rdr["producto"].ToString();
                productos.stock = Convert.ToInt32(rdr["stock"]);
                productos.precios = Convert.ToInt32(rdr["precios"]);
                productos.idCat = Convert.ToInt32(rdr["idCat"]);
                productos.idMarca = Convert.ToInt32(rdr["idmarcas"]);


                model.Add(productos);
            }
            conexionBD.Close();

            return model;
        }
       
        public void actualizarProductos(string producto, int precio, int id, int idCat, int idMarca, int stock)
        {
            string query = "update productos set producto='" + producto + "', precios=" + precio + ", idCat=" + idCat + ",idmarcas=" + idMarca + ",stock=" + stock + " where id=" + id + "";
            conexionBD.Open();
            SqlCommand comando = new SqlCommand(query, conexionBD);
            comando.ExecuteNonQuery();
            conexionBD.Close();

        }
        public List<Models.Categorias> listarCategorias()
        {
            string sql = "select *from categorias";
            SqlCommand cmd = new SqlCommand(sql, conexionBD);

            var model = new List<Models.Categorias>();

            conexionBD.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var categoria = new Models.Categorias();
                categoria.id = Convert.ToInt32(rdr["id"]);
                categoria.categorias = rdr["categoria"].ToString();
                model.Add(categoria);
            }
            conexionBD.Close();

            return model;
        }
        public List<Models.Marcas> listarMarcas()
        {
            string sql = "select *from marcas";
            SqlCommand cmd = new SqlCommand(sql, conexionBD);

            var model = new List<Models.Marcas>();

            conexionBD.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var marca = new Models.Marcas();
                marca.id = Convert.ToInt32(rdr["id"]);
                marca.marcas = rdr["marca"].ToString();
                model.Add(marca);
            }
            conexionBD.Close();

            return model;
        }
        public void eliminarProducto(int id)
        {
            string sql = " delete from productos where id='" + id + "'";
            conexionBD.Open();
            SqlCommand cmd = new SqlCommand(sql, conexionBD);

            cmd.ExecuteNonQuery();
            conexionBD.Close();
        }
        public List<Models.Marcas> listarMarcasDependiente(int id)
        {
            string sql = "select  m.id,m.marca from marcas m join categorias c join marcaycategoria myc on myc.idCat=c.id on myc.idMarca=m.id where c.id=" + id + "";
            SqlCommand cmd = new SqlCommand(sql, conexionBD);

            var model = new List<Models.Marcas>();

            conexionBD.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                var marcasDependiente = new Models.Marcas();
                marcasDependiente.id = Convert.ToInt32(rdr["id"]);
                marcasDependiente.marcas = rdr["marca"].ToString();

                model.Add(marcasDependiente);
            }
            conexionBD.Close();

            return model;
        }
    }
}
