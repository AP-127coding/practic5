using System.Drawing;
using System.Runtime.Serialization;
using System.Text.Encodings.Web;
using System.Runtime.Serialization.Json;

namespace practic5
{
    [Serializable]
    partial class Circle
    {
        public int X
        {
            set { x = value; }
        }
        public int Y
        {
            set { y = value; }
        }
        public int Radius
        {
            set { R = (value >= 1) ? value : 1; }
        }
        public Color Fill
        {
            set
            {
                if (Check.check(value) == 1) ColorFillCircle = value;
                else
                {
                    Console.WriteLine("Error in ColorFill");
                    return;
                }

            }
        }
        public Color Stroke
        {
            set
            {
                if (Check.check(value) == 1) ColorStrokeCircle = value;
                else
                {
                    Console.WriteLine("Error in ColorFill");
                    return;
                }
            }
        }

        public partial void print() // вывод Круга
        {
            Console.WriteLine("x: " + x);
            Console.WriteLine("y: " + y);
            Console.WriteLine("R: " + R);
            Console.WriteLine("ColorFill: ");   //вывод цвета заливик 
            ColorPrint.print_color(ColorFillCircle);
            Console.WriteLine("ColorStroke: ");  //вывод цвета обводки
            ColorPrint.print_color(ColorStrokeCircle);
        }

        public partial double GetPerimetr()
        {
            return 2 * 3.14 * R;
        }

        public partial double GetSquare()
        {
            return 3.14 * R * R;
        }

        public partial void MoveX(int dx) // смещение по оси X
        {
            x += dx;
        }

        public partial void MoveY(int dy) // смещение по оси Y
        {
            y += dy;
        }
    }
    partial class Triangle
    {
        public int X1
        {
            set { x1 = value; }
        }
        public int Y1
        {
            set { y1 = value; }
        }
        public int X2
        {
            set { x2 = value; }
        }
        public int Y2
        {
            set { y2 = value; }
        }
        public int X3
        {
            set { x3 = value; }
        }
        public int Y3
        {
            set { y3 = value; }
        }
        private partial double GetLine(int x1, int y1, int x2, int y2)  //функция для определения стороны треугольник(ищет по т.Пифагора)
        {
            int a = Math.Abs(x1 - x2);
            int b = Math.Abs(y1 - y2);
            double c = Math.Sqrt(a * a + b * b);
            return c;

        }
        public Color FillT
        {
            set
            {
                if (Check.check(value) == 1) ColorFillTriangle = value;
                else
                {
                    Console.WriteLine("Error in ColorFill");
                    return;
                }
            }
        }
        public Color StrokeT
        {
            set
            {
                if (Check.check(value) == 1) ColorStrokeTriangle = value;
                else
                {
                    Console.WriteLine("Error in ColorStroke");
                    return;
                }

            }
        }
        public partial double GetPerimetr() //периметр треугольника
        {
            double a = GetLine(x1, y1, x2, y2);
            double b = GetLine(x1, y1, x3, y3);
            double c = GetLine(x2, y2, x3, y3);
            return a + b + c;

        }
        public partial double GetSquare() //площадь треугольника

        {
            double a = GetLine(x1, y1, x2, y2);
            double b = GetLine(x1, y1, x3, y3);
            double c = GetLine(x2, y2, x3, y3);
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));

        }
        public partial void MoveX(int dx) //пемерещение по х координате

        {
            x1 += dx;
            x2 += dx;
            x3 += dx;
        }
        public partial void MoveY(int dy) //перемещение по y координате
        {
            y1 += dy;
            y2 += dy;
            y3 += dy;
        }
        public partial void print() //вывод
        {
            Console.WriteLine("x1 : " + x1);
            Console.WriteLine("y1 : " + y1);

            Console.WriteLine("x2 : " + x2);
            Console.WriteLine("y2 : " + y2);

            Console.WriteLine("x3 : " + x3);
            Console.WriteLine("y3 : " + y3);

            Console.WriteLine("ColorFill : ");
            ColorPrint.print_color(ColorFillTriangle);


            Console.WriteLine("ColorStroke : ");
            ColorPrint.print_color(ColorStrokeTriangle);

        }


    }
    
    partial class VectorImage
    {
        public partial int GetQuantityCircle() //нахождение количества кругов
        {
            return circle.Count;
        }
        public partial void AddCircle(int x, int y, int r, Color fill, Color stroke) //добавление круга
        {
            int k = circle.Count;
            circle.Add(new Circle(x, y, r, fill, stroke));
            circle[k].X = x;
            circle[k].Y = y;
            circle[k].Radius = r;
            circle[k].Fill = fill;
            circle[k].Stroke = stroke;

        }
        public partial void AddTriangle(int X1, int Y1, int X2, int Y2, int X3, int Y3, Color filltriangle, Color stroketriangle) //добавления треугольника
        {
            int k = triangle.Count;
            triangle.Add(new Triangle(X1, Y1, X2, Y2, X3, Y3, filltriangle, stroketriangle));
            triangle[k].X1 = X1;
            triangle[k].Y1 = Y1;
            triangle[k].X2 = X2;
            triangle[k].Y2 = Y2;
            triangle[k].X3 = X3;
            triangle[k].Y3 = Y3;
            triangle[k].FillT = filltriangle;
            triangle[k].StrokeT = stroketriangle;

        }
        public partial int GetQuantityTriangle() // нахождение количества треугольников
        {
            return triangle.Count;
        }
        public partial void DeleteCircle(int j) //удаление круга по индексу
        {
            try
            {
                if (j < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                var add = circle;
                circle.RemoveAt(j);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Индекса меньше нуля не существует");
            }


        }
        public partial void GetCircle(int i) //получение круга по индексу
        {
            try
            {
                if (i >= circle.Count || i < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                Console.WriteLine($"Circle [{i}]:");
                circle[i].print();
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("По этому индексу нет треугольника!");
            }

        }

        public partial void DeleteTriangle(int i) //удаление треугольника по индексу
        {
            try
            {
                if (i < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                for (int j = i; j < triangle.Count - 1; j++) triangle[j] = triangle[j + 1];
                triangle.RemoveAt(0 + triangle.Count - 1);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Индекса меньше нуля не существует");
            }

        }

        public partial void GetTriangle(int i) //получение треугольтника по индексу
        {
            try
            {
                if (i >= triangle.Count || i < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                Console.WriteLine($"Triangle [{i}]:");
                triangle[i].print();
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("По этому индексу нет треугольника!");
            }


        }
        public partial void MoveX(int dx) //перемещение всех фигур по х координате
        {
            for (int i = 0; i < circle.Count; i++)
            {
                circle[i].MoveX(dx);
            }

            for (int i = 0; i < triangle.Count; i++)
            {
                triangle[i].MoveX(dx);
            }

        }
        public partial void MoveY(int dy) //перемещение по y координате
        {
            for (int i = 0; i < circle.Count; i++)
            {
                circle[i].MoveY(dy);
            }

            for (int i = 0; i < triangle.Count; i++)
            {
                triangle[i].MoveY(dy);
            }

        }
    }
    class Program
    {
       static void Main()
        {
            Circle circle = new Circle(12, 15, 18, Color.red, Color.blue);
            FileStream file = File.Create("circle.json");
            DataContractJsonSerializer form = new DataContractJsonSerializer(circle.GetType());

            form.WriteObject(file, circle);
            Console.WriteLine("Данные сериализованы");
            file.Close();

            file = File.OpenRead("circle.json");

            Circle c = form.ReadObject(file) as Circle;
            Console.WriteLine("Данные десериализованы");

            c.print();
        }
    }
}
