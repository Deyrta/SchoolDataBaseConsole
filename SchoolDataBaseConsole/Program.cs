using System;
using System.IO;

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
            while(true)
            {
                Console.WriteLine("Pick action(1 - Show Data; 2 - Search Data; 3 - Select Data; 4 - Delete Data; 5 - Enter Data; Anything else to exit:");
                choise = int.Parse(Console.ReadLine());
                switch(choise)
                {
                    case 1:
                        Console.WriteLine("Enter which table you want to see(1/2/3):");
                        programmeInterface.ShowData(int.Parse(Console.ReadLine()));
                        break;
                    case 2:
                        Console.WriteLine("Write a word to search:");
                        programmeInterface.SearchData(Console.ReadLine());
                        break;
                    case 3:
                        Console.WriteLine("How many tables you want to see(2/3)?");
                        int localChoise = int.Parse(Console.ReadLine());
                        if(localChoise != 2 || localChoise != 3)
                        {
                            Console.WriteLine("You picked wrong number.");
                            continue;
                        }    
                        programmeInterface.SelectData(localChoise);
                        break;
                    case 4:
                        Console.WriteLine("Pick table where you want to delete a label.");
                        localChoise = int.Parse(Console.ReadLine());
                        Console.WriteLine("Pick a word from label:");
                        programmeInterface.DeleteData(Console.ReadLine(),localChoise);
                        break;
                    case 5:
                        Console.WriteLine("Pick a table where you want to enter a data");
                        programmeInterface.EnterData(int.Parse(Console.ReadLine()));
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
                catch(Exception e)
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
        public void EnterData(int tableNumber)
        {
            switch(tableNumber)
            {
                case 1:
                    Console.WriteLine("You picked first table, enter a data:");
                    srArray = File.ReadAllLines(QuestionnairePath, System.Text.Encoding.Default);
                    for (int i = 0; i < srArray.Length; i++)
                    {
                        if (srArray[i].Contains("Full name"))
                        {
                            Console.WriteLine("Enter Full name:");
                            srArray[i] = "\n" + Console.ReadLine();
                        }
                        else if (srArray[i].Contains("School Number"))
                        {
                            Console.WriteLine("Enter School Number");
                            srArray[i] = "\n" + Console.ReadLine();
                        }
                        else if (srArray[i].Contains("Class Number")) 
                        {
                            Console.WriteLine("Enter Class number:");
                            srArray[i] = "\n" + Console.ReadLine();
                        }
                        else if (srArray[i].Contains("Class Teacher"))
                        {
                            Console.WriteLine("Enter Class Teacher:");
                            srArray[i] = "\n" + Console.ReadLine();
                        }
                        else if (srArray[i].Contains("Class Specialisation"))
                        {
                            Console.WriteLine("Enter Class Specialisation");
                            srArray[i] = "\n" + Console.ReadLine();
                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("You picked second table, enter a data:");
                    srArray = File.ReadAllLines(schoolsPath, System.Text.Encoding.Default);
                    for (int i = 0; i < srArray.Length; i++)
                    {
                        if (srArray[i].Contains("School number"))
                        {
                            Console.WriteLine("Enter School number:");
                            srArray[i] = "\n" + Console.ReadLine();
                        }
                        else if (srArray[i].Contains("School Level"))
                        {
                            Console.WriteLine("Enter School Level:");
                            srArray[i] = "\n" + Console.ReadLine();
                        }
                        else if (srArray[i].Contains("School Specialisation"))
                        {
                            Console.WriteLine("Enter School Specialisation:");
                            srArray[i] = "\n" + Console.ReadLine();
                        }
                        else if (srArray[i].Contains("School Director"))
                        {
                            Console.WriteLine("Enter School Director:");
                            srArray[i] = "\n" + Console.ReadLine();
                        }
                    }
                    break;
                case 3:
                    Console.WriteLine("You picked third table, enter a data:");
                    srArray = File.ReadAllLines(classesPath, System.Text.Encoding.Default);
                    for (int i = 0; i < srArray.Length; i++)
                    {
                        if (srArray[i].Contains("Number of Students in Class"))
                        {
                            Console.WriteLine("Enter Number of Students in Class:");
                            srArray[i] = "\n" + Console.ReadLine();
                        }
                        else if (srArray[i].Contains("Class Teacher"))
                        {
                            Console.WriteLine("Enter Class Teacher:");
                            srArray[i] = "\n" + Console.ReadLine();
                        }
                        else if (srArray[i].Contains("Class specialisation"))
                        {
                            Console.WriteLine("Enter School Director:");
                            srArray[i] = "\n" + Console.ReadLine();
                        }
                    }
                    break;
            }
        }

        public void SearchData(string word) // затестити
        {
            int i = 0;
            string[] tempFiles = new string[5] { @"D:\TempFile1.txt", @"D:\TempFile2.txt", @"D:\TempFile3.txt", @"D:\TempFile4.txt", @"D:\TempFile5.txt" };

            srArray = File.ReadAllLines(QuestionnairePath, System.Text.Encoding.Default);  // Search in first table
            if (srArray[i].Contains("Full name"))
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
            else if (srArray[i].Contains("School Number"))
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
            else if (srArray[i].Contains("Class Number"))
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
            else if (srArray[i].Contains("Class Teacher"))
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
            else if (srArray[i].Contains("Class Specialisation"))
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

            for (i = 0; i < tempFiles.Length; i++)
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

            string output = "";

            for (i = 0; i < tempFiles.Length; i++)
            {
                temporaryArray = File.ReadAllLines(tempFiles[i], System.Text.Encoding.Default);
                output += temporaryArray[0] + "\t";
            }

            output += "\n";
            for(i=0;i<tempFiles.Length;i++)
            {
                temporaryArray = File.ReadAllLines(tempFiles[i], System.Text.Encoding.Default);
                output += temporaryArray[wordPosition] + "\t";
            }

            Console.WriteLine();

            srArray = File.ReadAllLines(schoolsPath, System.Text.Encoding.Default);   // search in second table
            if (srArray[i].Contains("School number"))
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
            else if (srArray[i].Contains("School Level"))
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
            else if (srArray[i].Contains("School Specialisation"))
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
            else if (srArray[i].Contains("School Director"))
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

            output = "";

            for (i = 0; i < tempFiles.Length; i++)
            {
                temporaryArray = File.ReadAllLines(tempFiles[i], System.Text.Encoding.Default);
                output += temporaryArray[0] + "\t";
            }

            output += "\n";
            for (i = 0; i < tempFiles.Length; i++)
            {
                temporaryArray = File.ReadAllLines(tempFiles[i], System.Text.Encoding.Default);
                output += temporaryArray[wordPosition] + "\t";
            }

            Console.WriteLine();

            srArray = File.ReadAllLines(classesPath, System.Text.Encoding.Default);
            if (srArray[i].Contains("Number of Students in Class"))
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
            else if (srArray[i].Contains("Class Teacher"))
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
            else if (srArray[i].Contains("Class Specialisation"))
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

            output = "";

            for (i = 0; i < tempFiles.Length; i++)
            {
                temporaryArray = File.ReadAllLines(tempFiles[i], System.Text.Encoding.Default);
                output += temporaryArray[0] + "\t";
            }

            output += "\n";
            for (i = 0; i < tempFiles.Length; i++)
            {
                temporaryArray = File.ReadAllLines(tempFiles[i], System.Text.Encoding.Default);
                output += temporaryArray[wordPosition] + "\t";
            }
        }

        public void SelectData(int tableValue) // затестити
        {
            int[] tablesChoise = new int[2];
            string[] arrayOutput;
            int i = 0;
            if (tableValue == 2)
            {
                Console.WriteLine("Pick first table(Use keys 1,2,3:");
                tablesChoise[0] = int.Parse(Console.ReadLine());
                Console.WriteLine("Pick second table(Use keys 1,2,3:");
                tablesChoise[1] = int.Parse(Console.ReadLine()); 
                if(tablesChoise[0]>tablesChoise[1])
                {
                    int swap = tablesChoise[0];
                    tablesChoise[0] = tablesChoise[1];
                    tablesChoise[1] = swap;
                }

                int tableChoiseValue = tablesChoise[0] + tablesChoise[1];

                switch (tableChoiseValue)
                {
                    case 3: // 1 2
                        arrayOutput = new string[8];

                        srArray = File.ReadAllLines(QuestionnairePath, System.Text.Encoding.Default);
                        if (srArray[i].Contains("Full name"))
                        {
                            while (srArray[i] != "School Number")
                            {
                                arrayOutput[0] += srArray[i] + "\n";
                                i++;
                            }
                        }
                        else if (srArray[i].Contains("School Number"))
                        {
                            while (srArray[i] != "Class Number")
                            {
                                arrayOutput[1] += srArray[i] + "\n";
                                i++;
                            }
                        }
                        else if (srArray[i].Contains("Class Number"))
                        {
                            while (srArray[i] != "Class Teacher")
                            {
                                arrayOutput[2] += srArray[i] + "\n";
                                i++;
                            }
                        }
                        else if (srArray[i].Contains("Class Teacher"))
                        {
                            while (srArray[i] != "Class Specialisation")
                            {
                                arrayOutput[3] += srArray[i] + "\n";
                                i++;
                            }
                        }
                        else if (srArray[i].Contains("Class Specialisation"))
                        {
                            while (i < srArray.Length)
                            {
                                arrayOutput[4] += srArray[i] + "\n";
                                i++;
                            }
                        }

                        i = 0;

                        srArray = File.ReadAllLines(schoolsPath, System.Text.Encoding.Default);
                        if (srArray[i].Contains("School Level"))
                        {
                            while (srArray[i] != "School Specialisation")
                            {
                                arrayOutput[5] += srArray[i] + "\n";
                                i++;
                            }
                        }
                        else if (srArray[i].Contains("School Specialisation"))
                        {
                            while (srArray[i] != "School Director")
                            {
                                arrayOutput[6] += srArray[i] + "\n";
                                i++;
                            }
                        }
                        else if (srArray[i].Contains("School Director"))
                        {
                            while (i < srArray.Length)
                            {
                                arrayOutput[7] += srArray[i] + "\n";
                                i++;
                            }
                        }

                        for (i = 0; i < arrayOutput.Length; i++)
                        {
                            Console.WriteLine(arrayOutput[i] + "\t");
                        }
                        break;
                    case 5: //2 3 
                        srArray = File.ReadAllLines(schoolsPath, System.Text.Encoding.Default);
                        arrayOutput = new string[7];
                        if (srArray[i].Contains("School Number"))
                        {
                            while (srArray[i] != "School Level")
                            {
                                arrayOutput[0] += srArray[i] + "\n";
                                i++;
                            }
                        }
                        else if (srArray[i].Contains("School Level"))
                        {
                            while (srArray[i] != "School Specialisation")
                            {
                                arrayOutput[1] += srArray[i] + "\n";
                                i++;
                            }
                        }
                        else if (srArray[i].Contains("School Specialisation"))
                        {
                            while (srArray[i] != "School Director")
                            {
                                arrayOutput[2] += srArray[i] + "\n";
                                i++;
                            }
                        }
                        else if (srArray[i].Contains("School Director"))
                        {
                            while (i < srArray.Length)
                            {
                                arrayOutput[3] += srArray[i] + "\n";
                                i++;
                            }
                        }

                        i = 0;

                        srArray = File.ReadAllLines(classesPath, System.Text.Encoding.Default);
                        if (srArray[i].Contains("Number of Students in Class"))
                        {
                            while (srArray[i] != "Class Teacher")
                            {
                                arrayOutput[4] += srArray[i] + "\n";
                                i++;
                            }
                        }
                        else if (srArray[i].Contains("Class Teacher"))
                        {
                            while (srArray[i] != "Class specialisation")
                            {
                                arrayOutput[5] += srArray[i] + "\n";
                                i++;
                            }
                        }
                        else if (srArray[i].Contains("Class specialisation"))
                        {
                            while (i < srArray.Length)
                            {
                                arrayOutput[6] += srArray[i] + "\n";
                                i++;
                            }
                        }

                        for (i = 0; i < arrayOutput.Length; i++)
                        {
                            Console.WriteLine(arrayOutput[i] + "\t");
                        }
                        break;
                    case 4: //1 3
                        srArray = File.ReadAllLines(QuestionnairePath, System.Text.Encoding.Default);
                        arrayOutput = new string[6];
                        if (srArray[i].Contains("Full name"))
                        {
                            while (srArray[i] != "School Number")
                            {
                                arrayOutput[0] += srArray[i] + "\n";
                                i++;
                            }
                        }
                        else if (srArray[i].Contains("School Number"))
                        {
                            while (srArray[i] != "Class Number")
                            {
                                arrayOutput[1] += srArray[i] + "\n";
                                i++;
                            }
                        }
                        else if (srArray[i].Contains("Class Number"))
                        {
                            while (srArray[i] != "Class Teacher")
                            {
                                arrayOutput[2] += srArray[i] + "\n";
                                i++;
                            }
                        }
                        else if (srArray[i].Contains("Class Teacher"))
                        {
                            while (srArray[i] != "Class Specialisation")
                            {
                                arrayOutput[3] += srArray[i] + "\n";
                                i++;
                            }
                        }
                        else if (srArray[i].Contains("Class Specialisation"))
                        {
                            while (i < srArray.Length)
                            {
                                arrayOutput[4] += srArray[i] + "\n";
                                i++;
                            }
                        }
                        for (i = 0; i < arrayOutput.Length; i++)
                        {
                            Console.WriteLine(arrayOutput[i] + "\t");
                        }

                        i = 0;

                        srArray = File.ReadAllLines(classesPath, System.Text.Encoding.Default);
                        arrayOutput = new string[3];
                        if (srArray[i].Contains("Number of Students in Class"))
                        {
                            while (srArray[i] != "Class Teacher")
                            {
                                arrayOutput[5] += srArray[i] + "\n";
                                i++;
                            }
                        }

                        for (i = 0; i < arrayOutput.Length; i++)
                        {
                            Console.WriteLine(arrayOutput[i] + "\t");
                        }
                        break;
                }
            }
            else
            {
                srArray = File.ReadAllLines(QuestionnairePath, System.Text.Encoding.Default);
                arrayOutput = new string[10];
                i = 0;
                if (srArray[i].Contains("Full name"))
                {
                    while (srArray[i] != "School Number")
                    {
                        arrayOutput[0] += srArray[i] + "\n";
                        i++;
                    }
                }
                else if (srArray[i].Contains("School Number"))
                {
                    while (srArray[i] != "Class Number")
                    {
                        arrayOutput[1] += srArray[i] + "\n";
                        i++;
                    }
                }
                else if (srArray[i].Contains("Class Number"))
                {
                    while (srArray[i] != "Class Teacher")
                    {
                        arrayOutput[2] += srArray[i] + "\n";
                        i++;
                    }
                }
                else if (srArray[i].Contains("Class Teacher"))
                {
                    while (srArray[i] != "Class Specialisation")
                    {
                        arrayOutput[3] += srArray[i] + "\n";
                        i++;
                    }
                }
                else if (srArray[i].Contains("Class Specialisation"))
                {
                    while (i < srArray.Length)
                    {
                        arrayOutput[4] += srArray[i] + "\n";
                        i++;
                    }
                }

                i = 0;

                srArray = File.ReadAllLines(schoolsPath, System.Text.Encoding.Default);
                if (srArray[i].Contains("School Number"))
                {
                    while (srArray[i] != "School Level")
                    {
                        arrayOutput[5] += srArray[i] + "\n";
                        i++;
                    }
                }
                else if (srArray[i].Contains("School Level"))
                {
                    while (srArray[i] != "School Specialisation")
                    {
                        arrayOutput[6] += srArray[i] + "\n";
                        i++;
                    }
                }
                else if (srArray[i].Contains("School Specialisation"))
                {
                    while (srArray[i] != "School Director")
                    {
                        arrayOutput[7] += srArray[i] + "\n";
                        i++;
                    }
                }
                else if (srArray[i].Contains("School Director"))
                {
                    while (i < srArray.Length)
                    {
                        arrayOutput[8] += srArray[i] + "\n";
                        i++;
                    }
                }

                i = 0;

                srArray = File.ReadAllLines(classesPath, System.Text.Encoding.Default);
                arrayOutput = new string[3];
                if (srArray[i].Contains("Number of Students in Class"))
                {
                    while (srArray[i] != "Class Teacher")
                    {
                        arrayOutput[9] += srArray[i] + "\n";
                        i++;
                    }
                }

                for (i = 0; i < arrayOutput.Length; i++)
                {
                    Console.WriteLine(arrayOutput[i] + "\t");
                }
            }
        }

        public void DeleteData(string word, int tableNumber) // затестити
        {
            int i = 0;
            string[] tempFiles = new string[5] { @"D:\TempFile1.txt", @"D:\TempFile2.txt", @"D:\TempFile3.txt", @"D:\TempFile4.txt", @"D:\TempFile5.txt" };

            switch (tableNumber)
            {
                case 1:
                    srArray = File.ReadAllLines(QuestionnairePath, System.Text.Encoding.Default);
                    if (srArray[i].Contains("Full name"))
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
                    else if (srArray[i].Contains("School Number"))
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
                    else if (srArray[i].Contains("Class Number"))
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
                    else if (srArray[i].Contains("Class Teacher"))
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
                    else if (srArray[i].Contains("Class Specialisation"))
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
                        temporaryArray = File.ReadAllLines(tempFiles[i], System.Text.Encoding.Default);
                        temporaryArray[wordPosition] = " ";
                        File.WriteAllLines(tempFiles[i], temporaryArray, System.Text.Encoding.Default);
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
                        if (File.Exists(tempFiles[i]))
                            File.Delete(tempFiles[j]);
                    }
                    break;
                case 2:
                    srArray = File.ReadAllLines(schoolsPath, System.Text.Encoding.Default);
                    if (srArray[i].Contains("School number"))
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
                    else if (srArray[i].Contains("School Level"))
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
                    else if (srArray[i].Contains("School Specialisation"))
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
                    else if (srArray[i].Contains("School Director"))
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
                        temporaryArray[wordPosition] = " ";
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

                    File.WriteAllLines(QuestionnairePath, srArray, System.Text.Encoding.Default);

                    for (j = 0; j < 4; j++)
                    {
                        if(File.Exists(tempFiles[i]))
                            File.Delete(tempFiles[j]);
                    }
                    break;
                case 3:
                    srArray = File.ReadAllLines(classesPath, System.Text.Encoding.Default);
                    if (srArray[i].Contains("Number of Students in Class"))
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
                    else if (srArray[i].Contains("Class Teacher"))
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
                    else if (srArray[i].Contains("Class Specialisation"))
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
                        temporaryArray[wordPosition] = " ";
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
                        if (File.Exists(tempFiles[i]))
                            File.Delete(tempFiles[j]);
                    }
                    break;
            }
        }

        public void ShowData(int tableNumber) 
        {
            string[] arrayOutput;
            int i = 0;
            switch(tableNumber)
            {
                case 1:
                    srArray = File.ReadAllLines(QuestionnairePath, System.Text.Encoding.Default);
                    arrayOutput = new string[5];
                    if (srArray[i].Contains("Full name"))
                    {
                        while (srArray[i] != "School Number")
                        {
                            arrayOutput[0] += srArray[i] +"\n";
                            i++;
                        }
                    }
                    else if (srArray[i].Contains("School Number"))
                    {
                        while (srArray[i] != "Class Number")
                        {
                            arrayOutput[1] += srArray[i]+"\n";
                            i++;
                        }
                    }
                    else if (srArray[i].Contains("Class Number"))
                    {
                        while (srArray[i] != "Class Teacher")
                        {
                            arrayOutput[2] += srArray[i] + "\n";
                            i++;
                        }
                    }
                    else if (srArray[i].Contains("Class Teacher"))
                    {
                        while (srArray[i] != "Class Specialisation")
                        {
                            arrayOutput[3] += srArray[i] + "\n";
                            i++;
                        }
                    }
                    else if (srArray[i].Contains("Class Specialisation"))
                    {
                        while (i < srArray.Length)
                        {
                            arrayOutput[4] += srArray[i] + "\n";
                            i++;
                        }
                    }
                    for (i=0;i<arrayOutput.Length;i++)
                    {
                        Console.WriteLine(arrayOutput[i] + "\t");
                    }
                    break;
                case 2:
                    srArray = File.ReadAllLines(schoolsPath, System.Text.Encoding.Default);
                    arrayOutput = new string[4];
                    if (srArray[i].Contains("School Number"))
                    {
                        while (srArray[i] != "School Level")
                        {
                            arrayOutput[0] += srArray[i] + "\n";
                            i++;
                        }
                    }
                    else if (srArray[i].Contains("School Level"))
                    {
                        while (srArray[i] != "School Specialisation")
                        {
                            arrayOutput[1] += srArray[i] + "\n";
                            i++;
                        }
                    }
                    else if (srArray[i].Contains("School Specialisation"))
                    {
                        while (srArray[i] != "School Director")
                        {
                            arrayOutput[2] += srArray[i] + "\n";
                            i++;
                        }
                    }
                    else if (srArray[i].Contains("School Director"))
                    {
                        while (i<srArray.Length)
                        {
                            arrayOutput[3] += srArray[i] + "\n";
                            i++;
                        }
                    }
                    for (i = 0; i < arrayOutput.Length; i++)
                    {
                        Console.WriteLine(arrayOutput[i] + "\t");
                    }
                    break;
                case 3:
                    srArray = File.ReadAllLines(classesPath, System.Text.Encoding.Default);
                    arrayOutput = new string[3];
                    if (srArray[i].Contains("Number of Students in Class"))
                    {
                        while (srArray[i] != "Class Teacher")
                        {
                            arrayOutput[0] += srArray[i] + "\n";
                            i++;
                        }
                    }
                    else if (srArray[i].Contains("Class Teacher"))
                    {
                        while (srArray[i] != "Class specialisation")
                        {
                            arrayOutput[1] += srArray[i] + "\n";
                            i++;
                        }
                    }
                    else if (srArray[i].Contains("Class specialisation"))
                    {
                        while (i<srArray.Length)
                        {
                            arrayOutput[2] += srArray[i] + "\n";
                            i++;
                        }
                    }
                    for (i = 0; i < arrayOutput.Length; i++)
                    {
                        Console.WriteLine(arrayOutput[i] + "\t");
                    }
                    break;
            }
        }
    }
}
