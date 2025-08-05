using System.Text.Json;
using System.Text.Json.Serialization;

namespace Securely.JsonConverters;

/// <summary>
/// Helps converts different formatted date strings to DateTime objects.
/// </summary>
public class DateTimeConverter : JsonConverter<DateTime>
{
    private readonly List<string> _formats = new() {
        "MM/dd/yyyy",
        "MM-dd-yyyy",
        "MM/dd/yyyy HH:mm",
        "MM-dd-yyyy HH:mm",
        "MM/d/yyyy HH:mm:ss",
        "MM-dd-yyyy HH:mm:ss",
        "yyyy-MM-ddTHH:mm:ss",
        "yyyy-MM-dd",
        "yyyy-M-dd",
    };

    /// <summary>
    /// Called when reading JSON to convert a string representation of a date into a DateTime object.
    /// </summary>
    /// <param name="reader"></param>
    /// <param name="typeToConvert"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        foreach (var format in _formats)
        {
            if (DateTime.TryParseExact(reader.GetString(), format, null, System.Globalization.DateTimeStyles.None, out var date))
            {
                return date;
            }
        }

        return default;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    /// <param name="options"></param>
    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("yyyy-MM-ddTHH:mm:ss"));
    }
}