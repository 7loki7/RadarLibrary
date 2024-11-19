using Newtonsoft.Json;
using static RadarLibrary.Models;

namespace RadarLibrary
{
    public class RadarCommunicator(string radarIp)
    {
        private readonly HttpClient _client = new();

        public async Task<RadarResponse> GetRadarStatusAsync()
        {
            try
            {
                var response = await _client.GetAsync(radarIp);
                if (response.IsSuccessStatusCode)
                {
                    return new RadarResponse { IsOnline = true };
                }
                return new RadarResponse { IsOnline = false};
            }
            catch (Exception ex)
            {
                return new RadarResponse { IsOnline = false, LastError = ex.Message };
            }
        }

        public async Task<List<RadarTarget>?> GetRadarDataAsync()
        {
            try
            {
                var response = await _client.GetAsync(radarIp);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(responseContent))
                {
                    Console.WriteLine($"Received empty response");
                    return null;
                }

                var radarResponse = JsonConvert.DeserializeObject<RadarResponse>(responseContent);
                return radarResponse?.Targets ?? null;
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"HTTP Request Error: {httpEx.Message}");
                return null;
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"JSON Deserialization Error: {jsonEx.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}");
                return null;
            }
        }
    }
}