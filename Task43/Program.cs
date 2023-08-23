// Задача 43:
// Напишите программу, которая
// найдёт точку пересечения двух прямых, заданных уравнениями:
// y = k1 * x + b1;    y = k2 * x + b2.
// Значения k1, b1 и k2, b2 задаются пользователем:
// k1 = 5, b1 = 2;     k2 = 9, b2 = 4     –> (-0,5; -0,5)
//          y  +
//          ^
//          |
//          *
//          |
//          +
//          |
//  ── ── ──|── ── ── > x
//          |
//          |
//       +  |
//          |
//       *  |

double X(int k1X, int b1X, int k2X, int b2X)
{
    return (double)(b2X - b1X) / (k1X - k2X);
}

double Y(int kY, int bY, double xY)
{
    return kY * xY + bY;
}

void Graph(int k1G, int b1G, int k2G, int b2G)
{
    int border = 5;                             // Задаю границы графика,
    int xMin = -border; int xMax = border;      // чтобы вошли и точка пересечения, и оси координат,
    int yMin = -border; int yMax = border;      // с запасом по 5 единиц с каждой стороны.
    if (k1G == k2G)
    {
        if (b1G < 0 || b2G < 0) yMin = b1G < b2G ? b1G - border : b2G - border;
        if (b1G > 0 || b2G > 0) yMax = b1G > b2G ? b1G + border : b2G + border;
    }
    else
    {
        double xG = X(k1G, b1G, k2G, b2G);
        double yG = Y(k1G, b1G, xG);
        if (xG < 0) xMin = (int)xG - border;
        else xMax = (int)xG + border;
        if (yG < 0) yMin = (int)yG - border;
        else yMax = (int)yG + border;
    }
    
    for (int j = yMax + 2; j >= yMin; j--)      // Вывод графика в заданных границах,
    {                                           // добавлено 2 строки в начале графика
        for (int i = xMin; i <= xMax; i++)      // для вывода вверху графика символов "y" и "^".
        {
            if (i == 0 && j == yMax + 2) Console.Write("y");
            else if (i == 0 && j == yMax + 1) Console.Write("^");
            else if (j == k1G * i + b1G && j == k2G * i + b2G) Console.Write("#");
            else if (j == k1G * i + b1G) Console.Write("+");
            else if (j == k2G * i + b2G) Console.Write("*");
            else if (i == 0) Console.Write("|");
            else Console.Write(" ");
            if (j == 0)
            {
                if (i == xMax) Console.Write("> x");
                else Console.Write("──");
            }
            else Console.Write("  ");
        }
        Console.WriteLine();
    }
}

// int k1 = 5; int b1 = 2; int k2 = 9; int b2 = 4; // –> (-0,5; -0,5)

Console.WriteLine("Для уравнения: y = k1 * x + b1");
Console.Write("Введите коэффициент k1: ");
int k1 = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите коэффициент b1: ");
int b1 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Для уравнения: y = k2 * x + b2");
Console.Write("Введите коэффициент k2: ");
int k2 = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите коэффициент b2: ");
int b2 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine();

if (k1 == k2)
{
    if (b1 == b2) Console.WriteLine("Прямые совпадают.");
    else Console.WriteLine("Прямые не пересекаются.");
}
else
{
    double x = X(k1, b1, k2, b2);
    double y = Y(k1, b1, x);
    double xRound = Math.Round(x, 3);
    double yRound = Math.Round(y, 3);
    Console.WriteLine($"Точка пересечения двух прямых: x = {xRound}; y = {yRound}.");
}

Graph(k1, b1, k2, b2);
