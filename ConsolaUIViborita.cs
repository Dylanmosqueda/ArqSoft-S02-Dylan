namespace Ahorcado;

public class ConsolaUIViborita
{
    private readonly MotorViborita _motor;

    // Constructor simplificado (Expression-bodied)
    public ConsolaUIViborita(MotorViborita motor) => _motor = motor;

    public void MostrarTablero()
    {
        Console.SetCursorPosition(0, 0);
        Console.WriteLine($"=== VIBORITA === Puntos: {_motor.Puntos}");

        // Uso de interpolación en lugar de concatenación con '+'
        Console.WriteLine($"+{new string('-', _motor.Ancho)}+");

        for (int y = 0; y < _motor.Alto; y++)
        {
            Console.Write("|");

            for (int x = 0; x < _motor.Ancho; x++)
            {
                var pos = (x, y);

                // Lógica de dibujo simplificada con Switch Expression (C# 8+)
                char pixel = pos switch
                {
                    _ when pos == _motor.Cuerpo.First() => '€', // cabeza
                    _ when _motor.Cuerpo.Contains(pos) => '0', // cuerpo
                    _ when pos == _motor.Comida => 'º', // comida
                    _ => ' '  // vacío
                };

                Console.Write(pixel);
            }

            Console.WriteLine("|");
        }

        Console.WriteLine($"+{new string('-', _motor.Ancho)}+");
        Console.WriteLine("Flechas: mover | Q: salir");
    }

    // Simplificado a una sola línea con operador ternario
    public ConsoleKey LeerTecla() =>
        Console.KeyAvailable ? Console.ReadKey(intercept: true).Key : ConsoleKey.NoName;

    // Indentación corregida
    public void MostrarMensaje(string mensaje) => Console.WriteLine(mensaje);
}