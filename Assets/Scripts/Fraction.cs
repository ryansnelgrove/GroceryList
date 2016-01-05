using System;

public class Fraction {

    private int num, den;

    public int Numerator
    {
        get { return num; }
    }

    public int Denominator
    {
        get { return den; }
    }

    public Fraction(int num, int den)
    {
        this.num = num;

        if (den > 0)
        {
            this.den = den;
        }
        else if (den < 0)
        {
            this.num *= -1;
        }
        else
        {
            throw new DivideByZeroException("Denominator cannot be 0.");
        }
    }

    public Fraction(float floatValue)
    {
        Fraction temp = ApproximateFraction(floatValue);
        num = temp.num;
        den = temp.den;
    }

    public static Fraction Parse(float f)
    {
        return ApproximateFraction(f);
    }

    public float ToFloat(int decimalPlaces)
    {
        if (this.den == 0)
            return float.NaN;

        return (float)Math.Round(num / (float)den, decimalPlaces);
    }

    public static Fraction operator +(Fraction a, Fraction b)
    {
        return new Fraction(a.num * b.den + b.num * a.den, a.den * b.den);
    }

    public static Fraction operator *(Fraction a, Fraction b)
    {
        return new Fraction(a.num * b.num, a.den * b.den);
    }

    public static Fraction operator -(Fraction a, Fraction b)
    {
        return new Fraction(a.num * b.den - b.num * a.den, a.den * b.den);
    }

    public static Fraction operator /(Fraction a, Fraction b)
    {
        return new Fraction(a.num * b.den, a.den * b.num);
    }

    public static implicit operator float(Fraction f)
    {
        return (float)f.num / f.den;
    }

    private static Fraction ApproximateFraction(float value)
    {
        const float EPSILON = 0.000001f;

        int n = 1;
        int d = 1;
        float fraction = n / d;

        while (Math.Abs(fraction - value) > EPSILON)
        {
            if (fraction < value)
            {
                n++;
            }
            else
            {
                d++;
                n = (int)Math.Round(value * d);
            }

            fraction = n / (float)d;
        }

        return new Fraction(n, d);
    }

    public override string ToString()
    {
        string ret = "";
        int whole = num / den;
        if (whole != 0)
        {
            ret += whole + " ";
        }
        ret += Math.Abs(num % den) + "/" + den;
        return ret;
    }
}
