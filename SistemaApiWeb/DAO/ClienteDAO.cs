﻿using SistemaApiWeb.Entidades;
using Microsoft.Data.SqlClient;

namespace SistemaApiWeb.DAO
{
    public class ClienteDAO
    {
        private string cadena;
        //Constructor
        public ClienteDAO()
        {

            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("cn");
        }

        //GetCliente
        public IEnumerable<Cliente> GetClientes()
        {
            List<Cliente> clientesList = new List<Cliente>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("exec sp_listar_clientes", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    clientesList.Add(new Cliente()
                    {
                        idcliente = dr.GetInt32(0),
                        nombre = dr.GetString(1),
                        direccion = dr.GetString(2),
                        idpais = Int32.Parse(dr.GetString(3)),
                        telefono = dr.GetInt32(4),

                    });
                }

            }
            return clientesList;
        }

        //Agregar cliente
        public string Agregar(Cliente cliente) 
        {
            string  mensaje = "";

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("exec sp_insertar_cliente",
                        cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", cliente.nombre);
                    cmd.Parameters.AddWithValue("@direccion", cliente.direccion);
                    cmd.Parameters.AddWithValue("@idpais", cliente.idpais);
                    cmd.Parameters.AddWithValue("@telefono", cliente.telefono);
                   
                    cn.Open();
                    int c = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha agregado {c} cliente";
                }
                catch (Exception ex) { mensaje = ex.Message; }
            }
            return mensaje;
        }

        //Editar cliente
        public string Actualizar(Cliente cliente)
        {
            string mensaje = "";
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_editar_cliente", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idcliente", cliente.idcliente);
                    cmd.Parameters.AddWithValue("@nombre", cliente.nombre);
                    cmd.Parameters.AddWithValue("@direccion", cliente.direccion);
                    cmd.Parameters.AddWithValue("@idpais", cliente.idpais);
                    cmd.Parameters.AddWithValue("@telefono", cliente.telefono);

                    cn.Open();
                    int c = cmd.ExecuteNonQuery();
                    mensaje = $"Se ha actualizado {c} cliente";
                }
                catch (Exception ex) { mensaje = ex.Message; }
            }
            return mensaje;
        }
    }
}
