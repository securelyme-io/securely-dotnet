using System.Text.Json;

namespace Securely.JsonConverters;

/// <summary>
/// Find of a catch all just to make sure if things are numbers but we are expecting a string, that it doesnt bomb
/// </summary>
public class StringConverter : System.Text.Json.Serialization.JsonConverter<string>
{
    /// <summary>
    /// Called when reading JSON to convert a string representation of a date into a DateTime object.
    /// </summary>
    /// <param name="reader"></param>
    /// <param name="typeToConvert"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
        {
            var stringValue = reader.GetInt32();
            return stringValue.ToString();
        }
        else if (reader.TokenType == JsonTokenType.String)
        {
            return reader!.GetString();
        }

        throw new System.Text.Json.JsonException();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    /// <param name="options"></param>
    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value);
    }
}
