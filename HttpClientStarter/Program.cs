
using System.Net.Http.Json;
using System.Runtime.InteropServices;

using var client = new HttpClient();

var requestBody = new StringContent("{\r\n  \"id\": 100,\r\n  \"name\": \"Jane Doe\",\r\n  \"username\": \"janedoe\",\r\n  \"email\": \"jane@example.com\",\r\n  \"isActive\": true,\r\n  \"roles\": [\"admin\", \"editor\"],\r\n  \"address\": {\r\n    \"street\": \"123 Main St\",\r\n    \"city\": \"Metropolis\",\r\n    \"zipcode\": \"12345\"\r\n  }\r\n}");

var response = await client.PostAsync("https://localhost:7163/weatherforecast", requestBody);

// ✅ Show response details

while (true)
{
Console.WriteLine("\nSelect Actions:");
Console.WriteLine("A - GET");
Console.WriteLine("B - POST");
Console.WriteLine("C - PUT");
Console.WriteLine("D - DELETE");
Console.Write("\nEnter your choice: ");

string choice = Console.ReadLine();

;
if (choice == "A")
{
    response = await client.GetAsync("https://localhost:7163/weatherforecast");
}
else if (choice == "B")
{
    response = await client.PostAsync("https://jsonplaceholder.typicode.com/posts", requestBody);
}
else if (choice == "C")
{
    response = await client.PutAsJsonAsync("https://jsonplaceholder.typicode.com/posts/1", requestBody);
}
else if (choice == "D")
{
    response = await client.DeleteAsync("https://jsonplaceholder.typicode.com/posts/1");
}
else
{
    Console.WriteLine("Invalid choice.");

    return;
}
Console.WriteLine($"Status Code: {(int)response.StatusCode}");
Console.WriteLine($"Status: {response.StatusCode}");
Console.WriteLine($"Is Success: {response.IsSuccessStatusCode}");


var body = await response.Content.ReadAsStringAsync();

Console.WriteLine($"\nBody:\n{ body}");
}