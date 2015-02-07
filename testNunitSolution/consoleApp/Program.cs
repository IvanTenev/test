using System;

namespace consoleApp
{
	abstract class abClass
	{
		public abstract string GetName ();

	}

	class abChild : abClass
	{
		public override string GetName()
		{
			//return this.GetType ().ToString ();
			return("abChild");
		}
	}

	class abChild2 : abClass
	{
		public override string GetName()
		{
			//return this.GetType ().ToString ();
			return("abChild2");
		}
	}



	static class sClass1 
	{
		static int a;
		static sClass1()
		{
			a = 7;
		}
		static public void printName()
		{
			Console.WriteLine ("sClass1:{0}",a);
		}
	}


	interface IPrintName
	{
		void printName();
	}

	class A : IPrintName
	{
		public void printName()
		{
			Console.WriteLine ("A");
		}

		public virtual void printNameOVR()
		{
			Console.WriteLine ("Ao");
		}

	}

	class B : A , IPrintName
	{
		new public void printName()
		{
			Console.WriteLine ("B");
		}

		public override void printNameOVR()
		{
			Console.WriteLine ("Bo");
		}

		public void printNameBase()
		{
			base.printName ();
		}

	}

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
	//		cl1 cl1Obj; 
	//		cl1Obj = new cl1(); 
	//		Console.WriteLine ("Hello World! {0}", cl1Obj.M2);
	//		//WriteParams ();
	//		MainClass mc = new MainClass ();
	//		mc.WriteParams ();
			//cl1Obj.WriteParams ();

	//		BNode<int> BNode = new BNode<int>(5);

			Console.WriteLine ("direct access");
			sClass1.printName ();

			A a = new A();
			a.printName ();
			a.printNameOVR ();

			B b = new B();
			b.printName();
			b.printNameOVR ();
			Console.WriteLine ("Print base.");b.printNameBase ();

			Console.WriteLine ("through reference to the base class+override");
			A c;
			c = a;
			c.printName ();
			c.printNameOVR ();
			c = b;
			c.printName ();
			c.printNameOVR ();

			Console.WriteLine ("through interface");
			IPrintName ipn;
			ipn = a;
			ipn.printName ();
			ipn = b;
			ipn.printName ();

			abClass abc;

			abChild ab0 = new abChild ();
			abChild2 ab1 = new abChild2 ();

			Console.WriteLine ("through abstract class");
			abc = ab0;
			Console.WriteLine (abc.GetName ());

			abc = ab1;
			Console.WriteLine (abc.GetName ());

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
