﻿using Newtonsoft.Json;
using System;

namespace Databar.Services
{
    /// <summary>
    /// Custom converter to handle boolean and TINYINT JSON conversion.
    /// </summary>
    /// <remarks>
    /// Inspired by similar problem on StackOverflow.
    /// </remarks>
    public class BooleanConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((bool)value) ? 1 : 0);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return reader.Value.ToString() == "1";
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(bool);
        }
    }
}
