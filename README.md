# MarkdownRemove
 

C# Port of the node.js module [remove-markdown](https://github.com/stiang/remove-markdown) licensed under the MIT License. See [LICENSE](https://github.com/stiang/remove-markdown/blob/master/LICENSE) for the full License.
  
```cs

var markdownRemover = new MarkdownRemover(); // To create a markdown remover with default options


var markdownRemover = new MarkdownRemover(delegate(MarkdownRemoverOptions options) // Or to create a markdown remover with customised options
{
    options.UseImgAltText = true;
});

var text = "![Image](/assets/images/sample.png)";
var textWithoutMarkdown = markdownRemover.RemoveMarkdown(text);
```  
  
