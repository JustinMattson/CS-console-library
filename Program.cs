// I have never done any programming in C# where multiple files are involved.
// I used the following example to try to learn how to code in C#
// github.com/BoiseCodeWorks/dotnet-19-ConsoleLibrary/blob/master

using System;

namespace console_library
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.Clear();
      // Create another file to contain the main functions?
      App app = new App();
      app.Setup();
      app.Run();
      Console.Clear();
      Console.WriteLine("Welcome to Console Library!");
    }
  }
}
