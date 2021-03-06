using Newtonsoft.Json;
// <copyright file="BooleanConverterTest.cs">Copyright ©  2014</copyright>

using System;
using Databar.Services;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Databar.Services.Tests
{
    [TestClass]
    [PexClass(typeof(BooleanConverter))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class BooleanConverterTest
    {

        [PexMethod]
        public void WriteJson(
            [PexAssumeUnderTest]BooleanConverter target,
            JsonWriter writer,
            object value,
            JsonSerializer serializer
        )
        {
            target.WriteJson(writer, value, serializer);
            // TODO: add assertions to method BooleanConverterTest.WriteJson(BooleanConverter, JsonWriter, Object, JsonSerializer)
        }

        [PexMethod]
        public object ReadJson(
            [PexAssumeUnderTest]BooleanConverter target,
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer
        )
        {
            object result = target.ReadJson(reader, objectType, existingValue, serializer);
            return result;
            // TODO: add assertions to method BooleanConverterTest.ReadJson(BooleanConverter, JsonReader, Type, Object, JsonSerializer)
        }

        [PexMethod]
        public bool CanConvert([PexAssumeUnderTest]BooleanConverter target, Type objectType)
        {
            bool result = target.CanConvert(objectType);
            return result;
            // TODO: add assertions to method BooleanConverterTest.CanConvert(BooleanConverter, Type)
        }
    }
}
