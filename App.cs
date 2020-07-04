using System;
using console_library.Models;

namespace console_library
{
  public class App
  {
    private Library Library { get; set; }
    public bool LibraryRunning { get; set; }
    public void Setup()
    {
      // Create default books
      Book WhereTheSidewalkEnds = new Book("Where the Sidewalk Ends", "Shel Silverstein");
      Book TheHobbit = new Book("The Hobbit", "J.R.R. Tolkien");
      Book TheLionTheWitchAndTheWardrobe = new Book("The Lion, The Witch, and the Wardrobe", "C.S. Lewis");
      Book HarryPotterAndTheSorcerersStone = new Book("Harry Potter and the Sorcerer's Stone", "J.K. Rowling");

      // Add the default books to the library
      Library.Books.Add(WhereTheSidewalkEnds);
      Library.Books.Add(TheHobbit);
      Library.Books.Add(TheLionTheWitchAndTheWardrobe);
      Library.Books.Add(HarryPotterAndTheSorcerersStone);
    }

    public void Run()
    {
      // Start the application
      Console.WriteLine("Welcome to the Console Library!");

      // the menu options will dispaly below the line above in the console.

      while (LibraryRunning)
      {
        DisplayMenu();
      }
    }

    public void DisplayMenu()
    {
      Console.WriteLine("\n  1. View Books");
      Console.WriteLine("  2. Check Out");
      Console.WriteLine("  3. Return Book");
      Console.WriteLine("  4. Exit Console Library");
      Console.WriteLine("\nPlease enter a number [1-4]:");
      ProcessInput();
    }

    public void ProcessInput()
    {
      // if text is entered instead of a number the application
      // int choice = Convert.ToInt32(Console.ReadLine());
      string choice = Console.ReadLine();
      switch (choice)
      {
        case "1":
          Library.ViewBooks();
          break;
        case "2":
          Library.CheckOut();
          break;
        case "3":
          Library.BookReturn();
          break;
        case "4":
          LibraryRunning = false;
          break;
        default:
          Console.WriteLine("Please enter a number [1-4]");
          ProcessInput();
          break;
      }
    }
    // This is a constructor method to create an insance of the App.
    // This creates a new instance of Library
    public App()
    {
      Library = new Library();
      LibraryRunning = true;
    }
  }
}