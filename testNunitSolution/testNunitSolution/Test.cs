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
		private bool Error=false;

		[SetUp]
		public void TestSetup()
		{
			Assert.False (Error);
			Console.WriteLine ("Test setup");
		}

		[Test()]
		public void Test_IsInstanceOf_cl1 ()
		{
			//Assert.Pass ("pass exception");
			//Assert.Fail ();
			cl1 cl1Obj = new cl1 ();
			Assert.IsInstanceOf<cl1> (cl1Obj);
		}

		[Test()]
		public void Test_AreEqual1 ()
		{
			cl1 cl1Obj = new cl1 ();
			//Assert.AreEqual (cl1Obj.M1, 1);
			Assert.That (cl1Obj.M1==0);
		}

		[Test()]
		public void Test_IsM1eq0 ()
		{
			cl1 cl1Obj = new cl1 ();
			Assert.IsTrue (cl1Obj.M1 == 0);
		}

		[Test()]
		public void Test_InterfaceWriteParams()
		{
			cl1 cl = new cl1 ();
			Assert.IsNotNull (cl);
		}

		[Test()]
		[ExpectedException()]
		public void Test_ExceptionTest()
		{
			cl1 cl = new cl1 ();
			cl.WriteParams ();
		}

		[Test]
		public void Test_10_Fail()
		{
			Assert.Fail ("failure");
		}

		[Test]
		public void Test_11_Inconclusive()
		{
			Assert.Inconclusive ("inconclusive");
		}

		[Test]
		public void Test_13_Ignore()
		{
			Assert.Ignore ("ignore");
		}

		[Test]
		public void Test_99_SetError()
		{
			//Error=true; 
			//Assert.Fail ();
		}

		[Test]
		public void Test_05_HttpServer()
		{
			if (!testHttp ("http://192.168.9.1:80 ")) 
			{
				Error = true;
				Assert.Fail ("The web service is not available on this address");
			}
		}

		[Test]
		public void Test_04_PingAddress()
		{
			if (!testPing (IPAddress.Parse("192.168.9.1"))) 
			{
				Error = true;
				Assert.Fail ("Device is not present in the network");
			}
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
	}
}