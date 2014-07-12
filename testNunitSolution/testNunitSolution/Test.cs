using NUnit.Framework;
using System;
using consoleApp;

namespace testNunitSolution
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void TestCase ()
		{
			//Assert.Pass ("pass exception");
			//Assert.Fail ();
			//Assert.
			cl1 cl1Obj = new cl1 ();
			Assert.IsInstanceOf<cl1> (cl1Obj);
			Assert.IsTrue (cl1Obj.M1 == 0);
			Assert.AreEqual (cl1Obj.M1, 1);
			//Assert.Fail ();
		}
	}
}