using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practic5
{
    enum Color//цвета
    {
        black = 0,
        blue = 1,
        green = 2,
        red = 4,
        white = 7
    };
    class Check
    {
        internal static int check(Color A)
        { //проверка правильности цвета
            switch (A)
            {
                case Color.black: return 1;
                case Color.green: return 1;
                case Color.blue: return 1;
                case Color.red: return 1;
                case Color.white: return 1;
                default: return 0;
            }
        }
    }
    partial class ColorPrint
    {
        internal static void print_color(Color color)
        {   //вывод цвета 
            switch (color)
            {
                case Color.black: Console.WriteLine("BLACK"); break;
                case Color.green: Console.WriteLine("GREEN"); break;
                case Color.blue: Console.WriteLine("BLUE"); break;
                case Color.red: Console.WriteLine("RED"); break;
                case Color.white: Console.WriteLine("WHITE"); break;
            }
        }
    }

    partial class Circle
    {
        private int x, y;                      //центр круга
        private int R;                         //радиус круга
        private Color ColorFillCircle;               //цвет заливки
        private Color ColorStrokeCircle;             //цвет обводки
        public Circle(int XCoor, int YCoor, int Radius, Color Fill, Color Stroke)
        {//конструкктор
            x = XCoor; y = YCoor;


            if (Radius >= 1) R = Radius;
            else
            {
                Console.WriteLine("Error in Radius: " + R);
                R = 1;
            }


            if (Check.check(Fill) == 1) ColorFillCircle = Fill;
            else
            {
                Console.WriteLine("Error in color of fill: "); //если цвет неправильный, делаем цвет красным
                ColorFillCircle = Color.red;
            }
            if (Check.check(Stroke) == 1) ColorStrokeCircle = Stroke;
            else
            {
                Console.WriteLine("Error in color of fill");
                ColorStrokeCircle = Color.red;
            }

        }
        public partial double GetPerimetr();                           //получение периметра круга
        public partial double GetSquare();                             //получение площади круга
        public partial void MoveX(int dx);                              //перемещение по х координате
        public partial void MoveY(int dy);                              //перемещение по y координате
        public partial void print();                                   //вывод
    }
    partial class Triangle
    {
        int x1, y1, x2, y2, x3, y3;          //координаты вершин
        Color ColorFillTriangle, ColorStrokeTriangle;           //цвета заливик и обводки
        public Triangle(int X1Coor, int Y1Coor, int X2Coor, int Y2Coor, int X3Coor, int Y3Coor, Color Fill, Color Stroke)
        { // конструктор

            x1 = X1Coor; y1 = Y1Coor; x2 = X2Coor; y2 = Y2Coor; x3 = X3Coor; y3 = Y3Coor;


            if (Check.check(Fill) == 1) ColorFillTriangle = Fill;
            else
            {
                Console.WriteLine("Error in Color Fill"); //если цвет неправильный, делаем цвет красным
                ColorPrint.print_color(Fill);
                ColorFillTriangle = Color.red;
            }
            if (Check.check(Stroke) == 1) ColorStrokeTriangle = Stroke;
            else
            {
                Console.WriteLine("Error in Color Stroke");
                ColorPrint.print_color(Stroke);
                ColorStrokeTriangle = Color.red;
            }
        }

        private partial double GetLine(int x1, int y1, int x2, int y2);  //функция для определения стороны треугольник(ищет по т.Пифагора)
        public partial double GetPerimetr();      //периметр треугольника
        public partial double GetSquare();    //площадь треугольника
        public partial void MoveX(int dx);   //пемерещение по х координате
        public partial void MoveY(int dy);     //перемещение по y координате        
        public partial void print();         //вывод
    }

    partial class VectorImage
    {
        List<Circle> circle = new List<Circle>();
        List<Triangle> triangle = new List<Triangle>();

        int Width;
        int Height;


        public VectorImage(int X, int Y, int r, Color fillcircle, Color strokecircle, int X1, int Y1, int X2, int Y2,
        int X3, int Y3, Color filltriangle, Color stroketriangle, int width, int height)
        {
            Width = width;
            Height = height;
            circle.Add(new Circle(X, Y, r, fillcircle, strokecircle));
            circle[0].X = X;
            circle[0].Y = Y;
            circle[0].Radius = r;
            circle[0].Fill = fillcircle;
            circle[0].Stroke = strokecircle;

            triangle.Add(new Triangle(X1, Y1, X2, Y2, X3, Y3, filltriangle, stroketriangle));
            triangle[0].X1 = X1;
            triangle[0].Y1 = Y1;
            triangle[0].X2 = X2;
            triangle[0].Y2 = Y2;
            triangle[0].X3 = X3;
            triangle[0].Y3 = Y3;
            triangle[0].FillT = filltriangle;
            triangle[0].StrokeT = stroketriangle;
        }//конструктор

        public partial int GetQuantityCircle();  //нахождение количества кругов
        public partial void AddCircle(int x, int y, int r, Color fill, Color stroke);    //добавление круга

        public partial void AddTriangle(int X1, int Y1, int X2, int Y2, int X3, int Y3, Color filltriangle, Color stroketriangle); //добавления треугольника
        public partial int GetQuantityTriangle(); // нахождение количества треугольников
        public partial void DeleteCircle(int j);       //удаление круга по индексу
        public partial void GetCircle(int i);          //получение круга по индексу

        public partial void DeleteTriangle(int i);       //удаление треугольника по индексу
        public partial void GetTriangle(int i);          //получение треугольтника по индексу

        public partial void MoveX(int dx);           //перемещение всех фигур по х координате
        public partial void MoveY(int dy);        //перемещение по y координате
    }
}
