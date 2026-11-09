using Backend;

var list = new DoublyLinkedList<string>();
var option = string.Empty;

do
{
    option = Menu();
    switch (option)
    {
        case "1":
            Console.WriteLine("================================");
            Console.Write("Ingrese un valor: ");
            list.InsertItem(Console.ReadLine()!);
            Console.WriteLine("================================");
            break;
        case "2":
            Console.WriteLine("================================");
            Console.WriteLine(list);
            Console.WriteLine("================================");
            break;
        case "3":
            Console.WriteLine("================================");
            Console.WriteLine(list.ToStringReverse());
            Console.WriteLine("================================");
            break;
        case "4":
            Console.WriteLine("================================");
            list.OrderDescending();
            Console.WriteLine(list.ToString());
            Console.WriteLine("================================");
            break;
        case "5":
            var modes = list.GetModes();
            if (modes.Count > 0)
            {
                if (modes.Count == 1)
                {
                    Console.WriteLine("================================");
                    Console.WriteLine($"La moda es {modes[0]}.");
                    Console.WriteLine("================================");
                }
                else
                {
                    Console.WriteLine("================================");
                    Console.WriteLine($"Las modas son {string.Join(" y ", modes)}.");
                    Console.WriteLine("================================");
                }
            }
            else
            {
                Console.WriteLine("================================");
                Console.WriteLine("La lista está vacía, no hay modas.");
                Console.WriteLine("================================");
            }
            break;
        case "6":
            Console.WriteLine("================================");
            Console.WriteLine(list.GetGraph());
            Console.WriteLine("================================");
            break;
        case "7":
            Console.WriteLine("================================");
            Console.Write("Ingrese un valor: ");
            var itemToSearch = Console.ReadLine()!;
            Console.WriteLine(list.Exists(itemToSearch)
                ? $"¡El elemento: '{itemToSearch}' si existe!"
                : $"¡El elemento: '{itemToSearch}' no existe!");
            Console.WriteLine("================================");
            break;
        case "8":
            Console.WriteLine("================================");
            Console.Write("Eliminar una ocurrencia, ingrese el valor: ");
            var inputRemove = Console.ReadLine();
            Console.WriteLine("================================");

            if (!string.IsNullOrEmpty(inputRemove))
            {
                if (list.RemoveOccurrence(inputRemove))
                {
                    Console.WriteLine($"Se ha eliminado {inputRemove}");
                    Console.WriteLine("================================");
                    Console.WriteLine($"Lista actual: {list.ToString()}");
                    Console.WriteLine("================================");
                }
                else
                {
                    Console.WriteLine($"El elemento '{inputRemove}' no existe en la lista.");
                    Console.WriteLine("================================");
                }
            }
            break;
        case "9":
            Console.WriteLine("================================");
            Console.Write("Eliminar todas las ocurrencia, ingrese el valor: ");
            var inputRemoveAll = Console.ReadLine();
            Console.WriteLine("================================");

            if (!string.IsNullOrEmpty(inputRemoveAll))
            {
                if (list.RemoveAllOccurrence(inputRemoveAll))
                {                    
                    Console.WriteLine("Se ha ejecutado la eliminación masiva.");
                    Console.WriteLine("================================");
                    Console.WriteLine($"Lista actual: {list.ToString()}");
                    Console.WriteLine("================================");
                }
                else
                {
                    Console.WriteLine($"El elemento '{inputRemoveAll}' no existe en la lista.");
                    Console.WriteLine("================================");
                }
            }

            break;
        default:
            Console.WriteLine("Opción invalida.");
            Console.WriteLine("================================");
            break;
    }
} while (option != "0");

string Menu()
{
    Console.WriteLine("1. Adicionar.");
    Console.WriteLine("2. Mostrar hacia adelante.");
    Console.WriteLine("3. Mostrar hacia atrás");
    Console.WriteLine("4. Ordernar decendente.");
    Console.WriteLine("5. Mostrar la(s) moda(s).");
    Console.WriteLine("6. Mostrar gráfico.");
    Console.WriteLine("7. Existe.");
    Console.WriteLine("8. Eliminar ocurrencia.");
    Console.WriteLine("9. Eliminar todas las ocurrencias.");
    Console.WriteLine("0. Salir.");
    Console.WriteLine("================================");
    Console.Write("Ingresa una opción: ");

    return Console.ReadLine()!;
}