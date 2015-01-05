using System;

namespace consoleApp
{
	public class cl1:IWriteParams
	{
		private int m1;
		private int m2;
		public int M1 
		{
			get{ return m1; }
			set { m1 = value;}
		}
	
		public int M2
		{
			get{ return m2; }
			set { m2 = value; }
		}

		public cl1()
		{
			m1=0;
			m2=10;
		}

		public void WriteParams()
		{
			Console.WriteLine ("I am cl1 class");
			throw new Exception("I am exception of the cl1 class");
		}
	}

	interface ITest{
		int test(int it);
	}

	interface IWriteParams {
		void  WriteParams();
	}

	class MainClass: IWriteParams
	{
		public void WriteParams()
		{
			Console.WriteLine ("I am MainClass");
		}

		public static void Main (string[] args)
		{
			cl1 cl1Obj; 
			cl1Obj = new cl1(); 
			Console.WriteLine ("Hello World! {0}", cl1Obj.M2);
			//WriteParams ();
			MainClass mc = new MainClass ();
			mc.WriteParams ();
			//cl1Obj.WriteParams ();

			BNode<int> BNode = new BNode<int>(5);
		}
	}

	class BNode<D>
	{
		private D data;
		public BNode(D data)
		{
			this.data = data;
		}

		BNode<D> left;
		BNode<D> right;

		public D DATA
		{
			get{ return data; }
			set{ data = value;}
		}

		public void addNode(D data)
		{
		}

		public D findNode(D data)
		{
			return data;
		}
	}
}
