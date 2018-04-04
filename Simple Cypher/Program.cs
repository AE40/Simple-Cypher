using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Cypher {
	class Program {

		static int codeLength = 5;
		static string charset = "abcdefghijklmnopqrstuvwxyz0123456789";

		static void Main( string [] args ) {


			Console.WriteLine( "What code length would you like?" );

			while( true ) {
				string s = Console.ReadLine();
				int num;
				if( int.TryParse( s, out num ) ) {
					codeLength = num;
					break;
				} else {
					Console.WriteLine( "That's not a number, enter a number" );
				}
			}

			while( true ) {

				string code = GenerateCode();
				int attempts = 0;

				Console.Clear();
				Console.WriteLine( "Enter your first number" );

				for( int i = 0; i < codeLength; i++ ) {

					char codeChar = code [ i ];
					int codeCharID = GetCharsetID( codeChar );

					while( true ) { //keep retrying
						ConsoleKeyInfo key = Console.ReadKey( true );
						char c = key.KeyChar;

						if( charset.Contains( c ) ) {
							//char within charset

							int charID = GetCharsetID( c );
							attempts++;

							if( codeChar == c ) {
								//char correct

								Console.Clear();
								Console.WriteLine( "{0} Is Correct", c );
								break; //dont retry
							} else {

								//char incorrect
								Console.WriteLine( "{0} Is Incorrect", c );

								if( charID > codeCharID ) {
									Console.WriteLine( "Aim lower" );  // too high
								} else {
									Console.WriteLine( "Aim higher" ); // too low
								}

							}
						}
					}
				}
				Console.Clear();
				Console.WriteLine( "The code was: {0}", code );
				Console.WriteLine( "It took you {0} attempts to guess the full code", attempts );
				Console.ReadLine();
				Console.Clear();
			}
		}
		public static int GetCharsetID( char c ) {
			for( int i = 0; i < charset.Length; i++ ) {
				if( charset [ i ] == c )
					return i;
			}
			throw new ArgumentOutOfRangeException();
		}

		public static string GenerateCode( ) {
			int currLength = 0;
			string result = "";
			Random rand = new Random();

			while(currLength < codeLength) {
				currLength++;
				int charID = rand.Next( charset.Length - 1 );
				char next = charset [ charID ];
				result += next;
			}

			return result;

		}

	}
}
