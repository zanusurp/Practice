using School;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School2
{
    class Program
    {
        static void Main(string[] args)
        {
            EagerLoading();
        }
        static void EagerLoading()
        {
            using(SchoolContext context = DbContextFactory.Create())
            {
                //Include("Standard")
                var query = from x in context.Students.Include("Standard")
                            where x.StudentID < 4
                            select x;


                foreach (var item in query)
                {
                    Console.WriteLine($"{item.StudentID} / {item.StudentName} / {item.Standard.StandardName} / {item.Standard.Teachers.FirstOrDefault().TeacherName}");
                }

            }
        }
        private static void Update(Student student)
        {
            //1.State 변경
            //2. Database옵션 설정
            using(SchoolContext context = DbContextFactory.Create())
            {
                context.Entry(student).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        private static void Delete(Student student)
        {
            //1.State 변경
            //2. Database옵션 설정
            using (SchoolContext context = DbContextFactory.Create())
            {
                context.Entry(student).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
