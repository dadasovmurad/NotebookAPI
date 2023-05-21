using DataAccess.Concrete.EntityFramework;
using System;
using System.Linq;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            NotebookDBContext notebookDBContext = new NotebookDBContext();
            var note = notebookDBContext.Notes.Include(x => x.Category).ToList();
            foreach (var item in note)
            {
                Console.WriteLine(item.Header);
                Console.WriteLine(item.Content);
                Console.WriteLine(item.Category.Name);
                Console.WriteLine(item.CreatedDate);
            }
        }
    }
}