# MarkdownRemove

## Install via NuGet [![NuGet](https://img.shields.io/nuget/v/MarkdownRemove.svg)](https://www.nuget.org/packages/MarkdownRemove/) 

`Install-Package MarkdownRemove`
 
 
 ## About
 
- Small simple C# library to remove markdown from text

- C# Port of the node.js module [remove-markdown](https://github.com/stiang/remove-markdown) licensed under the MIT License. See [LICENSE](https://github.com/stiang/remove-markdown/blob/master/LICENSE) for the full License.
  
  
## Quick Example

```cs

var markdownRemover = new MarkdownRemover(); // To create a markdown remover with default options


var markdownRemover = new MarkdownRemover(delegate(MarkdownRemoverOptions options) // Or to create a markdown remover with customised options
{
    options.UseImgAltText = true;
});

var text = "![Image](/assets/images/sample.png)";
var textWithoutMarkdown = markdownRemover.RemoveMarkdown(text);
```  
  
