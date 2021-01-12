using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace 언제나_휴일직렬화
{
    [Serializable]
    class Man
    {
        internal string Name
        {
            get;
            private set;
        }
        internal int Age
        {
            get;
            private set;

        }
        internal Man(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public override string ToString()
        {
            return string.Format("이름 : {0} , 나이 : {1}", Name,Age);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //바이너리 포멧
            Man man = new Man("홍길동", 29);
            FileStream fs = new FileStream("man.txt",FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, man);
            fs.Close();

            FileStream fs2 = new FileStream("man.txt", FileMode.Open);
            BinaryFormatter bf2 = new BinaryFormatter();
            Man man2 = bf2.Deserialize(fs2) as Man;
            fs2.Close();

            Console.WriteLine(man2);
            //소프 포메ㅐㅅ
            Man man3 = new Man("홍길동", 33);
            FileStream fs3 = new FileStream("man2.xml", FileMode.Create);
            SoapFormatter bf3 = new SoapFormatter();
            bf3.Serialize(fs3, man3);
            fs.Close();

            FileStream fs4 = new FileStream("man2.xml", FileMode.Open);
            SoapFormatter bf4 = new SoapFormatter();
            Man man4 = bf4.Deserialize(fs4) as Man;
            fs4.Close();

            Console.WriteLine(man4);
        }
    }
}
