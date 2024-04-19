using Microsoft.Data.SqlClient;
using System.Data;

namespace Data
{
    public class Conexion
    {
        private  String cadena; 
        public Conexion(string servidor, string bd) 
        {
            cadena = $"Server={servidor};Database={bd};Integrated Security=True; TrustServerCertificate=True";
        }
       

        

        public DataSet ObtenerusuariosSinSincronizar()
        {
            //con el using lo uqe este dentro del bloque se cierra automaticamente
            DataSet dt = new DataSet();

            using SqlConnection conn = new SqlConnection(cadena);
            var query = "ConsultarUsuariosNoSincronizados";


            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                var adaptador = new SqlDataAdapter(cmd);
                adaptador.Fill(dt);
                return dt;

            }
            catch (Exception ex)
            {
                throw new Exception($"se ha generado un error al conectar o ejecutar la consulta, {ex.Message}");

            }


        }

        public bool ActualizarSincronizados(int idUsuario)
        {
            using SqlConnection conn = new SqlConnection(cadena);
            var query = "GuardarUsuarioSincronizado";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UsuarioId", idUsuario);

            try
            { 
                conn.Open();
                var resultado =cmd.ExecuteNonQuery();
                if(resultado > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw new Exception($"se ha generado un error al guardar sincronizado, {ex.Message}");
            }
        }

    }
}
