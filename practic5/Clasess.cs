using System;
using System.Linq;


namespace lab2WIn
{

    public enum Colors         //цвета
    {
        black = 0,
        blue = 1,
        green = 2,
        red = 4,
        white = 7
    };
    class Check
    {
        internal static int check(Colors A)
        { //проверка правильности цвета
            switch (A)
            {
                case Colors.black: return 1;
                case Colors.green: return 1;
                case Colors.blue: return 1;
                case Colors.red: return 1;
                case Colors.white: return 1;
                default: return 0;
            }
        }
    }
    partial class ColorPrint
    {
        internal static void print_color(Colors color)
        {   //вывод цвета 
            switch (color)
            {
                case Colors.black: Console.WriteLine("BLACK"); break;
                case Colors.green: Console.WriteLine("GREEN"); break;
                case Colors.blue: Console.WriteLine("BLUE"); break;
                case Colors.red: Console.WriteLine("RED"); break;
                case Colors.white: Console.WriteLine("WHITE"); break;
            }
        }
        internal static string print_colorstring(Colors color)
        {   //вывод цвета 
            switch (color)
            {
                case Colors.black: return "Черный";
                case Colors.green: return "Зеленый";
                case Colors.blue: return "Синий";
                case Colors.red: return "Красный";
                case Colors.white: return "Белый";
                default: return "";
            }

        }
    }

    public class Figure
    {
        public Colors ColorFill;
        public Colors ColorStroke;
        public Colors Fill
        {
            set
            {
                if (Check.check(value) == 1) ColorFill = value;
                else
                {
                    Console.WriteLine("Error in ColorFill");
                    return;
                }

            }
        }
        public Colors Stroke
        {
            set
            {
                if (Check.check(value) == 1) ColorStroke = value;
                else
                {
                    Console.WriteLine("Error in ColorFill");
                    return;
                }
            }
        }
        public Figure(Colors Fill, Colors Stroke)
        {
            if (Check.check(Fill) == 1) ColorFill = Fill;
            else
            {
                Console.WriteLine("Error in color of fill: "); //если цвет неправильный, делаем цвет красным
                ColorFill = Colors.red;
            }
            if (Check.check(Stroke) == 1) ColorStroke = Stroke;
            else
            {
                Console.WriteLine("Error in color of fill");
                ColorStroke = Colors.red;
            }
        } // конструктор для общих полей
        public virtual double GetPerimetr() { return 0; }
        public virtual double GetSquare() { return 0; }
        public virtual void MoveX(int dx) { }
        public virtual void MoveY(int dy) { }
        public virtual void print(int i) { }
        public virtual void PrintSquare(int i) { }
        public virtual void PrintPerimetr(int i) { }
    }
    public partial class Circle : Figure
    {
        private int x, y;                      //центр круга
        private int R;                         //радиус круга
        public Circle(int XCoor, int YCoor, int Radius, Colors Fill, Colors Stroke) : base(Fill, Stroke)
        {//конструкктор
            x = XCoor;
            y = YCoor;
            if (Radius >= 1) R = Radius;
            else
            {
                Console.WriteLine("Error in Radius: " + R);
                R = 1;
            }
        }
        public override partial double GetPerimetr();                           //получение периметра круга
        public override partial double GetSquare();                             //получение площади круга
        public override partial void MoveX(int dx);                             //перемещение по х координате
        public override partial void MoveY(int dy);                             //перемещение по y координате
        public override partial void PrintSquare(int i);                        //вывод площади
        public override partial void print(int i);                              //вывод
        public override partial void PrintPerimetr(int i);                      // вывод периметра
    }
    public partial class Triangle : Figure
    {
        int x1, y1, x2, y2, x3, y3;          //координаты вершин

        public Triangle(int X1Coor, int Y1Coor, int X2Coor, int Y2Coor, int X3Coor, int Y3Coor, Colors Fill, Colors Stroke) : base(Fill, Stroke) // конструктор
        {

            x1 = X1Coor;
            y1 = Y1Coor;
            x2 = X2Coor;
            y2 = Y2Coor;
            x3 = X3Coor;
            y3 = Y3Coor;

        }

        public partial double GetLine(int x1, int y1, int x2, int y2);          //функция для определения стороны треугольник(ищет по т.Пифагора)
        public override partial double GetPerimetr();                           //периметр треугольника
        public override partial double GetSquare();                             //площадь треугольника
        public override partial void MoveX(int dx);                             //пемерещение по х координате
        public override partial void MoveY(int dy);                             //перемещение по y координате        
        public override partial void PrintSquare(int i);                        //вывод площади
        public override partial void print(int i);                              //вывод
        public override partial void PrintPerimetr(int i);                      // вывод периметра

    }
    public partial class VectorImage
    {
        public List<Circle> circlelist = new List<Circle>();
        public List<Triangle> trianglelist = new List<Triangle>();

        int Width;
        int Height;
        public VectorImage() { }
        public VectorImage(int X, int Y, int r, Colors fillcircle, Colors strokecircle, int X1, int Y1, int X2, int Y2,
        int X3, int Y3, Colors filltriangle, Colors stroketriangle, int width, int height)
        {
            Width = width;
            Height = height;
            circlelist.Add(new Circle(X, Y, r, fillcircle, strokecircle));
            circlelist[0].X = X;
            circlelist[0].Y = Y;
            circlelist[0].Radius = r;
            circlelist[0].Fill = fillcircle;
            circlelist[0].Stroke = strokecircle;

            trianglelist.Add(new Triangle(X1, Y1, X2, Y2, X3, Y3, filltriangle, stroketriangle));
            trianglelist[0].X1 = X1;
            trianglelist[0].Y1 = Y1;
            trianglelist[0].X2 = X2;
            trianglelist[0].Y2 = Y2;
            trianglelist[0].X3 = X3;
            trianglelist[0].Y3 = Y3;
            trianglelist[0].Fill = filltriangle;
            trianglelist[0].Stroke = stroketriangle;
        }//конструктор

        public partial int GetQuantityCircle();  //нахождение количества кругов
        public partial void AddCircle(int x, int y, int r, Colors fill, Colors stroke);    //добавление круга

        public partial void AddTriangle(int X1, int Y1, int X2, int Y2, int X3, int Y3, Colors filltriangle, Colors stroketriangle); //добавления треугольника
        public partial int GetQuantityTriangle();         // нахождение количества треугольников
        public partial void DeleteCircle(int j);          //удаление круга по индексу
        public partial void GetCircle(int i);             //получение круга по индексу
        public partial void DeleteTriangle(int i);        //удаление треугольника по индексу
        public partial void GetTriangle(int i);           //получение треугольника по индексу
        public partial void MoveXCircle(int dx, int i);   // перемещение одного круга по x координате 
        public partial void MoveYCircle(int dy, int j);   // перемещение одного круга по y координате 
        public partial void MoveXTriangle(int dx, int i); // перемещение одного треугольника по x координате 
        public partial void MoveYTriangle(int dy, int j); // перемещение одного треугольника по y координате 
        public partial void MoveXCircles(int dx);         //перемещение всех кругов по х координате
        public partial void MoveYCircles(int dy);         //перемещение по y координате всех кругов
        public partial void MoveXTriangles(int dx);       //перемещение всех треугольников по х координате
        public partial void MoveYTriangles(int dy);       //перемещение всех треугольников по y координате

    }
}
