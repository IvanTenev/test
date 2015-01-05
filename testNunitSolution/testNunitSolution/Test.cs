using NUnit.Framework;
using System;
using consoleApp;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace testNunitSolution
{
	[TestFixture()]
	public class Test
	{
		private bool StopTestExecution=false;
		private int i=0;

		[TestFixtureSetUp]
		public void Init()
		{
			//
			Console.WriteLine ("Fixture setup");
			//Debug.WriteLine ("test");
			i++;
		}

		[SetUp]
		public void TestSetup()
		{
			Assert.False (StopTestExecution);
			Console.WriteLine ("Test setup"+i.ToString());
		}

		[Test(), Description("test number 74")]
		public void _74_IsInstanceOf_cl1 ()
		{
			//Assert.Pass ("pass exception");
			//Assert.Fail ();
			cl1 cl1Obj = new cl1 ();
			Assert.IsInstanceOf<cl1> (cl1Obj);
		}

		[Test()]
		public void _70_AreEqual1 ()
		{
			cl1 cl1Obj = new cl1 ();
			//Assert.AreEqual (cl1Obj.M1, 1);
			Assert.That (cl1Obj.M1==0);
		}

		[Test()]
		public void _71_IsM1eq0 ()
		{
			cl1 cl1Obj = new cl1 ();
			Assert.IsTrue (cl1Obj.M1 == 0);
		}

		[Test()]
		public void _73_InterfaceWriteParams()
		{
			cl1 cl = new cl1 ();
			Assert.IsNotNull (cl);
		}

		[Test()]
		[ExpectedException()]
		public void _72_ExceptionTest()
		{
			cl1 cl = new cl1 ();
			cl.WriteParams ();
		}

		[Test]
		public void _10_Fail()
		{
			Assert.Fail ("failure");
		}

		[Test]
		public void _11_Inconclusive()
		{
			Console.WriteLine (	TestContext.CurrentContext.Result.Status.ToString());
			Console.WriteLine (TestContext.CurrentContext.Test.Name.ToString());
			Assert.Inconclusive ("inconclusive");
		}

		[Test]
		public void _13_Ignore()
		{
			Assert.Ignore ("ignore");
		}

		[Test]
		public void _99_SetError()
		{
			//Error=true; 
			//Assert.Fail ();
		}

		[Test]
		public void _05_HttpServer()
		{
			if (!testHttp ("http://192.168.9.1:80 ")) 
			{
				StopTestExecution = true;
				Assert.Fail ("The web service is not available on this address");
			}
		}

		[Test]
		public void _04_PingAddress()
		{
			if (!testPing (IPAddress.Parse("192.168.9.1"))) 
			{
				StopTestExecution = true;
				Assert.Fail ("Device is not present in the network");
			}
		}

		[TestCase(12,3,4)]
		[TestCase(12,2,6)]
		[TestCase(12,4,3)]
		public void DivideTest(int n, int d, int q)
		{
			Assert.AreEqual( q, n / d );
		}

		[TestCase(12,3, Result=4)]
		[TestCase(12,2, Result=5)]
		[TestCase(12,4, Result=3)]
		public int DivideTest2(int n, int d)
		{
			return( n / d );
		}

		private bool testHttp(string url)
		{
			try
			{
				//Creating the HttpWebRequest
				HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
				//Setting the Request method HEAD, you can also use GET too.
				request.Method = "HEAD";
				//Getting the Web Response.
				HttpWebResponse response = request.GetResponse() as HttpWebResponse;
				//Returns TURE if the Status code == 200
				return (response.StatusCode == HttpStatusCode.OK);
			}
			catch
			{
				//Any exception will returns false.
				return false;
			}
		}

		private bool testPing(IPAddress ip)
		{
			Ping pingSender = new Ping ();
			PingOptions options = new PingOptions ();

			// Use the default Ttl value which is 128, 
			// but change the fragmentation behavior.
			options.DontFragment = true;

			// Create a buffer of 32 bytes of data to be transmitted. 
			string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
			byte[] buffer = Encoding.ASCII.GetBytes (data);
			int timeout = 120;
			PingReply reply = pingSender.Send (ip, timeout, buffer, options);

			if (reply.Status != IPStatus.Success)
				return(false);
			else
				return(true);

		}

		[TestFixtureTearDown]
		public void Closure()
		{
			Console.WriteLine ("End of test!");
		}


	}
}