using System;
using NUnit.Framework;

namespace Fxt2Txt.Test.Unit
{
    [TestFixture]
    public class InputFileTests
    {
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void InvalidFileName_Throws(string fileName)
        {
            Assert.Throws<ArgumentException>(() => new InputFile(fileName));
        }

        [Test]
        public void Ctor_AnticipatedFile_PathIsStored()
        {
            var sut = new InputFile("BLAH.TXT");

            Assert.That(sut.Path, Is.EqualTo("BLAH.TXT"));
        }

        [Test]
        public void Ctor_GivenTxtFile_RecognisesAsTxtFile()
        {
            var sut = new InputFile("BLAH.TXT");

            Assert.That(sut.IsTxt, Is.True);
        }

        [Test]
        public void Ctor_GivenFxtFile_RecognisesAsFxtFile()
        {
            var sut = new InputFile("BLAH.FXT");

            Assert.That(sut.IsFxt, Is.True);
        }
    }
}
