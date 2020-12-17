using System;

namespace CSharp_Net_module1_2_1_lab
{

    // 1) declare interface ILibraryUser
    // declare method's signature for methods of class LibraryUser
    interface ILibraryUser
    {
        
        void AddBook(string book);
        void RemoveBook(int index);
        string BookInfo(int index);
        int BooksCount();
        
    }


    // 2) declare class LibraryUser, it implements ILibraryUser
    class LibraryUser : ILibraryUser
    {
        // 3) declare properties: FirstName (read only), LastName (read only), 
        // Id (read only), Phone (get and set), BookLimit (read only)
        #region private
        string FirstName;
        string LastName;
        int ID;
        string Phone;
        int BookLimit;

        
        #endregion

        // 4) declare field (bookList) as a string array
        private string[] bookList;

        // 5) declare indexer BookList for array bookList
        private int BookList = 0;

        // 6) declare constructors: default and parameter
        public LibraryUser()
        {
            FirstName = null;
            LastName = null;
            ID = 1111;
            Phone = "1111111111";
            BookLimit = 0;
        }

        public LibraryUser(string FirstName, 
                           string LastName,
                           string Phone,
                           int BookLimit)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            ID = CreateID();
            this.Phone = Phone;
            this.BookLimit = BookLimit;
        }
        
        int CreateID()
        {
            Random rnd = new Random();
            return rnd.Next(1000, 9999);
        }
        
        // 7) declare methods: 

        //AddBook() – add new book to array bookList
        public void AddBook(string book)
        {
            // if no book we create array
            if(BookList == 0)
            {
                bookList = new string[BookLimit];
                bookList[0] = book;
                BookList++;
                Console.WriteLine("Book: {0}, added. ", book);
                return;
            }
            // if person take book we add new to array
            else
            {
                // if book limit is out
                if (BookLimit == BookList)
                {
                    Console.WriteLine("Limit of books is out!");
                    return;
                }
                // add new book
                else
                {
                    bookList[BookList] = book;
                    BookList++;
                    Console.WriteLine("Book: {0}, added. ", book);
                    return;
                }
            }
        }

        //RemoveBook() – remove book from array bookList
        public void RemoveBook(int index)
        {
            // check empty array
            if (BookList == 0)
                Console.WriteLine("Array is free!");
            else
            {
                for (int i = index; i < BookList; i++)
                {
                    // if delete last book
                    if (i == (BookList - 1))
                    {
                        bookList[i] = null;
                        BookList--;
                        return;
                    }
                    // when stop swap books
                    if (bookList[i] == null)
                    {
                        BookList--;
                        return;
                    }
                    // swap alg
                    else
                    {
                        bookList[i] = bookList[i + 1];
                        continue;
                    }
                }
            }
            

        }

        //BookInfo() – returns book info by index
        public string BookInfo(int index)
        {
            string bookData = bookList[index];
            Console.WriteLine("{0}. {1}", index + 1, bookData);
            return bookData;
        }

        //BooksCout() – returns current count of books
        public int BooksCount()
        {
            // check empty array
            if (bookList[0] == null)
                return 0;
            // check full array
            if (bookList[BookList - 1] != null)
                return BookList;
            // count books
            else
            {
                int counter = 0;
                bool marker = false;
                while (!marker)
                {
                    counter++;
                    if (bookList[counter] == null)
                    {
                        marker = true;
                        break;
                    }

                }
                return counter;
            }
        }
        
        
        public void PrintAllBook()
        {
            for (int i = 0; i < BookLimit; i++)
            {
                Console.WriteLine("{0}. {1}", i+1, bookList[i]);
            }
        }

        // Geters

        public string GetFirstName() { return FirstName; }
        public string GetLastName() { return LastName; }
        public string GetPhone() { return Phone; }
        public int GetID() { return ID; }
        public int GetLimit() { return BookLimit; }

    }
}
