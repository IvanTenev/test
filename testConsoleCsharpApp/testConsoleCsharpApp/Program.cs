using System;
using System.Collections.Generic;


namespace testConsoleCsharpApp
{
	interface ISize
	{
		int getSize ();
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			//Console.WriteLine ("Hello World!");
			//string ln1 = Console.ReadLine ();
			//Console.WriteLine (ln1);


			//create Mugs and fill them with initial amount of BEER
			Mug mg3 = new Mug (300);
			Mug mg5 = new Mug (500);
			Mug mg8 = new Mug (800, 800);
			//System.Collections.Generic.List<Mug> mugList = new System.Collections.Generic.List<Mug>(new Mug[] { mg3, mg5, mg8 });
			List<Mug> mugList = new List<Mug>(new Mug[] { mg3, mg5, mg8 });


			/*Mug currentMug = mg8;

			if(currentMug == mg8)
				currentMug = mg5;
			else if(currentMug == mg5)
				currentMug = mg3;
			else 
				currentMug = mg8;
*/

			/*Console.WriteLine (currentMug.getFilled ());

			Console.WriteLine ("---------------------------------");
			Console.WriteLine ("Mug 300: " + mg3.getFilled ());
			Console.WriteLine ("Mug 500: " + mg5.getFilled ());
			Console.WriteLine ("Mug 800: " + mg8.getFilled ());
*/

			foreach (Mug m in mugList) 
			{
				Console.WriteLine ("Mug " + m.getSize() + ": " +  m.filled);
			}
			Console.WriteLine ("---------------------------------");

			mg8.pourTO (mg3);
			mg8.pourTO (mg5);

			foreach (Mug m in mugList) 
			{
				Console.WriteLine ("Mug " + m.getSize() + ": " +  m.filled);
			}
			//or: 
			//mugList.Add (mg3);
			//mugList.Add (mg5);
			//mugList.Add (mg8);
			//Console.WriteLine(String.Concat ("t", "e", "s", "t"));


/*			Console.WriteLine ("---------------------------------");
			Console.WriteLine ("Mug 300: " + mg3.getFilled ());
			Console.WriteLine ("Mug 500: " + mg5.getFilled ());
			Console.WriteLine ("Mug 800: " + mg8.getFilled ());
*/

			/*mg3.filled=5;
			Console.WriteLine (mg3.filled); */

		}
	}


	class Mug
	{
		private int sizeML;
		private int filledML;

		public Mug(int sz, int fl=0) 
		{
			sizeML=sz;
			filledML=fl;
			//Console.WriteLine("Constructor called");
		}

		~Mug()
		{
			//Console.WriteLine("Destructor called");
		}

		//through property filled
		public int filled {
			set { filledML = value; }
			get { return(filledML); }
		}

		public static bool operator == (Mug lval, Mug rval)
		{ 
			if (lval.filledML == rval.filledML && lval.sizeML == rval.sizeML) return(true);
			else return(false);
		}

		public static bool operator != (Mug lval, Mug rval)
		{
			if (lval.filledML != rval.filledML || lval.sizeML != rval.sizeML) return(true);
			else return(false);
		}

		public int getSize() { return(sizeML); }
		public int getFilled() { return(filledML); }
		public void setFilled(int amountML) { filledML = amountML; }

		public int pourTO(Mug mg)
		{
			int remainsToML = mg.getSize () - mg.getFilled ();
			if (remainsToML >= this.filledML) {
				mg.setFilled (mg.getFilled() + this.filledML);
				this.filledML = 0;
			} else {
				mg.setFilled (mg.getSize());
				this.filledML -= remainsToML;
			}
			return(this.filledML);
		}
	}
}
