using System;
using Fxt2Txt.Conversion;
using NUnit.Framework;

namespace Fxt2Txt.Test.Unit.Conversion
{
    [TestFixture]
    public class ConverterTests
    {
        private Converter _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new Converter(new FxtSerializer());
        }

        [Test]
        public void Execute_UnknownExtensionProvided_ThrowsException()
        {
            var input = new InputFile("FOO.BAR");

            Assert.Throws<InvalidOperationException>(() => _sut.Execute(input));
        }

        [Test]
        public void Execute_SuppliedFxtFile_GeneratesTextFile()
        {
            var input = new InputFile("TEST1.FXT");

            var outputFileName = _sut.Execute(input);

            Assert.That(outputFileName, Is.EqualTo("TEST1.TXT"));
        }

        [Test]
        public void Execute_SuppliedTxtFile_GeneratesFxtFile()
        {
            var input = new InputFile("TEST2.TXT");

            var outputFileName = _sut.Execute(input);

            Assert.That(outputFileName, Is.EqualTo("TEST2.FXT"));
        }
    }
}
