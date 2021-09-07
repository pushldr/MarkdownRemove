using System;
using NUnit.Framework;

namespace MarkdownRemove.Tests
{
    public class CustomOptions
    {
        private MarkdownRemover _markdownRemover;

        [SetUp]
        public void Setup()
        {
            _markdownRemover = new MarkdownRemover(delegate(MarkdownRemoverOptions options)
            {
                options.StripListLeaders = true;
                options.ListLeaderChar = "-";
                options.RemoveInlineLinks = false;
                options.UseImgAltText = true;
            });
        }

        [Test]
        public void TestStripListLeaders()
        {
            var input = 
                        "1. Item1\n" +
                        "2. Item2\n" +
                        "3. Item3\n" +
                        "4. Item4";
            var output = _markdownRemover.RemoveMarkdown(input);
            var expected = 
                            "- Item1\n" +
                           "- Item2\n" +
                           "- Item3\n" +
                           "- Item4";
            Console.WriteLine(output);
            Assert.AreEqual(expected, output);
            
        }

        [Test]
        public void TestRemoveInlineLinks()
        {
            var input = "[this](https://example.com)";
            var output = _markdownRemover.RemoveMarkdown(input);
            Assert.AreEqual(input, output);
        }

        [Test]
        public void TestRemoveImages()
        {
            var input = "![Image](/assets/images/sample.png)";
            var output = _markdownRemover.RemoveMarkdown(input);
            var expected = "Image";
            Assert.AreEqual(expected, output);
        }
    }
}