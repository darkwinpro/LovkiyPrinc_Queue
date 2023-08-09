using System;
using System.Collections;

public class Program
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    
    public static void Main()
    {
        var n = Convert.ToInt32(Console.ReadLine());
        string[] array = new string[n];
        
        for (var i = 0; i < array.Length; i++)
        {
            array[i] = Console.ReadLine();
        }

        var m = array[0].Length;

        Queue<Coordinate> points = new Queue<Coordinate>();

        int[,] labyrinth = new int[n + 2, m + 2];

        int xPrincess = 0;
        int yPrincess = 0;
        
        for (var i = 0; i <= n + 1; i++)
        {
            for (var j = 0; j <= m + 1 ; j++)
            {
                labyrinth[i, j] = -1;
            }
        }

        for (int i = 0; i < n; i++)
        {
            string str = array[i];

            for (int j = 0; j < m; j++)
            {
                if (str[j] == '1')
                {
                    labyrinth[i + 1, j + 1] = -1000;
                    points.Enqueue(new Coordinate { X = i + 1, Y = j + 1 });
                }
                else if (str[j] == '.')
                {
                    labyrinth[i + 1, j + 1] = 0;
                }
                else if (str[j] == '2')
                {
                    xPrincess = i + 1;
                    yPrincess = j + 1;
                    labyrinth[i + 1, j + 1] = 0;
                }
            }
        }

        int step = 1;
        int start = 1;
        int end = 1;
        int count = 1;
        
        while (points.Count > 0)
        {
            for (int i = start; i <= end; i++)
            {
                Coordinate currentCoordinate= points.Dequeue();
                int x = currentCoordinate.X;
                int y = currentCoordinate.Y;

                if (labyrinth[x - 1, y] == 0)
                {
                    labyrinth[x - 1, y] = step;
                    points.Enqueue(new Coordinate { X = x - 1, Y = y });
                    count++;
                }
                
                if (labyrinth[x + 1, y] == 0)
                {
                    labyrinth[x + 1, y] = step;
                    points.Enqueue(new Coordinate { X = x + 1, Y = y });
                    count++;
                }
                
                if (labyrinth[x, y - 1] == 0)
                {
                    labyrinth[x, y - 1] = step;
                    points.Enqueue(new Coordinate { X = x, Y = y  - 1 });
                    count++;
                }
                
                if (labyrinth[x, y + 1] == 0)
                {
                    labyrinth[x, y + 1] = step;
                    points.Enqueue(new Coordinate { X = x, Y = y  + 1 });
                    count++;
                }
                
                if (labyrinth[x + 1, y - 1] == 0)
                {
                    labyrinth[x + 1, y - 1] = step;
                    points.Enqueue(new Coordinate { X = x + 1, Y = y - 1 });
                    count++;
                }
                
                if (labyrinth[x - 1, y + 1] == 0)
                {
                    labyrinth[x - 1, y + 1] = step;
                    points.Enqueue(new Coordinate { X = x - 1, Y = y + 1 });
                    count++;
                }
                
                if (labyrinth[x - 1, y - 1] == 0)
                {
                    labyrinth[x - 1, y - 1] = step;
                    points.Enqueue(new Coordinate { X = x - 1, Y = y  - 1 });
                    count++;
                }
                
                if (labyrinth[x + 1, y + 1] == 0)
                {
                    labyrinth[x + 1, y + 1] = step;
                    points.Enqueue(new Coordinate { X = x + 1, Y = y  + 1 });
                    count++;
                }
            }

            start = end + 1;
            end = count;
            step++;
        }
        
        if (labyrinth[xPrincess, yPrincess] == 0)
        {
            Console.WriteLine("Бесконечность");
        }
        else if (labyrinth[xPrincess, yPrincess] > 0)
        {
            Console.WriteLine(labyrinth[xPrincess, yPrincess] * 5);
        }
    }
}