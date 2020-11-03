using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dto.RespostaGoogleAPI
{
    public class RespostaGoogleApi
    {
        [JsonProperty("results")]
        public Result[] Results { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class Result
    {
        [JsonProperty("access_points")]
        public object[] AccessPoints { get; set; }

        [JsonProperty("address_components")]
        public Address_Components[] AddressComponents { get; set; }

        [JsonProperty("formatted_address")]
        public string FormattedAddress { get; set; }

        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }

        [JsonProperty("place_id")]
        public string PlaceId { get; set; }

        [JsonProperty("types")]
        public string[] Types { get; set; }
    }

    public class Geometry
    {
        [JsonProperty("bounds")]
        public Bounds Bounds { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("location_type")]
        public string LocationType { get; set; }

        [JsonProperty("viewport")]
        public Viewport Viewport { get; set; }
    }

    public class Bounds
    {
        [JsonProperty("northeast")]
        public Northeast Northeast { get; set; }

        [JsonProperty("southwest")]
        public Southwest Southwest { get; set; }
    }

    public class Northeast
    {
        [JsonProperty("lat")]
        public float Lat { get; set; }

        [JsonProperty("lng")]
        public float Lng { get; set; }
    }

    public class Southwest
    {
        [JsonProperty("lat")]
        public float Lat { get; set; }

        [JsonProperty("lng")]
        public float Lng { get; set; }
    }

    public class Location
    {
        [JsonProperty("lat")]
        public float Lat { get; set; }

        [JsonProperty("lng")]
        public float Lng { get; set; }
    }

    public class Viewport
    {
        [JsonProperty("northeast")]
        public Northeast1 Northeast { get; set; }

        [JsonProperty("southwest")]
        public Southwest1 Southwest { get; set; }
    }

    public class Northeast1
    {
        [JsonProperty("lat")]
        public float Lat { get; set; }

        [JsonProperty("lng")]
        public float Lng { get; set; }
    }

    public class Southwest1
    {
        [JsonProperty("lat")]
        public float Lat { get; set; }

        [JsonProperty("lng")]
        public float Lng { get; set; }
    }

    public class Address_Components
    {
        [JsonProperty("long_name")]
        public string LongName { get; set; }

        [JsonProperty("short_name")]
        public string ShortName { get; set; }

        [JsonProperty("types")]
        public string[] Types { get; set; }
    }

}
