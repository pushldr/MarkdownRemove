using System;
using NUnit.Framework;

namespace MarkdownRemove.Tests
{
    public class DefaultOptions
    {
        private MarkdownRemover _markdownRemover;

        [SetUp]
        public void Setup()
        {
            _markdownRemover = new MarkdownRemover();
        }

        [Test]
        public void TestRemoveAtxStyleHeaders()
        {
            var input = "# Title\n" +
                        "\n" +
                        "This is a paragraph describing something.\n" +
                        "Something something something\n" +
                        "\n" +
                        "## More info\n" +
                        "- Item1\n" +
                        "- Item2\n" +
                        "- Item3\n" +
                        "- Item4";
            var output = _markdownRemover.RemoveMarkdown(input);
            var expected = "Title\n" +
                           "\n" +
                           "This is a paragraph describing something.\n" +
                           "Something something something\n" +
                           "\n" +
                           "More info\n" +
                           "- Item1\n" +
                           "- Item2\n" +
                           "- Item3\n" +
                           "- Item4";
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void TestRemoveInlineLinks()
        {
            var input = "[this](https://example.com)";
            var output = _markdownRemover.RemoveMarkdown(input);
            var expected = "this";
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void TestRemoveImages()
        {
            var input = "![Image](/assets/images/sample.png)";
            var output = _markdownRemover.RemoveMarkdown(input);
            var expected = "";
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void TestRemoveHtmlTags()
        {
            var input = "<title>Test</title>";
            var output = _markdownRemover.RemoveMarkdown(input);
            var expected = "Test";
            Assert.AreEqual(expected, output);
        }
        
        [Test]
        public void TestRemoveEmphasis()
        {
            var input = "**THIS**";
            var output = _markdownRemover.RemoveMarkdown(input);
            var expected = "THIS";
            Assert.AreEqual(expected, output);
        }
    }
}