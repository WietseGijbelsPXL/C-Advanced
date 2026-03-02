using System.Reflection.Metadata;
using System.Text;

namespace File_IO_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //StreamReader sr = new StreamReader("Data.txt");
            //while (!sr.EndOfStream)
            //{
            //    Console.WriteLine(sr.ReadLine());
            //}
            //sr.Close();

            //using (StreamReader streamr = new StreamReader("Data.txt"))
            //{
            //    while (!streamr.EndOfStream)
            //    {
            //        Console.WriteLine(streamr.ReadLine());
            //    }
            //}

            //StreamWriter sw = new StreamWriter("demo.txt",true);
            //for (int i = 0; i < 10; i++)
            //{
            //    sw.WriteLine(i);
            //}
            //sw.Close();

            //byte[] buffer = Encoding.UTF8.GetBytes("Hello World");
            //using (FileStream fs = new FileStream("data.bin", FileMode.Create))
            //{
            //    fs.Write(buffer,0,buffer.Length);
            //}

            //byte[] buffer = new byte[1024];
            //using (FileStream fs = new FileStream("data.bin", FileMode.Open))
            //{
            //    int length = fs.Read(buffer,0,1024);
            //    Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, length));
            //}

            DirectoryInfo dirinfo = new DirectoryInfo("C:\\Users\\Eigenaar\\Desktop\\Wietse\\School\\PXL\\Data Advanced");
            if (dirinfo.Exists)
            {
                foreach (FileInfo file in dirinfo.GetFiles())
                {
                    Console.WriteLine(file.FullName);
                }
            }
            else
            {
                dirinfo.CreateSubdirectory("testje");
            }
        }
    }
}
