using NUnit.Framework;

namespace Fxt2Txt.Test.Unit
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        public void Main_NoArgsProvided_ExitsWithMinusOneCode()
        {
            var result = Program.Main(new string[0]);

            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public void Main_ValidFileProvided_ExitsWithZeroCode()
        {
            var result = Program.Main(new[] { "TEST1.FXT" });

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Main_ValidFileProvided_InvokesConverter()
        {
            var called = false;
            Program.Convert = file =>
            {
                called = true;
                return "";
            };

            Program.Main(new[] { "TEST1.FXT" });

            Assert.That(called, Is.True);
        }
    }
}
