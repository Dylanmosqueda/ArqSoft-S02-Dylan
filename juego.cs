using System;
using System.Collections.Generic;
using System.Text;

namespace Ahorcado
{
    public class Juego
    {
        // Lista de palabras posibles
        private List<string> _palabras = new()
        {
            "arquitectura",
            "interfaz",
            "polimorfismo",
            "encapsulamiento",
            "herencia"
        };

        // Variables principales
        private string _palabraSecreta;
        private List<char> _letrasUsadas;
        private int _intentosRestantes;

        // Constructor
        public Juego()
        {
            var random = new Random();

            // Selecciona una palabra aleatoria
            _palabraSecreta = _palabras[random.Next(_palabras.Count)];

            // Inicializa lista de letras usadas
            _letrasUsadas = new List<char>();

            // Número de intentos permitidos
            _intentosRestantes = 6;
        }

        public void Jugar()
        {
            Console.Clear();
            Console.WriteLine("=== AHORCADO ===");

            while (_intentosRestantes > 0)
            {
                MostrarTablero();

                if (VerificarVictoria())
                {
                    Console.WriteLine("\n¡Ganaste! La palabra era: " + _palabraSecreta);
                    Console.Write("\n¿Jugar otra vez? (s/n): ");

                    if (Console.ReadLine()?.ToLower() == "s")
                        new Juego().Jugar();

                    return;
                }

                Console.Write("\nIngresa una letra: ");
                char letra = Console.ReadLine()[0];

                if (_letrasUsadas.Contains(letra))
                {
                    Console.WriteLine("Ya usaste esa letra.");
                    continue;
                }

                _letrasUsadas.Add(letra);

                if (!_palabraSecreta.Contains(letra))
                    _intentosRestantes--;
            }

            MostrarTablero();

            Console.WriteLine("\nPerdiste. La palabra era: " + _palabraSecreta);
            Console.Write("\n¿Jugar otra vez? (s/n): ");

            if (Console.ReadLine()?.ToLower() == "s")
                new Juego().Jugar();
        }

        private bool VerificarVictoria()
        {
            foreach (char c in _palabraSecreta)
            {
                if (!_letrasUsadas.Contains(c))
                    return false;
            }

            return true;
        }

        private void MostrarTablero()
        {
            Console.Clear();
            MostrarAhorcado();

            Console.WriteLine($"Intentos restantes: {_intentosRestantes}");
            Console.WriteLine($"Letras usadas: {string.Join(", ", _letrasUsadas)}");

            Console.Write("Palabra: ");

            foreach (char c in _palabraSecreta)
            {
                Console.Write(_letrasUsadas.Contains(c) ? c : '_');
            }

            Console.WriteLine();
        }

        private void MostrarAhorcado()
        {
            string[] etapas = new string[]
            {
                " -----\n | |\n |\n |\n |\n |\n=========",
                " -----\n | |\n O |\n |\n |\n |\n=========",
                " -----\n | |\n O |\n | |\n |\n |\n=========",
                " -----\n | |\n O |\n/| |\n |\n |\n=========",
                " -----\n | |\n O |\n/|\\ |\n |\n |\n=========",
                " -----\n | |\n O |\n/|\\ |\n/ |\n |\n=========",
                " -----\n | |\n O |\n/|\\ |\n/ \\ |\n |\n========="
            };

            Console.WriteLine(etapas[6 - _intentosRestantes]);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Juego juego = new Juego();
            juego.Jugar();
        }
    }
}