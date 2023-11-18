using System;
using System.IO;
using ChartJSCore.Helpers;
using ChartJSCore.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace ChartJSCoreTest;

[TestFixture]
public class ConvertersTests
{
    #region BoolIntStringConverter
    [Test]
    public void CanConvert_StringType_ReturnsTrue()
    {
        // Arrange
        BoolIntStringConverter converter = new BoolIntStringConverter();

        // Act
        bool result = converter.CanConvert(typeof(string));

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void CanConvert_OtherType_ReturnsFalse()
    {
        // Arrange
        BoolIntStringConverter converter = new BoolIntStringConverter();

        // Act
        bool result = converter.CanConvert(typeof(int));

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ReadJson_ValidInput_ReturnsInputValue()
    {
        // Arrange
        BoolIntStringConverter converter = new BoolIntStringConverter();
        JsonReader reader = new JsonTextReader(new StringReader("\"test\""));

        // Act
        object result = converter.ReadJson(reader, typeof(string), null, new JsonSerializer());

        // Assert
        Assert.AreEqual("test", result);
    }

    [Test]
    public void WriteJson_BoolValue_WritesBoolValue()
    {
        // Arrange
        BoolIntStringConverter converter = new BoolIntStringConverter();
        StringWriter writer = new StringWriter();
        JsonWriter jsonWriter = new JsonTextWriter(writer);
        object value = true;

        // Act
        converter.WriteJson(jsonWriter, value, new JsonSerializer());

        // Assert
        Assert.AreEqual("true", writer.ToString());
    }

    [Test]
    public void WriteJson_IntValue_WritesIntValue()
    {
        // Arrange
        BoolIntStringConverter converter = new BoolIntStringConverter();
        StringWriter writer = new StringWriter();
        JsonWriter jsonWriter = new JsonTextWriter(writer);
        object value = 42;

        // Act
        converter.WriteJson(jsonWriter, value, new JsonSerializer());

        // Assert
        Assert.AreEqual("42", writer.ToString());
    }

    [Test]
    public void WriteJson_NegativeIntValue_WritesIntValue()
    {
        // Arrange
        BoolIntStringConverter converter = new BoolIntStringConverter();
        StringWriter writer = new StringWriter();
        JsonWriter jsonWriter = new JsonTextWriter(writer);
        int value = -42;

        // Act
        converter.WriteJson(jsonWriter, value, new JsonSerializer());

        // Assert
        Assert.AreEqual("-42", writer.ToString());
    }

    [Test]
    public void WriteJson_StringValue_WritesStringValue()
    {
        // Arrange
        BoolIntStringConverter converter = new BoolIntStringConverter();
        StringWriter writer = new StringWriter();
        JsonWriter jsonWriter = new JsonTextWriter(writer);
        object value = "test";

        // Act
        converter.WriteJson(jsonWriter, value, new JsonSerializer());

        // Assert
        Assert.AreEqual("\"test\"", writer.ToString());
    }
    #endregion BoolIntStringConverter

    #region PlainJsonStringConverter 

    [Test]
    public void PlainJsonStringConverter_CanConvert_StringType_ReturnsTrue()
    {
        // Arrange
        PlainJsonStringConverter converter = new PlainJsonStringConverter();

        // Act
        bool result = converter.CanConvert(typeof(string));

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void PlainJsonStringConverter_CanConvert_OtherType_ReturnsFalse()
    {
        // Arrange
        PlainJsonStringConverter converter = new PlainJsonStringConverter();

        // Act
        bool result = converter.CanConvert(typeof(int));

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void PlainJsonStringConverter_ReadJson_ValidInput_ReturnsInputValue()
    {
        // Arrange
        PlainJsonStringConverter converter = new PlainJsonStringConverter();
        JsonReader reader = new JsonTextReader(new StringReader("\"test\""));

        // Act
        object result = converter.ReadJson(reader, typeof(string), null, new JsonSerializer());

        // Assert
        Assert.AreEqual("test", result);
    }

    [Test]
    public void WriteJson_ValidStringValue_WritesRawValue()
    {
        // Arrange
        PlainJsonStringConverter converter = new PlainJsonStringConverter();
        StringWriter writer = new StringWriter();
        JsonWriter jsonWriter = new JsonTextWriter(writer);
        object value = "test";

        // Act
        converter.WriteJson(jsonWriter, value, new JsonSerializer());

        // Assert
        Assert.AreEqual("\"test\"", writer.ToString());
    }

    [Test]
    public void WriteJson_NonStringValue_ThrowsArgumentException()
    {
        // Arrange
        PlainJsonStringConverter converter = new PlainJsonStringConverter();
        StringWriter writer = new StringWriter();
        JsonWriter jsonWriter = new JsonTextWriter(writer);
        object value = 42; // Non-string value

        // Act & Assert
        Assert.Throws<ArgumentException>(() => converter.WriteJson(jsonWriter, value, new JsonSerializer()));
    }
    #endregion PlainJsonStringConverter

    #region PaddingConverter
        [Test]
    public void CanConvert_PaddingType_ReturnsTrue()
    {
        // Arrange
        PaddingConverter converter = new PaddingConverter();

        // Act
        bool result = converter.CanConvert(typeof(Padding));

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void PaddingConverter_CanConvert_OtherType_ReturnsFalse()
    {
        // Arrange
        PaddingConverter converter = new PaddingConverter();

        // Act
        bool result = converter.CanConvert(typeof(int));

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void PaddingConverter_ReadJson_ValidInput_ReturnsInputValue()
    {
        // Arrange
        PaddingConverter converter = new PaddingConverter();
        JsonReader reader = new JsonTextReader(new StringReader("\"test\""));

        // Act
        object result = converter.ReadJson(reader, typeof(Padding), null, new JsonSerializer());

        // Assert
        Assert.AreEqual("test", result);
    }

    [Test]
    public void WriteJson_PaddingIntValue_WritesPaddingIntValue()
    {
        // Arrange
        PaddingConverter converter = new PaddingConverter();
        StringWriter writer = new StringWriter();
        JsonWriter jsonWriter = new JsonTextWriter(writer);
        Padding paddingValue = new Padding { PaddingInt = 42 };

        // Act
        converter.WriteJson(jsonWriter, paddingValue, new JsonSerializer());

        // Assert
        Assert.AreEqual("42", writer.ToString());
    }

    [Test]
    public void WriteJson_PaddingObjectValue_SerializesPaddingObject()
    {
        // Arrange
        PaddingConverter converter = new PaddingConverter();
        StringWriter writer = new StringWriter();
        JsonWriter jsonWriter = new JsonTextWriter(writer);
        Padding paddingValue = new Padding {  };

        // Act
        converter.WriteJson(jsonWriter, paddingValue, new JsonSerializer());

        // Assert
        Assert.AreEqual("{\"key\":\"value\"}", writer.ToString());
    }

    [Test]
    public void WriteJson_NullPaddingValue_ThrowsArgumentException()
    {
        // Arrange
        PaddingConverter converter = new PaddingConverter();
        StringWriter writer = new StringWriter();
        JsonWriter jsonWriter = new JsonTextWriter(writer);
        Padding paddingValue = null;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => converter.WriteJson(jsonWriter, paddingValue, new JsonSerializer()));
    }
    #endregion PaddingConverter
}
