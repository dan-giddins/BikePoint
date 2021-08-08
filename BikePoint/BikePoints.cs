using System;
using Newtonsoft.Json;

namespace BikePoint
{
	public partial class BikePoint
	{
		[JsonProperty("$type")]
		public string Type { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }

		[JsonProperty("commonName")]
		public string CommonName { get; set; }

		[JsonProperty("placeType")]
		public PlaceType PlaceType { get; set; }

		[JsonProperty("additionalProperties")]
		public AdditionalProperty[] AdditionalProperties { get; set; }

		[JsonProperty("children")]
		public object[] Children { get; set; }

		[JsonProperty("childrenUrls")]
		public object[] ChildrenUrls { get; set; }

		[JsonProperty("lat")]
		public double Lat { get; set; }

		[JsonProperty("lon")]
		public double Lon { get; set; }
	}

	public partial class AdditionalProperty
	{
		[JsonProperty("$type")]
		public string Type { get; set; }

		[JsonProperty("category")]
		public Category Category { get; set; }

		[JsonProperty("key")]
		public Key Key { get; set; }

		[JsonProperty("sourceSystemKey")]
		public SourceSystemKey SourceSystemKey { get; set; }

		[JsonProperty("value")]
		public string Value { get; set; }

		[JsonProperty("modified")]
		public DateTimeOffset Modified { get; set; }
	}

	public enum Category { Description };

	public enum Key { InstallDate, Installed, Locked, NbBikes, NbDocks, NbEmptyDocks, RemovalDate, Temporary, TerminalName };

	public enum SourceSystemKey { BikePoints };

	public enum PlaceType { BikePoint };
}
