using Newtonsoft.Json;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using WebAPIClient;
using Microsoft.Extensions.Configuration;
using WebAPIClient.Dtos;
using HttpClient client = new();

var configManager = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", false, true)
    .AddEnvironmentVariables()
    .Build();

var targetUrl = configManager.GetValue<string>("HealthCheckUrl");

await ProcessRepositoriesAsync(client, targetUrl);

static async Task ProcessRepositoriesAsync(HttpClient client, string? targetUrl)
{
    try
    {
        var jsonString = await client.GetStringAsync(targetUrl);

        var jsonBase = JsonConvert.DeserializeObject<ResultDto>(jsonString);
        var entriesToArr = JObject.Parse(jsonString)["entries"]?.Children().ToArray();

        List<string> propertiesToIgnore = new List<string>();
        foreach (var entry in entriesToArr)
        {
            var propertyName = entry.ToString().Split(":").First().Replace('"', ' ').Trim();

            if (!propertyName.Contains("Adapter"))
            {
                propertiesToIgnore.Add(propertyName);
            }
        }

        var jsonResult = JsonConvert.SerializeObject(jsonBase,
            Formatting.Indented,
            new JsonSerializerSettings
            {
                ContractResolver = new IgnorePropertiesResolver(propertiesToIgnore.ToArray())
            });

        Console.Write(jsonResult);

        SaveJsonToXmlFile(jsonResult);
    } 
    catch(Exception e)
    {
        Console.WriteLine(e.Message);
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
            //string createText = "Hello and Welcome" + Environment.NewLine;
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
}

