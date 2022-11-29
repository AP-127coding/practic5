namespace lab2WIn
{
    public partial class Circle : Figure
    {
        public int X
        {
            set { x = value; }
            get { return x; }
        }
        public int Y
        {
            set { y = value; }
            get { return y; }
        }
        public int Radius
        {
            set { R = (value >= 1) ? value : 1; }
            get { return R; }
        }


        public override partial double GetPerimetr()
        {
            return 2 * 3.14 * R;
        }

        public override partial double GetSquare()
        {
            return 3.14 * R * R;
        }

        public override partial void MoveX(int dx) // смещение по оси X
        {
            x += dx;
        }

        public override partial void MoveY(int dy) // смещение по оси Y
        {
            y += dy;
        }
        public override partial void PrintSquare(int i)
        {
            Console.WriteLine($"Круг [{i}]:\nx: {x}\ny: {y}\nРадиус: {R}\nЦвет заливки: {ColorPrint.print_colorstring(ColorFill)}\nЦвет обводки: {ColorPrint.print_colorstring(ColorStroke)}\nПлощадь: {GetSquare()}");
        }
        public override partial void PrintPerimetr(int i)
        {
            Console.WriteLine($"Круг [{i}]:\nx: {x}\ny: {y}\nРадиус: {R}\nЦвет заливки: {ColorPrint.print_colorstring(ColorFill)}\nЦвет обводки: {ColorPrint.print_colorstring(ColorStroke)}\nПериметр: {GetPerimetr()}");
        }
        public override partial void print(int i) // вывод Круга
        {
            Console.WriteLine($"Круг [{i}]:\nx: {x}\ny: {y}\nРадиус: {R}\nЦвет заливки: {ColorPrint.print_colorstring(ColorFill)}\nЦвет обводки: {ColorPrint.print_colorstring(ColorStroke)}");
        }

    }
    public partial class Triangle : Figure
    {
        public int X1
        {
            set { x1 = value; }
            get { return x1; }
        }
        public int Y1
        {
            set { y1 = value; }
            get { return y1; }
        }
        public int X2
        {
            set { x2 = value; }
            get { return x2; }
        }
        public int Y2
        {
            set { y2 = value; }
            get { return y2; }
        }
        public int X3
        {
            set { x3 = value; }
            get { return x3; }
        }
        public int Y3
        {
            set { y3 = value; }
            get { return y3; }
        }
        public partial double GetLine(int x1, int y1, int x2, int y2)  //функция для определения стороны треугольник(ищет по т.Пифагора)
        {
            int a = Math.Abs(x1 - x2);
            int b = Math.Abs(y1 - y2);
            double c = Math.Sqrt(a * a + b * b);
            return c;

        }
        public override partial double GetPerimetr() //периметр треугольника
        {
            double a = GetLine(x1, y1, x2, y2);
            double b = GetLine(x1, y1, x3, y3);
            double c = GetLine(x2, y2, x3, y3);
            return a + b + c;

        }
        public override partial double GetSquare() //площадь треугольника

        {
            double a = GetLine(x1, y1, x2, y2);
            double b = GetLine(x1, y1, x3, y3);
            double c = GetLine(x2, y2, x3, y3);
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));

        }
        public override partial void MoveX(int dx) //пемерещение по х координате
        {
            x1 += dx;
            x2 += dx;
            x3 += dx;
        }
        public override partial void MoveY(int dy) //перемещение по y координате
        {
            y1 += dy;
            y2 += dy;
            y3 += dy;
        }
        public override partial void PrintSquare(int i)
        {
            Console.WriteLine($"Треугольник[{i}]:\nx1: {x1}\ny1: {y1}\nx2: {x2}\ny2: {y2}\nx3: {x3}\ny3: {y3}\nЦвет заливки: {ColorPrint.print_colorstring(ColorFill)}\nЦвет обовдки: {ColorPrint.print_colorstring(ColorStroke)}\nПлощадь: {GetSquare()}");
        }
        public override partial void PrintPerimetr(int i)
        {
            Console.WriteLine($"Треугольник[{i}]:\nx1: {x1}\ny1: {y1}\nx2: {x2}\ny2: {y2}\nx3: {x3}\ny3: {y3}\nЦвет заливки: {ColorPrint.print_colorstring(ColorFill)}\nЦвет обовдки: {ColorPrint.print_colorstring(ColorStroke)}\nПериметр: {GetPerimetr()}");
        }
        public override partial void print(int i) //вывод
        {
            Console.WriteLine($"Треугольник[{i}]:\nx1: {x1}\ny1: {y1}\nx2: {x2}\ny2: {y2}\nx3: {x3}\ny3: {y3}\nЦвет заливки: {ColorPrint.print_colorstring(ColorFill)}\nЦвет обовдки: {ColorPrint.print_colorstring(ColorStroke)}");
        }

    }
    public partial class VectorImage
    {
        public partial int GetQuantityCircle() //нахождение количества кругов
        {
            return circlelist.Count;
        }
        public partial void AddCircle(int x, int y, int r, Colors fill, Colors stroke) //добавление круга
        {
            int k = circlelist.Count;
            circlelist.Add(new Circle(x, y, r, fill, stroke));
            circlelist[k].X = x;
            circlelist[k].Y = y;
            circlelist[k].Radius = r;
            circlelist[k].Fill = fill;
            circlelist[k].Stroke = stroke;

        }
        public partial void AddTriangle(int X1, int Y1, int X2, int Y2, int X3, int Y3, Colors filltriangle, Colors stroketriangle) //добавления треугольника
        {
            int k = trianglelist.Count;
            trianglelist.Add(new Triangle(X1, Y1, X2, Y2, X3, Y3, filltriangle, stroketriangle));
            trianglelist[k].X1 = X1;
            trianglelist[k].Y1 = Y1;
            trianglelist[k].X2 = X2;
            trianglelist[k].Y2 = Y2;
            trianglelist[k].X3 = X3;
            trianglelist[k].Y3 = Y3;
            trianglelist[k].Fill = filltriangle;
            trianglelist[k].Stroke = stroketriangle;

        }
        public partial int GetQuantityTriangle() // нахождение количества треугольников
        {
            return trianglelist.Count;
        }
        public partial void DeleteCircle(int j) //удаление круга по индексу
        {
            if (j > circlelist.Count - 1)
            {
                Console.WriteLine("Такого индекса не сущствует, количество добавленных кругов = " + circlelist.Count);
                
            }
            else
            {
                circlelist.RemoveAt(j);
                Console.WriteLine("Круг успешно удален");
            }

        }

        public partial void GetCircle(int i) //получение круга по индексу
        {
            if (i >= circlelist.Count)
            {
                Console.WriteLine($"Нет круга по этому индексу, количество кругов : {circlelist.Count}");
                
            }
            else circlelist[i].print(i);
        }
        public partial void DeleteTriangle(int i) //удаление треугольника по индексу
        {
            if (i > trianglelist.Count - 1)
            {
                Console.WriteLine("Такого индекса не сущствует, количество добавленных треугольников = " + circlelist.Count);
                
            }
            else
            {
                trianglelist.RemoveAt(i);
                Console.WriteLine("Треугольник успешно удален");
            }
        }
        public partial void GetTriangle(int i) //получение треугольтника по индексу
        {

            if (i >= trianglelist.Count)
            {
                Console.WriteLine($"Нет треугольника по этому индексу, количество треугольников : {trianglelist.Count}");
            }
            else trianglelist[i].print(i);
        }
        public partial void MoveXCircles(int dx) //перемещение всех фигур по х координате
        {
            for (int i = 0; i < circlelist.Count; i++)
            {
                circlelist[i].MoveX(dx);
            }
        }
        public partial void MoveYCircles(int dy) //перемещение по y координате
        {
            for (int i = 0; i < circlelist.Count; i++)
            {
                circlelist[i].MoveY(dy);
            }
        }
        public partial void MoveXTriangles(int dx)
        {
            for (int i = 0; i < trianglelist.Count; i++)
            {
                trianglelist[i].MoveX(dx);
            }
        }
        public partial void MoveYTriangles(int dy)
        {
            for (int i = 0; i < trianglelist.Count; i++)
            {
                trianglelist[i].MoveY(dy);
            }
        }

        public partial void MoveXCircle(int dx, int i)
        {
            circlelist[i].MoveX(dx);
        }
        public partial void MoveYCircle(int dy, int j)
        {
            circlelist[j].MoveY(dy);
        }
        public partial void MoveXTriangle(int dx, int i)
        {
            trianglelist[i].MoveX(dx);
        }
        public partial void MoveYTriangle(int dy, int j)
        {
            trianglelist[j].MoveY(dy);
        }
    }
    internal static class Program
    {
        
        static void Main()
        {
            
        }
    }
}