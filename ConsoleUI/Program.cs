using DataAccess.Concrete.EntityFramework;
using System;
using System.Linq;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using DataAccess.Abstract;
using Core.DataAccess;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            GetNoteHeader();
        }
        static void GetAllNoteHeaders()
        {
            IEntityRepository<Note> noteDal = new EfNoteDal();
            foreach (var item in noteDal.GetAll())
            {
                Console.WriteLine(item.Header);
            }
        }
        static void GetNoteHeader()
        {
            IEntityRepository<Note> noteDal = new EfNoteDal();
            var note = noteDal.Get(x => x.Header.Equals("MyTestNote"));
            Console.WriteLine(note.Header);
        }
    }
}