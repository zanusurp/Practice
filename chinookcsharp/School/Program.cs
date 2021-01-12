using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //insert();
            List<Student> students1 = SelectByMethod();
            List<Student> students2 = SelectByLinq();
            GroupByLinq();
            CountByLinq();
            CountByMethod();
        }

        //skip and take ====================================
        private static void SkipAndTakeByMethod()
        {
            //paging 
            int countPerPage = 15;
            using(SchoolContext context = DbContextFactory.Create())
            {
                var query = context.Students
                            .OrderByDescending(x => x.StudentName)
                            .ThenBy(x => x.StandardId)
                            .Select(x => new { x.StudentID, x.StudentName })
                            .Skip((3-1)*countPerPage)
                            .Take(3);
                foreach (var item in query)
                {
                    Console.WriteLine($"{item.StudentID} / {item.StudentName}");
                }
            }
        }
        private static void SkipAndTakeByLinq()
        {
            using (SchoolContext context = DbContextFactory.Create())
            {
                var query = from x in context.Students
                            orderby x.StudentName descending, x.StandardId
                            select new { x.StudentID, x.StudentName };
                foreach (var x in query)
                {
                    Console.WriteLine($"{x.StudentID} / {x.StudentName}");
                }
            }
        }
        //skip and take 
        //Min --------------------------------------------
        private static void MinByMethod()
        {
            using (SchoolContext context = DbContextFactory.Create())
            {
                string min = context.Students
                             .Where(x => x.StudentID < 5)
                             .Min(x=>x.StudentName);
                Console.WriteLine(min);
            }
        }
        private static void MinByLinq()
        {
            using(SchoolContext context = DbContextFactory.Create())
            {
                var query = from x in context.Students
                            where x.StudentID < 5
                            select x;
                string min = query.Min(x => x.StudentName);
                Console.WriteLine(min);
            }
        }
        //Min 
        //COUNT ============================================
        private static void CountByMethod()
        {
            using (SchoolContext context = DbContextFactory.Create())
            {
                var count = context.Students
                            .Where(x => x.StudentID > 10)
                            .Count();
                Console.WriteLine(count);
                            
            }
        }
        private static void CountByLinq()
        {
            using(SchoolContext context = DbContextFactory.Create())
            {
                var count = from x in context.Students
                            where x.StudentID > 10
                            select x;
                Console.WriteLine(count.Count());
            }
        }
        //COUNT 
        //Group ------------------------------------------------
        private static void GroupByMethod()
        {
            using(SchoolContext context = DbContextFactory.Create())
            {
                var query = context.Students
                             .GroupBy(x => x.StandardId);
                foreach (var group in query)
                {
                    Console.WriteLine(group.Key);
                    foreach (var student in group)
                    {
                        Console.WriteLine(student.StudentName);
                    }
                }
            }
        }
        private static void GroupByLinq()
        {
            using(SchoolContext context  = DbContextFactory.Create())
            {
                IQueryable<IGrouping<int?, Student>> query = from x in context.Students
                                                             group x by x.StandardId into g
                                                             select g;
                foreach (var group in query)
                {
                    Console.WriteLine(group.Key);
                    foreach (var student in group)
                    {
                        Console.WriteLine(student.StudentName);
                    }
                }
            }
            
        }
        //Group 

        //First-----------------------------------------------
        private static Student FirstByLinq()
        {
            using (SchoolContext context = DbContextFactory.Create())
            {
                var query = from x in context.Students
                            where x.StudentName == "Bill"
                            select x;
                return query.First();
            }
        }
        private static Student FirstByMethod()
        {
            using(SchoolContext context = DbContextFactory.Create())
            {
                return context.Students.Where(x => x.StudentName == "Bill").First();
            }
        }
        //First
        //select By Name-----------------------------------------------
        private static List<Student> SelectByNameMethod()
        {
            using (SchoolContext context = DbContextFactory.Create())
            {
                return context.Students.Where(x=>x.StudentName=="Bill").ToList();
            }
        }
        private static List<Student> SelectByNameLinq()
        {
            using (SchoolContext context = DbContextFactory.Create())
            {
                IQueryable<Student> query = from x in context.Students
                            where x.StudentName == "Bill"
                            select x;
                return query.ToList();
            }
        }
        //select By Name
        //select List-----------------------------------------------
        private static List<Student> SelectByMethod()
        {
            using (SchoolContext context = DbContextFactory.Create())
            {
                return  context.Students.ToList();
            }
        }
        private static List<Student> SelectByLinq()
        {
            using(SchoolContext context = DbContextFactory.Create())
            {
                var query = from x in context.Students
                            select x;
                return query.ToList();
            }
        }
        //select List
        //insert-----------------------------------------------
        private static void insert()
        {
            using (SchoolContext context = DbContextFactory.Create())
            {
                context.Database.Log = log => Console.WriteLine(log);
                Student student = new Student();
                student.StudentName = "oma";
                context.Students.Add(student);

                Teacher teacher = new Teacher();
                teacher.TeacherName = "hama";
                context.Teachers.Add(teacher);

                context.SaveChanges();
            }
        }
        //insert
        //Update -----------------------------------------------
        private static void Update()
        {
            using (SchoolContext context = DbContextFactory.Create())
            {
                context.Database.Log = log => Console.WriteLine(log);

                Student student = context.Students.First(x=>x.StudentID > 10);
                student.StudentName = "aaoma";
                
               

                context.SaveChanges();
            }
        }
        //Update 
        //Delete -----------------------------------------------
        private static void Delete()
        {
            using (SchoolContext context = DbContextFactory.Create())
            {
                Student student = context.Students.First(x => x.StudentID > 10);
                context.Students.Remove(student);
                context.SaveChanges();

            }
        }
        //Delete 
    }
}
