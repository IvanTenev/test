using NUnit.Framework;
using System;
using consoleApp;

namespace testNunitSolution
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void TestCaseIsInstanceOf_cl1 ()
		{
			//Assert.Pass ("pass exception");
			//Assert.Fail ();
			cl1 cl1Obj = new cl1 ();
			Assert.IsInstanceOf<cl1> (cl1Obj);
		}

		[Test()]
		public void TestCaseAreEqual1 ()
		{
			cl1 cl1Obj = new cl1 ();
			Assert.AreEqual (cl1Obj.M1, 1);
		}

		[Test()]
		public void TestCase_IsM1eq0 ()
		{
			cl1 cl1Obj = new cl1 ();
			Assert.IsTrue (cl1Obj.M1 == 0);
		}
	}
}