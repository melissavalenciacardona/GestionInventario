using System;
using System.Collections.Generic;

namespace LabSoft.Data
{
    public static class DataGenerator
    {
        private static readonly Random Random = new Random();

        public static string GenerateRandomNombre()
        {
            var firstNames = new[] { "Juan", "María", "Pedro", "Ana", "Luis", "Laura", "Carlos", "Isabel", "Javier", "Cristina" };
            return firstNames[Random.Next(firstNames.Length)];
        }

        public static string GenerateRandomApellido()
        {
            var lastNames = new[] { "Pérez", "Gómez", "López", "Martínez", "Fernández", "García", "Rodríguez", "González", "Hernández", "Morales" };
            return lastNames[Random.Next(lastNames.Length)];
        }
        public static string GenerateRandomTipoDocumento()
        {
            var tipos = new[] { "TI", "CC", "Pasaporte" };
            return tipos[Random.Next(tipos.Length)];
        }
        public static string GenerateRandomNumeroDocumento()
        {
            return $"{Random.Next(10000000, 99999999)}";
        }
        public static string GenerateRandomEmail(string name)
        {
            var domains = new[] { "example.com", "test.com", "demo.com" };
            return $"{name.ToLower().Replace(" ", ".")}@{domains[Random.Next(domains.Length)]}";
        }

        public static string GenerateRandomPhone()
        {
            return $"+34 600 000 {Random.Next(100, 999)}";
        }
        public static string GenerateRandomPassword()
        {
            return "123456";
        }
        public static Direccion GenerateRandomAddress()
        {
            return new Direccion
            {
                Calle = $"Calle {Random.Next(1, 100)}",
                Numero = $"{Random.Next(1, 50)}",
                Ciudad = "Ciudad Desconocida",
                CodigoPostal = $"{Random.Next(1000, 9999)}",
                Pais = "España"
            };
        }

        public static Preferencia GenerateRandomPreferences()
        {
            return new Preferencia
            {
                RecibirInformacion = Random.Next(0, 2) == 0,
                NotificacionPorSms = Random.Next(0, 2) == 0,
                CanalPreferido = Random.Next(0, 2) == 0 ? "email" : "sms"
            };
        }
    }

}
