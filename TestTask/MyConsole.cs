using System;
using System.IO;
using TestTask.constants;

namespace TestTask
{
	public static class MyConsole
	{
        public static int CountThreads = 0;
        private static bool isWork = true;

        public static void StartConsole()
        {
            while (isWork)
            {
                Console.Write(Paths.PathToTest + ">");
                var inputComand = Console.ReadLine().Split(' ');
                var comand = inputComand[0];

                switch (comand.ToLower())
                {
                    case "cd":
                        ChangeDirectory(inputComand);
                        break;
                    case "dir":
                        ShowDirectory(inputComand);
                        break;
                    case "runtest":
                        SelectTestMethod(inputComand);
                        break;
                }
            }
        }

        private static void SelectTestMethod(string[] inputComand)
        {
            if (inputComand.Length > 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверная запись команды");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            if (inputComand.Length <= 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверная запись команды. Нужно записать название сборки теста.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            if (File.Exists(Path.Combine(Paths.PathToTest, inputComand[1])))
            {
                Paths.PathToTest += "\\" + inputComand[1];
                Console.WriteLine("Введите количество потоков:");
                CountThreads = int.Parse(Console.ReadLine());
                
                if(CountThreads > Environment.ProcessorCount)
                {
                    Console.WriteLine($"Количество потоков не должно превышать количество ядер компьютера ({Environment.ProcessorCount}).");
                    CountThreads = Environment.ProcessorCount;
                }

                isWork = false;
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Тест не найден.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static void ShowDirectory(string[] inputComand)
        {
            if (inputComand.Length > 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверная запись команды");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            var files = Directory.EnumerateFileSystemEntries(Paths.PathToTest);

            foreach (var file in files)
            {
                var fileWithOutType = file.Remove(0, Paths.PathToTest.Length).Split('.');

                if (fileWithOutType.Length > 1)
                {
                    if (fileWithOutType[1] != "dll")
                    {
                        continue;
                    }

                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write(file.Substring(Paths.PathToTest.Length) + "  ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
        }

        private static void ChangeDirectory(string[] inputComand)
        {
            if (inputComand.Length > 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверная запись команды");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            if (inputComand.Length <= 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверная запись команды. Нужно записать директорию");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            var isExist = Directory.Exists(inputComand[1]);

            if (isExist)
            {
                Paths.PathToTest = inputComand[1];
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверный путь " + inputComand[1]);
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
    }
}
