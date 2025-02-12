package scanner_1;

import java.util.Scanner;
import java.io.File;
import java.io.FileNotFoundException;

class Main
{
    public static void main(String[] args)
    {
        File f1 = new File("input.txt");
        Scanner s = null;
        Scanner s1 = null;
        try
        {
            // Olvassuk be a fájlból az össze számot és adjuk őket össze:
            s = new Scanner(f1);
            s1 = new Scanner(s.nextLine());
            int sum = 0;
            while (s1.hasNextInt())
            {
                int currNum = s1.nextInt();
                sum += currNum;
            }
            System.out.println(sum);
        }
        catch (FileNotFoundException e)
        {
            System.err.println("Error while opening the file for reading");
        }
        finally
        {
            s.close();
            s1.close();
        }
    }
}