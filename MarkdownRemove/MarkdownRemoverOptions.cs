namespace MarkdownRemove
{
    public class MarkdownRemoverOptions
    {
        public bool Gfm = true;                 
        public bool UseImgAltText = false;    
        public bool ReplaceTwoOrMoreNewLinesWithOne = true;
        public bool RemoveInlineCode = true;
        public bool RemoveCodeBlocks = true;
        public bool RemoveEmphasis = true;
        public bool RemoveAtxStyleHeaders = true;
        public bool RemoveReferenceStyleLinks = true;
        public bool RemoveBlockquotes = true;
        public bool RemoveInlineLinks = true;
        public bool RemoveImages = true;
        public bool RemoveFootnotes = true;
        public bool RemoveSeTextStyleHeaders = true;
        public bool RemoveHtmlTags = true;
        public bool RemoveFencedCodeblocks = true;
        public bool RemoveStrikethrough = true;
    }
}