using System.Diagnostics;

namespace AITextApp.Helpers
{
    public static class APIKeyValidationHelper
    {
        const string OpenAIRequestUrl = "https://api.openai.com/v1/engines";

        public static (bool isValid, string message) ValidateApiKeyFormat(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                return (false, "Api key can not be empty."); // Key cannot be empty
            }

            if (!apiKey.StartsWith("sk-"))
            {
                return (false, "Api key prefix must be sk-"); // Key prefix must be sk-
            }

            return (true, string.Empty);
        }

        public static async Task<(bool isValid, string message)> ValidateOpenAIApiKeyAsync(string apiKey)
        {
            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
                var response = await client.GetAsync(OpenAIRequestUrl);

                if (response.IsSuccessStatusCode)
                {
                    // API key is valid
                    return (true, "Api key is valid.");
                }
                // Handle invalid key error
                // Consider logging the error details for debugging
                Debug.WriteLine($"Invalid API key response: {response.StatusCode} - {response.ReasonPhrase}");
                return (false, "Invalid API key response.");
            }
            catch (Exception ex)
            {
                // Handle network or other exceptions
                Debug.WriteLine($"Error during API key validation: {ex.Message}");
                // Consider displaying an error message to the user
                return (false, "Error during API key validation.");
            }
        }
    }
}
