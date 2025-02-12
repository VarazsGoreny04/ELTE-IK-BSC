using System;
internal class Program {
   //Func<int, bool> az int -> bool függvények típusa
   public static int Megszamol(int[] X, Func<int, bool> T)
   {
      int db=0;
      foreach(var x in X)
      {
         if(T(x)) db++;
	  }
      return db;
   }
   static bool Paros(int x){return x%2==0;}
   static void Main(string[] args){
      int [] A={1,2,3,8,9,7,3};
      Console.WriteLine(Megszamol(A,Paros));
      Func<int, bool> g;//g függvény típusú változó
      g=Paros;//függvény-értékadás
      g= x => {return x%3==0;};//függvénydefiniálás lambda kifejezéssel
      Console.WriteLine(Megszamol(A,g));//függvényváltozó mint paraméter
      Console.WriteLine(Megszamol(A, x => x%3==0));//explicit függvénydefiniálás mint paraméter
   }
}

