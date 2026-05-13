// Menú principal

Console.WriteLine("¿Qué juego quieres jugar?");
Console.WriteLine("  1 — Ahorcado");
Console.WriteLine("  2 — Viborita");
Console.Write("Opción: ");

var opcion = Console.ReadLine();

if (opcion == "1")
{
    // --- LÓGICA DEL AHORCADO ---

    var repositorio = new Ahorcado.PalabrasEnMemoria();

    Console.WriteLine("=== AHORCADO ===");

    /* Selección de categoría ANTES de crear el motor */
    Console.WriteLine("Elige una categoría:");
    Console.WriteLine("1. Arquitectura");
    Console.WriteLine("2. POO");
    Console.WriteLine("3. .NET");
    Console.Write("Opción: ");

    string opcionCategoria = Console.ReadLine();

    string categoria = opcionCategoria switch
    {
        "1" => "Arquitectura",
        "2" => "POO",
        "3" => ".NET",
        _ => "POO"
    };

    repositorio.SeleccionarCategoria(categoria);

    var motor = new Ahorcado.MotorAhorcado(repositorio);
    var ui = new Ahorcado.ConsolaUI(motor);

    while (!motor.Ganado() && !motor.Perdido())
    {
        ui.MostrarTablero();

        char letra = ui.PedirLetra();

        if (motor.LetraYaUsada(letra))
        {
            ui.MostrarMensaje("Ya usaste esa letra.");
            continue;
        }

        motor.RegistrarLetra(letra);
    }

    ui.MostrarTablero();

    if (motor.Ganado())
        ui.MostrarMensaje($"\n¡Ganaste! La palabra era: {motor.PalabraSecreta}");
    else
        ui.MostrarMensaje($"\nPerdiste. La palabra era: {motor.PalabraSecreta}");

    if (ui.PreguntarOtraVez())
    {
        Console.WriteLine("Elige una categoría:");
        Console.WriteLine("1. Arquitectura");
        Console.WriteLine("2. POO");
        Console.WriteLine("3. .NET");
        Console.Write("Opción: ");

        opcionCategoria = Console.ReadLine();

        categoria = opcionCategoria switch
        {
            "1" => "Arquitectura",
            "2" => "POO",
            "3" => ".NET",
            _ => "POO"
        };

        repositorio.SeleccionarCategoria(categoria);

        var nuevoMotor = new Ahorcado.MotorAhorcado(repositorio);
        var nuevaUI = new Ahorcado.ConsolaUI(nuevoMotor);
    }
}
else if (opcion == "2")
{
    // --- LÓGICA DE LA VIBORITA ---

    var motor = new Ahorcado.MotorViborita();
    var ui = new Ahorcado.ConsolaUIViborita(motor);

    Console.CursorVisible = false;

    while (!motor.Ganado() && !motor.Perdido())
    {
        ui.MostrarTablero();

        var tecla = ui.LeerTecla();

        if (tecla == ConsoleKey.Q) break;

        if (tecla != ConsoleKey.NoName)
            motor.CambiarDireccion(tecla);

        motor.Avanzar();

        Thread.Sleep(150);
    }

    ui.MostrarTablero();

    ui.MostrarMensaje(
        motor.Ganado()
        ? "\n¡Ganaste! Llegaste a 10 puntos."
        : "\nGame over."
    );

    Console.CursorVisible = true;
}
else
{
    Console.WriteLine("Opción no válida.");
}
