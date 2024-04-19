

namespace Consola
{
    public class Configuracion
    {
        public static Dictionary<string, string> Conf = new Dictionary<string, string>();
        public Dictionary<string, string> ObtenerConfiguracion(string rutaArchivoConfiguracion)
        {
            try
            {
                if (string.IsNullOrEmpty(rutaArchivoConfiguracion)) throw new Exception("la ruta de configuraicon del archivo no puede ser nula");
                var confi = File.ReadAllLines(rutaArchivoConfiguracion);
                foreach (var linea in confi)
                {
                    var lineaCongif = linea.Split('=');
                    Conf.Add(lineaCongif[0], lineaCongif[1]);
                }
                return Conf;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"error al leer el archivo de configuracion, {ex.Message}");
                return null;
            }
        }
    }
}
