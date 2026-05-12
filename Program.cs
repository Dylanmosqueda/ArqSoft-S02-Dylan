
var repositorio = new Ahorcado.PalabrasEnMemoria();
var motor = new Ahorcado.MotorAhorcado(repositorio);
var ui = new Ahorcado.ConsolaUI(motor);

Console.WriteLine("=== AHORCADO ===");

Console.WriteLine("Elige una categoría:");
Console.WriteLine("1. Arquitectura");
Console.WriteLine("2. POO");
Console.WriteLine("3. .NET");
Console.Write("Opción: ");

string opcion = Console.ReadLine();

string categoria = opcion switch
{
    "1" => "Arquitectura",
    "2" => "POO",
    "3" => ".NET",
    _ => "POO"
};

repositorio.SeleccionarCategoria(categoria);
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
{
    ui.MostrarMensaje($"\n¡Ganaste! La palabra era: {motor.PalabraSecreta}");
}
else
{
    ui.MostrarMensaje($"\nPerdiste. La palabra era: {motor.PalabraSecreta}");
}

if (ui.PreguntarOtraVez())
{
    
    Console.WriteLine("Elige una categoría:");
    Console.WriteLine("1. Arquitectura");
    Console.WriteLine("2. POO");
    Console.WriteLine("3. .NET");
    Console.Write("Opción: ");

    opcion = Console.ReadLine();

    categoria = opcion switch
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