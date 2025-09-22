namespace Ejercicio_Integrador_DOO
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Instancia[] InstanciasVirtuales = new Instancia[4];

            InstanciasVirtuales[0] = new ProcesoDeDatos("ETL_Clientes", "1.0", "Linux", "SQL Server", "PostgreSQL");
            InstanciasVirtuales[1] = new ProcesoDeDatos("ETL_Ventas", "1.0", "Linux", "MySQL", "MongoDB");

            InstanciasVirtuales[2] = new Aplicacion("App_Clientes", "2.1", "Windows", "C#", "10.0", "SQL Server");
            InstanciasVirtuales[3] = new Aplicacion("App_Ventas", "3.0", "Windows", "Java", "17", "MySQL");

            foreach (var instancia in InstanciasVirtuales)
            {
                instancia.LevantarInstancia();
            }

            foreach (var instancia in InstanciasVirtuales)
            {
                instancia.DetenerInstancia();
            }
        }

        public abstract class Instancia
        {
            public string Nombre;
            public string Version;
            public string SistemaOperativo;
            public bool Estado;

            public Instancia() { }
            public Instancia(string nombre, string version, string sistemaOperativo)
            {
                Nombre = nombre;
                Version = version;
                SistemaOperativo = sistemaOperativo;
                Estado = false;
            }

            public virtual void LevantarInstancia()
            {
                Estado = true;
                Console.WriteLine($"[{Nombre}] Instancia iniciada.");
            }
            public virtual void DetenerInstancia()
            {
                Estado = false;
                Console.WriteLine($"[{Nombre}] Instancia detenida.");
            }
        }

        public class ProcesoDeDatos : Instancia
        {
            public string DatosDeOrigen;
            public string DatosDeDestino;

            public ProcesoDeDatos() : base() { }
            public ProcesoDeDatos(string nombre, string version, string sistemaOperativo,
                                   string datosDeOrigen, string datosDeDestino)
                : base(nombre, version, sistemaOperativo)
            {
                DatosDeOrigen = datosDeOrigen;
                DatosDeDestino = datosDeDestino;
            }

            public override void LevantarInstancia()
            {
                if (!string.IsNullOrEmpty(DatosDeOrigen) && !string.IsNullOrEmpty(DatosDeDestino))
                {
                    Estado = true;
                    Console.WriteLine($"[Proceso] {Nombre} levantada correctamente.\n" +
                                      $"Acceso correcto a datos de origen: {DatosDeOrigen}\n" +
                                      $"Acceso correcto a datos de destino: {DatosDeDestino}");
                }
                else
                {
                    Console.WriteLine($"[Proceso] {Nombre} no pudo levantarse. Faltan datos de origen o destino.");
                }
            }
        }

        public class Aplicacion : Instancia
        {
            public string LenguajeDeProgramacion;
            public string VersionDelLenguaje;
            public string BaseDeDatos;

            public Aplicacion() : base() { }

            public Aplicacion(string nombre, string version, string sistemaOperativo,
                              string lenguajeDeProgramacion, string versionDelLenguaje, string baseDeDatos)
                : base(nombre, version, sistemaOperativo)
            {
                LenguajeDeProgramacion = lenguajeDeProgramacion;
                VersionDelLenguaje = versionDelLenguaje;
                BaseDeDatos = baseDeDatos;
            }

            public override void LevantarInstancia()
            {
                if (!string.IsNullOrEmpty(LenguajeDeProgramacion) &&
                    !string.IsNullOrEmpty(VersionDelLenguaje) &&
                    !string.IsNullOrEmpty(BaseDeDatos))
                {
                    Estado = true;
                    Console.WriteLine($"[Aplicación] {Nombre} levantada correctamente.\n" +
                                      $"Lenguaje instalado: {LenguajeDeProgramacion}\n" +
                                      $"Versión: {VersionDelLenguaje}\n" +
                                      $"Acceso a la base de datos: {BaseDeDatos}");
                }
                else
                {
                    Console.WriteLine($"[Aplicación] {Nombre} no pudo levantarse. Faltan datos.");
                }
            }
        }
    }
}
