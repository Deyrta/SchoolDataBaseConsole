using System;
using System.IO;
using System.Linq;

namespace SchoolDataBaseConsole
{
    class Program
    {
        static int Main(string[] args)
        {
            DataBaseInterface DB = new DataBaseInterface();
            DB.DBInterface();
            return 0;
        }
    }

    class DataBaseInterface : DataBaseLogic
    {
        DataBaseLogic programmeInterface;
        public DataBaseInterface() : base()
        {
            programmeInterface = new DataBaseLogic(); 
        }

        public void DBInterface()
        {
            int choise;
            int localChoise;
            while(true)
            {
                Console.WriteLine("Pick action(1 - Search Data; 2 - OutPut Data; 3 - Delete Data; 4 - Enter Data; Anything else to exit:");
                choise = int.Parse(Console.ReadLine());

                switch(choise)
                {
                    case 1:
                        Console.WriteLine("Write table number where you want to find a word:");
                        localChoise = int.Parse(Console.ReadLine());
                        Console.WriteLine("Write a word to search:");
                        programmeInterface.SearchData(Console.ReadLine(),localChoise);
                        break;
                    case 2:
                        Console.WriteLine("How many tables you want to see(1,2,3)?");
                        localChoise = int.Parse(Console.ReadLine());
                        if(localChoise != 2 && localChoise != 3 && localChoise != 1)
                        {
                            Console.WriteLine("You picked wrong number.");
                            continue;
                        }
                        else 
                            programmeInterface.OutputData(localChoise);
                        break;
                    case 3:
                        Console.WriteLine("Pick table where you want to delete a label.");
                        localChoise = int.Parse(Console.ReadLine());
                        Console.WriteLine("Pick a word from label:");
                        programmeInterface.DeleteData(Console.ReadLine(),localChoise);
                        break;
                    case 4:
                        Console.WriteLine("Pick a table where you want to enter a data");
                        programmeInterface.EnterData(int.Parse(Console.ReadLine()));
                        break;
                    case 5:
                        Console.WriteLine("Pick how many tables(Use keys 1,2,3:");
                        localChoise = int.Parse(Console.ReadLine());
                        if (localChoise != 2 && localChoise != 3 && localChoise != 1)
                        {
                            Console.WriteLine("You picked wrong number.");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Pick a word:");
                            programmeInterface.SelectData(localChoise, Console.ReadLine());
                        }
                            break;
                    default:
                        choise = -1;
                        Console.WriteLine("Exiting program...");
                        break;
                }
                if (choise == -1)
                    break;
            }
        }
    }

    class DataBaseLogic
    {
        private string QuestionnairePath = @"D:\QuestionnaireDataTable.txt";
        private string schoolsPath = @"D:\SchoolsDataTable.txt";
        private string classesPath = @"D:\ClassesDataTable.txt";
        private StreamWriter dataWriter;
        private string[] srArray;

        public DataBaseLogic()
        {
            if (!(File.Exists(QuestionnairePath)))
            {
                try
                {
                    using (dataWriter = new StreamWriter(QuestionnairePath, false, System.Text.Encoding.Default))
                    {
                        dataWriter.WriteLine("Full Name\nSchool Number\nClass Number\nClass Teacher\nClass Specialisation");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e + "Creating fille error. Code: 1");
                }
            }
            if (!(File.Exists(schoolsPath)))
            {
                try
                {
                    using (dataWriter = new StreamWriter(schoolsPath, false, System.Text.Encoding.Default))
                    {
                        dataWriter.WriteLine("School number\nSchool Level\nSchool Specialisation\nSchool Director");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e + "Creating fille error. Code: 2");
                }
            }
            if (!(File.Exists(classesPath)))
            {
                try
                {
                    using (dataWriter = new StreamWriter(classesPath, false, System.Text.Encoding.Default))
                    {
                        dataWriter.WriteLine("Number of Students in Class\nClass Teacher\nClass Specialisation");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e + "Creating fille error. Code: 3");
                }
            }
        }

        public void SelectData(int tableValue, string word) // затестити 2 і 3
        {
            int[] tableChoise = new int[2];
            int i = 0;
            int wordPositionValue;
            string[] tempFiles = new string[10]
            { @"D:\TempFile1.txt", @"D:\TempFile2.txt", @"D:\TempFile3.txt", @"D:\TempFile4.txt", @"D:\TempFile5.txt",
                @"D:\TempFile6.txt",@"D:\TempFile7.txt",@"D:\TempFile8.txt",@"D:\TempFile9.txt",@"D:\TempFile10.txt"};
            string[] temporaryArray;
            int[] wordPosition = new int[50];
            if (tableValue==1) 
            {
                Console.WriteLine("Which table?");
                int localChoise = int.Parse(Console.ReadLine());
                SearchData(word, localChoise);
            } // работає 100%

            else if(tableValue==2) 
            {
                Console.WriteLine("Pick first table(Use keys 1,2,3:)");
                tableChoise[0] = int.Parse(Console.ReadLine());
                Console.WriteLine("Pick second table(Use keys 1,2,3:)");
                tableChoise[1] = int.Parse(Console.ReadLine());
                if (tableChoise[0] > tableChoise[1])
                {
                    int swap = tableChoise[0];
                    tableChoise[0] = tableChoise[1];
                    tableChoise[1] = swap;
                }

                switch (tableChoise[0]+tableChoise[1])
                {
                    case 3: // 1 2
                        for (int j = 0; j < wordPosition.Length; j++)
                            wordPosition[j] = (-1);
                        srArray = File.ReadAllLines(QuestionnairePath, System.Text.Encoding.Default);  // Search in first table
                        if (srArray[i] == "Full Name")
                        {
                            using (dataWriter = new StreamWriter(tempFiles[0], false, System.Text.Encoding.Default))
                            {
                                while (srArray[i] != "School Number")
                                {
                                    dataWriter.WriteLine(srArray[i]);
                                    i++;
                                }
                            }
                        }
                        if (srArray[i] == "School Number")
                        {
                            using (dataWriter = new StreamWriter(tempFiles[1], false, System.Text.Encoding.Default))
                            {
                                while (srArray[i] != "Class Number")
                                {
                                    dataWriter.WriteLine(srArray[i]);
                                    i++;
                                }
                            }
                        }
                        if (srArray[i] == "Class Number")
                        {
                            using (dataWriter = new StreamWriter(tempFiles[2], false, System.Text.Encoding.Default))
                            {
                                while (srArray[i] != "Class Teacher")
                                {
                                    dataWriter.WriteLine(srArray[i]);
                                    i++;
                                }
                            }
                        }
                        if (srArray[i] == "Class Teacher")
                        {
                            using (dataWriter = new StreamWriter(tempFiles[3], false, System.Text.Encoding.Default))
                            {
                                while (srArray[i] != "Class Specialisation")
                                {
                                    dataWriter.WriteLine(srArray[i]);
                                    i++;
                                }
                            }
                        }
                        if (srArray[i] == "Class Specialisation")
                        {
                            using (dataWriter = new StreamWriter(tempFiles[4], false, System.Text.Encoding.Default))
                            {
                                while (i < srArray.Length)
                                {
                                    dataWriter.WriteLine(srArray[i]);
                                    i++;
                                }
                            }
                        }

                        
                        srArray = File.ReadAllLines(schoolsPath, System.Text.Encoding.Default);   // search in second table
                        for (int j = 0; i < srArray.Length; i++)
                            if (srArray[j] == "School Level")
                            {
                                i = j;
                                break;
                            }
                        if (srArray[i] == "School Level")
                        {
                            using (dataWriter = new StreamWriter(tempFiles[5], false, System.Text.Encoding.Default))
                            {
                                while (srArray[i] != "School Specialisation")
                                {
                                    dataWriter.WriteLine(srArray[i]);
                                    i++;
                                }
                            }
                        }
                        if (srArray[i] == "School Specialisation")
                        {
                            using (dataWriter = new StreamWriter(tempFiles[6], false, System.Text.Encoding.Default))
                            {
                                while (srArray[i] != "School Director")
                                {
                                    dataWriter.WriteLine(srArray[i]);
                                    i++;
                                }
                            }
                        }
                        if (srArray[i] == "School Director")
                        {
                            using (dataWriter = new StreamWriter(tempFiles[7], false, System.Text.Encoding.Default))
                            {
                                while (i < srArray.Length)
                                {
                                    dataWriter.WriteLine(srArray[i]);
                                    i++;
                                }
                            }
                        }

                        wordPositionValue = 0;

                        for (i = 0; i < 7; i++)
                        {
                            temporaryArray = File.ReadAllLines(tempFiles[i], System.Text.Encoding.Default);
                            for (int k = 0; k < temporaryArray.Length; k++)
                            {
                                if (temporaryArray[k] == word)
                                {
                                    wordPosition[wordPositionValue] = k;
                                    wordPositionValue++;
                                }
                            }
                        }

                        for (int j = 0; j < wordPositionValue; j++)
                            if (wordPosition[j] != (-1))
                            {
                                for (int k = 0; k < 7; k++)
                                {
                                    temporaryArray = File.ReadAllLines(tempFiles[k], System.Text.Encoding.Default);
                                    Console.WriteLine(temporaryArray[0] + "\n" + temporaryArray[wordPosition[j]]);
                                }
                            }

                        for (i = 0; i < 7; i++)
                            if (File.Exists(tempFiles[i]))
                                File.Delete(tempFiles[i]);
                        break;
                    case 5: // 2 3
                        for (int j = 0; j < wordPosition.Length; j++)
                            wordPosition[j] = (-1);
                        i = 0;
                        srArray = File.ReadAllLines(schoolsPath, System.Text.Encoding.Default);   // search in second table
                        if (srArray[i] == "School number")
                        {
                            using (dataWriter = new StreamWriter(tempFiles[0], false, System.Text.Encoding.Default))
                            {
                                while (srArray[i] != "School Level")
                                {
                                    dataWriter.WriteLine(srArray[i]);
                                    i++;
                                }
                            }
                        }
                        if (srArray[i] == "School Level")
                        {
                            using (dataWriter = new StreamWriter(tempFiles[1], false, System.Text.Encoding.Default))
                            {
                                while (srArray[i] != "School Specialisation")
                                {
                                    dataWriter.WriteLine(srArray[i]);
                                    i++;
                                }
                            }
                        }
                        if (srArray[i] == "School Specialisation")
                        {
                            using (dataWriter = new StreamWriter(tempFiles[2], false, System.Text.Encoding.Default))
                            {
                                while (srArray[i] != "School Director")
                                {
                                    dataWriter.WriteLine(srArray[i]);
                                    i++;
                                }
                            }
                        }
                        if (srArray[i] == "School Director")
                        {
                            using (dataWriter = new StreamWriter(tempFiles[3], false, System.Text.Encoding.Default))
                            {
                                while (i < srArray.Length)
                                {
                                    dataWriter.WriteLine(srArray[i]);
                                    i++;
                                }
                            }
                        }

                        i = 0;
                        srArray = File.ReadAllLines(classesPath, System.Text.Encoding.Default); // third table
                        if (srArray[i] == "Number of Students in Class")
                        {
                            using (dataWriter = new StreamWriter(tempFiles[4], false, System.Text.Encoding.Default))
                            {
                                while (srArray[i] != "Class Teacher")
                                {
                                    dataWriter.WriteLine(srArray[i]);
                                    i++;
                                }
                            }
                        }
                        if (srArray[i] == "Class Teacher")
                        {
                            using (dataWriter = new StreamWriter(tempFiles[5], false, System.Text.Encoding.Default))
                            {
                                while (srArray[i] != "Class Specialisation")
                                {
                                    dataWriter.WriteLine(srArray[i]);
                                    i++;
                                }
                            }
                        }
                        if (srArray[i] == "Class Specialisation")
                        {
                            using (dataWriter = new StreamWriter(tempFiles[6], false, System.Text.Encoding.Default))
                            {
                                while (i < srArray.Length)
                                {
                                    dataWriter.WriteLine(srArray[i]);
                                    i++;
                                }
                            }
                        }

                        wordPositionValue = 0;

                        for (i = 0; i < 7; i++)
                        {
                            temporaryArray = File.ReadAllLines(tempFiles[i], System.Text.Encoding.Default);
                            for (int k = 0; k < temporaryArray.Length; k++)
                            {
                                if (temporaryArray[k] == word)
                                {
                                    wordPosition[wordPositionValue] = k;
                                    wordPositionValue++;
                                }
                            }
                        }

                        for (int j = 0; j < wordPositionValue; j++)
                            if (wordPosition[j] != (-1))
                            {
                                for (int k = 0; k < 7; k++)
                                {
                                    temporaryArray = File.ReadAllLines(tempFiles[k], System.Text.Encoding.Default);
                                    Console.WriteLine(temporaryArray[0] + "\n" + temporaryArray[wordPosition[j]]);
                                }
                            }

                        for (i = 0; i < 7; i++)
                            if (File.Exists(tempFiles[i]))
                                File.Delete(tempFiles[i]);
                        break;
                    case 4: // 1 3
                        for (int j = 0; j < wordPosition.Length; j++)
                            wordPosition[j] = (-1);
                        i = 0;
                        srArray = File.ReadAllLines(QuestionnairePath, System.Text.Encoding.Default);  // Search in first table
                        if (srArray[i] == "Full Name")
                        {
                            using (dataWriter = new StreamWriter(tempFiles[0], false, System.Text.Encoding.Default))
                            {
                                while (srArray[i] != "School Number")
                                {
                                    dataWriter.WriteLine(srArray[i]);
                                    i++;
                                }
                            }
                        }
                        if (srArray[i] == "School Number")
                        {
                            using (dataWriter = new StreamWriter(tempFiles[1], false, System.Text.Encoding.Default))
                            {
                                while (srArray[i] != "Class Number")
                                {
                                    dataWriter.WriteLine(srArray[i]);
                                    i++;
                                }
                            }
                        }
                        if (srArray[i] == "Class Number")
                        {
                            using (dataWriter = new StreamWriter(tempFiles[2], false, System.Text.Encoding.Default))
                            {
                                while (srArray[i] != "Class Teacher")
                                {
                                    dataWriter.WriteLine(srArray[i]);
                                    i++;
                                }
                            }
                        }
                        if (srArray[i] == "Class Teacher")
                        {
                            using (dataWriter = new StreamWriter(tempFiles[3], false, System.Text.Encoding.Default))
                            {
                                while (srArray[i] != "Class Specialisation")
                                {
                                    dataWriter.WriteLine(srArray[i]);
                                    i++;
                                }
                            }
                        }
                        if (srArray[i] == "Class Specialisation")
                        {
                            using (dataWriter = new StreamWriter(tempFiles[4], false, System.Text.Encoding.Default))
                            {
                                while (i < srArray.Length)
                                {
                                    dataWriter.WriteLine(srArray[i]);
                                    i++;
                                }
                            }
                        }

                        i = 0;
                        srArray = File.ReadAllLines(classesPath, System.Text.Encoding.Default); // third table
                        if (srArray[i] == "Number of Students in Class")
                        {
                            using (dataWriter = new StreamWriter(tempFiles[5], false, System.Text.Encoding.Default))
                            {
                                while (srArray[i] != "Class Teacher")
                                {
                                    dataWriter.WriteLine(srArray[i]);
                                    i++;
                                }
                            }
                        }

                        wordPositionValue = 0;

                        for (i = 0; i < 6; i++)
                        {
                            temporaryArray = File.ReadAllLines(tempFiles[i], System.Text.Encoding.Default);
                            for (int k = 0; k < temporaryArray.Length; k++)
                            {
                                if (temporaryArray[k] == word)
                                {
                                    wordPosition[wordPositionValue] = k;
                                    wordPositionValue++;
                                }
                            }
                        }

                        for (int j = 0; j < wordPositionValue; j++)
                            if (wordPosition[j] != (-1))
                            {
                                for (int k = 0; k < 6; k++)
                                {
                                    temporaryArray = File.ReadAllLines(tempFiles[k], System.Text.Encoding.Default);
                                    Console.WriteLine(temporaryArray[0] + "\n" + temporaryArray[wordPosition[j]]);
                                }
                            }

                        for (i = 0; i < 6; i++)
                            if (File.Exists(tempFiles[i]))
                                File.Delete(tempFiles[i]);
                        break;
                }
            } // Затестити

            else if(tableValue==3)
            {
                for(int j = 0; j < wordPosition.Length; j++)
                            wordPosition[j] = (-1);
                srArray = File.ReadAllLines(QuestionnairePath, System.Text.Encoding.Default);  // Search in first table
                if (srArray[i] == "Full Name")
                {
                    using (dataWriter = new StreamWriter(tempFiles[0], false, System.Text.Encoding.Default))
                    {
                        while (srArray[i] != "School Number")
                        {
                            dataWriter.WriteLine(srArray[i]);
                            i++;
                        }
                    }
                }
                if (srArray[i] == "School Number")
                {
                    using (dataWriter = new StreamWriter(tempFiles[1], false, System.Text.Encoding.Default))
                    {
                        while (srArray[i] != "Class Number")
                        {
                            dataWriter.WriteLine(srArray[i]);
                            i++;
                        }
                    }
                }
                if (srArray[i] == "Class Number")
                {
                    using (dataWriter = new StreamWriter(tempFiles[2], false, System.Text.Encoding.Default))
                    {
                        while (srArray[i] != "Class Teacher")
                        {
                            dataWriter.WriteLine(srArray[i]);
                            i++;
                        }
                    }
                }
                if (srArray[i] == "Class Teacher")
                {
                    using (dataWriter = new StreamWriter(tempFiles[3], false, System.Text.Encoding.Default))
                    {
                        while (srArray[i] != "Class Specialisation")
                        {
                            dataWriter.WriteLine(srArray[i]);
                            i++;
                        }
                    }
                }
                if (srArray[i] == "Class Specialisation")
                {
                    using (dataWriter = new StreamWriter(tempFiles[4], false, System.Text.Encoding.Default))
                    {
                        while (i < srArray.Length)
                        {
                            dataWriter.WriteLine(srArray[i]);
                            i++;
                        }
                    }
                }


                srArray = File.ReadAllLines(schoolsPath, System.Text.Encoding.Default);   // search in second table
                for (int j = 0; i < srArray.Length; i++)
                    if (srArray[j] == "School Level")
                    {
                        i = j;
                        break;
                    }
                if (srArray[i] == "School Level")
                {
                    using (dataWriter = new StreamWriter(tempFiles[5], false, System.Text.Encoding.Default))
                    {
                        while (srArray[i] != "School Specialisation")
                        {
                            dataWriter.WriteLine(srArray[i]);
                            i++;
                        }
                    }
                }
                if (srArray[i] == "School Specialisation")
                {
                    using (dataWriter = new StreamWriter(tempFiles[6], false, System.Text.Encoding.Default))
                    {
                        while (srArray[i] != "School Director")
                        {
                            dataWriter.WriteLine(srArray[i]);
                            i++;
                        }
                    }
                }
                if (srArray[i] == "School Director")
                {
                    using (dataWriter = new StreamWriter(tempFiles[7], false, System.Text.Encoding.Default))
                    {
                        while (i < srArray.Length)
                        {
                            dataWriter.WriteLine(srArray[i]);
                            i++;
                        }
                    }
                }

                i = 0;
                srArray = File.ReadAllLines(classesPath, System.Text.Encoding.Default); // third table
                if (srArray[i] == "Number of Students in Class")
                {
                    using (dataWriter = new StreamWriter(tempFiles[8], false, System.Text.Encoding.Default))
                    {
                        while (srArray[i] != "Class Teacher")
                        {
                            dataWriter.WriteLine(srArray[i]);
                            i++;
                        }
                    }
                }

                wordPositionValue = 0;

                for (i = 0; i < 9; i++)
                {
                    temporaryArray = File.ReadAllLines(tempFiles[i], System.Text.Encoding.Default);
                    for (int k = 0; k < temporaryArray.Length; k++)
                    {
                        if (temporaryArray[k] == word)
                        {
                            wordPosition[wordPositionValue] = k;
                            wordPositionValue++;
                        }
                    }
                }

                for (int j = 0; j < wordPositionValue; j++)
                    if (wordPosition[j] != (-1))
                    {
                        for (int k = 0; k < 9; k++)
                        {
                            temporaryArray = File.ReadAllLines(tempFiles[k], System.Text.Encoding.Default);
                            Console.WriteLine(temporaryArray[0] + "\n" + temporaryArray[wordPosition[j]]);
                        }
                    }

                for (i = 0; i < 9; i++)
                    if (File.Exists(tempFiles[i]))
                        File.Delete(tempFiles[i]);
            } // затестити
        }

        public void EnterData(int tableNumber) // работає
        {
            switch (tableNumber)
            {
                case 1:
                    Console.WriteLine("You picked first table, enter a data:");
                    srArray = File.ReadAllLines(QuestionnairePath, System.Text.Encoding.Default);
                    for (int i = 0; i < srArray.Length; i++)
                    {
                        if (srArray[i] == "Full Name")
                        {
                            Console.WriteLine("Enter Full name:");
                            srArray[i] += "\n" + Console.ReadLine();
                        }
                        if (srArray[i] == "School Number")
                        {
                            Console.WriteLine("Enter School Number");
                            srArray[i] += "\n" + Console.ReadLine();
                        }
                        if (srArray[i] == "Class Number")
                        {
                            Console.WriteLine("Enter Class number:");
                            srArray[i] += "\n" + Console.ReadLine();
                        }
                        if (srArray[i] == "Class Teacher")
                        {
                            Console.WriteLine("Enter Class Teacher:");
                            srArray[i] += "\n" + Console.ReadLine();
                        }
                        if (srArray[i] == "Class Specialisation")
                        {
                            Console.WriteLine("Enter Class Specialisation");
                            srArray[i] += "\n" + Console.ReadLine();
                        }
                    }
                    File.WriteAllLines(QuestionnairePath, srArray, System.Text.Encoding.Default);
                    break;
                case 2:
                    Console.WriteLine("You picked second table, enter a data:");
                    srArray = File.ReadAllLines(schoolsPath, System.Text.Encoding.Default);
                    for (int i = 0; i < srArray.Length; i++)
                    {
                        if (srArray[i] == "School number")
                        {
                            Console.WriteLine("Enter School number:");
                            srArray[i] += "\n" + Console.ReadLine();
                        }
                        if (srArray[i] == "School Level")
                        {
                            Console.WriteLine("Enter School Level:");
                            srArray[i] += "\n" + Console.ReadLine();
                        }
                        if (srArray[i] == "School Specialisation")
                        {
                            Console.WriteLine("Enter School Specialisation:");
                            srArray[i] += "\n" + Console.ReadLine();
                        }
                        if (srArray[i] == "School Director")
                        {
                            Console.WriteLine("Enter School Director:");
                            srArray[i] += "\n" + Console.ReadLine();
                        }
                    }
                    File.WriteAllLines(schoolsPath, srArray, System.Text.Encoding.Default);
                    break;
                case 3:
                    Console.WriteLine("You picked third table, enter a data:");
                    srArray = File.ReadAllLines(classesPath, System.Text.Encoding.Default);
                    for (int i = 0; i < srArray.Length; i++)
                    {
                        if (srArray[i] == "Number of Students in Class")
                        {
                            Console.WriteLine("Enter Number of Students in Class:");
                            srArray[i] += "\n" + Console.ReadLine();
                        }
                        if (srArray[i] == "Class Teacher")
                        {
                            Console.WriteLine("Enter Class Teacher:");
                            srArray[i] += "\n" + Console.ReadLine();
                        }
                        if (srArray[i] == "Class Specialisation")
                        {
                            Console.WriteLine("Enter School Director:");
                            srArray[i] += "\n" + Console.ReadLine();
                        }
                    }
                    File.WriteAllLines(classesPath, srArray, System.Text.Encoding.Default);
                    break;
            }
        }

        public void SearchData(string word, int tableValue) // Перетестити
        {
            int i = 0;
            int wordPositionValue;
            string[] tempFiles = new string[5] { @"D:\TempFile1.txt", @"D:\TempFile2.txt", @"D:\TempFile3.txt", @"D:\TempFile4.txt", @"D:\TempFile5.txt" };
            string[] temporaryArray;
            int[] wordPosition = new int[50];

            switch (tableValue)
            {
                case 1:
                    for (int j = 0; j < wordPosition.Length; j++)
                        wordPosition[j] = (-1);
                    srArray = File.ReadAllLines(QuestionnairePath, System.Text.Encoding.Default);  // Search in first table
                    if (srArray[i] == "Full Name")
                    {
                        using (dataWriter = new StreamWriter(tempFiles[0], false, System.Text.Encoding.Default))
                        {
                            while (srArray[i] != "School Number")
                            {
                                dataWriter.WriteLine(srArray[i]);
                                i++;
                            }
                        }
                    }
                    if (srArray[i] == "School Number")
                    {
                        using (dataWriter = new StreamWriter(tempFiles[1], false, System.Text.Encoding.Default))
                        {
                            while (srArray[i] != "Class Number")
                            {
                                dataWriter.WriteLine(srArray[i]);
                                i++;
                            }
                        }
                    }
                    if (srArray[i] == "Class Number")
                    {
                        using (dataWriter = new StreamWriter(tempFiles[2], false, System.Text.Encoding.Default))
                        {
                            while (srArray[i] != "Class Teacher")
                            {
                                dataWriter.WriteLine(srArray[i]);
                                i++;
                            }
                        }
                    }
                    if (srArray[i] == "Class Teacher")
                    {
                        using (dataWriter = new StreamWriter(tempFiles[3], false, System.Text.Encoding.Default))
                        {
                            while (srArray[i] != "Class Specialisation")
                            {
                                dataWriter.WriteLine(srArray[i]);
                                i++;
                            }
                        }
                    }
                    if (srArray[i] == "Class Specialisation")
                    {
                        using (dataWriter = new StreamWriter(tempFiles[4], false, System.Text.Encoding.Default))
                        {
                            while (i < srArray.Length)
                            {
                                dataWriter.WriteLine(srArray[i]);
                                i++;
                            }
                        }
                    }

                    wordPositionValue = 0;

                    for (i = 0; i < tempFiles.Length; i++)
                    {
                        temporaryArray = File.ReadAllLines(tempFiles[i], System.Text.Encoding.Default);
                        for (int k = 0; k < temporaryArray.Length; k++)
                        {
                            if (temporaryArray[k] == word)
                            {
                                wordPosition[wordPositionValue] = k;
                                wordPositionValue++;
                            }
                        }
                    }

                    for (int j = 0; j < wordPositionValue; j++)
                        if (wordPosition[j] != (-1))
                        {
                            for (int k = 0; k < 3; k++)
                            {
                                temporaryArray = File.ReadAllLines(tempFiles[k], System.Text.Encoding.Default);
                                Console.WriteLine(temporaryArray[0] + "\n" + temporaryArray[wordPosition[j]]);
                            }
                        }

                    for (i = 0; i < tempFiles.Length; i++)
                        if (File.Exists(tempFiles[i]))
                            File.Delete(tempFiles[i]);
                    break;
                case 2:
                    for (int j = 0; j < wordPosition.Length; j++)
                        wordPosition[j] = (-1);
                    i = 0;
                    srArray = File.ReadAllLines(schoolsPath, System.Text.Encoding.Default);   // search in second table
                    if (srArray[i] == "School number")
                    {
                        using (dataWriter = new StreamWriter(tempFiles[0], false, System.Text.Encoding.Default))
                        {
                            while (srArray[i] != "School Level")
                            {
                                dataWriter.WriteLine(srArray[i]);
                                i++;
                            }
                        }
                    }
                    if (srArray[i] == "School Level")
                    {
                        using (dataWriter = new StreamWriter(tempFiles[1], false, System.Text.Encoding.Default))
                        {
                            while (srArray[i] != "School Specialisation")
                            {
                                dataWriter.WriteLine(srArray[i]);
                                i++;
                            }
                        }
                    }
                    if (srArray[i] == "School Specialisation")
                    {
                        using (dataWriter = new StreamWriter(tempFiles[2], false, System.Text.Encoding.Default))
                        {
                            while (srArray[i] != "School Director")
                            {
                                dataWriter.WriteLine(srArray[i]);
                                i++;
                            }
                        }
                    }
                    if (srArray[i] == "School Director")
                    {
                        using (dataWriter = new StreamWriter(tempFiles[3], false, System.Text.Encoding.Default))
                        {
                            while (i < srArray.Length)
                            {
                                dataWriter.WriteLine(srArray[i]);
                                i++;
                            }
                        }
                    }

                    wordPositionValue = 0;

                    for (i = 0; i < 4; i++)
                    {
                        temporaryArray = File.ReadAllLines(tempFiles[i], System.Text.Encoding.Default);
                        for (int k = 0; k < temporaryArray.Length; k++)
                        {
                            if (temporaryArray[k] == word)
                            {
                                wordPosition[wordPositionValue] = k;
                                wordPositionValue++;
                            }
                        }
                    }

                    for (int j = 0; j < wordPositionValue; j++)
                        if (wordPosition[j] != (-1))
                        {
                            for (int k = 0; k < 3; k++)
                            {
                                temporaryArray = File.ReadAllLines(tempFiles[k], System.Text.Encoding.Default);
                                Console.WriteLine(temporaryArray[0] + "\n" + temporaryArray[wordPosition[j]]);
                            }
                        }

                    for (i = 0; i < 4; i++)
                        if (File.Exists(tempFiles[i]))
                            File.Delete(tempFiles[i]);
                    break;
                case 3:
                    for (int j = 0; j < wordPosition.Length; j++)
                        wordPosition[j] = (-1);
                    i = 0;
                    srArray = File.ReadAllLines(classesPath, System.Text.Encoding.Default); // third table
                    if (srArray[i] == "Number of Students in Class")
                    {
                        using (dataWriter = new StreamWriter(tempFiles[0], false, System.Text.Encoding.Default))
                        {
                            while (srArray[i] != "Class Teacher")
                            {
                                dataWriter.WriteLine(srArray[i]);
                                i++;
                            }
                        }
                    }
                    if (srArray[i] == "Class Teacher")
                    {
                        using (dataWriter = new StreamWriter(tempFiles[1], false, System.Text.Encoding.Default))
                        {
                            while (srArray[i] != "Class Specialisation")
                            {
                                dataWriter.WriteLine(srArray[i]);
                                i++;
                            }
                        }
                    }
                    if (srArray[i] == "Class Specialisation")
                    {
                        using (dataWriter = new StreamWriter(tempFiles[2], false, System.Text.Encoding.Default))
                        {
                            while (i < srArray.Length)
                            {
                                dataWriter.WriteLine(srArray[i]);
                                i++;
                            }
                        }
                    }

                    wordPositionValue = 0;

                    for (i = 0; i < 3; i++)
                    {
                        temporaryArray = File.ReadAllLines(tempFiles[i], System.Text.Encoding.Default);
                        for (int k = 0; k < temporaryArray.Length; k++)
                        {
                            if (temporaryArray[k] == word)
                            {
                                wordPosition[wordPositionValue] = k;
                                wordPositionValue++;
                            }
                        }
                    }

                    for (int j = 0; j < wordPositionValue; j++)
                        if (wordPosition[j] != (-1))
                        {
                            for (int k = 0; k < 3; k++)
                            {
                                temporaryArray = File.ReadAllLines(tempFiles[k], System.Text.Encoding.Default);
                                Console.WriteLine(temporaryArray[0] + "\n" + temporaryArray[wordPosition[j]]);
                            }
                        }

                    for (i = 0; i < 3; i++)
                        if(File.Exists(tempFiles[i]))
                            File.Delete(tempFiles[i]);
                    break;
                default:
                    Console.WriteLine("Wrong table number");
                    break;
            }
        }

        public void OutputData(int tableValue) // работає
        {
            int[] tablesChoise = new int[2];
            string[] arrayOutput;
            int i;
            if(tableValue==1)
            {
                Console.WriteLine("Pick table for output(use keys 1,2,3:)");
                switch(int.Parse(Console.ReadLine()))
                {
                    case 1:
                        ShowTable(1);
                        break;
                    case 2:
                        ShowTable(2);
                        break;
                    case 3:
                        ShowTable(3);
                        break;
                    default:
                        Console.WriteLine("Wrong number");
                        break;
                }
            }
            else if (tableValue == 2)
            {
                Console.WriteLine("Pick first table(Use keys 1,2,3:)");
                tablesChoise[0] = int.Parse(Console.ReadLine());
                Console.WriteLine("Pick second table(Use keys 1,2,3:)");
                tablesChoise[1] = int.Parse(Console.ReadLine());
                if (tablesChoise[0] > tablesChoise[1])
                {
                    int swap = tablesChoise[0];
                    tablesChoise[0] = tablesChoise[1];
                    tablesChoise[1] = swap;
                }

                int tableChoiseValue = tablesChoise[0] + tablesChoise[1];

                switch (tableChoiseValue)
                {
                    case 3: // 1 2
                        ShowTable(1);
                        srArray = File.ReadAllLines(schoolsPath, System.Text.Encoding.Default);
                        arrayOutput = new string[4];
                        for (i = 0; i < srArray.Length; i++)
                            if (srArray[i] == "School Level")
                                break;
                        
                        if (srArray[i] == "School Level")
                        {
                            while (srArray[i] != "School Specialisation")
                            {
                                arrayOutput[0] += srArray[i] + "\n";
                                i++;
                            }
                        }
                        if (srArray[i] == "School Specialisation")
                        {
                            while (srArray[i] != "School Director")
                            {
                                arrayOutput[1] += srArray[i] + "\n";
                                i++;
                            }
                        }
                        if (srArray[i] == "School Director")
                        {
                            while (i < srArray.Length)
                            {
                                arrayOutput[2] += srArray[i] + "\n";
                                i++;
                            }
                        }
                        for (i = 0; i < arrayOutput.Length; i++)
                        {
                            Console.WriteLine(arrayOutput[i]);
                        }
                        break;
                    case 5: //2 3 
                        ShowTable(2);
                        i = 0;
                        arrayOutput = new string[3];

                        srArray = File.ReadAllLines(classesPath, System.Text.Encoding.Default);
                        if (srArray[i]=="Number of Students in Class")
                        {
                            while (srArray[i] != "Class Teacher")
                            {
                                arrayOutput[0] += srArray[i] + "\n";
                                i++;
                            }
                        }
                        if (srArray[i] == "Class Teacher")
                        {
                            while (srArray[i] != "Class specialisation")
                            {
                                arrayOutput[1] += srArray[i] + "\n";
                                i++;
                            }
                        }
                        if (srArray[i] == "Class Specialisation")
                        {
                            while (i < srArray.Length)
                            {
                                arrayOutput[2] += srArray[i] + "\n";
                                i++;
                            }
                        }

                        for (i = 0; i < arrayOutput.Length; i++)
                        {
                            Console.WriteLine(arrayOutput[i]);
                        }
                        break;
                    case 4: //1 3
                        ShowTable(1);
                        i = 0;
                        arrayOutput = new string[1];

                        srArray = File.ReadAllLines(classesPath, System.Text.Encoding.Default);
                        if (srArray[i] == "Number of Students in Class")
                        {
                            while (srArray[i] != "Class Teacher")
                            {
                                arrayOutput[0] += srArray[i] + "\n";
                                i++;
                            }
                        }

                        for (i = 0; i < arrayOutput.Length; i++)
                        {
                            Console.WriteLine(arrayOutput[i]);
                        }
                        break;
                }
            }
            else
            {
                srArray = File.ReadAllLines(QuestionnairePath, System.Text.Encoding.Default);
                arrayOutput = new string[10];
                ShowTable(1);

                srArray = File.ReadAllLines(schoolsPath, System.Text.Encoding.Default);
                for (i = 0; i < srArray.Length; i++)
                    if (srArray[i] == "School Level")
                        break;

                if (srArray[i] == "School Level")
                {
                    while (srArray[i] != "School Specialisation")
                    {
                        arrayOutput[0] += srArray[i] + "\n";
                        i++;
                    }
                }
                if (srArray[i] == "School Specialisation")
                {
                    while (srArray[i] != "School Director")
                    {
                        arrayOutput[1] += srArray[i] + "\n";
                        i++;
                    }
                }
                if (srArray[i] == "School Director")
                {
                    while (i < srArray.Length)
                    {
                        arrayOutput[2] += srArray[i] + "\n";
                        i++;
                    }
                }

                i = 0;

                srArray = File.ReadAllLines(classesPath, System.Text.Encoding.Default);
                if (srArray[i] == "Number of Students in Class")
                {
                    while (srArray[i] != "Class Teacher")
                    {
                        arrayOutput[0] += srArray[i] + "\n";
                        i++;
                    }
                }

                for (i = 0; i < arrayOutput.Length; i++)
                {
                    Console.WriteLine(arrayOutput[i] + "\t");
                }
            }
        }
    
        public void DeleteData(string word, int tableNumber) // Залишає після себе пропуски, але працює
        {
            int i = 0;
            string[] tempFiles = new string[5] { @"D:\TempFile1.txt", @"D:\TempFile2.txt", @"D:\TempFile3.txt", @"D:\TempFile4.txt", @"D:\TempFile5.txt" };

            switch (tableNumber)
            {
                case 1:
                    srArray = File.ReadAllLines(QuestionnairePath, System.Text.Encoding.Default);
                    if (srArray[i]=="Full Name")
                    {
                        using (dataWriter = new StreamWriter(tempFiles[0], false, System.Text.Encoding.Default))
                        {
                            while (srArray[i] != "School Number")
                            {
                                dataWriter.WriteLine(srArray[i]);
                                i++;
                            }
                        }
                    }
                    if (srArray[i]=="School Number")
                    {
                        using (dataWriter = new StreamWriter(tempFiles[1], false, System.Text.Encoding.Default))
                        {
                            while (srArray[i] != "Class Number")
                            {
                                dataWriter.WriteLine(srArray[i]);
                                i++;
                            }
                        }
                    }
                    if (srArray[i]=="Class Number")
                    {
                        using (dataWriter = new StreamWriter(tempFiles[2], false, System.Text.Encoding.Default))
                        {
                            while (srArray[i] != "Class Teacher")
                            {
                                dataWriter.WriteLine(srArray[i]);
                                i++;
                            }
                        }
                    }
                    if (srArray[i]=="Class Teacher")
                    {
                        using (dataWriter = new StreamWriter(tempFiles[3], false, System.Text.Encoding.Default))
                        {
                            while (srArray[i] != "Class Specialisation")
                            {
                                dataWriter.WriteLine(srArray[i]);
                                i++;
                            }
                        }
                    }
                    if (srArray[i]=="Class Specialisation")
                    {
                        using (dataWriter = new StreamWriter(tempFiles[4], false, System.Text.Encoding.Default))
                        {
                            while (i < srArray.Length)
                            {
                                dataWriter.WriteLine(srArray[i]);
                                i++;
                            }
                        }
                    }

                    string[] temporaryArray;
                    int wordPosition = -1;

                    for(i=0;i<tempFiles.Length;i++)
                    {
                        temporaryArray = File.ReadAllLines(tempFiles[i], System.Text.Encoding.Default);
                        for (int k = 0; k < temporaryArray.Length; k++)
                        {
                            if (temporaryArray[k].Contains(word))
                            {
                                wordPosition = k;
                                break;
                            }
                        }
                        if (wordPosition != -1)
                            break;
                    }

                    for(i=0;i<tempFiles.Length;i++)
                    {
                        if (wordPosition != (-1))
                        {
                            temporaryArray = File.ReadAllLines(tempFiles[i], System.Text.Encoding.Default);
                            temporaryArray[wordPosition] = "";
                            File.WriteAllLines(tempFiles[i], temporaryArray, System.Text.Encoding.Default);
                        }
                    }

                    int j = 0;

                    temporaryArray = File.ReadAllLines(tempFiles[0], System.Text.Encoding.Default); 
                    for (i=0;i<temporaryArray.Length && j < srArray.Length; i++,j++)
                        srArray[j] = temporaryArray[i];

                    temporaryArray = File.ReadAllLines(tempFiles[1], System.Text.Encoding.Default);
                    for (i = 0; i < temporaryArray.Length && j < srArray.Length; i++, j++)
                        srArray[j] = temporaryArray[i];

                    temporaryArray = File.ReadAllLines(tempFiles[2], System.Text.Encoding.Default);
                    for (i = 0; i < temporaryArray.Length && j < srArray.Length; i++, j++)
                        srArray[j] = temporaryArray[i];

                    temporaryArray = File.ReadAllLines(tempFiles[3], System.Text.Encoding.Default);
                    for (i = 0; i < temporaryArray.Length && j < srArray.Length; i++, j++)
                        srArray[j] = temporaryArray[i];

                    temporaryArray = File.ReadAllLines(tempFiles[4], System.Text.Encoding.Default);
                    for (i = 0; i < temporaryArray.Length && j < srArray.Length; i++, j++)
                        srArray[j] = temporaryArray[i];

                    File.WriteAllLines(QuestionnairePath, srArray, System.Text.Encoding.Default);

                    for (j = 0; j < tempFiles.Length; j++)
                    {
                        if (File.Exists(tempFiles[j]))
                            File.Delete(tempFiles[j]);
                    }
                    
                    break;
                case 2:
                    srArray = File.ReadAllLines(schoolsPath, System.Text.Encoding.Default);
                    if (srArray[i]=="School number")
                    {
                        using (dataWriter = new StreamWriter(tempFiles[0], false, System.Text.Encoding.Default))
                        {
                            while (srArray[i] != "School Level")
                            {
                                dataWriter.WriteLine(srArray[i]);
                                i++;
                            }
                        }
                    }
                    if (srArray[i]=="School Level")
                    {
                        using (dataWriter = new StreamWriter(tempFiles[1], false, System.Text.Encoding.Default))
                        {
                            while (srArray[i] != "School Specialisation")
                            {
                                dataWriter.WriteLine(srArray[i]);
                                i++;
                            }
                        }
                    }
                    if (srArray[i]=="School Specialisation")
                    {
                        using (dataWriter = new StreamWriter(tempFiles[2], false, System.Text.Encoding.Default))
                        {
                            while (srArray[i] != "School Director")
                            {
                                dataWriter.WriteLine(srArray[i]);
                                i++;
                            }
                        }
                    }
                    if (srArray[i]=="School Director")
                    {
                        using (dataWriter = new StreamWriter(tempFiles[3], false, System.Text.Encoding.Default))
                        {
                            while (i<srArray.Length)
                            {
                                dataWriter.WriteLine(srArray[i]);
                                i++;
                            }
                        }
                    }

                    wordPosition = -1;

                    for (i = 0; i < 4; i++)
                    {
                        temporaryArray = File.ReadAllLines(tempFiles[i], System.Text.Encoding.Default);
                        for (int k = 0; k < temporaryArray.Length; k++)
                        {
                            if (temporaryArray[k].Contains(word))
                            {
                                wordPosition = k;
                                break;
                            }
                        }
                        if (wordPosition != -1)
                            break;
                    }

                    for (i = 0; i < 4; i++)
                    {
                        temporaryArray = File.ReadAllLines(tempFiles[i], System.Text.Encoding.Default);
                        temporaryArray[wordPosition] = "";
                        File.WriteAllLines(tempFiles[i], temporaryArray, System.Text.Encoding.Default);
                    }

                    j = 0;

                    temporaryArray = File.ReadAllLines(tempFiles[0], System.Text.Encoding.Default);
                    for (i = 0; i < 4 && j < srArray.Length; i++, j++)
                        srArray[j] = temporaryArray[i];

                    temporaryArray = File.ReadAllLines(tempFiles[1], System.Text.Encoding.Default);
                    for (i = 0; i < 4 && j < srArray.Length; i++, j++)
                        srArray[j] = temporaryArray[i];

                    temporaryArray = File.ReadAllLines(tempFiles[2], System.Text.Encoding.Default);
                    for (i = 0; i < 4 && j < srArray.Length; i++, j++)
                        srArray[j] = temporaryArray[i];

                    temporaryArray = File.ReadAllLines(tempFiles[3], System.Text.Encoding.Default);
                    for (i = 0; i < 4 && j < srArray.Length; i++, j++)
                        srArray[j] = temporaryArray[i];

                    File.WriteAllLines(schoolsPath, srArray, System.Text.Encoding.Default);

                    for (j = 0; j < 4; j++)
                    {
                        if(File.Exists(tempFiles[j]))
                            File.Delete(tempFiles[j]);
                    }

                    break;
                case 3:
                    srArray = File.ReadAllLines(classesPath, System.Text.Encoding.Default);
                    if (srArray[i]=="Number of Students in Class")
                    {
                        using (dataWriter = new StreamWriter(tempFiles[0], false, System.Text.Encoding.Default))
                        {
                            while (srArray[i] != "Class Teacher")
                            {
                                dataWriter.WriteLine(srArray[i]);
                                i++;
                            }
                        }
                    }
                    if (srArray[i]=="Class Teacher")
                    {
                        using (dataWriter = new StreamWriter(tempFiles[1], false, System.Text.Encoding.Default))
                        {
                            while (srArray[i] != "Class Specialisation")
                            {
                                dataWriter.WriteLine(srArray[i]);
                                i++;
                            }
                        }
                    }
                    if (srArray[i]=="Class Specialisation")
                    {
                        using (dataWriter = new StreamWriter(tempFiles[2], false, System.Text.Encoding.Default))
                        {
                            while (i<srArray.Length)
                            {
                                dataWriter.WriteLine(srArray[i]);
                                i++;
                            }
                        }
                    }

                    wordPosition = -1;

                    for (i = 0; i < 3; i++)
                    {
                        temporaryArray = File.ReadAllLines(tempFiles[i], System.Text.Encoding.Default);
                        for (int k = 0; k < temporaryArray.Length; k++)
                        {
                            if (temporaryArray[k].Contains(word))
                            {
                                wordPosition = k;
                                break;
                            }
                        }
                        if (wordPosition != -1)
                            break;
                    }

                    for (i = 0; i < 3; i++)
                    {
                        temporaryArray = File.ReadAllLines(tempFiles[i], System.Text.Encoding.Default);
                        temporaryArray[wordPosition] = "";
                        File.WriteAllLines(tempFiles[i], temporaryArray, System.Text.Encoding.Default);
                    }

                    j = 0;
                    temporaryArray = File.ReadAllLines(tempFiles[0], System.Text.Encoding.Default);
                    for (i = 0; i < temporaryArray.Length; i++, j++)
                        srArray[j] = temporaryArray[i];

                    temporaryArray = File.ReadAllLines(tempFiles[1], System.Text.Encoding.Default);
                    for (i = 0; i < temporaryArray.Length; i++, j++)
                        srArray[j] = temporaryArray[i];

                    temporaryArray = File.ReadAllLines(tempFiles[2], System.Text.Encoding.Default);
                    for (i = 0; i < temporaryArray.Length; i++, j++)
                        srArray[j] = temporaryArray[i];

                    File.WriteAllLines(classesPath, srArray, System.Text.Encoding.Default);

                    for (j = 0; j < 4; j++)
                    {
                        if (File.Exists(tempFiles[j]))
                            File.Delete(tempFiles[j]);
                    }
                    break;
            }
        }

        private void ShowTable(int tableNumber) // Працює!! 
        {
            string[] arrayOutput;
            int i = 0;
            switch(tableNumber)
            {
                case 1:
                    srArray = File.ReadAllLines(QuestionnairePath, System.Text.Encoding.Default);
                    arrayOutput = new string[5] { "","","","","",};
                    if (srArray[i]=="Full Name")
                    {
                        while (srArray[i] != "School Number")
                        {
                            arrayOutput[0] += srArray[i] +"\n";
                            i++;
                        }
                    }
                    if (srArray[i] == "School Number")
                    {
                        while (srArray[i] != "Class Number")
                        {
                            arrayOutput[1] += srArray[i]+"\n";
                            i++;
                        }
                    }
                    if (srArray[i] == "Class Number")
                    {
                        while (srArray[i] != "Class Teacher")
                        {
                            arrayOutput[2] += srArray[i] + "\n";
                            i++;
                        }
                    }
                    if (srArray[i] == "Class Teacher")
                    {
                        while (srArray[i] != "Class Specialisation")
                        {
                            arrayOutput[3] += srArray[i] + "\n";
                            i++;
                        }
                    }
                    if (srArray[i] == "Class Specialisation")
                    {
                        while (i < srArray.Length)
                        {
                            arrayOutput[4] += srArray[i] + "\n";
                            i++;
                        }
                    }
                    for (i=0;i<arrayOutput.Length;i++)
                    {
                        Console.WriteLine(arrayOutput[i]);
                    }
                    break;
                case 2:
                    srArray = File.ReadAllLines(schoolsPath, System.Text.Encoding.Default);
                    arrayOutput = new string[4];
                    if (srArray[i]=="School number")
                    {
                        while (srArray[i] != "School Level")
                        {
                            arrayOutput[0] += srArray[i] + "\n";
                            i++;
                        }
                    }
                    if (srArray[i]=="School Level")
                    {
                        while (srArray[i] != "School Specialisation")
                        {
                            arrayOutput[1] += srArray[i] + "\n";
                            i++;
                        }
                    }
                    if (srArray[i]=="School Specialisation")
                    {
                        while (srArray[i] != "School Director")
                        {
                            arrayOutput[2] += srArray[i] + "\n";
                            i++;
                        }
                    }
                    if(srArray[i]=="School Director")
                    {
                        while (i<srArray.Length)
                        {
                            arrayOutput[3] += srArray[i] + "\n";
                            i++;
                        }
                    }
                    for (i = 0; i < arrayOutput.Length; i++)
                    {
                        Console.WriteLine(arrayOutput[i]);
                    }
                    break;
                case 3:
                    srArray = File.ReadAllLines(classesPath, System.Text.Encoding.Default);
                    arrayOutput = new string[3];
                    if (srArray[i]=="Number of Students in Class")
                    {
                        while (srArray[i] != "Class Teacher")
                        {
                            arrayOutput[0] += srArray[i] + "\n";
                            i++;
                        }
                    }
                    if (srArray[i]=="Class Teacher")
                    {
                        while (srArray[i] != "Class Specialisation")
                        {
                            arrayOutput[1] += srArray[i] + "\n";
                            i++;
                        }
                    }
                    if (srArray[i]=="Class Specialisation")
                    {
                        while (i<srArray.Length)
                        {
                            arrayOutput[2] += srArray[i] + "\n";
                            i++;
                        }
                    }
                    for (i = 0; i < arrayOutput.Length; i++)
                    {
                        Console.WriteLine(arrayOutput[i]);
                    }
                    break;
            }
        }
    }
}
