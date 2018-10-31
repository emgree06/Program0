// Program 0
//CIS 200-01
//Due Date: 1/29/18
//Grading ID: Z9435
// Starting Point

// File: Program.cs
// This file creates a simple test application class that creates
// an list of LibraryBook objects and tests them.
//The file also creates patrons who can check out a book.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

public class Program
{
    // Precondition:  None
    // Postcondition: The LibraryBook class has been tested
    public static void Main(string[] args)
    {
        LibraryBook book1 = new LibraryBook("The Wright Guide to C#", "Andrew Wright", "UofL Press",
            2010, "ZZ25 3G");  // 1st test book
        LibraryBook book2 = new LibraryBook("Harriet Pooter", "IP Thief", "Stealer Books",
            2000, "AG773 ZF"); // 2nd test book
        LibraryBook book3 = new LibraryBook("The Color Mauve", "Mary Smith", "Beautiful Books Ltd.",
            1985, "JJ438 4T"); // 3rd test book
        LibraryBook book4 = new LibraryBook("The Guan Guide to SQL", "Jeff Guan", "UofL Press",
            2016, "ZZ24 4F");    // 4th test book
        LibraryBook book5 = new LibraryBook("The Big Book of Doughnuts", "Homer Simpson", "Doh Books",
            2001, "AE842 7A"); // 5th test book


        LibraryPatron Patron1 = new LibraryPatron("Emily", "1841319");// 1st Patron
        LibraryPatron Patron2 = new LibraryPatron("Libby", "1111111");//2nd Patron
        LibraryPatron Patron3 = new LibraryPatron("Help", "AAA1234");//3rd Patron


        List<LibraryBook> theBooks = new List<LibraryBook> { book1, book2, book3, book4, book5 }; // A List of books

        WriteLine("Original list of books");
        WriteLine("----------------------");
        PrintBooks(theBooks);
        Pause();


        // Make changes
        book1.CheckOut(Patron1);
        book2.Publisher = "Borrowed Books";
        book3.CheckOut(Patron2);
        book4.CallNumber = "AB123 4A";
        book5.CheckOut(Patron3);
        book5.CopyrightYear = -1234;// Attempt invalid year
        
        WriteLine("After changes");
        WriteLine("-------------");
        PrintBooks(theBooks);
        Pause();

        // Return the books
        book1.ReturnToShelf();
        book3.ReturnToShelf();
        book5.ReturnToShelf();
        
        WriteLine("After returning the books");
        WriteLine("-------------------------");
        PrintBooks(theBooks);
    }

    // Precondition:  None
    // Postcondition: The books have been printed to the console
    public static void PrintBooks(List<LibraryBook> book)
    {
        foreach (LibraryBook b in book)
        {
            Console.WriteLine(b);
            Console.WriteLine();
        }
    }


    // Precondition:  None
    // Postcondition: Pauses program execution until user presses Enter and
    //                then clears the screen
    public static void Pause()
    {
        Console.WriteLine("Press Enter to Continue...");
        Console.ReadLine();

        Console.Clear(); // Clear screen
    }
}
