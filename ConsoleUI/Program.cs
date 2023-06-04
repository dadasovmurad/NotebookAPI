using DataAccess.Concrete.EntityFramework;
using System;
using System.Linq;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using DataAccess.Abstract;
using Core.DataAccess;
using Business.Abstract;
using Business.Concrete;
using System.Collections.Generic;
using Core.Utilities.Security.Hashing;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            string password = "hello world";
            byte[] passwordHash;
            byte[] passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            bool verify = HashingHelper.VerifyPasswordHash(password+"SAD", passwordHash, passwordSalt);
            Console.WriteLine(verify);
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
        static void GetCategoryNames()
        {
            ICategoryService categoryService = new CategoryManager(new EfCategoryDal());
            List<string> categoryNames = categoryService.GetNames().Data;
            foreach (var item in categoryNames)
            {
                Console.WriteLine(item);
            }
        }
    }
}