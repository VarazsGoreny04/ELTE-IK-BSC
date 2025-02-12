using System;
internal class Program {
	static int a=1;   //osztály adattag
    static int x=11;  //osztály adattag
	static int f(int x)
	{//az f függvényblokk kezdete
		int a=2;//az a változó lokális az f függvényblokkban
		int ff(int xx)
		{//az ff lokális függvényblokk kezdete
			int a=3;
			x=x+xx+a+Program.a;
			return x;
		}//az ff függvényblokk vége

		{//névtelen blokk kezdete
		//int a; nem lehet, névtelen blokkban nem lehet újradeklarálni
			int lf(int x)
			{//a névtelen blokkban definiált lokális függvény
				return x+a;
			}
			int aa=4;   //lokális a névtelen blokkban
			a+=lf(aa);  //a: az f blokkban deklarált
		}//névtelen blokk vége
      return ff(x)+a;//a lokális ff hívása
	}//az f függvényblokk vége
	//{ x++;} osztályblokkban nem lehet névtelen blokk
	static void Main(string[] args){
		var y=f(x);     //x a Program osztályblokk adattagja
		Console.WriteLine(y);
		Console.WriteLine(f(a+x+y));
		Console.WriteLine(x);
	}//Main függvényblokk vége
}//Program osztályblokk vége

