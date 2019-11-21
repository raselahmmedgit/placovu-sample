using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DocGenerator
{
	public static class SyntaxNodeExtensions
	{
        private static readonly Regex SingleLineHideComment = new Regex(@"\/\/\s*hide", RegexOptions.Compiled);
        private static readonly Regex SingleLineJsonComment = new Regex(@"\/\/\s*json", RegexOptions.Compiled);

        /// <summary>
        /// Determines if the node should be hidden i.e. not included in the documentation,
        /// based on the precedence of a //hide single line comment
        /// </summary>
        public static bool ShouldBeHidden(this SyntaxNode node) => 
            node.HasLeadingTrivia && ShouldBeHidden(node, node.GetLeadingTrivia());

        public static bool ShouldBeHidden(this SyntaxNode node, SyntaxTriviaList leadingTrivia) =>
            leadingTrivia != default(SyntaxTriviaList) &&
            SingleLineHideComment.IsMatch(node.GetLeadingTrivia().ToFullString());

        /// <summary>
        /// Determines if the node should be json serialized based on the precedence of
        /// a //json single line comment
        /// </summary>
        public static bool ShouldBeConvertedToJson(this SyntaxNode node) => 
            node.HasLeadingTrivia && ShouldBeConvertedToJson(node, node.GetLeadingTrivia());

        /// <summary>
        /// Determines if the node should be json serialized based on the precedence of
        /// a //json single line comment
        /// </summary>
        public static bool ShouldBeConvertedToJson(this SyntaxNode node, SyntaxTriviaList leadingTrivia)
        {
            if (leadingTrivia == default(SyntaxTriviaList))
                return false;

            var singleLineCommentIndex = leadingTrivia.IndexOf(SyntaxKind.SingleLineCommentTrivia);

            if (singleLineCommentIndex == -1)
                return false;

            // all trivia after the single line should be whitespace or end of line
            if (!leadingTrivia
                .SkipWhile((l, i) => i < singleLineCommentIndex)
                .Any(l => l.IsKind(SyntaxKind.EndOfLineTrivia) || l.IsKind(SyntaxKind.WhitespaceTrivia)))
            {
                return false;
            }

            return SingleLineJsonComment.IsMatch(leadingTrivia.ElementAt(singleLineCommentIndex).ToFullString());
        }

        /// <summary>
        /// Determines if the node is preceded by any multiline documentation.
        /// </summary>
        /// <param name="node">The node.</param>
        public static bool HasMultiLineDocumentationCommentTrivia(this SyntaxNode node) => 
            node.HasLeadingTrivia &&
	        node.GetLeadingTrivia().Any(c => c.IsKind(SyntaxKind.MultiLineDocumentationCommentTrivia));

        /// <summary>
        /// Try to get the json representation of the first anonymous object expression descendent
        /// node.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        public static bool TryGetJsonForSyntaxNode(this SyntaxNode node, out string json)
        {
            json = null;

            // find the first anonymous object expression
            var creationExpressionSyntax = node.DescendantNodes()
                .OfType<AnonymousObjectCreationExpressionSyntax>()
                .FirstOrDefault();

            return creationExpressionSyntax != null &&
                   creationExpressionSyntax.ToFullString().TryGetJsonForAnonymousType(out json);
        }

        /// <summary>
        /// Gets the starting line of the node
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        public static int StartingLine(this SyntaxNode node) => 
            node.SyntaxTree.GetLineSpan(node.Span).StartLinePosition.Line;

	    public static SyntaxNode WithLeadingEndOfLineTrivia(this SyntaxNode node)
	    {
	        var leadingTrivia = node.GetLeadingTrivia();
	        var triviaToRemove = leadingTrivia.Reverse().SkipWhile(t => t.IsKind(SyntaxKind.EndOfLineTrivia));
	        foreach (var syntaxTrivia in triviaToRemove)
	        {
                node = node.ReplaceTrivia(syntaxTrivia, default(SyntaxTrivia));
            }

	        return node;
	    }
    }
}