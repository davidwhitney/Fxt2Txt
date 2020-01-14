using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Fxt2Txt.Test.Unit
{
    public class FxtSerializerTests
    {
        private FxtSerializer _sut;
        [SetUp] public void Setup() => _sut = new FxtSerializer();

        [Test]
        public void Serialize_OneRowOfTextProvided_GeneratesByteStream()
        {
            var entries = new List<string> { "[100]This is a test" };

            var data = _sut.Serialize(entries).ToList();
            
            Assert.That(data.Count, Is.GreaterThan(0));
        }

        [Test]
        public void Deserialize_OneRowOfTextProvided_ReturnsCorrectNumberOfRows()
        {
            var entries = new List<string> { "[100]This is a test" };

            var data = _sut.Serialize(entries).ToList();
            var result = _sut.Deserialize(data).ToList();
            
            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public void Deserialize_OneRowOfTextProvided_DeserializesData()
        {
            var entries = new List<string> { "[100]This is a test" };

            var data = _sut.Serialize(entries).ToList();
            var result = _sut.Deserialize(data).ToList();
            
            Assert.That(result[0], Is.EqualTo(entries[0]));
        }

        [Test]
        public void Deserialize_FooterRequested_AddsFooterBraces()
        {
            var entries = new List<string> { "[100]This is a test" };

            var data = _sut.Serialize(entries, true).ToList();
            var result = _sut.Deserialize(data).ToList();
            
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result[1], Is.EqualTo("[]\u001a"));
            Assert.That(result[2], Is.EqualTo("[]"));
        }
    }
}