﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, merge,
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
// to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

using System;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp.Resolver
{
	/// <summary>
	/// Find all entities that are referenced in the scanned AST.
	/// </summary>
	public sealed class FindReferencedEntities : IResolveVisitorNavigator
	{
		readonly Action<AstNode, IEntity> referenceFound;
		
		public FindReferencedEntities(Action<AstNode, IEntity> referenceFound)
		{
			if (referenceFound == null)
				throw new ArgumentNullException("referenceFound");
			this.referenceFound = referenceFound;
		}
		
		public ResolveVisitorNavigationMode Scan(AstNode node)
		{
			return ResolveVisitorNavigationMode.Resolve;
		}
		
		public void Resolved(AstNode node, ResolveResult result)
		{
			if (ParenthesizedExpression.ActsAsParenthesizedExpression(node))
				return;
			
			MemberResolveResult mrr = result as MemberResolveResult;
			if (mrr != null) {
				referenceFound(node, mrr.Member.MemberDefinition);
			}
			TypeResolveResult trr = result as TypeResolveResult;
			if (trr != null) {
				ITypeDefinition typeDef = trr.Type.GetDefinition();
				if (typeDef != null)
					referenceFound(node, typeDef);
			}
			ForEachResolveResult ferr = result as ForEachResolveResult;
			if (ferr != null) {
				Resolved(node, ferr.GetEnumeratorCall);
				if (ferr.CurrentProperty != null)
					referenceFound(node, ferr.CurrentProperty);
				if (ferr.MoveNextMethod != null)
					referenceFound(node, ferr.MoveNextMethod);
			}
		}
		
		public void ProcessConversion(Expression expression, ResolveResult result, Conversion conversion, IType targetType)
		{
			if (conversion.IsUserDefined || conversion.IsMethodGroupConversion) {
				referenceFound(expression, conversion.Method.MemberDefinition);
			}
		}
	}
}
