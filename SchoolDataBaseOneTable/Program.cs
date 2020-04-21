using System;
using System.IO;

namespace SchoolDataBaseOneTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введiть мiсце де будуть зберiгатися даннi(Приклад: D:\\mytext.txt):");
            SchoolDataBase UI = new SchoolDataBase(Console.ReadLine());
            int choise;
            while(true) // інтерфейс програми
            {
                Console.WriteLine
                    ("Виберiть дiю: 1 - Ввiд данних;2 - Вивiд данних;3 - Видалення данних;4 - Вибiрка данних; \n5 - Пошук за ключовим словом;6 - Створити клас;7 - Вивести клас;Будь-яка iнша клавiша - Вихiд");
                try
                {
                    choise = int.Parse(Console.ReadLine());
                }
                catch
                {
                    break;
                }
                switch(choise)
                {
                    case 1:
                        UI.EnterData();
                        break;
                    case 2:
                        UI.ShowData();
                        break;
                    case 3:
                        Console.WriteLine("Введiть слово з рядка який хочете видалити:");
                        UI.DeleteData(Console.ReadLine());
                        break;
                    case 4:
                        Console.WriteLine("Введiть кiлькiсть таблиць для виводу(1,2,3,4):");
                        choise = int.Parse(Console.ReadLine());
                        UI.SelectData(choise);
                        break;
                    case 5:
                        Console.WriteLine("Введiть ключове слово:");
                        UI.SearchData(Console.ReadLine());
                        break;
                    case 6:
                        Console.WriteLine("Введiть клас(Приклад:9А):");
                        UI.CreateClass(Console.ReadLine());
                        break;
                    case 7:
                        Console.WriteLine("Введiть клас(Приклад:9А):");
                        UI.SearchData(Console.ReadLine());
                        break;
                    default:
                        choise = -1;
                        break;
                }
                if (choise == (-1))
                    break;
            }
        }
    }

    class SchoolDataBase
    {
        private string path;
        private string[] srArray;
        private int[] headersPositions = new int[5];

        public SchoolDataBase(string path) // работає
        {
            string file = @"";
            this.path = file + path;
            if (!(File.Exists(path)))
            {
                try
                {
                    using (StreamWriter dataWriter = new StreamWriter(path, false, System.Text.Encoding.Default))
                    {
                        dataWriter.WriteLine("ПIБ\nДата Народження\nКлас\nУспiшнiсть\nСпецiалiзацiя");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e + "Creating fille error.");
                }
            }
            UpgradeHeadersPositions();
        }

        public void CreateClass(string classValue) // test
        {
            srArray = File.ReadAllLines(path, System.Text.Encoding.Default);
            for (int i = 0; i < srArray.Length; i++)
            {
                if (srArray[i] == "ПIБ")
                {
                    Console.WriteLine("Введiть ПIБ:");
                    srArray[i] += "\n" + Console.ReadLine();
                }
                if (srArray[i] == "Дата Народження")
                {
                    Console.WriteLine("Введiть Дата Народження:");
                    srArray[i] += "\n" + Console.ReadLine();
                }
                if (srArray[i] == "Клас")
                {
                    srArray[i] += "\n" + classValue;
                }
                if (srArray[i] == "Успiшнiсть")
                {
                    Console.WriteLine("Введiть Успішність:");
                    srArray[i] += "\n" + Console.ReadLine();
                }
                if (srArray[i] == "Спецiалiзацiя")
                {
                    Console.WriteLine("Введiть Спецiалiзацiя:");
                    srArray[i] += "\n" + Console.ReadLine();
                }
            }

            using (StreamWriter dataWriter = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                for (int i = 0; i < srArray.Length; i++)
                    dataWriter.WriteLine(srArray[i]);
            }
            UpgradeHeadersPositions();
        }

        public void EnterData() // Работає
        {
            srArray = File.ReadAllLines(path, System.Text.Encoding.Default);
            for (int i = 0; i < srArray.Length; i++)
            {
                if (srArray[i] == "ПIБ")
                {
                    Console.WriteLine("Введiть ПIБ:");
                    srArray[i] += "\n" + Console.ReadLine();
                }
                if (srArray[i] == "Дата Народження")
                {
                    Console.WriteLine("Введiть Дата Народження:");
                    srArray[i] += "\n" + Console.ReadLine();
                }
                if (srArray[i] == "Клас")
                {
                    Console.WriteLine("Введiть Клас:");
                    srArray[i] += "\n" + Console.ReadLine();
                }
                if (srArray[i] == "Успiшнiсть")
                {
                    Console.WriteLine("Введiть Успішність:");
                    srArray[i] += "\n" + Console.ReadLine();
                }
                if (srArray[i] == "Спецiалiзацiя")
                {
                    Console.WriteLine("Введiть Спецiалiзацiя:");
                    srArray[i] += "\n" + Console.ReadLine();
                }
            }

            using (StreamWriter dataWriter = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                for(int i=0;i<srArray.Length;i++)
                    dataWriter.WriteLine(srArray[i]);
            }
            UpgradeHeadersPositions();
        }

        public void SearchData(string word) // Працює
        {
            srArray = File.ReadAllLines(path, System.Text.Encoding.Default);
            int[] wordPosition = new int[50]; // 50 Макс кількість співпадань
            int wordsMatchCount = 0;
            int[] rowsForDelete = new int[50];

            for (int i = 0; i < srArray.Length; i++)
                if (srArray[i] == word)
                {
                    wordPosition[wordsMatchCount] = i;
                    wordsMatchCount++;
                }

            for (int i = 0; i < wordsMatchCount; i++)
                rowsForDelete[i] = FindWordBetweenHeaders(wordPosition[i]);

            for (int i = 0; i < wordsMatchCount - 1; i++)
                if (rowsForDelete[i] == rowsForDelete[i + 1])
                    rowsForDelete[i] = (-1);

            for (int i = 0; i < wordsMatchCount; i++)
                if (rowsForDelete[i] != -1)
                    for (int j = 0; j < headersPositions.Length; j++)
                        Console.WriteLine(srArray[headersPositions[j]] + "\n" + srArray[headersPositions[j] + rowsForDelete[i]]);
        }

        private void OutputOneTable(int choise) // Працює
        {
            switch (choise)
            {
                case 1:
                    Console.WriteLine(srArray[headersPositions[0]]); //
                    for (int i = headersPositions[0]+1; i < headersPositions[1]; i++)
                        Console.WriteLine(srArray[i]);
                    break;
                case 2:
                    Console.WriteLine(srArray[headersPositions[1]]);
                    for (int i = headersPositions[1]+1; i < headersPositions[2]; i++)
                        Console.WriteLine(srArray[i]);
                    break;
                case 3:
                    Console.WriteLine(srArray[headersPositions[3]]);
                    for (int i = headersPositions[3]+1; i < headersPositions[4]; i++)
                        Console.WriteLine(srArray[i]);
                    break;
                case 4:
                    Console.WriteLine(srArray[headersPositions[4]]);
                    for (int i = headersPositions[4]+1; i < srArray.Length; i++)
                        Console.WriteLine(srArray[i]);
                    break;
                default:
                    Console.WriteLine("Wrong number!");
                    break;
            }
        }

        public void SelectData(int tablesCount) // Працює
        {
            srArray = File.ReadAllLines(path, System.Text.Encoding.Default);
            int[] localChoise = new int[2];
            switch(tablesCount)
            {
                case 1:
                    Console.WriteLine("Виберiть рядок для вивoду(1 - ПIБ;2 - Дата Народження;3 - Успiшнiсть;4 - Спецiалiзацiя;):");
                    localChoise[0] = int.Parse(Console.ReadLine());
                    OutputOneTable(localChoise[0]);
                    break;
                case 2:
                    Console.WriteLine("Виберiть додаткову таблицю для виводу(1 - Дата Народження;2 - Успiшнiсть;3 - Спецiалiзацiя;):");
                    localChoise[0] = int.Parse(Console.ReadLine());
                    OutputOneTable(1);
                    OutputOneTable(localChoise[0]+1);
                    break;
                case 3:
                    while (true)
                    {
                        Console.WriteLine("Виберiть першу додаткову таблицю для виводу(1 - Дата Народження;2 - Успiшнiсть;3 - Спецiалiзацiя;):");
                        localChoise[0] = int.Parse(Console.ReadLine());
                        Console.WriteLine("Виберiть другу додаткову таблицю для виводу(1 - Дата Народження;2 - Успiшнiсть;3 - Спецiалiзацiя;):");
                        localChoise[1] = int.Parse(Console.ReadLine());
                        if (localChoise[0] != localChoise[1])
                            break;
                        else
                            Console.WriteLine("Вкажiть не одинаковi таблицi!");
                    }
                    OutputOneTable(1);
                    OutputOneTable(localChoise[0]+1);
                    OutputOneTable(localChoise[1]+1);
                    break;
                case 4:
                    ShowData();
                    break;
                default:
                    Console.WriteLine("Wrong table number!");
                    break;
            }
        }

        public void ShowData() // 100% работає
        {
            srArray = File.ReadAllLines(path, System.Text.Encoding.Default);
            for (int i=0;i<srArray.Length; i++)
                Console.WriteLine(srArray[i]);
        }

        private int FindWordBetweenHeaders(int rowForDelete) // Працює
        {
            for (int i = 0; i < headersPositions.Length-1; i++)
                if (headersPositions[i] < rowForDelete && rowForDelete < headersPositions[i + 1])
                    rowForDelete -= headersPositions[i];
            return rowForDelete;
        }

        public void DeleteData(string word) // Працює але залишає пропуски
        {
            srArray = File.ReadAllLines(path, System.Text.Encoding.Default);
            int[] wordPosition = new int[50]; // 50 Макс кількість співпадань
            int wordsMatchCount = 0;
            int[] rowsForDelete = new int[50];

            for (int i = 0; i < srArray.Length; i++)
                if (srArray[i] == word)
                {
                    wordPosition[wordsMatchCount] = i;
                    wordsMatchCount++;
                }

            for (int i = 0; i < wordsMatchCount; i++)
                rowsForDelete[i] = FindWordBetweenHeaders(wordPosition[i]);

            for (int i = 0; i < wordsMatchCount - 1; i++)
                if (rowsForDelete[i] == rowsForDelete[i + 1])
                    rowsForDelete[i] = (-1);

            for (int i = 0; i < wordsMatchCount; i++)
                if (rowsForDelete[i] != -1)
                    for (int j = 0; j < headersPositions.Length; j++)
                        srArray[headersPositions[j]+rowsForDelete[i]] = "";

            using (StreamWriter dataWriter = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                for (int i = 0; i < srArray.Length; i++)
                    dataWriter.WriteLine(srArray[i]);
            }
            UpgradeHeadersPositions();
        }

        private void UpgradeHeadersPositions() // Работає
        {
            int i = 0;
            srArray = File.ReadAllLines(path, System.Text.Encoding.Default);

            while (srArray[i] != "Дата Народження")
            {
                if (srArray[i] == "ПIБ")
                    headersPositions[0] = i;
                i++;
            }

            while (srArray[i] != "Клас")
            {
                if (srArray[i] == "Дата Народження")
                    headersPositions[1] = i;
                    i++;
            }

            while (srArray[i] != "Успiшнiсть")
            {
                if (srArray[i] == "Клас")
                    headersPositions[2] = i;
                i++;
            }

            while (srArray[i] != "Спецiалiзацiя")
            {
                if (srArray[i] == "Успiшнiсть")
                    headersPositions[3] = i;
                i++;
            }

            while (i < srArray.Length)
            {
                if (srArray[i] == "Спецiалiзацiя")
                    headersPositions[4] = i;
                i++;
            }
        }
    }
}
