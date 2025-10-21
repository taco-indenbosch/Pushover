using System.Text.Json.Serialization;

namespace Heddes.Pushover;

public class PushoverMessage
{
	[JsonPropertyName("token")] public string ApiToken { get; set; }

	[JsonPropertyName("attachment_type")] public string AttachmentType { get; set; }

	[JsonPropertyName("device")] public string Device { get; set; }

	[JsonPropertyName("expire")] public int ExpireInSeconds { get; set; }

	[JsonPropertyName("html")] public int Html { get; set; }

	[JsonPropertyName("message")] public string Message { get; set; }

	[JsonPropertyName("priority")] public int Priority { get; set; }

	[JsonPropertyName("retry")] public int RetryAfterSeconds { get; set; }

	[JsonPropertyName("sound")] public string Sound { get; set; }

	[JsonPropertyName("timestamp")] public long Timestamp { get; set; }

	[JsonPropertyName("ttl")] public int? TimeToLive { get; set; }

	[JsonPropertyName("title")] public string Title { get; set; }

	[JsonPropertyName("url")] public string? Url { get; set; }

	[JsonPropertyName("url_title")] public string UrlTitle { get; set; }

	[JsonPropertyName("user")] public string User { get; set; }
}

public class SendMessageResponse
{
	public SendMessageResponse()
	{
		RequestId = string.Empty;
	}

	[JsonPropertyName("errors")] public string[]? Errors { get; set; }

	[JsonPropertyName("request")] public string RequestId { get; set; }

	[JsonPropertyName("status")] public int Status { get; set; }
}