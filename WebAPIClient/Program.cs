using Newtonsoft.Json;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;
using HttpClient client = new();

var configManager = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", false, true)
    .AddEnvironmentVariables()
    .Build();

var targetUrl = configManager.GetValue<string>("HealthCheckUrl");

await ProcessRepositoriesAsync(client, targetUrl);

async Task ProcessRepositoriesAsync(HttpClient client, string? targetUrl)
{
    try
    {
        var jsonString = await client.GetStringAsync(targetUrl);
        var jsonDynamicToList = JObject.Parse(jsonString)["entries"]?.Children().ToList();

        List<JToken> result = new List<JToken>();

        foreach (var entry in jsonDynamicToList)
        {
            var propertyName = entry.ToString().Split(":").First().ToLower();
            
            if (propertyName.Contains("adapter"))
            {
                result.Add(entry);
            }
        }

        var resultString = "{" + String.Join(",", result) + "}";

        Console.WriteLine(resultString);

        SaveJsonToXmlFile(resultString);
    } 
    catch(Exception e)
    {
        throw new Exception(e.Message);
    }
}

void SaveJsonToXmlFile(string jsonString)
{
    XNode node = JsonConvert.DeserializeXNode(jsonString, "Root");
    
    string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
    string sFile = System.IO.Path.Combine(sCurrentDirectory, @"../../../XMLDataFiles/health.xml");
    string path = Path.GetFullPath(sFile);

    // This text is added only once to the file.
    if (!File.Exists(path))
    {
        // Create a file to write to.
        File.WriteAllText(path, node?.ToString());
    }
    else
    {
        File.WriteAllText(path, String.Empty);
        File.WriteAllText(path, node?.ToString());
    }

    //Open the file to read from.
    string readText = File.ReadAllText(path);
    Console.WriteLine(readText);
}

