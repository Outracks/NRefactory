﻿// 
// JoinStringAction.cs
// 
// Author:
//      Mansheng Yang <lightyang0@gmail.com>
// 
// Copyright (c) 2012 Mansheng Yang <lightyang0@gmail.com>
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CodeRefactorings;
using Microsoft.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ICSharpCode.NRefactory6.CSharp.Refactoring;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Simplification;
using Microsoft.CodeAnalysis.Formatting;

namespace ICSharpCode.NRefactory6.CSharp.Refactoring
{
	[NRefactoryCodeRefactoringProvider(Description = "Join string literals")]
	[ExportCodeRefactoringProvider("Join string literal", LanguageNames.CSharp)]
	public class JoinStringAction : SpecializedCodeAction<BinaryExpressionSyntax>
	{
		protected override IEnumerable<CodeAction> GetActions(Document document, SemanticModel semanticModel, SyntaxNode root, TextSpan span, BinaryExpressionSyntax node, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		} 
//		protected override CodeAction GetAction (SemanticModel context, BinaryOperatorExpression node)
//		{
//			if (node.Operator != BinaryOperatorType.Add)
//				return null;
//
//			PrimitiveExpression left;
//			var leftBinaryOperatorExpr = node.Left as BinaryOperatorExpression;
//			if (leftBinaryOperatorExpr != null && leftBinaryOperatorExpr.Operator == BinaryOperatorType.Add) {
//				left = leftBinaryOperatorExpr.Right as PrimitiveExpression;
//			} else {
//				left = node.Left as PrimitiveExpression;
//			}
//			var right = node.Right as PrimitiveExpression;
//
//			if (left == null || right == null ||
//				!(left.Value is string) || !(right.Value is string) || !node.OperatorToken.Contains(context.Location))
//				return null;
//
//			var isLeftVerbatim = left.LiteralValue.StartsWith("@", System.StringComparison.Ordinal);
//			var isRightVerbatime = right.LiteralValue.StartsWith("@", System.StringComparison.Ordinal);
//			if (isLeftVerbatim != isRightVerbatime)
//				return null;
//
//			return new CodeAction (context.TranslateString ("Join strings"), script => {
//				var start = context.GetOffset (left.EndLocation) - 1;
//				var end = context.GetOffset (right.StartLocation) + (isLeftVerbatim ? 2 : 1);
//				script.RemoveText (start, end - start);
//			}, node.OperatorToken);
//		}
	}
}
