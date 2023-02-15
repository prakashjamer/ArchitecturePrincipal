﻿using BasicLinQ.DBSETDbContext;
using BasicLinQ.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLinQ
{
    public class BasicLinq
    {
        private TestDBContext _dbContext;
        public BasicLinq()
        {
            _dbContext = new TestDBContext();
            //GetStudentDataIquerable();
            //linqGetEvenNumbers();
            //GetStudentDataLamdaExpression();
            GetStudentCout();
        }
        private void GetStudentDataIquerable()
        {
           // _dbContext.Database.ExecuteSql("update tabl");
            IQueryable<Student> lst = from c in _dbContext.Students
                                      where c.FirstName == "prakash"
                                      select c;
            foreach (var item in lst)
            {
                Console.WriteLine($"Data received First Name {item.FirstName} , Last Name {item.LastName} ");
            }
        }
        private void GetStudentDataLamdaExpression()
        {
            IQueryable<Student> lst = _dbContext.Students.Where(c => c.FirstName == "Reshu").Take(10).Select(c=>c);
            foreach (var item in lst)
            {
                Console.WriteLine($"Data received First Name {item.FirstName} , Last Name {item.LastName} ");
            }
        }
        void linqGetEvenNumbers()
        {
            int[] numbers = { 1, 2, 3 };
            var t = numbers.Where(n => n % 2 == 0).FirstOrDefault();

        }

        private void GetStudentCout()
        {
            IQueryable<Student> lst = _dbContext.Students;
            int count = lst.Count();
            foreach (var item in lst)
            {
                Console.WriteLine($"Data received First Name {item.FirstName} , Last Name {item.LastName} ");
            }
        }
    }
}

