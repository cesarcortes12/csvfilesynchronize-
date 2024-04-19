using System.Data;

namespace Data
{
    public class ManejadorArchivo
    {
        public bool GuardarEnCsv(DataRow row, string rutaArchivo)
        {
            if (String.IsNullOrEmpty(rutaArchivo)) { throw new Exception("la ruta no puede ser vacia"); }
            try
            {
                var cadena = $"{row["id"]},{row["nombre"]},{row["apellido"]},{row["email"]},{row["genero"]},{row["usuario"]},{row["activo"]}";

                var directorio = Path.GetDirectoryName(rutaArchivo);
                    if(!Directory.Exists(directorio))
                        {
                            Directory.CreateDirectory(directorio);
                        }

                    using (StreamWriter writer = new StreamWriter(rutaArchivo, true))
                    {
                    writer.WriteLine(cadena);
                    writer.Close();
                    return true;   
                    }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"se ha generado un error al guardar el archivo csv [{rutaArchivo}]:{ex.Message}");
                return false;
            }
        }

    }
}
