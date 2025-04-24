using System;
using System.Text.RegularExpressions;


///
///GRUPO: 
/// Sebastian Silva - 31843360
/// Rafael Zubiillaga - 31027844
/// Joseph Adan - 31181474
///

namespace GestionClientes
{
    /// <summary>
    /// Clase principal que representa un cliente en el sistema de gestión
    /// </summary>
    public class Cliente
    {
        // Campos privados para encapsular la información
        private readonly string _nombre;
        private string _correo;
        private string _telefono;

        /// <summary>
        /// Constructor para crear instancias de Cliente
        /// </summary>
        /// <param name="nombre">Nombre completo del cliente</param>
        /// <param name="correo">Dirección de correo electrónico</param>
        /// <param name="telefono">Número de teléfono</param>
        /// <exception cref="ArgumentException">Se lanza cuando los datos proporcionados no son válidos</exception>
        public Cliente(string nombre, string correo, string telefono)
        {
            _nombre = ValidarNombre(nombre);
            _correo = ValidarCorreo(correo);
            _telefono = ValidarTelefono(telefono);
        }

        // Propiedades públicas para acceso controlado
        public string Nombre => _nombre;

        public string Correo 
        { 
            get => _correo;
            private set => _correo = ValidarCorreo(value);
        }

        public string Telefono 
        { 
            get => _telefono;
            private set => _telefono = ValidarTelefono(value);
        }

        /// <summary>
        /// Muestra la información del cliente en formato legible
        /// </summary>
        public void MostrarInformacion()
        {
            Console.WriteLine("Información del Cliente:");
            Console.WriteLine($"- Nombre: {Nombre}");
            Console.WriteLine($"- Correo: {Correo}");
            Console.WriteLine($"- Teléfono: {Telefono}\n");
        }

        /// <summary>
        /// Actualiza la dirección de correo electrónico del cliente
        /// </summary>
        /// <param name="nuevoCorreo">Nueva dirección de correo electrónico</param>
        /// <exception cref="ArgumentException">Se lanza cuando el correo no es válido</exception>
        public void ActualizarCorreo(string nuevoCorreo)
        {
            Correo = nuevoCorreo;
            Console.WriteLine($"Correo actualizado: {Correo}");
        }

        /// <summary>
        /// Actualiza el número de teléfono del cliente
        /// </summary>
        /// <param name="nuevoTelefono">Nuevo número de teléfono</param>
        /// <exception cref="ArgumentException">Se lanza cuando el teléfono no es válido</exception>
        public void ActualizarTelefono(string nuevoTelefono)
        {
            Telefono = nuevoTelefono;
            Console.WriteLine($"Teléfono actualizado: {Telefono}");
        }

        #region Métodos de validación
        private string ValidarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede estar vacío o contener solo espacios en blanco");
            
            if (nombre.Length < 3)
                throw new ArgumentException("El nombre debe tener al menos 3 caracteres");

            return nombre.Trim();
        }

        private string ValidarCorreo(string correo)
        {
            if (string.IsNullOrWhiteSpace(correo))
                throw new ArgumentException("El correo no puede estar vacío");

            string patronCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(correo, patronCorreo))
                throw new ArgumentException("El formato del correo electrónico no es válido");

            return correo.Trim();
        }

        private string ValidarTelefono(string telefono)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                throw new ArgumentException("El teléfono no puede estar vacío");

            // Eliminar espacios y caracteres especiales
            string telefonoLimpio = Regex.Replace(telefono, @"[^\d+]", "");
            
            if (telefonoLimpio.Length < 8)
                throw new ArgumentException("El teléfono debe tener al menos 8 dígitos");

            return telefono.Trim();
        }
        #endregion
    }

    class Programa
    {
        // Easter Egg: SSDev - Desarrollado por Sebastian Silva
        // Si escribes "sebastian" en cualquier momento, ¡descubrirás algo especial!
        private static bool _easterEggActivado = false;

        static void Main(string[] args)
        {
            try
            {
                // Ejemplo de uso del sistema
                Cliente cliente1 = new Cliente(
                    "Ana García López",
                    "ana.garcia@example.com",
                    "+34 600 123 456"
                );

                bool continuar = true;
                while (continuar)
                {
                    Console.Clear();
                    Console.WriteLine("=== Sistema de Gestión de Clientes ===");
                    Console.WriteLine("\nInformación actual del cliente:");
                    cliente1.MostrarInformacion();

                    Console.WriteLine("\nOpciones disponibles:");
                    Console.WriteLine("1. Actualizar correo electrónico");
                    Console.WriteLine("2. Actualizar teléfono");
                    Console.WriteLine("3. Ver información actual");
                    Console.WriteLine("4. Salir");
                    Console.Write("\nSeleccione una opción (1-4): ");

                    string opcion = Console.ReadLine();

                    // Verificar si se activó el easter egg
                    if (opcion.ToLower() == "sebastian")
                    {
                        ActivarEasterEgg();
                        continue;
                    }

                    switch (opcion)
                    {
                        case "1":
                            ActualizarCorreoInteractivo(cliente1);
                            break;
                        case "2":
                            ActualizarTelefonoInteractivo(cliente1);
                            break;
                        case "3":
                            Console.WriteLine("\nPresione cualquier tecla para continuar...");
                            Console.ReadKey();
                            break;
                        case "4":
                            continuar = false;
                            Console.WriteLine("\nGracias por usar el sistema. ¡Hasta pronto!");
                            break;
                        default:
                            Console.WriteLine("\nOpción no válida. Presione cualquier tecla para continuar...");
                            Console.ReadKey();
                            break;
                    }
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error de validación: {ex.Message}");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        private static void ActivarEasterEgg()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║  ¡Felicidades! Has encontrado la firma de Sebastian!       ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║  💻  Desarrollado por Sebastian Silva  💻                  ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║  \"Cada línea de código es una oportunidad para             ║");
            Console.WriteLine("║    crear algo extraordinario\"                              ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            
            _easterEggActivado = true;
            
            // Efecto especial de "código"
            Console.WriteLine("\nCompilando pasión...");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("💻 ");
                System.Threading.Thread.Sleep(500);
            }
            
            Console.WriteLine("\n\n¡Código ejecutado con éxito! 🚀");
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void ActualizarCorreoInteractivo(Cliente cliente)
        {
            Console.Clear();
            Console.WriteLine("=== Actualización de Correo Electrónico ===");
            Console.WriteLine($"\nCorreo actual: {cliente.Correo}");
            Console.Write("\nIngrese el nuevo correo electrónico (o presione Enter para cancelar): ");
            
            string nuevoCorreo = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(nuevoCorreo))
            {
                Console.WriteLine("\nOperación cancelada.");
            }
            else
            {
                try
                {
                    Console.WriteLine($"\n¿Desea cambiar el correo de '{cliente.Correo}' a '{nuevoCorreo}'?");
                    Console.Write("Ingrese 'S' para confirmar o cualquier otra tecla para cancelar: ");
                    
                    if (Console.ReadLine().ToUpper() == "S")
                    {
                        cliente.ActualizarCorreo(nuevoCorreo);
                        Console.WriteLine("\nCorreo actualizado exitosamente!");
                    }
                    else
                    {
                        Console.WriteLine("\nOperación cancelada.");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"\nError: {ex.Message}");
                }
            }
            
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void ActualizarTelefonoInteractivo(Cliente cliente)
        {
            Console.Clear();
            Console.WriteLine("=== Actualización de Teléfono ===");
            Console.WriteLine($"\nTeléfono actual: {cliente.Telefono}");
            Console.Write("\nIngrese el nuevo número de teléfono (o presione Enter para cancelar): ");
            
            string nuevoTelefono = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(nuevoTelefono))
            {
                Console.WriteLine("\nOperación cancelada.");
            }
            else
            {
                try
                {
                    Console.WriteLine($"\n¿Desea cambiar el teléfono de '{cliente.Telefono}' a '{nuevoTelefono}'?");
                    Console.Write("Ingrese 'S' para confirmar o cualquier otra tecla para cancelar: ");
                    
                    if (Console.ReadLine().ToUpper() == "S")
                    {
                        cliente.ActualizarTelefono(nuevoTelefono);
                        Console.WriteLine("\nTeléfono actualizado exitosamente!");
                    }
                    else
                    {
                        Console.WriteLine("\nOperación cancelada.");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"\nError: {ex.Message}");
                }
            }
            
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}