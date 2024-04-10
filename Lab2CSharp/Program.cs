namespace Lab2CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Оберіть завдання для вирішення:");
            Console.WriteLine("Завдання 1. Визначити, чи є добуток елементів тризначним числом.");
            Console.WriteLine("Завдання 2. Підрахунок кількості елементів, більших за попередній у одновимірному масиві.");
            Console.WriteLine("Завдання 3. Підрахувати суму елементів, розташованих на побічної діагоналі.");
            Console.WriteLine("Завдання 4. Для кожного рядка підрахувати кількість додатних елементів і записати дані в новий масив.");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                case 3:
                    Task3();
                    break;
                case 4:
                    Task4();
                    break;
                default:
                    Console.WriteLine("Помилка введення");
                    break;
            }
        }
        
        static void Task1()
        {
            int[] array1D = InputArray1D();
            PrintResult(IsProductThreeDigit(array1D), "одновимірного");

            int[,] array2D = InputArray2D();
            PrintResult(IsProductThreeDigit(array2D), "двовимірного");
        } 
        
        static int[] InputArray1D() 
        { 
            Console.WriteLine("Розмірність одновимірного масиву:"); 
            int n1D = int.Parse(Console.ReadLine());
            
            int[] array1D = new int[n1D];
            
            Console.WriteLine("Елементи одновимірного масиву:"); 
            for (int i = 0; i < n1D; i++) 
            {
            array1D[i] = int.Parse(Console.ReadLine()); 
            }
            
            return array1D; 
        }
        
        static int[,] InputArray2D()
        {
            Console.WriteLine("Розмірність двовимірного масиву:"); 
            Console.WriteLine("n = ");
            int n = int.Parse(Console.ReadLine());
    
            Console.WriteLine("m = ");
            int m = int.Parse(Console.ReadLine());

            int[,] array2D = new int[n, m];

            Console.WriteLine("Елементи двовимірного масиву:");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array2D[i, j] = int.Parse(Console.ReadLine());
                }
            }
            return array2D;
        }

        static bool IsProductThreeDigit(int[] arr) 
        {
        int product = 1;
        foreach (int num in arr)
        {
            product *= num;
        }
        return product >= 100 && product <= 999; 
        }
        
        static bool IsProductThreeDigit(int[,] arr) 
        {
        int product = 1;
        int rows = arr.GetLength(0);
        int cols = arr.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                product *= arr[i, j];
            }
        }
        return product >= 100 && product <= 999; 
        }
        
        static void PrintResult(bool isThreeDigit, string type) 
        { 
            if (isThreeDigit) 
            {
            Console.WriteLine($"Добуток елементів {type} масиву є тризначним числом."); 
            }
            else 
            {
            Console.WriteLine($"Добуток елементів {type} масиву не є тризначним числом."); 
            } 
        }

        static void Task2()
        {
            int[] array1D = InputArray1D();
            int count = CountElementsGreaterThanPrevious(array1D);
            Console.WriteLine($"Кількість елементів, більших за попередній: {count}");
        }

        static int CountElementsGreaterThanPrevious(int[] arr)
        {
            int count = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > arr[i - 1])
                {
                    count++;
                }
            }
            return count;
        }
        
        static void Task3()
        {
            int[,] array2D = InputArray2D();
            int sum = SumOfElementsOnSecondaryDiagonal(array2D);
            Console.WriteLine($"Сума елементів на побічній діагоналі: {sum}");
        }
        
        static int SumOfElementsOnSecondaryDiagonal(int[,] arr)
        {
            int sum = 0;
            int n = arr.GetLength(0);
            int m = arr.GetLength(1);

            // Побічна діагональ: елементи з індексами [i, m - i - 1]
            for (int i = 0; i < n; i++)
            {
                sum += arr[i, m - i - 1];
            }

            return sum;
        }

        static void Task4()
        {
            int[][] array2D = InputShArray2D();
            int[] positiveCounts = CountPositiveElementsInRows(array2D);
    
            Console.WriteLine("Кількість додатних елементів у кожному рядку:");
            for (int i = 0; i < positiveCounts.Length; i++)
            {
                Console.WriteLine($"Рядок {i + 1}: {positiveCounts[i]}");
            }
        }
        
        static int[][] InputShArray2D()
        {
            Console.WriteLine("Розмірність східчастого масиву:");
            Console.WriteLine("Кількість рядків (n): ");
            int n = int.Parse(Console.ReadLine());

            int[][] jaggedArray2D = new int[n][];

            Console.WriteLine("Елементи східчастого масиву:");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Кількість елементів у {i + 1}-му рядку:");
                int m = int.Parse(Console.ReadLine());
                jaggedArray2D[i] = new int[m];

                Console.WriteLine($"Елементи {i + 1}-го рядку:");
                for (int j = 0; j < m; j++)
                {
                    jaggedArray2D[i][j] = int.Parse(Console.ReadLine());
                }
            }
            return jaggedArray2D;
        }
        static int[] CountPositiveElementsInRows(int[][] arr)
        {
            int rows = arr.Length;
            int[] positiveCounts = new int[rows];

            for (int i = 0; i < rows; i++)
            {
                int count = 0;
                foreach (int num in arr[i])
                {
                    if (num > 0)
                    {
                        count++;
                    }
                }
                positiveCounts[i] = count;
            }

            return positiveCounts;
        }

    }
}
