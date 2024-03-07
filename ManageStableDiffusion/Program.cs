using System.Net.Http.Json;
string url = "http://127.0.0.1:7860";

var payload = new
{
    prompt = "puppy dog",
    steps = 5
};

using var client = new HttpClient();
var response = await client.PostAsJsonAsync($"{url}/sdapi/v1/txt2img", payload);
var r = await response.Content.ReadFromJsonAsync<Response>();
using var f = File.OpenWrite("output.png");
f.Write(Convert.FromBase64String(r.Images[0]));
