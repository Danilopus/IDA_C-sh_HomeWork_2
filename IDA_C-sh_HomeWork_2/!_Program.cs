// HomeWork template 1.1 // date: 25.09.2023

using Service;
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;

/// QUESTIONS ///
/// 1. 

// HomeWork 2 : [Arrays & strings] --------------------------------

namespace IDA_C_sh_HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MainMenu.MainMenu mainMenu = new MainMenu.MainMenu();

            do
            {
                Console.Clear();
                mainMenu.Show_menu();
                if (mainMenu.User_Choice_Handle() == 0) break;
                Console.ReadKey();
            } while (true);
        }

        public static void Task_1(string work_name)
        /*  Объявить одномерный (5 элементов) массив с име-
        нем A и двумерный массив (3 строки, 4 столбца) дроб-
        ных чисел с именем B. Заполнить одномерный массив
        А числами, введенными с клавиатуры пользователем, а
        двумерный массив В случайными числами с помощью
        циклов. Вывести на экран значения массивов: массива
        А в одну строку, массива В — в виде матрицы. Найти в
        данных массивах общий максимальный элемент, мини-
        мальный элемент, общую сумму всех элементов, общее
        произведение всех элементов, сумму четных элементов
        массива А, сумму нечетных столбцов массива В.
        */
        {
            Console.WriteLine(work_name + "\n");
                        
            double[] A = new double[5];
            for (int i = 0; i < A.Length; i++) 
            { 
                //Console.WriteLine("A["+i+"] -> ");
                //A[i] = ServiceFunction.Get_Double();
                A[i] = Convert.ToInt32(ServiceFunction.Get_Random(1000));
            }

            double[,] B = new double[3,4];            
            for (int i = 0; i <= B.GetUpperBound(0); i++)
            {
                // for (int ii = 0; ii < B.GetUpperBound(i); ii++)
                for (int ii = 0; ii <= B.GetUpperBound(1); ii++)
                    B[i, ii] = ServiceFunction.Get_Random(100);
            }

            Console.WriteLine("\nArray A info:");
            foreach (var item in A) { Console.Write(item + " | "); }
            Console.Write("\nmax -> "+ max(A));
            Console.Write("\nmin -> " + min(A));
            Console.Write("\nsum -> " + sum(A));
            Console.Write("\nmult -> " + mult(A));
            Console.Write("\nsum_if_even -> " + sum_if_even(A));


            Console.WriteLine("\nArray B info:");
            foreach (var item in B) { Console.WriteLine(item); }


            for (int i = 0; i < B.GetUpperBound(0); i++)
            {
                for (int ii = 0; ii < B.GetUpperBound(1); ii++)
                     Console.Write(B[i, ii] + " | ");
                Console.Write("\b\b \n");
            }


            double max (double[] x) 
            {
                double max = x[0];
                foreach (var item in x)
                {
                    max = item > max ? item : max;
                }
                return max;
            }
            double min(double[] x)
            {
                double min = x[0];
                foreach (var item in x)
                {
                    min = item < min ? item : min;
                }
                return min;
            }
            double sum(double[] x)
            {
                double sum = 0;
                try
                {
                    foreach (var item in x)
                    {
                        sum += item;
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                return sum;
            }
            double mult(double[] x)
            {
                double mult = 1;
                try
                {
                    foreach (var item in x)
                    {
                        mult *= item;
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                return mult;
            }
            double sum_if_even(double[] x)
            {
                double sum = 0;
                try
                {
                    foreach (var item in x)
                    {
                        if (item % 2 == 0) sum += item;
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                return sum;
            }




            Console.Write("Number [1..100] -> ");



        }

 /// Array service functions --------------------------- 
        static double max (double[] x) 
            {
                double max = x[0];
                foreach (var item in x)
                {
                    max = item > max? item : max;
                }
                return max;
            }
        // Проблема: неопределены операции над any. 
        //any max<any>(any[,] x)    Error CS0019  Operator '>' cannot be applied to operands of type 'any' and 'any'
        // Не знаю как это решить пока что - поэтому делаю просто перегрузки на нужные аргументы
        static int max(int[,] x)
        {
            int max = x[0,0];
            foreach (var item in x)
            {
                max = item > max ? item : max;
            }
            return max;
        }

        static double min(double[] x)
        {
            double min = x[0];
            foreach (var item in x)
            {
                min = item < min ? item : min;
            }
            return min;
        }
        static int min(int[,] x)
        {
            int min = x[0,0];
            foreach (var item in x)
            {
                min = item < min ? item : min;
            }
            return min;
        }

        static double sum(double[] x)
        {
            double sum = 0;
            try
            {
                foreach (var item in x)
                {
                    sum += item;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return sum;
        }
        static int sum(int[,] x)
        {
            int sum = 0;
            try
            {
                foreach (var item in x)
                {
                    sum += item;
                }
            }
           // Возможно переполнение при суммировании
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return sum;
        }
        static double mult(double[] x)
        {
            double mult = 1;
            try
            {
                foreach (var item in x)
                {
                    mult *= item;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return mult;
        }
/// Array service functions ---------------------------

        public static void Task_2(string work_name)
        /*    Дан двумерный массив размерностью 5×5, заполнен-
        ный случайными числами из диапазона от –100 до 100.
        Определить сумму элементов массива, расположенных
        между минимальным и максимальным элементами..
        */
        {
            Console.WriteLine(work_name + "\n");

            int[,] B = new int[5, 5];

            for (int i = 0; i <= B.GetUpperBound(0); i++)
            {                
                for (int ii = 0; ii <= B.GetUpperBound(1); ii++)
                    B[i, ii] = Convert.ToInt32(ServiceFunction.Get_Random(100, -100));
            }

            for (int i = 0; i < B.GetUpperBound(0); i++)
            {
                for (int ii = 0; ii < B.GetUpperBound(1); ii++)
                    Console.Write(B[i, ii] + " | ");
                Console.Write("\b\b \n");
            }

            Console.WriteLine("Summ of all elements of array between MIN [" + min(B) + "] and MAX [" + max(B) + "] -> " + (sum(B) - max(B) - min(B)));

        }
        public static void Task_3(string work_name)
        /*  Пользователь вводит строку с клавиатуры. 
         *  Необходимо зашифровать данную строку используя шифр Цезаря.
        */
        {
            Console.WriteLine(work_name + "\n");


            string user_input_str = "«today is a good day for walking. i will try to walk near the sea».";

            Console.Write("\nEnter a string -> " + user_input_str);

            //string tmp_str = Console.ReadLine();
            // string user_input_str = "«today is a good\rday for walking. i will try to walk near the sea».";


            Ceaser_engine(Crypt_mode.crypt, 5, ref user_input_str);
            Console.Write("\n\nCrypt with CEASER - > " +  user_input_str);

            Ceaser_engine(Crypt_mode.decrypt, 5, ref user_input_str);
            Console.Write("\n\nDecrypt with CEASER - > " + user_input_str); ;


            string Ceaser_engine(Crypt_mode mode, int crypt_offset,  ref string original_str)
            {     
                if (mode == Crypt_mode.decrypt) crypt_offset = crypt_offset * (-1); 
                char[] char_arr_tmp = new char[original_str.Length];
                for (int i = 0; i < original_str.Length; i++)
                {
                    // Пробелы должны остаться где были
                    if (original_str[i] == ' ')
                    {
                        char_arr_tmp[i] = ' ';
                        continue;
                    }
                    char_arr_tmp[i] = Convert.ToChar(Convert.ToByte(original_str[i]) + crypt_offset);
                }
                original_str = new string(char_arr_tmp);
                return original_str;
            }

        }
        enum Crypt_mode { crypt, decrypt};
        public static void Task_4(string work_name)
        /*  Создайте приложение, которое производит операции
        над матрицами:
        ■ Умножение матрицы на число;
        ■ Сложение матриц;
        ■ Произведение матриц.
        */
        {

            ConsoleKeyInfo pressed_key;
            do
            {
                Console.Clear();
                Console.WriteLine(work_name + "\n");
                Console.WriteLine("\nAvailable operations:\n" +
                    "1 - Koefficient multiply\n" +
                    "2 - Summation\n" +
                    "3 - Multiplication");
                pressed_key = Console.ReadKey();        

                switch (pressed_key.Key) 
                {
                    
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        {
                            double[,] Operand_1 = matrix_init(1);
                            if (Operand_1 == null) return;
                            ServiceFunction.Array_Console_Out(Operand_1);
                            ServiceFunction.Array_Console_Out(Matrix_koef_multiply_get_koef(Operand_1)); 
                            break; 
                        }
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        {
                            double[,] Operand_1 = matrix_init(1);
                            if (Operand_1 == null) return;
                            ServiceFunction.Array_Console_Out(Operand_1);
                            double[,] Operand_2 = matrix_init(2);
                            if (Operand_2 == null) return;
                            ServiceFunction.Array_Console_Out(Operand_2);
                            Console.WriteLine("\nmatrix_1 + matrix_2 = matrix_3:\n");
                            ServiceFunction.Array_Console_Out(Matrix_summ(Operand_1, Operand_2));
                            break;
                        }
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        {
                            double[,] Operand_1 = matrix_init(1);
                            if (Operand_1 == null) return;
                            ServiceFunction.Array_Console_Out(Operand_1);
                            double[,] Operand_2 = matrix_init(2);
                            if (Operand_2 == null) return;
                            ServiceFunction.Array_Console_Out(Operand_2);
                            Console.WriteLine("\nmatrix_1 * matrix_2 = matrix_4:\n");
                            ServiceFunction.Array_Console_Out(Matrix_mult(Operand_1, Operand_2));
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            return;
                        }

                }
              Console.ReadKey();
            } while (true);


            double[,] matrix_init(int num)
                {
                Console.WriteLine("\n\nmatrix_" + num + " initialisation:\n" +
                       "1 - Full Random (dimensions & values)\n" +
                       "2 - Manually dimensions / Values random\n" +
                       "3 - Full Manually");
                ConsoleKeyInfo pressed_key_2;
                do
                {                   
                    pressed_key_2 = Console.ReadKey();
                    Console.WriteLine();
                    switch (pressed_key_2.Key)
                    {
                        case ConsoleKey.D1: case ConsoleKey.NumPad1: return FullRandom_matrix(); 
                        case ConsoleKey.D2: case ConsoleKey.NumPad2: return Manually_dim_values_random_matrix();  
                        case ConsoleKey.D3: case ConsoleKey.NumPad3: return FullManually_matrix();
                        case ConsoleKey.Escape: return null;
                        default: break;
                    }
                    Console.Write("\b");
                } while (true);
                //return new double[1, 1];
                throw new Exception("\nMatrix initialiase failure");

            }

            double[,] FullRandom_matrix()
            {
                double[,] tmp_matrix = new double[Convert.ToInt32(ServiceFunction.Get_Random(10, 2)), Convert.ToInt32(ServiceFunction.Get_Random(10,2))];
                ServiceFunction.Array_Fill_Random(ref tmp_matrix, 100);
                return tmp_matrix;
            }
            double[,] Manually_dim_values_random_matrix()
            {
                Console.Write("\nEnter matrix dimensions:\nRows - > ");
                int rows = ServiceFunction.Get_Int(1, 20, "try in range [1..20]");
                Console.Write("Columns - > ");
                int columns = ServiceFunction.Get_Int(1, 20, "try in range [1..20]");
                
                double[,] tmp_matrix = new double[rows, columns];
                ServiceFunction.Array_Fill_Random(ref tmp_matrix, 100);
                return tmp_matrix;
            }
            double[,] FullManually_matrix()
            {
                Console.Write("\nEnter matrix dimensions:\nRows - > ");
                int rows = ServiceFunction.Get_Int(1, 5, "try in range [1..5]");
                Console.Write("\nColumns - > ");
                int columns = ServiceFunction.Get_Int(1, 5, "try in range [1..5]");
                double[,] tmp_matrix = new double[rows, columns];
                for (int i = 0; i < tmp_matrix.GetLength(0); i++)
                    for (int ii = 0; ii < tmp_matrix.GetLength(1); ii++)
                    {
                        Console.Write("element [" + i + "][" + ii + "] -> ");
                        tmp_matrix[i, ii] = ServiceFunction.Get_Double();
                    }

                return tmp_matrix;
            }


        /*    double[,] matrix = new double[9, 9];
            Console.WriteLine("\nmatrix_1:\n");
            ServiceFunction.Array_Fill_Random(ref matrix, 100);
            ServiceFunction.Array_Console_Out(matrix);*/

     /*       double koef = 1.5;
            Console.WriteLine("\nmatrix_1 * koef["+koef+"] = matrix_2:\n");
            double[,] matrix_2 = Matrix_koef_multiply(matrix, koef);
            ServiceFunction.Array_Console_Out(matrix_2);*/

            /*double[,] matrix_2 = new double[9, 9];
            Console.WriteLine("\nmatrix_2:\n");
            ServiceFunction.Array_Fill_Random(ref matrix_2);
            ServiceFunction.Array_Console_Out(matrix);*/

  /*          Console.WriteLine("\nmatrix_1 + matrix_2 = matrix_3:\n");
            ServiceFunction.Array_Console_Out(Matrix_summ(matrix, matrix_2));

            Console.WriteLine("\nmatrix_1 * matrix_2 = matrix_4:\n");
            ServiceFunction.Array_Console_Out(Matrix_mult(matrix, matrix_2));*/

            double[,] Matrix_koef_multiply_get_koef(double[,] matrix)
            {
                Console.Write("\nEnter koef -> ");
                double koef = ServiceFunction.Get_Double();
               Console.WriteLine("\nmatrix_1 * koef[" + koef + "] = matrix_2:\n");
                return Matrix_koef_multiply(matrix, koef);
            }
            double[,] Matrix_koef_multiply(double[,] matrix, double koef)
            {
                double[,] tmp_matrix = new double[matrix.GetLength(0), matrix.GetLength(1)];
                for (int i = 0; i <= matrix.GetUpperBound(0); i++)
                {
                    for (int ii = 0; ii <= matrix.GetUpperBound(1); ii++)
                        tmp_matrix[i, ii] = matrix[i, ii] * koef;
                }
                return tmp_matrix;
            }
            double [,] Matrix_summ(double[,] matrix_1, double[,] matrix_2)
            {
                if (matrix_1.GetLength(0) != matrix_2.GetLength(0) || matrix_1.GetLength(1) != matrix_2.GetLength(1))
                    throw new Exception("\nMatrix not equal. Cannot summ\n");

                double[,] matrix_tmp = new double[matrix_1.GetLength(0), matrix_1.GetLength(1)];

                for (int i=0; i< matrix_tmp.GetLength(0); i++)
                {
                    for (int ii = 0; ii < matrix_tmp.GetLength(1);ii++)
                        matrix_tmp[i, ii] = matrix_1[i,ii] + matrix_2[i, ii];
                }
                return matrix_tmp;
            }
            double[,] Matrix_mult(double[,] matrix_1, double[,] matrix_2)
            {
                if (matrix_1.GetLength(1) != matrix_2.GetLength(0))
                    throw new Exception("\nmatrix_1 columns not equal matrix_2 rows. Cannot multiply\n");

                double[,] matrix_tmp = new double[matrix_1.GetLength(0), matrix_2.GetLength(1)];

                for (int i = 0; i < matrix_1.GetLength(0); i++)
                {
                    for (int ii = 0; ii < matrix_2.GetLength(1); ii++)
                    {
                        matrix_tmp[i, ii] = 0;
                        for (int iii = 0; iii < matrix_1.GetLength(1); iii++)
                            matrix_tmp[i, ii] += matrix_1[i, iii] * matrix_2[iii, ii];
                    }
                }
                return matrix_tmp;
            }

        }
        public static void Task_5(string work_name)
        /*  Пользователь с клавиатуры вводит в строку ариф-
        метическое выражение. Приложение должно посчитать
        его результат. Необходимо поддерживать только две
        операции: + и –.
        */
        {
            Console.Write(work_name + "\n");

            Console.Write("Enter an arithmetic statement (operand_1 +/- operand_2):\n");
            string user_input = Console.ReadLine();
            char[] parcers = new char[]{ '-', '+' };
            int parcer_index = user_input.IndexOfAny(parcers);
            if (parcer_index == -1) { throw new Exception("\nNo supported arithmetic operation found"); }
            Double.TryParse(user_input.Substring(0, parcer_index), out double operand_1);
            Double.TryParse(user_input.Substring(parcer_index+1), out double operand_2);
            Console.Write("\nresult -> ");
            switch (user_input[parcer_index]) 
            {
                case '-': Console.WriteLine(operand_1 +" - "+ operand_2+" = "+ (operand_1- operand_2)); break;
                case '+': Console.WriteLine(operand_1 + " + " + operand_2 + " = " + (operand_1 + operand_2)); break;
            }
        }
        public static void Task_6(string work_name)
        /*  Пользователь с клавиатуры вводит некоторый текст.
        Приложение должно изменять регистр первой буквы
        каждого предложения на букву в верхнем регистре..
        Например, если пользователь ввёл: «today is a good
        day for walking. i will try to walk near the sea».
        Результат работы приложения: «Today is a good day
        for walking. I will try to walk near the sea».
        */
        {
            Console.WriteLine(work_name+"\n");
            Console.WriteLine("Enter a text (or press F1 to load default):\n");
            string user_text;
            ConsoleKey pressed_key = Console.ReadKey().Key;
            if (pressed_key == ConsoleKey.F1) 
            { 
                user_text = "«today is a good day for walking. i will try to walk near the sea»."; 
                Console.WriteLine(user_text);
            }
            else user_text = Convert.ToString(pressed_key) + Console.ReadLine();
            if (string.IsNullOrEmpty(user_text)) { throw new Exception("Error: NULL string"); }

            char[] chars = user_text.ToCharArray();
            bool make_next_letter_capital_flag = true;
            for (int i = 0; i< chars.Length; i++)
            {
                if (make_next_letter_capital_flag && Char.IsLetter(chars[i]))
                {
                    chars[i] = Char.ToUpper(chars[i]);
                    make_next_letter_capital_flag = false;
                }
                if (chars[i] == '.') 
                    make_next_letter_capital_flag = true;
            }

            Console.WriteLine("\nresult:\n");
            Console.WriteLine(chars);
        }
        public static void Task_7(string work_name)
        /*  Создайте приложение, проверяющее текст на недо-
        пустимые слова. Если недопустимое слово найдено, оно
        должно быть заменено на набор символов *. По итогам
        работы приложения необходимо показать статистику
        действий.

        Например, если и у нас есть такой текст:
        To be, or not to be, that is the question,
        Whether 'tis nobler in the mind to suffer
        The slings and arrows of outrageous fortune
        Or to take arms against a sea of troubles,
        And by opposing end them? To die: to sleep;
        No more; and by a sleep to say we end
        The heart-ache and the thousand natural shocks
        That flesh is heir to? 'tis a consumation
        Devoutly to be wish'd. To die, to sleep

        Недопустимое слово: die.

        Результат работы:
        To be, or not to be, that is the question,
         Whether 'tis nobler in the mind to suffer
        The slings and arrows of outrageous fortune
        Or to take arms against a sea of troubles,
        And by opposing end them? To ***: to sleep;
        No more; and by a sleep to say we end
        The heart-ache and the thousand natural shocks
        That flesh is heir to? 'tis a consumation
        Devoutly to be wish'd. To ***, to sleep.
        Статистика: 2 замены слова die.
        */
        {
            Console.WriteLine(work_name + "\n");
            Console.WriteLine("Enter a text (or press F1 to load default):\n");
            string user_text;
            ConsoleKey pressed_key = Console.ReadKey().Key;
            if (pressed_key == ConsoleKey.F1)
            {
                user_text = "        To be, or not to be, that is the question,\r\n        " +
                    "Whether 'tis nobler in the mind to suffer\r\n        " +
                    "The slings and arrows of outrageous fortune\r\n        " +
                    "Or to take arms against a sea of troubles,\r\n        " +
                    "And by opposing end them? To die: to sleep;\r\n        " +
                    "No more; and by a sleep to say we end\r\n        " +
                    "The heart-ache and the thousand natural shocks\r\n        " +
                    "That flesh is heir to? 'tis a consumation\r\n        " +
                    "Devoutly to be wish'd. To die, to sleep";
                Console.WriteLine(user_text);
            }
            else user_text = Convert.ToString(pressed_key) + Console.ReadLine();
            if (string.IsNullOrEmpty(user_text)) { throw new Exception("Error: NULL string"); }

            Console.Write("\nEnter a forbidden word : ");
            string forbidden_word = Console.ReadLine();
            if (string.IsNullOrEmpty(forbidden_word)) { throw new Exception("Error: NULL string"); }

            
            char[] replace_with_string = new char[forbidden_word.Length];
            for (int i = 0; i < replace_with_string.Length; i++)
                replace_with_string[i] = '*';

            int appearance = Regex.Matches(user_text, forbidden_word).Count();

            string result =  user_text.Replace(forbidden_word, new string(replace_with_string), true, System.Globalization.CultureInfo.CurrentCulture);

            Console.WriteLine("\nresult:\n" + result);
            Console.WriteLine("\nstatistics: made "+appearance+" changes of word " + forbidden_word);


        }

    }// class Program
}// namespace
