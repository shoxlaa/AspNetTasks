// See https://aka.ms/new-console-template for more information
// This code demonstrates how to retrieve your connection string
// from an environment variable.
using Azure.Communication.Identity;
using Azure.Core;
using Azure.Identity;

string endpoint = "https://discordninja.communication.azure.com/";
TokenCredential tokenCredential = new DefaultAzureCredential();
var client = new CommunicationIdentityClient(new Uri(endpoint), tokenCredential);

var identityResponse = await client.CreateUserAsync();
var identity = identityResponse.Value;
Console.WriteLine($"\nCreated an identity with ID: {identity.Id}");