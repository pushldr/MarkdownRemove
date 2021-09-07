using System;
using System.Text.RegularExpressions;

namespace MarkdownRemove
{
    public class MarkdownRemover
    {
        private readonly MarkdownRemoverOptions _options;

        public MarkdownRemover()
        {
            _options = new MarkdownRemoverOptions();
        }
        
        public MarkdownRemover(Action<MarkdownRemoverOptions> options)
        {
            _ = options ?? throw new ArgumentNullException(nameof(options));
            
            _options = new MarkdownRemoverOptions();
            
            options(_options);
        }

        /// <summary>
        /// Removes markdown based on the options passed to the remover
        /// </summary>
        /// <param name="text">Text to remove markdown from</param>
        /// <returns>Text without markdown</returns>
        public string RemoveMarkdown(string text)
        {
            string output = String.Copy(text);
            
            
            output = Regex.Replace(output, "^(-\\s*?|\\*\\s*?|_\\s*?){3,}\\s*$", "", RegexOptions.Multiline);
            
         
            if (_options.StripListLeaders) 
                output = Regex.Replace(output, @"^([\f\r\t]*)([\*\-\+]|\d+\.)\s",  string.IsNullOrEmpty(_options.ListLeaderChar) ? "$1" : $"{_options.ListLeaderChar} $1", RegexOptions.Multiline);
            
            
            if (_options.Gfm) {
                
                // Header
                //output = Regex.Replace(output, "\n={2,}",  "\n");
                    
                if(_options.RemoveFencedCodeblocks)
                    output = Regex.Replace(output, "~{3}.*\n",  "");
                    
                // Strikethrough
                if(_options.RemoveStrikethrough)
                    output = Regex.Replace(output, "~~",  "");
                    
                // Fenced codeblocks
                if(_options.RemoveFencedCodeblocks)
                    output = Regex.Replace(output, "`{3}.*\n",  "");
            }
            
            // Remove HTML tags
            if(_options.RemoveHtmlTags) 
                output = Regex.Replace(output, "<[^>]*>",  "");
            
            // Remove setext-style headers
            if (_options.RemoveSeTextStyleHeaders)
                output = Regex.Replace(output, "^[=\\-]{2,}\\s*$", "");

            // Remove footnotes?
            if (_options.RemoveFootnotes)
            {
                output = Regex.Replace(output, "\\[\\^.+?\\](\\: .*?$)?", "");
                output = Regex.Replace(output, "\\s{0,2}\\[.*?\\]: .*?$", "");
            }

            // Remove images
            if(_options.RemoveImages)
                output = Regex.Replace(output, @"\!\[(.*?)\][\[\(].*?[\]\)]",  _options.UseImgAltText ? "$1" : "");
            
            // Remove inline links
            if(_options.RemoveInlineLinks)
                output = Regex.Replace(output, @"\[(.*?)\][\[\(].*?[\]\)]",  "$1");

            // Remove blockquotes
            if(_options.RemoveBlockquotes)
                output = Regex.Replace(output, @"^\s{0,3}>\s?",  "");
            
            // Remove reference-style links?
            if(_options.RemoveReferenceStyleLinks)
                output = Regex.Replace(output, "^\\s{1,2}\\[(.*?)\\]: (\\S+)( \".*?\")?\\s*$",  "");

            // Remove atx-style headers
            if(_options.RemoveAtxStyleHeaders)
                output = Regex.Replace(output, @"^(\n)?\s{0,}#{1,6}\s+| {0,}(\n)?\s{0,}#{0,} {0,}(\n)?\s{0,}$",  "$1$2$3", RegexOptions.Multiline);
                
            // Remove emphasis (repeat the line to remove double emphasis)
            if (_options.RemoveEmphasis)
            {
                output = Regex.Replace(output, @"([\*_]{1,3})(\S.*?\S{0,1})\1", "$2");
                output = Regex.Replace(output, @"([\*_]{1,3})(\S.*?\S{0,1})\1", "$2");
            }

            // Remove code blocks
            if(_options.RemoveCodeBlocks)
                output = Regex.Replace(output, @"(`{3,})(.*?)\1",  "$2", RegexOptions.Multiline);
                
            // Remove inline code
            if(_options.RemoveInlineCode)
                output = Regex.Replace(output, @"`(.+?)`",  "$1");
                
            // Replace two or more newlines with exactly two? Not entirely sure this belongs here...
            if(_options.ReplaceTwoOrMoreNewLinesWithOne)
                output = Regex.Replace(output, @"\n{2,}",  "\n\n");

            return output;

        }
        
        
    }
    
}