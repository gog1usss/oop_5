class TPTriangle
{
    private double leg1;
    private double leg2;

    public TPTriangle()
    {
        leg1 = 0;
        leg2 = 0;
    }

    public TPTriangle(double leg1, double leg2)
    {
        this.leg1 = leg1;
        this.leg2 = leg2;
    }

    public TPTriangle(TPTriangle other)
    {
        leg1 = other.leg1;
        leg2 = other.leg2;
    }

    public void Read()
    {
        Console.Write("Введіть довжину першого катета: ");
        leg1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введіть довжину другого катета: ");
        leg2 = Convert.ToDouble(Console.ReadLine());
    }

    public void Print()
    {
        Console.WriteLine($"Довжина першого катета: {leg1}");
        Console.WriteLine($"Довжина другого катета: {leg2}");
        Console.WriteLine($"Гіпотенуза: {GetHypotenuse()}");
        Console.WriteLine($"Площа: {GetArea()}");
        Console.WriteLine($"Периметр: {GetPerimeter()}");
    }

    public double GetHypotenuse()
    {
        return Math.Sqrt(leg1 * leg1 + leg2 * leg2);
    }

    public double GetArea()
    {
        return (leg1 * leg2) / 2;
    }

    public double GetPerimeter()
    {
        return leg1 + leg2 + GetHypotenuse();
    }

    public static TPTriangle operator +(TPTriangle t1, TPTriangle t2)
    {
        return new TPTriangle(t1.leg1 + t2.leg1, t1.leg2 + t2.leg2);
    }

    public static TPTriangle operator -(TPTriangle t1, TPTriangle t2)
    {
        return new TPTriangle(t1.leg1 - t2.leg1, t1.leg2 - t2.leg2);
    }

    public static TPTriangle operator *(TPTriangle t, double scalar)
    {
        return new TPTriangle(t.leg1 * scalar, t.leg2 * scalar);
    }

    public bool IsEqualArea(TPTriangle other)
    {
        return GetArea() == other.GetArea();
    }
}

class Main_Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        TPTriangle triangle1 = new TPTriangle(3, 4);
        TPTriangle triangle2 = new TPTriangle(5, 12);

        Console.WriteLine("Трикутник 1:");
        triangle1.Print();

        Console.WriteLine("\nТрикутник 2:");
        triangle2.Print();

        TPTriangle sumTriangle = triangle1 + triangle2;
        Console.WriteLine("\nСума катетів двох трикутників:");
        sumTriangle.Print();

        TPTriangle diffTriangle = triangle1 - triangle2;
        Console.WriteLine("\nРізниця катетів двох трикутників:");
        diffTriangle.Print();

        TPTriangle scaledTriangle = triangle1 * 2;
        Console.WriteLine("\nТрикутник 1, помножений на 2:");
        scaledTriangle.Print();

        Console.WriteLine($"\nТрикутник 1 і Трикутник 2 мають однакову площу? {triangle1.IsEqualArea(triangle2)}");
    }
}
