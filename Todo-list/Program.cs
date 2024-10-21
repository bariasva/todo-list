using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;


class Todo
{
    static void InMemoryStream()
    {
        using (MemoryStream ms = new MemoryStream())
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes("Memory stream example");
            ms.Write(data, 0, data.Length);
            ms.Seek(0, SeekOrigin.Begin); // Reset the position to read from the beginning
            byte[] buffer = new byte[ms.Length];
            ms.Read(buffer, 0, buffer.Length);
            string result = System.Text.Encoding.UTF8.GetString(buffer);
            Console.WriteLine("Data from MemoryStream: ");
            Console.WriteLine(result);
        }
    }

    static void WriteFile()
    {
        string path = "output.txt";
        using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
        {
            string content = "This is an example of writing to a file using streams.";
            byte[] data = System.Text.Encoding.UTF8.GetBytes(content);
            fs.Write(data, 2, data.Length - 2);
            Console.WriteLine("Data written to file successfully.");
        }
    }

    static void Addline(string content)
    {
        string path = "output.txt";
        byte[] data = System.Text.Encoding.UTF8.GetBytes(Environment.NewLine + content);
        using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.None))
        {
            fs.Write(data, 0, data.Length);
        }

    }

    static void ReadFile()
    {
        string path = "output.txt";
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);

            string content = System.Text.Encoding.UTF8.GetString(buffer);
            Console.WriteLine("File Content: ");
            Console.WriteLine(content);
        }
    }
    static void Main()
    {
        bool isRunning = true;
        while (isRunning == true)
        {
            Console.WriteLine("a) Show");
            Console.WriteLine("b) Add");
            Console.WriteLine("c) Close");
            Console.WriteLine("Enter option: ");
            string? option = Console.ReadLine();

            if (option != null)
            {
                switch (option)
                {
                    case "a":
                        ReadFile();
                        break;
                    case "b":
                        Console.WriteLine("What do you want to add to the list?");
                        string? task = Console.ReadLine();
                        if (task != null)
                        {
                            Addline(task);
                        }
                        else
                        {
                            Console.WriteLine("This is empty, please try again with some text");
                        }

                        break;
                    case "c":
                        isRunning = false;
                        break;
                }
            }
        }

    }
}