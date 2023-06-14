// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Collections.Generic;

namespace SistemaNomina
{
    class Program
    {
        static List<Empleado> empleados = new List<Empleado>();

        static void Main(string[] args)
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("===== MENÚ PRINCIPAL =====");
                Console.WriteLine("1. Ingresar empleado");
                Console.WriteLine("2. Ver empleados");
                Console.WriteLine("3. Eliminar empleado");
                Console.WriteLine("4. Ver nómina de empleados");
                Console.WriteLine("5. Reporte de empleados mujeres");
                Console.WriteLine("6. Reporte de empleados con licencia");
                Console.WriteLine("7. Reporte de empleados con sueldo superior a $50,000");
                Console.WriteLine("8. Salir");

                Console.Write("Seleccione una opción: ");
                int opcion = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (opcion)
                {
                    case 1:
                        IngresarEmpleado();
                        break;
                    case 2:
                        VerEmpleados();
                        break;
                    case 3:
                        EliminarEmpleado();
                        break;
                    case 4:
                        VerNomina();
                        break;
                    case 5:
                        ReporteMujeres();
                        break;
                    case 6:
                        ReporteLicencia();
                        break;
                    case 7:
                        ReporteSueldoSuperior();
                        break;
                    case 8:
                        salir = true;
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void IngresarEmpleado()
        {
            Console.WriteLine("===== INGRESAR EMPLEADO =====");

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Apellido: ");
            string apellido = Console.ReadLine();

            Console.Write("Edad: ");
            int edad = int.Parse(Console.ReadLine());

            Console.Write("Sexo (M/F): ");
            char sexo = char.Parse(Console.ReadLine());

            Console.Write("Fecha de Nacimiento (dd/mm/yyyy): ");
            DateTime fechaNacimiento = DateTime.Parse(Console.ReadLine());

            Console.Write("Posee Licencia (S/N): ");
            bool poseeLicencia = Console.ReadLine().ToUpper() == "S";

            Console.Write("Sueldo Bruto: ");
            decimal sueldoBruto = decimal.Parse(Console.ReadLine());

            Empleado empleado = new Empleado(nombre, apellido, edad, sexo, fechaNacimiento, poseeLicencia, sueldoBruto);
            empleados.Add(empleado);

            Console.WriteLine("Empleado ingresado correctamente.");
        }

        static void VerEmpleados()
        {
            Console.WriteLine("===== VER EMPLEADOS =====");
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
            }
            else
            {
                foreach (Empleado empleado in empleados)
                {
                    Console.WriteLine(empleado.ToString());
                }
            }
        }

        static void EliminarEmpleado()
        {
            Console.WriteLine("===== ELIMINAR EMPLEADO =====");
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
            }
            else
            {
                Console.Write("Ingrese el índice del empleado a eliminar: ");
                int indice = int.Parse(Console.ReadLine());

                if (indice >= 0 && indice < empleados.Count)
                {
                    empleados.RemoveAt(indice);
                    Console.WriteLine("Empleado eliminado correctamente.");
                }
                else
                {
                    Console.WriteLine("Índice inválido.");
                }
            }
        }

        static void VerNomina()
        {
            Console.WriteLine("===== VER NÓMINA DE EMPLEADOS =====");
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados.");
            }
            else
            {
                foreach (Empleado empleado in empleados)
                {
                    Console.WriteLine($"Nombre: {empleado.Nombre} {empleado.Apellido}");
                    Console.WriteLine($"Sueldo Bruto: {empleado.SueldoBruto}");
                    Console.WriteLine($"Sueldo Neto: {CalcularSueldoNeto(empleado.SueldoBruto)}");
                    Console.WriteLine($"TSS: {CalcularTSS(empleado.SueldoBruto)}");
                    Console.WriteLine($"Impuesto sobre la Renta: {CalcularImpuestoRenta(empleado.SueldoBruto)}");
                    Console.WriteLine();
                }
            }
        }

        static void ReporteMujeres()
        {
            Console.WriteLine("===== REPORTE DE EMPLEADOS MUJERES =====");
            List<Empleado> empleadosMujeres = empleados.FindAll(empleado => empleado.Sexo == 'F');
            if (empleadosMujeres.Count == 0)
            {
                Console.WriteLine("No hay empleados mujeres registradas.");
            }
            else
            {
                foreach (Empleado empleado in empleadosMujeres)
                {
                    Console.WriteLine(empleado.ToString());
                }
            }
        }

        static void ReporteLicencia()
        {
            Console.WriteLine("===== REPORTE DE EMPLEADOS CON LICENCIA =====");
            List<Empleado> empleadosConLicencia = empleados.FindAll(empleado => empleado.PoseeLicencia);
            if (empleadosConLicencia.Count == 0)
            {
                Console.WriteLine("No hay empleados con licencia registrados.");
            }
            else
            {
                foreach (Empleado empleado in empleadosConLicencia)
                {
                    Console.WriteLine(empleado.ToString());
                }
            }
        }

        static void ReporteSueldoSuperior()
        {
            Console.WriteLine("===== REPORTE DE EMPLEADOS CON SUELDO SUPERIOR A $50,000 =====");
            List<Empleado> empleadosSueldoSuperior = empleados.FindAll(empleado => empleado.SueldoBruto > 50000);
            if (empleadosSueldoSuperior.Count == 0)
            {
                Console.WriteLine("No hay empleados con sueldo superior a $50,000 registrados.");
            }
            else
            {
                foreach (Empleado empleado in empleadosSueldoSuperior)
                {
                    Console.WriteLine(empleado.ToString());
                }
            }
        }

        static decimal CalcularSueldoNeto(decimal sueldoBruto)
        {
            // Lógica para calcular el sueldo neto
            return sueldoBruto - (sueldoBruto * 0.10m); // Ejemplo: Aplicamos un descuento del 10%
        }

        static decimal CalcularTSS(decimal sueldoBruto)
        {
            // Lógica para calcular el TSS
            return sueldoBruto * 0.15m; // Ejemplo: 15% del sueldo bruto
        }

        static decimal CalcularImpuestoRenta(decimal sueldoBruto)
        {
            // Lógica para calcular el impuesto sobre la renta
            return sueldoBruto * 0.18m; // Ejemplo: 18% del sueldo bruto
        }
    }

    class Empleado
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public char Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool PoseeLicencia { get; set; }
        public decimal SueldoBruto { get; set; }

        public Empleado(string nombre, string apellido, int edad, char sexo, DateTime fechaNacimiento, bool poseeLicencia, decimal sueldoBruto)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Sexo = sexo;
            FechaNacimiento = fechaNacimiento;
            PoseeLicencia = poseeLicencia;
            SueldoBruto = sueldoBruto;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre} {Apellido}\n" +
                   $"Edad: {Edad}\n" +
                   $"Sexo: {Sexo}\n" +
                   $"Fecha de Nacimiento: {FechaNacimiento}\n" +
                   $"Posee Licencia: {PoseeLicencia}\n" +
                   $"Sueldo Bruto: {SueldoBruto}\n";
        }
    }
}
