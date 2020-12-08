using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UsuariosMVC.Models
{
    public class MantenimientoAlumno
    {
        private SqlConnection conec = null;
        private void conectar()
        {
            conec = new SqlConnection(ConfigurationManager.ConnectionStrings["conecStr"].ConnectionString);
            conec.Open();

        }


        public List<Alumno> Listar()
        {
            List<Alumno> alumnos = new List<Alumno>();
            conectar();
            using (conec)
            {
                SqlCommand comando = new SqlCommand("Select * from Alumno;", conec);
                SqlDataReader sdr = comando.ExecuteReader();

                if (sdr.HasRows)
                {

                    while (sdr.Read())
                    {
                        alumnos.Add(new Alumno()
                        {
                            Nombre = sdr.GetString(1),
                            ApellidoP = sdr.GetString(2),
                            ApellidoM = sdr.GetString(3),
                            Carrera = (sdr.IsDBNull(9) ? "N/D" : sdr.GetString(9)),
                            Email = (sdr.IsDBNull(8) ? "N/D" : sdr.GetString(8)),
                            Id_Alumno = sdr.GetInt32(0)
                        });

                    }

                }



            }
            return alumnos;
        }


        public string altaAlumno(Alumno alumno)
        {
            string strEstatus = string.Empty;
            try
            {
                conectar();
                using (conec)
                {

                    SqlCommand comando = new SqlCommand("Insert into Alumno VALUES(@nombre,@apellidoP,@apellidoM,@edad,@num1,@num2,@num3"
                        + ",@correo,@carrera,@campus,@prome,@hermanos);", conec);
                    comando.Parameters.AddWithValue("@nombre", alumno.Nombre);
                    comando.Parameters.AddWithValue("@apellidoP", alumno.ApellidoP);
                    comando.Parameters.AddWithValue("@apellidoM", alumno.ApellidoM);
                    comando.Parameters.AddWithValue("@edad", alumno.Edad);
                    comando.Parameters.AddWithValue("@num1", alumno.Num1);
                    comando.Parameters.AddWithValue("@num2", alumno.Num2);
                    comando.Parameters.AddWithValue("@num3", alumno.Num3);
                    comando.Parameters.AddWithValue("@correo", alumno.Email);
                    comando.Parameters.AddWithValue("@carrera", alumno.Carrera);
                    comando.Parameters.AddWithValue("@campus", alumno.Campus);
                    comando.Parameters.AddWithValue("@prome", alumno.PromedioMedioSup);
                    comando.Parameters.AddWithValue("@hermanos", alumno.HermanosInstitu);

                    strEstatus = comando.ExecuteNonQuery().ToString();

                }
            }
            catch (SqlException e)
            {
                strEstatus = "0";
            }


            return strEstatus;
        }

        public void EliminarAlumno(int id_Alumno)
        {
            conectar();

            using (conec)
            {
                SqlCommand comando = new SqlCommand("Delete from Alumno Where Id_Alumno = @Id_Alumno;", conec);
                comando.Parameters.AddWithValue("@Id_Alumno", id_Alumno);
                comando.ExecuteNonQuery();
            }
        }



        public Alumno DetalleAlumno(int id)
        {
            Alumno alumno = null;
            try
            {
                conectar();
                using (conec)
                {
                    SqlCommand comando = new SqlCommand("Select top 1 * from Alumno WHERE Id_Alumno = @Id_Alumno;", conec);
                    comando.Parameters.AddWithValue("@Id_Alumno", id);
                    SqlDataReader sdr = comando.ExecuteReader();

                    if (sdr.HasRows)
                    {

                        while (sdr.Read())
                        {
                            alumno = new Alumno() { Nombre = sdr.GetString(1), ApellidoP = 
                                sdr.GetString(2), ApellidoM = sdr.GetString(3),
                                 Edad=sdr.GetInt32(4),Num1 = sdr.GetString(5),
                            Num2 = sdr.GetString(6),Num3 = sdr.GetString(7),
                            Email = sdr.GetString(8),Carrera  = sdr.GetString(9),
                            Campus = sdr.GetString(10),PromedioMedioSup = sdr.GetDecimal(11),
                            HermanosInstitu = sdr.GetString(12)};

                        }

                    }



                }
            }
            catch (SqlException e)
            {
                alumno = null;
            }

            return alumno;
        }




    }
}