namespace PayAndGiveIoT
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Enter current machine's id:");
            var machineId = int.Parse(Console.ReadLine());

            while (true)
            {
                using var httpClient = new HttpClient
                {
                    BaseAddress = new Uri("https://payandgive.azurewebsites.net")
                };

                var request = new HttpRequestMessage(HttpMethod.Get, $"/api/machines/{machineId}/containers");

                var response = httpClient.Send(request);
                var containers = JsonSerializer.Deserialize<ContainerModel[]>(response.Content.ReadAsStringAsync().Result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (response.StatusCode == HttpStatusCode.OK && containers.Any())
                {
                    Console.WriteLine("Containers has been processed:");

                    foreach (var containerModel in containers)
                    {
                        Console.WriteLine($"Container {containerModel.Id} has been opened");
                    }

                    Console.WriteLine();
                }

                Thread.Sleep(5_000);
            }
        }
    }

    public class ContainerModel
    {
        public int Id { get; set; }

        public DateTime FixedLoadingTime { get; set; }

        public EatModel Eat { get; set; }

        public bool IsEmpty { get; set; }
    }

    public class EatModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }
    }
}
