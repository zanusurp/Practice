using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 언제나휴일
{
    //클라스 인터페이스 쓰는 법 
    internal interface IStudy
    {
        void Study();
    }
    internal interface ISleep
    {
        void Sleep();
    }
    class man
    {
        string name;
        int age;
        internal man() { }
        internal man(string name, int age)
        {
            this.name = name;
            this.age = age;
            Console.WriteLine(name+"man"+age);
        }
        internal virtual void Work()
        {
            Console.WriteLine("사람이 할일 ");
        }
    }
    class student: man, ISleep, IStudy
    {
        internal student() : base()
        {

        }
        internal student(string name, int age) : base(name,age)
        {
            Console.WriteLine(name+"student"+age);
        }

        public void Sleep()
        {
            Console.WriteLine("학생 잔다");
        }

        public void Study()
        {
            throw new NotImplementedException();
        }

        internal override void Work()
        {
            Console.WriteLine("학생이 할 일 ");
        }
    }
    //내부 이뉴머레이션 쓰는 법 
    class Member
    {
        public int id
        {
            get;
            private set;
        }
        public string name
        {
            get;
            private set;

        }
        
        public Member(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public override string ToString()
        {
            return string.Format("아아디 {0}, 이름 {1}",id,name);
        }
    }
    class MemberCollection : IEnumerable
    {
        ArrayList ar = new ArrayList();
        public void AddMember(Member mem)
        {
            ar.Add(mem);
        }

        public IEnumerator GetEnumerator()
        {
            return ar.GetEnumerator();
        }

    }
    //ICollection 
    public interface ICollection: IEnumerable
    {
        void CopyTO(Array array, int index);
        int Count//보관수
        {
            get;
        }
        bool IsSychronized
        {
            get;
        }
        object SyncRoot
        {
            get;
        }
    }
    //대리자 비동기
    delegate int DemoDele(int a, int b);
    
    class Program
    {
        static void Main(string[] args)
        {
            student s = new student("홍길",11);
            s.Work();

            //맴버 이뉴머레이션 
            MemberCollection mc = new MemberCollection();
            mc.AddMember(new Member(1, "hosiki"));
            mc.AddMember(new Member(2, "kakaki"));
            foreach (var item in mc)
            {
                Console.WriteLine(  item.ToString()); 
            }
            int[] arr = new int[3] { 1,2,4};
            
            ArrayList ar = new ArrayList();
            ar.Add(2);
            ar.Add(3);
            //View(ar); 왜지 안됨 

            DemoDele dele = Sum;
            dele.BeginInvoke(1, 5, EndSum, "Test");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Main: {0}",i);
                Thread.Sleep(100);
            }
            Console.ReadLine();
            
        }
        static int Sum(int a, int b)//deletast 1
        {
            int sum = 0;
            for(;a<=b; a++)
            {
                sum += a;
                Console.WriteLine("sum{0}", a);
                Thread.Sleep(100); 
            }
            return sum;
        }
        static void EndSum(IAsyncResult iar)//dele test 2
        {
            object abj = iar.AsyncState;
            AsyncResult ar = iar as AsyncResult;
            DemoDele dele = ar.AsyncState as DemoDele;
            Console.WriteLine("전달 받은 인자 {0} 수행 결과 {1}", abj,dele.EndInvoke(iar));
        }

        private static void View(ICollection ic)
        {
            Console.WriteLine("Count:{0}",ic.Count);
            foreach (var obj in ic)
            {
                Console.Write("{0}",obj);
            }
            Console.WriteLine();
        }
    }
    
}
