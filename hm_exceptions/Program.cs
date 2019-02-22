using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace hm_exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            string site = "https://alekseygulynin.ru";
            WebExistRequest(site);

            //List<int> arr = new List<int>();
            //Random rnd = new Random();
            //for (int i = 0; i < 5; i++)
            //{                
            //    arr.Add(rnd.Next(20));                
            //}
            //ArrayBorders(arr, 4);

            //string IIN = "";
            //CheckIIN(out IIN);
        }

        //1.	Перехватить исключение запроса к несуществующему веб ресурсу и вывести сообщение о том, что произошла ошибка. 
        //Программа должна завершиться без ошибок.
        public static void WebExistRequest(string site)
        {
            try
            {
                WebRequest req = WebRequest.Create(site);
                req.Credentials = CredentialCache.DefaultCredentials;
                WebResponse res = req.GetResponse();
                //Console.WriteLine(((HttpWebResponse)res).StatusDescription);                
                res.Close();
                Console.WriteLine("Сайт существует и доступен");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //2.	Написать программу, которая обращается к элементам массива по индексу и выходит за его пределы. 
        //После обработки исключения вывести в финальном блоке сообщение о завершении обработки массива.
        public static int ArrayBorders(List<int> arr, int index)
        {
            try
            {
                return arr[index];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1000;
            }
            finally
            {
                Console.WriteLine("Завершение обработки массива");
            }
        }

        //3.	Реализовать несколько методов или классов с методами и вызвать один метод из другого. 
        //В вызываемом методе сгенерировать исключение и «поднять» его в вызывающий метод.
        public static void IINString(out string IIN)
        {
            IIN = null;
            try
            {
                Console.WriteLine("Введите ИИН:");
                string str = Console.ReadLine();
                if (str.Length != 12)
                    throw new Exception("Неправильный ИИН");
                IIN = str;
            }
            catch 
            {
                Console.Write("Исключение: ");                
                throw;
            }
            
        }

        public static void CheckIIN(out string IIN)
        {
            IIN = null;
            try
            {
                IINString(out IIN);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
