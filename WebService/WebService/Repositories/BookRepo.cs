using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebService.Models;

namespace WebService.Repositories
{
    public class BookRepo : IRepository<Book>
    {
        const string path = "file.txt";

        public string Delete(int id)
        {
            try
            {
                using FileStream fs = new FileStream(path, FileMode.Truncate, FileAccess.Write);
                return "OK";
            }
            catch (Exception exc)
            {
                return exc.Message;
            }
        }

        public string Post(Book book)
        {
            if (File.Exists(path))
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(path, true))
                    {
                        sw.WriteLine($"ID = {book.ID}, Name = {book.Name}, Author = {book.Author}\n");
                    }
                    return "OK";
                }
                catch (Exception exc)
                {
                    return exc.Message;
                }
            }
            else
            {
                return "File not exist";
            }
        }

        public string Put(Book book)
        {
            if (File.Exists(path))
            {
                try
                {
                    using StreamWriter sw = new StreamWriter(path, false);
                    File.ReadLines(path)
                    .SkipWhile(line => !line.Contains($"ID = {book.ID}"))
                    .Skip(book.ID.ToString().Length);
                    return "";
                }
                catch (Exception exc)
                {
                    return exc.Message;
                }
            }
            else
            {
                return "File doesn't exist";
            }

        }

        public (IEnumerable<Book>, string) Get()
        {
            List<Book> books = new();
            try
            {
                using StreamReader sr = new StreamReader(path);
                while (sr.ReadLine() != null)
                {
                    books.Add(new Book { });
                }
                return (books, "OK");
            }
            catch(Exception exc)
            {
                return (books, exc.Message);
            }

        }

        public (Book, string) GetOne(int id)
        {
            Book book = new();
            if (File.Exists(path))
            {
                try
                {
                    string name = File.ReadLines(path)
                    .SkipWhile(line => !line.Contains($"ID = {id}"))
                    .Skip(id.ToString().Length)
                    .TakeWhile(line => !line.Contains("Author = ")).ToString();

                    string author = File.ReadLines(path)
                    .SkipWhile(line => !line.Contains($"Name = {name}"))
                    .Skip(id.ToString().Length)
                    .TakeWhile(line => !line.Contains("ID")).ToString();

                    Book resultingBook = new() { ID = id, Name = name, Author = author };
                    return (resultingBook, "OK");
                }
                catch (Exception exc)
                {
                    return (book, exc.Message);
                }
            }
            else
            {
                return (book, "File doesn't exist");
            }
        }
    }
}
