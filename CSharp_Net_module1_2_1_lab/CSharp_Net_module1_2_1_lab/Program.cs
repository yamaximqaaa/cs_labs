using System;

namespace CSharp_Net_module1_2_1_lab
{

    class Program
    {
        static void MainTask()
        {
            // 8) declare 2 objects. Use default and paremeter constructors
            LibraryUser user1 = new LibraryUser("Vasilii", "Peprovchich", "+380447777777", 2), user2 = new LibraryUser("Maria", "Ivanenko", "+380447777777", 2);
            Console.WriteLine("User1 " + user1.GetFirstName() + " " + user1.GetLastName() + " " + user1.GetID());
            Console.WriteLine("User2 " + user2.GetFirstName() + " " + user2.GetLastName() + " " + user2.GetID());

            // 9) do operations with books for all users: run all methods for both objects
            Console.WriteLine("User 1: add Harry Potter");
            user1.AddBook("Harry Potter");
            Console.WriteLine("User 2: add Sherlock Holmes");
            user2.AddBook("Sherlock Holmes");
            Console.WriteLine("user1.BooksCount = " + user1.BooksCount() + "; user2.BooksCount " + user2.BooksCount());
            Console.WriteLine("user2 :");
            Console.WriteLine("Add Kobzar");
            user2.AddBook("Kobzar");
            Console.WriteLine("user2.BooksCount " + user2.BooksCount());
            Console.WriteLine("Add Dorian Gray");
            user2.AddBook("Dorian Gray");
            Console.WriteLine("user2.BooksCount " + user2.BooksCount());
            Console.WriteLine("Remove Sherlock Holmes");
            user2.RemoveBook(1);
            Console.WriteLine("user2.BooksCount " + user2.BooksCount());
        }
        
        void MyTests()
        {
            var client1 = new LibraryUser("Max", "Lukashevich", "0980703727", 5);

            client1.AddBook("book1");
            client1.AddBook("book2");
            client1.AddBook("book3");
            client1.AddBook("book4");
            client1.AddBook("book5");

            client1.RemoveBook(1);
            client1.RemoveBook(0);
            client1.RemoveBook(4);

            client1.PrintAllBook();
            Console.WriteLine("Book count: " + client1.BooksCount());


            client1.AddBook("book1");
            client1.AddBook("book2");
            Console.WriteLine("Book count: " + client1.BooksCount());
            client1.PrintAllBook();
        }
        static void Main(string[] args)
        {
            MainTask();


        }
    }
}
