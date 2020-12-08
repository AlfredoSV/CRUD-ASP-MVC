using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UsuariosMVC.Models
{
    public class AccesoUsuario
    {
        private SqlConnection conec = null;
        private void conectar()
        {
            conec = new SqlConnection(ConfigurationManager.ConnectionStrings["conecStr"].ConnectionString);
            conec.Open();

        }

        public string validarUsu(string Usu_Name, string Usu_Pass)
        {
            var bandera = "";
            conectar();
            using (conec)
            {
                SqlCommand comando = new SqlCommand("Select * from Usuario WHERE Usu_Name = @Usu_Name and Usu_Pass = @Usu_Pass;",conec);
                comando.Parameters.AddWithValue("@Usu_Name", Usu_Name);
                comando.Parameters.AddWithValue("@Usu_Pass", Usu_Pass);
                SqlDataReader sdr = comando.ExecuteReader();
                bandera= (sdr.HasRows) ? "1" : "0";
            }

            return bandera;

        }
    }
}