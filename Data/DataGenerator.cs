using System;
using System.Collections.Generic;

namespace LabSoft.Data
{
    public static class DataGenerator
    {
        private static readonly Random Random = new Random();

        public static string GenerateRandomName()
        {
            var names = new[] { "Juan", "María", "Pedro", "Ana", "Luis", "Laura", "Carlos", "Isabel", "Javier", "Cristina" };
            return names[Random.Next(names.Length)];
        }

        public static string GenerateRandomLastName()
        {
            var lastNames = new[] { "García", "Rodríguez", "Martínez", "Hernández", "López", "Gómez", "Pérez", "Fernández", "González", "Morales" };
            return lastNames[Random.Next(lastNames.Length)];
        }

        public static string GenerateRandomDNIType()
        {
            var types = new[] { "CC", "TI"};
            return types[Random.Next(types.Length)];
        }

        public static string GenerateRandomDNI()
        {
            return $"{Random.Next(1000000, 9999999)}";
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

        public static string GenerateRandomPassword()
        {
            return Guid.NewGuid().ToString().Substring(0, 8);
        }
    }

}
