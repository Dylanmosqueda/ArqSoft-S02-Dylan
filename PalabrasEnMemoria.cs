using System;
using System.Collections.Generic;
using System.Text;

namespace Ahorcado
{
    public class PalabrasEnMemoria : IRepositorioPalabras
    {
        private readonly Dictionary<string, List<string>> _categorias = new()
        {
            {
                "Arquitectura",
                new List<string>
                {
                    "arquitectura",
                    "componente",
                    "descomposicion",
                    "dependencia",
                    "acoplamiento"
                }
            },
            {
                "POO",
                new List<string>
                {
                    "polimorfismo",
                    "encapsulamiento",
                    "herencia",
                    "abstraccion",
                    "clase"
                }
            },
            {
                ".NET",
                new List<string>
                {
                    "ensamblado",
                    "namespace",
                    "interfaz",
                    "delegado",
                    "middleware"
                }
            }
        };

        private string _categoriaSeleccionada = "POO";

        public void SeleccionarCategoria(string categoria)
        {
            if (_categorias.ContainsKey(categoria))
                _categoriaSeleccionada = categoria;
        }

        public string ObtenerPalabraAleatoria()
        {
            var random = new Random();
            var palabras = _categorias[_categoriaSeleccionada];

            return palabras[random.Next(palabras.Count)];
        }
    }

}
