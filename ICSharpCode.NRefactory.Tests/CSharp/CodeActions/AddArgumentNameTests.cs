﻿// 
// AddArgumentNameTests.cs
// 
// Author:
//      Ji Kun <jikun.nus@gmail.com>
// 
// Copyright (c) 2013 Ji Kun <jikun.nus@gmail.com>
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
using ICSharpCode.NRefactory.CSharp.Refactoring;
using NUnit.Framework;

namespace ICSharpCode.NRefactory.CSharp.CodeActions
{
	[TestFixture]
	public class AddArgumentNameTests : ContextActionTestBase
	{
		[Test]
		public void MethodInvocation1()
		{
			Test<AddArgumentNameAction>(@"
class TestClass
{
	public void Foo(int a, int b, float c = 0.1){}
	public void F()
	{
		Foo($1,b: 2);
	}
}", @"
class TestClass
{
	public void Foo(int a, int b, float c = 0.1){}
	public void F()
	{
		Foo (a: 1, b: 2);
	}
}");
		}

		[Test]
		public void MethodInvocation2()
		{
			Test<AddArgumentNameAction>(@"
class TestClass
{
	public void Foo(int a, int b, float c = 0.1){}
	public void F()
	{
		Foo($1, 2);
	}
}", @"
class TestClass
{
	public void Foo(int a, int b, float c = 0.1){}
	public void F()
	{
		Foo (a: 1, b: 2);
	}
}");
		}

		[Test]
		public void AttrbuteUsage()
		{
			Test<AddArgumentNameAction>(@"
public class AnyClass
{ 
[Obsolete($"" "", error: true)]
    static void Old() { }

    static void New() { }
}
", @"
public class AnyClass
{
	[Obsolete(message: "" "", error: true)]
	static void Old() { }
}");
		}
	}
}