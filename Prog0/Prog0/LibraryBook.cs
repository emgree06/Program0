// Program 0
// CIS 200 - 01
// Due: 1/29/2017
// Grading ID: Z9435

// File: LibraryBook.cs
// This file creates a simple LibraryBook class capable of tracking
// the book's title, author, publisher, copyright year, call number,
// and checked out status.
//This file also creates a HAS-A relationship between LibraryBook and Patron.
//This relationship enables the LibraryBook class to display 
//PatronName and PatronID from the LibraryPatron class.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class LibraryBook
{
    public const int DEFAULT_YEAR = 2017; // Default copyright year

    private string _title;      // The book's title
    private string _author;     // The book's author
    private string _publisher;  // The book's publisher
    private int _copyrightYear; // The book's year of copyright
    private string _callNumber; // The book's call number in the library
    private bool _checkedOut;   // The book's checked out status
    private LibraryPatron _patron;// backing field for patron name and ID

   
    public LibraryPatron Patron
    {
        /* Precondition: the book must be checked out for it to have a patron.
    * Therefore, the IsCheckedOut() method must return true 
    * Postcondition: If the book has been checked out then it will be assigned a Patron name and ID.
    * If the book hasn't been checked out it will be assigned the value null
    */
        get
        {
            return _patron;
        }

        private set
        {
            //Precondition: None
            //Postcondition: the patron is set to the specified value
            if (IsCheckedOut() == true)
            {
                _patron = value;
            }
            else
                _patron = null;
        }
    }

            // Precondition:  theCopyrightYear >= 0
            // Postcondition: The library book has been initialized with the specified
            //                values for title, author, publisher, copyright year, and
            //                call number. The book is not checked out.
            public LibraryBook(String theTitle, String theAuthor, String thePublisher,
        int theCopyrightYear, String theCallNumber)
    {
        Title = theTitle;
        Author = theAuthor;
        Publisher = thePublisher;
        CopyrightYear = theCopyrightYear;
        CallNumber = theCallNumber;

        ReturnToShelf(); // Make sure book is not checked out
    }

    public string Title
    {
        // Precondition:  None
        // Postcondition: The title has been returned
        get
        {
            return _title;
        }

        // Precondition:  None
        // Postcondition: The title has been set to the specified value
        set
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(Title)} is empty or null");
            }
            _title = value.Trim();
        }
    }

    public string Author
    {
        // Precondition:  None
        // Postcondition: The author has been returned
        get
        {
            return _author;
        }

        // Precondition:  None
        // Postcondition: The author has been set to the specified value
        set
        {
            _author = value;
        }
    }

    public string Publisher
    {
        // Precondition:  None
        // Postcondition: The publisher has been returned
        get
        {
            return _publisher;
        }

        // Precondition:  None
        // Postcondition: The publisher has been set to the specified value
        set
        {
            _publisher = value;
        }
    }

    public int CopyrightYear
    {
        // Precondition:  None
        // Postcondition: The copyright year has been returned
        get
        {
            return _copyrightYear;
        }

        // Precondition:  value >= 0
        // Postcondition: The copyright year has been set to the specified value
        set
        {
            if (value >= 0)
                _copyrightYear = value;
            else
                throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(CopyrightYear)} is invalid please re-enter");
        }
    }

    public string CallNumber
    {
        // Precondition:  None
        // Postcondition: The call number has been returned
        get
        {
            return _callNumber;
        }

        // Precondition:  None
        // Postcondition: The call number has been set to the specified value
        set
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(CallNumber)} is invalid please re-enter");
            }
            _callNumber = value.Trim();
        }
    }

    // Precondition:  None
    // Postcondition: The book is checked out by a patron
    public void CheckOut(LibraryPatron patron)
    {
        _checkedOut = true;
        Patron = patron;
    }

    // Precondition:  None
    // Postcondition: The book is not checked out and the HAS-A 
    //                  relationship between librarybook and patron is ended
    public void ReturnToShelf()
    {
        _checkedOut = false;
        _patron = null;
    }

    // Precondition:  None
    // Postcondition: true is returned if the book is checked out,
    //                otherwise false is returned
    public bool IsCheckedOut()
    {
        return _checkedOut;
    }


    // Precondition:  None
    // Postcondition: A string is returned representing the libary book's
    //                data on separate lines
    public override string ToString()
    {
        string NL = Environment.NewLine; // Newline shortcut

        return $"Title: {Title}{NL}Author: {Author}{NL}Publisher: {Publisher}{NL}" +
            $"Copyright: {CopyrightYear}{NL}Call Number: {CallNumber}{NL}" +
            $"{((IsCheckedOut() == false) ?  "Not Checked out" : $"Checked Out By: {(Patron)}")}";//If the method IsCheckedOut() returns false then the console will print
        //                                                                                          "Not checked out". If the book is checked out the console will print "Checked out By:"
        //                                                                                          And the information of the patron
    }

}
