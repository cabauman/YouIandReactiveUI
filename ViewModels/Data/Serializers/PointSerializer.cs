namespace Book.ViewModels.Data.Serializers
{
    using System;
    using System.Drawing;
    using System.Reflection;
    using Newtonsoft.Json;

    public sealed class PointSerializer : JsonConverter
    {
        public override bool CanConvert(Type objectType) =>
            typeof(PointF).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo()) ||
            typeof(PointF?).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = (string)reader.Value;

            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            var components = value
                .Split(',');
            return new PointF
            {
                X = float.Parse(components[0]),
                Y = float.Parse(components[1])
            };
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}