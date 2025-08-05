using System.Text.Json;
using System.Text.Json.Serialization;
using Securely.Subscriptions.Types;

namespace Securely.net.Converters;

/// <summary>
/// Provides custom JSON serialization and deserialization for the <see cref="Frequency"/> type.
/// </summary>
/// <remarks>This converter handles the conversion of <see cref="Frequency"/> objects to and from JSON string
/// representations. It is intended to be used with the <see cref="System.Text.Json"/> serialization
/// framework.</remarks>
public class FrequencyConverter : JsonConverter<Frequency>
{
    /// <summary>
    /// Reads and converts the JSON string representation of a frequency into a <see cref="Frequency"/> object.
    /// </summary>
    /// <param name="reader">The <see cref="Utf8JsonReader"/> to read the JSON data from. The reader must be positioned at a JSON string
    /// token.</param>
    /// <param name="type">The type of the object to convert. This parameter is not used in this implementation.</param>
    /// <param name="options">The serializer options to use. This parameter is not used in this implementation.</param>
    /// <returns>A <see cref="Frequency"/> object created from the JSON string, or <see langword="null"/> if the token is not a
    /// string.</returns>
    public override Frequency? Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            return new Frequency(reader.GetString()!);
        }

        return null;
    }

    /// <summary>
    /// Writes the string representation of a <see cref="Frequency"/> value to the specified <see
    /// cref="Utf8JsonWriter"/>.
    /// </summary>
    /// <param name="writer">The <see cref="Utf8JsonWriter"/> to which the value will be written. Cannot be <see langword="null"/>.</param>
    /// <param name="value">The <see cref="Frequency"/> value to write.</param>
    /// <param name="options">The serialization options to use. This parameter is not used in this implementation but is required by the
    /// method signature.</param>
    public override void Write(Utf8JsonWriter writer, Frequency value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
