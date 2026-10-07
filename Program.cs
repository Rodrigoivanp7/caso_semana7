namespace caso_semana7
{
    internal class Program
    {
        static int max = 100;
        static string[] nombres = new string[max];
        static double[] notas = new double[max];
        static int contador = 0;
        static public void Titulo()
        {
            Console.WriteLine("********");
            Console.WriteLine("Sistemas de notas");
            Console.WriteLine("********");
        }
        static public void Registrar_estudiante()
        {
            Console.WriteLine("Registro de estudiante nuevo: ");
            if (contador >= max)
            {
                Console.WriteLine("LLegamos a la capacidad máxima");
                return;
            }
            Console.WriteLine("Ingresar nombres: ");
            string nombre = Console.ReadLine();
            double nota;
            while (true)
            {
                Console.Write("Ingresar nota: ");
                nota = double.Parse(Console.ReadLine());
                if (nota >= 0 && nota <= 20)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error: La nota debe ser [0 - 20]: ");
                }
            }
            nombres[contador] = nombre;
            notas[contador] = nota;
            contador++;
        }
        static public void mostrar()
        {
            Console.WriteLine("***Listado de estudiantes***");
            if (contador == 0)
            {
                Console.WriteLine("No hay datos por mostrar");
                return;
            }
            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine($"(i + 1).- {nombres[i]} - Nota: {notas[i]}");
            }
        }

        static public void buscar_estudiante()
        {
            Console.WriteLine("***BUSCAR ESTUDIANTE***");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados");
                return;
            }
            Console.WriteLine("Ingresar nombre a buscar: ");
            string nombre_buscado = Console.ReadLine().ToLower();
            bool encontrado = false;
            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].Equals(nombre_buscado, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Estudiante encontrado: {nombres[i]} - Nota: {notas[i]}");
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("Estudiante no encontrado");
            }
        }

        static public void modificar_est()
        {
            Console.WriteLine("**MODIFICAR ESTUDIANTE**");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados");
                return;
            }
            Console.WriteLine("Ingresar nombre de estudiante: ");
            string nombre = Console.ReadLine();
            bool encontrado = false;
            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].Equals(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Estudiante encontrado: {nombres[i]} - Nota: {notas[i]}");
                    double nuevaNota;
                    while (true)
                    {
                        Console.WriteLine("Ingresar nueva nota: ");
                        nuevaNota = double.Parse(Console.ReadLine());
                        if (nuevaNota >= 0 && nuevaNota <= 20)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Error: La nota debe ser [0 - 20]");
                        }
                    }
                    notas[i] = nuevaNota;
                    Console.WriteLine($"Nota modificada: {nombres[i]} - Nueva Nota: {notas[i]}");
                    encontrado = true;
                    break;
                }
                if (!encontrado)
                {
                    Console.WriteLine("Estudiante no encontrado");
                }
            }
        }

            static public void burbuja()
            {
                for (int i = 0; i < contador - 1; i++)
                {
                    for (int j = 0; j < contador; j++)
                    {
                        if (notas[j] < notas[j + 1])
                        {
                            // Intercambiar notas
                            double tempNota = notas[j];
                            notas[j] = notas[j + 1];
                            notas[j + 1] = tempNota;
                            // Intercambiar nombres correspondientes
                            string tempNombre = nombres[j];
                            nombres[j] = nombres[j + 1];
                            nombres[j + 1] = tempNombre;
                        }
                    }
                }
            }

            static public void seleccion_des()
            {
                for (int i = 0; i < contador - 1; i++)
                {
                    int maxIndex = i;
                    for (int j = i + 1; j < contador; j++)
                    {
                        if (notas[j] > notas[maxIndex])
                        {
                            maxIndex = j;
                        }
                    }
                    // Intercambiar notas
                    double tempNota = notas[i];
                    notas[i] = notas[maxIndex];
                    notas[maxIndex] = tempNota;
                    // Intercambiar nombres correspondientes
                    string tempNombre = nombres[i];
                    nombres[i] = nombres[maxIndex];
                    nombres[maxIndex] = tempNombre;
                }
            }

            static public void mostrar_promedio_maximo()
            {
                if (contador == 0)
                {
                    Console.WriteLine("No hay estudiantes registrados");
                    return;
                }
                double suma = 0;
                double maxNota = notas[0];
                for (int i = 0; i < contador; i++)
                {
                    suma += notas[i];
                    if (notas[i] > maxNota)
                    {
                        maxNota = notas[i];
                    }
                }
                double promedio = suma / contador;
                Console.WriteLine($"Promedio de notas: {promedio}");
                Console.WriteLine($"Nota máxima: {maxNota}");
            }

            static void Main(string[] args)
            {
                Titulo();
                int opc = 0;
                while (opc != 8)
                {
                    Console.Clear();
                    Console.WriteLine("***MENU PRINCIPAL***");
                    Console.WriteLine("[1] Registrar estudiante");
                    Console.WriteLine("[2] Buscar estudiantes");
                    Console.WriteLine("[3] Modificar nota");
                    Console.WriteLine("[4] Mostrar lista sin ordenar");
                    Console.WriteLine("[5] Mostrar reporte ordenado por burbuja");
                    Console.WriteLine("[6] Mostrar por selección DESC");
                    Console.WriteLine("[7] Promedio y nota máxima");
                    Console.WriteLine("[8] Salir");
                    Console.Write("Ingresar opción: ");
                    if (!int.TryParse(Console.ReadLine(), out opc))
                    {
                        Console.WriteLine("Error: escriba un número entero");
                        continue;
                    }
                    switch (opc)
                    {
                        case 1:
                            Registrar_estudiante(); break;
                        case 2:
                            buscar_estudiante();
                            break;
                        case 3:
                            modificar_est();
                            break;
                        case 4:
                            mostrar(); break;
                        case 5:
                            burbuja();
                            mostrar();
                            break;
                        case 6:
                            seleccion_des();
                            mostrar();
                            break;
                        case 7:
                            mostrar_promedio_maximo();
                            break;
                        case 8:
                            Console.WriteLine("Saliendo del programa...");
                            break;
                        default:
                            Console.WriteLine("Opcion incorrecta");
                            break;
                    }
                    Console.ReadKey();
                }
            }
        }
    }
