using Consola;
using Data;
using System.Data;

string archivoConfiguracion = Path.Combine(Environment.CurrentDirectory, ".Env");
var configuracion = new Configuracion();
var conf = configuracion.ObtenerConfiguracion(archivoConfiguracion);





var conexion = new Conexion(conf["servidor"], conf["BaseDatos"]);

var manejadorArchivo = new ManejadorArchivo();

var usuarios = conexion.ObtenerusuariosSinSincronizar();

foreach(DataRow usuario in usuarios.Tables[0].Rows)
{
    try
    {
        if(manejadorArchivo.GuardarEnCsv(usuario, conf["RutaArchivo"]))
        {
            conexion.ActualizarSincronizados(int.Parse(usuario["id"].ToString()));
        }
    }
    catch (Exception ex)
    {

        Console.WriteLine(ex.Message);
    }
    

}
Console.WriteLine("Fin Lectura");





