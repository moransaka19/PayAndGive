namespace BloodIoT
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Net.Http.Json;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your jwt: ");
            var jwt = $"Bearer {Console.ReadLine()}";

            while (true)
            {
                Console.WriteLine("Enter blood test name: ");
                var modelName = Console.ReadLine();

                Console.WriteLine("Enter sugar level: ");
                var modelSugarLevel = decimal.Parse(Console.ReadLine());
                var model = new AddBloodTestModel()
                {
                    Name = modelName,
                    SugarLevel = modelSugarLevel,
                    Time = DateTime.Now
                };
                using var http = new HttpClient
                {
                    BaseAddress = new Uri("https://aaaaapzpzpzpzpz-api.azurewebsites.net/")
                };
                var request = new HttpRequestMessage(HttpMethod.Post, "/api/blood-tests")
                {
                    Content = JsonContent.Create(model)
                };
                request.Headers.Authorization = AuthenticationHeaderValue.Parse(jwt);
                var response = http.Send(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Console.WriteLine("Blood test has been added");
                    Console.WriteLine();
                }
            }
        }
    }
}
