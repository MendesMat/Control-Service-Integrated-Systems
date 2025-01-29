using Mendes.ControlService.ManagementAPI.Abstracts;
using System.Text.Json.Serialization;
using System.Text.Json;
using Mendes.ControlService.ManagementAPI.Models;

namespace Mendes.ControlService.ManagementAPI.Utilities;

public class CustomerBaseConverter : JsonConverter<CustomerBase>
{
    public override CustomerBase? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
        {
            var root = doc.RootElement;

            if (root.TryGetProperty("Type", out var typeProperty))
            {
                if (typeProperty.GetString() == "Individual")
                {
                    return JsonSerializer.Deserialize<IndividualCustomer>(root.GetRawText());
                }
                else if (typeProperty.GetString() == "Company")
                {
                    return JsonSerializer.Deserialize<CompanyCustomer>(root.GetRawText());
                }
            }

            return null;
        }
    }

    public override void Write(Utf8JsonWriter writer, CustomerBase value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteNullValue();
            return;
        }

        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
