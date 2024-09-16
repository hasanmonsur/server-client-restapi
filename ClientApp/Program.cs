// See https://aka.ms/new-console-template for more information
using System.Net.Http.Json;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

Console.WriteLine("Hello, World!");


        HttpClient _httpClient = new HttpClient();

        string apiUrl = "https://localhost:7204/api/Products";

        // Get all products
        var products = await _httpClient.GetFromJsonAsync<Product[]>(apiUrl);
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Id}: {product.Name} - ${product.Price}");
        }

        // Add a new product
        var newProduct = new Product { Name = "New Product", Price = 19.99M };
        var response = await _httpClient.PostAsJsonAsync(apiUrl, newProduct);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Product added successfully.");
        }

        // Get a product by id
        var productById = await _httpClient.GetFromJsonAsync<Product>($"{apiUrl}/1");
        Console.WriteLine($"{productById.Id}: {productById.Name} - ${productById.Price}");

        // Update a product
        var updateProduct = new Product { Id = 1, Name = "Updated Product", Price = 24.99M };
        await _httpClient.PutAsJsonAsync($"{apiUrl}/1", updateProduct);

        // Delete a product
        await _httpClient.DeleteAsync($"{apiUrl}/2");
 

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}