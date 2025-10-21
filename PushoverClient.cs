using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Heddes.Rest;

namespace Heddes.Pushover;

public class PushoverService
{
	public const string SendMessageUrl = "https://api.pushover.net/1/messages.json";

	public PushoverService(string apiKey, IHttpClient httpClient)
	{
		_apiKey = apiKey;
		_httpClient = httpClient;

		_jsonSerializationOptions = new JsonSerializerOptions
			{ DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
	}

	public virtual async Task SendMessage(PushoverMessage message)
	{
		if (string.IsNullOrEmpty(message.ApiToken))
			message.ApiToken = _apiKey;

		var json = JsonSerializer.Serialize(message, _jsonSerializationOptions);

		var request = new HttpRequestMessage
		{
			Method = HttpMethod.Post,
			RequestUri = new Uri(SendMessageUrl)
		};
		request.Content = new StringContent(json, Encoding.UTF8, "application/json");
		var response = await _httpClient.SendAsync(request);
		var responseText = await response.Content.ReadAsStringAsync();

		switch (response.StatusCode)
		{
			case HttpStatusCode.OK:
				JsonSerializer.Deserialize<SendMessageResponse>(responseText, _jsonSerializationOptions);
				break;

			default:
				throw new InvalidOperationException($"Unexpected status code {response.StatusCode} from Pushover.");
		}
	}

	#region Private fields

	private readonly string _apiKey;
	private readonly IHttpClient _httpClient;
	private readonly JsonSerializerOptions _jsonSerializationOptions;

	#endregion
}