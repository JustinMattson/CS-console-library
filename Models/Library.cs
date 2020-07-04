using System;
using System.Collections.Generic;

namespace console_library.Models
{
  public class Library
  {
    // The List must be declared public to be accessible to other files
    public List<Book> Books { get; set; }

    // Properties and methods required within this the class Library
    public void CheckOut()
    {
      ViewBooks();
      Console.WriteLine("\nWhich book would you like to check out? [Enter Book ID:]");
      // index is ignored if book is checked out.  Example:
      // If book 2 is checked out and book 2 is selected to be checked out again,
      // It will be book 3 that actually gets checked out.
      // ViewBooks() has been modified as to not display the book ID if it is unavailable.
      int num = 0;
      bool isNum = false;
      List<Book> books = Books.FindAll(b => b.Available);
      while (!isNum)
      {
        isNum = Int32.TryParse(Console.ReadLine(), out num);
        if (!isNum)
        {
          Console.WriteLine("Please enter Book ID: ");
          continue;
        }
        if (num < 1 || num > books.Count)
        {
          Console.WriteLine("Not a valid number.");
          isNum = false;
        }
      }

      Book choice = books[num - 1];
      choice.Available = false;
      Console.Clear();
      Console.WriteLine($"You checked out: {choice.Title}.");
    }

    public void BookReturn()
    {
      ViewBooks();
      Console.WriteLine("\nPlease enter the book Title you are returning:");
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("Title must match punctution and spelling exactly.\n");
      Console.ForegroundColor = ConsoleColor.White;
      Book returnBook = null;
      while (returnBook == null)
      {
        string bookTitle = Console.ReadLine().ToUpper();
        returnBook = Books.Find(b => b.Title.ToUpper() == bookTitle);
        // Book title needs to match inventory or user will be stuck in this loop
      }
      returnBook.Available = true;
      Console.Clear();
      Console.WriteLine($"\nThanks for returning: {returnBook.Title}.");
    }

    public void ViewBooks(bool onlyAvailable = false)
    {
      Console.Clear();
      var colorOG = Console.ForegroundColor; // default is white on black
      Console.ForegroundColor = ConsoleColor.Blue;
      Console.WriteLine("...titles in Blue are currently checked out.");
      Console.ForegroundColor = colorOG;
      int bookCount = 1;
      List<Book> books = Books;
      if (onlyAvailable)
      {
        books = books.FindAll(b => b.Available);
      }
      foreach (var book in books)
      {
        if (!book.Available)
        {
          Console.ForegroundColor = ConsoleColor.Blue;
          // Remove book from count if !Available
          bookCount--;
        }
        // This should be updated to dispaly only those where book.available = false...
        // This was fixed by decrementing the bookCount above.
        if (book.Available)
        {
          Console.WriteLine($"Book ID: {bookCount} - {book.Title} - By: {book.Author}");
        }
        else
        {
          Console.WriteLine($"Book ID:   - {book.Title} - By: {book.Author}");

        }
        bookCount++;
        Console.ForegroundColor = colorOG;
      }
    }
    public Library()
    {
      Books = new List<Book>();
    }
  }
}

//  The comments below contain my unfunctional code prior to looking at Darryl's Github
//  github.com/BoiseCodeWorks/dotnet-19-ConsoleLibrary
//   public string Location { get; set; }
//   public string Name { get; set; }

//   public Library(string location, string name)
//   {
//     Location = location;
//     Name = name;
//   }

//   public void PrintBooks()
//   {
//     for (int i = 0; i < Books.Count; i++)
//     {
//       Console.WriteLine($"{i + 1} {Books[i].Title} - {Books[i].Author}");
//     }
//   }
//   Book WhereTheSidewalkEnds = new Book("Where the Sidewalk Ends", "Shel Silverstein");
//   Book TheHobbit = new Book("The Hobbit", "J.R.R. Tolkien");
//   Book TheLionTheWitchAndTheWardrobe = new Book("The Lion, The Witch, and the Wardrobe", "C.S. Lewis");
//   Book HarryPotterAndTheSorcerersStone = new Book("Harry Potter and the Sorcerer's Stone", "J.K. Rowling");
// }

// public void AddBook(Book book)
// {
//   Books.Add(book);

// }
// public void PrintBooks()
// {
//   for (int i = 0; i < Books.Count; i++)
//   {
//     Console.WriteLine($"{i + 1} {Books[i].Title} - {Books[i].Author}");
//   }
// }
