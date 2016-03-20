using System;

namespace Telephone
{
	public class Telephone
	{
		public char[,] keymap = new char[8, 3] {
			{ 'a', 'b', 'c' },  //2
			{ 'd', 'e', 'f' },  //3
			{ 'g', 'h', 'i' },  //4
			{ 'j', 'k', 'l' },  //5
			{ 'm', 'n', 'o' }, //6
			{ 'p', 'r', 's' },  //7
			{ 't', 'u', 'v' }, //8
			{ 'w', 'x', 'y' }  //9
		};
		public char getCharkey(int telephonekey, int place){
			if (place > 3 || telephonekey > 9) {
				return (char)0;
			}
			else if (telephonekey >= 2 && place >= 1) {
				return keymap [telephonekey - 2, place - 1];
			} else {
				return Convert.ToChar (telephonekey.ToString());
			}
		}

		private int [] phoneNum;
		private char[] result = new char[7];

		public Telephone ( int[] n ) {
			phoneNum =n;
		}
		public void printWords() { 
			printWords(0);
		}
		/* if current number passes the last number
		 * 	it's the last, return the word;
		 * else 
		 * 	for three current number
		 *   current number -> the word;
		 *   recursion
		 * 	 if number is 0 or 1, return; */
		public void printWords(int digit){
			if (digit == 7) {
				Console.WriteLine (new String (result));
				return;
			}
				for (int i = 1; i <= 3; ++i) {
				result [digit] = getCharkey (phoneNum [digit], i);

				printWords (digit + 1);
				if (phoneNum [digit] == 0 || phoneNum[digit] == 1) {
					return;
				}
			}
		}
		/* generate each number by first numbers
		 * infinite loop
		 * 		Print number
		 * 		increase the last letter, if needed, increase the left one.
		 * 		if the very first letter reset, loop finishes.
		 *		O , 1 exception
		 *	gwp1wap
		 *	gwp1war
		 *	gwp1was
		 *	gwp1wbp
		 *	gwp1wbr
		 *
		*/
		public void printWords2(){
			for (int i = 0; i < 7; ++i) {
				result [i] = getCharkey (phoneNum [i], 1);
			}
			for (;;) {
				for (int i = 0; i < 7; ++i) {
					Console.Write(result [i]);
				}
				Console.Write("\n");
				for (int i = 6; i >= -1; --i)
				{
					if (i == -1)
						return;
					if (getCharkey (phoneNum [i], 3) == result [i] || phoneNum [i] == 0 || phoneNum [i] == 1) {
						result [i] = getCharkey (phoneNum [i], 1);  //move on to the next number
					} else if (getCharkey (phoneNum [i], 1) == result [i]) {
						result [i] = getCharkey (phoneNum [i], 2);
						break;
					} else if (getCharkey (phoneNum [i], 2) == result [i]){
						result [i] = getCharkey (phoneNum [i], 3);
						break;
					}
				}
			}
		}

		public static void Main (string[] args)
		{
			int[] number = {4,9,7,1,9,2,7};
			Telephone telephone = new Telephone (number);

			Console.WriteLine (telephone.getCharkey(3,3));
			//telephone.printWords ();
			telephone.printWords2 ();

			Console.WriteLine ("Hello World!");
		}
	}
}
