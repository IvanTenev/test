using NUnit.Framework;
using System;
using consoleApp;

namespace testNunitSolution
{
	[TestFixture()]
	public class Test
	{
		private bool Error=false;

		[SetUp]
		public void TestSetup()
		{
			Assert.False (Error);
			Console.WriteLine ("Test setup");
		}

		[Test()]
		public void TestCase_IsInstanceOf_cl1 ()
		{
			//Assert.Pass ("pass exception");
			//Assert.Fail ();
			cl1 cl1Obj = new cl1 ();
			Assert.IsInstanceOf<cl1> (cl1Obj);
		}

		[Test()]
		public void TestCase_AreEqual1 ()
		{
			cl1 cl1Obj = new cl1 ();
			//Assert.AreEqual (cl1Obj.M1, 1);
			Assert.That (cl1Obj.M1==0);
		}

		[Test()]
		public void TestCase_IsM1eq0 ()
		{
			cl1 cl1Obj = new cl1 ();
			Assert.IsTrue (cl1Obj.M1 == 0);
		}

		[Test()]
		public void TestCase_InterfaceWriteParams()
		{
			cl1 cl = new cl1 ();
			//Assert.IsNotEmpty (cl.WriteParams ());
			Assert.IsNull (cl);
		}

		[Test()]
		[ExpectedException()]
		public void TestCase_ExceptionTest()
		{
			cl1 cl = new cl1 ();
			cl.WriteParams ();
		}

		[Test]
		public void TestCase_01_Fail()
		{
			Assert.Fail ("failure");
			Console.WriteLine ("After failure");
		}

		[Test]
		public void TestCase_02_Inconclusive()
		{
			Assert.Inconclusive ("inconclusive");
		}

		[Test]
		public void TestCase_03_Ignore()
		{
			Assert.Ignore ("ignore");
		}

		[Test]
		public void TestCase_00_SetError()
		{
			//Error=true; Assert.Fail ();
		}

		private void t1()
		{
			Console.WriteLine ("test function");
		}
	}
}