using System;
using System.Net.Http;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MotorRegister.Web;
using MotorRegister.Web.RESTConnection;
using Radzen;
using RESTConnection.Authentication;
using RESTConnection.Connection;
using RESTConnection.Connection.RequestBuilder;
using RESTConnection.Connection.RequestBuilder.Url;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddRadzenComponents();

builder.Services.AddSingleton<HttpClient>(provider =>
{
    var client = new HttpClient
    {
        BaseAddress = new Uri("http://localhost:5173/"), // Ensure correct base address
        DefaultRequestVersion = new Version(2, 0), // Use HTTP/2 for compatibility
        Timeout = TimeSpan.FromSeconds(15) // Timeout for requests
    };
    client.DefaultRequestHeaders.AcceptEncoding.ParseAdd("gzip, deflate, br"); // Accept encoding
    return client;
});


await builder.Build().RunAsync();