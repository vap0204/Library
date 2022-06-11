using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace _2101681070
{
    //!!!!password for login : 2101681070
    class Program
    {
        class book
        {
            public int bookId;
            public string title;
            public int bookPrice;
            public string author;
            public string category;
            int sortingHelp;

            const int STD_OUTPUT_HANDLE = -11;
            const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 4;

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern IntPtr GetStdHandle(int nStdHandle);

            [DllImport("kernel32.dll")]
            static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

            [DllImport("kernel32.dll")]
            static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

            class ManagementLib : book
            {

                static List<book> bookList = new List<book>();
                static book mybook = new book();


                static void Main(string[] args)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Welcome! Enter your password:");
                    string password = Console.ReadLine();
                    if (password == "2101681070")
                    {
                        bool access = true;
                        bool exit = false;
                        while (access)
                        {
                            Console.WriteLine("                              ");
                            Console.WriteLine(
                                "                  " +
                                "Library Management Menu", Console.ForegroundColor = ConsoleColor.DarkGray);
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("                              ");
                            Console.WriteLine("                              ");
                            Console.WriteLine("                  " + " 1. Type 1 to add a book");
                            Console.WriteLine("                  " + " 2.Type 2 to delete a book");
                            Console.WriteLine("                  " + " 3. Type 3 to search a book");
                            Console.WriteLine("                  " + " 4. Type 4 to view the list of books");
                            Console.WriteLine("                  " + " 5. Type 5 to view books by category");
                            Console.WriteLine("                  " + " 6. Type 6 to close");
                            Console.WriteLine("                              ");
                            Console.WriteLine("     " + "Choose one option from menu to manage book details: ");
                            int option = int.Parse(Console.ReadLine());

                            if (option == 1)
                            {
                                AddBook();
                            }
                            else if (option == 2)
                            {
                                RemoveBook();
                            }
                            else if (option == 3)
                            {
                                SearchBook();
                            }
                            else if (option == 4)
                            {
                                ViewBookList();
                            }
                            else if (option == 5)
                            {
                                CategoryBook();
                            }
                            else if (option == 6)
                            {
                                exit = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("You type a wrong number/ key\nRetry !!!");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Your password is invalid");
                    }
                    Console.ReadLine();
                }
                //To add book details to the Library database
                public static void AddBook()
                {
                    book mybook = new book();
                    Console.WriteLine("Book ISBN:{0}", mybook.bookId = bookList.Count + 1);
                    Console.Write("Book's Title: ");
                    mybook.title = Console.ReadLine();
                    Console.Write("Book's Author:");
                    mybook.author = Console.ReadLine();
                    Console.Write("Book's Price:");
                    mybook.bookPrice = int.Parse(Console.ReadLine());
                    Console.WriteLine("Book's category: ");
                    mybook.category = Console.ReadLine();
                    try
                    {
                        bookList.Add(mybook);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }

                //To delete book details from the Library
                public static void RemoveBook()
                {
                    book mybook = new book();
                    Console.Write("Enter Book ISBN to be deleted : ");

                    int Del = int.Parse(Console.ReadLine());

                    if (bookList.Exists(sortingHelp => sortingHelp.bookId == Del))
                    {
                        bookList.RemoveAt(Del - 1);
                        Console.WriteLine("Book ISBN - {0} has been deleted", Del);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Book ISBN");
                    }

                    bookList.Add(mybook);
                }

                //To search book details from the Library using Book ISBN
                public static void SearchBook()
                {
                    book mybook = new book();
                    Console.Write("Search by BOOK id :");
                    int find = int.Parse(Console.ReadLine());

                    if (bookList.Exists(sortingHelp => sortingHelp.bookId == find))
                    {
                        foreach (book searchId in bookList)
                        {
                            if (searchId.bookId == find)
                            {
                                Console.WriteLine("Book ISBN :{0}\n" +
                                "Book's Title :{1}\n" +
                                "Book's Author :{2}\n" +
                                "Book's Price :{3}\n" +
                                "Book's Category: {4}"
                                , searchId.bookId, searchId.title, searchId.author, searchId.bookPrice, searchId.category);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Book ISBN {0} not found", find);
                    }
                }
                public static void CategoryBook()
                {
                    book mybook = new book();
                    Console.Write("Search by category : ");
                    string find = Convert.ToString(Console.ReadLine());

                    if (bookList.Exists(book => book.category == find))
                    {
                        foreach (book sortCategory in bookList)
                        {
                            if (sortCategory.category == find)
                            {
                                Console.WriteLine("Book ISBN :{0}\n" +
                                "Book's Title :{1}\n" +
                                "Book's Author :{2}\n" +
                                "Book's Price :{3}\n" +
                                "Book Category: {4}", sortCategory.bookId, sortCategory.title, sortCategory.author, sortCategory.bookPrice, sortCategory.category);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Book ISBN {0} not found", find);
                    }
                }
                public static void ViewBookList()
                {

                    foreach (var mybook in bookList)
                    {
                        Console.WriteLine("Book ISBN: " + mybook.bookId);
                        Console.WriteLine("Book title: " + mybook.title);
                        Console.WriteLine("Book author: " + mybook.author);
                        Console.WriteLine("Book Price: " + mybook.bookPrice);
                        Console.WriteLine("Book category: " + mybook.category);
                        Console.WriteLine("                                  ");
                        Console.WriteLine("                                  ");
                    }
                }


            }
        }
    }
}
