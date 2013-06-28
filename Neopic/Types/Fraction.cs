using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neopic
{
    public struct Fraction
    {
        private readonly int _numerator;
        private readonly int _denominator;
        private const int _overflow = 10000000;

        public static readonly Fraction Zero = new Fraction(0, 1);

        public Fraction(int _numerator)
            : this(_numerator, 1)
        {
        }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Attempt to create with invalid zero valued denominator", "denominator");

            if (numerator > _overflow || numerator < -_overflow)
                throw new ArgumentOutOfRangeException("_numerator", numerator, "Integer overflow");

            if (denominator > _overflow || denominator < -_overflow)
                throw new ArgumentOutOfRangeException("denominator", denominator, "Integer overflow");

            _numerator = denominator < 0 ? -numerator : numerator;
            _denominator = denominator < 0 ? -denominator : denominator;
        }

        public int Numerator
        {
            get { return _numerator; }
        }

        public int Denominator
        {
            get { return _denominator; }
        }

        public Fraction Reduce()
        {
            if (_numerator == 0)
            {
                return Zero;
            }
            else
            {
                var m = GreatestCommonDenominator(_numerator, _denominator);
                var n = _numerator / m;
                var d = _denominator / m;
                return new Fraction(d < 0 ? -n : n, d < 0 ? -d : d);
            }
        }

        public Fraction Reciprocal()
        {
            if (_numerator == 0)
                throw new DivideByZeroException();
            return new Fraction(_numerator < 0 ? -_denominator : _denominator, _numerator < 0 ? -_numerator : _numerator);
        }

        public static int GreatestCommonDenominator(int x, int y)
        {
            uint v1, v2, r;

            if (x == 0)
            {
                if (y > 0)
                    return y;
                else
                    return 1;
            }
            else if (y == 0)
            {
                if (x > 0)
                    return x;
                else
                    return 1;
            }

            //Euclid's algorithm
            if (x > y)
            {
                v1 = (uint)Math.Abs(x);
                v2 = (uint)Math.Abs(y);
            }
            else
            {
                v1 = (uint)Math.Abs(y);
                v2 = (uint)Math.Abs(x);
            }

            r = v1 % v2;
            while (r != 0)
            {
                v1 = v2;
                v2 = r;
                r = v1 % v2;
            }

            return (int)v2;
        }

        public static int LeastCommonMultiple(int x, int y)
        {
            int value = (x * y) / ((int)GreatestCommonDenominator(x, y));
            if (value < 0)
                value = 0;
            return value;
        }

        public static Fraction operator +(Fraction x, Fraction y)
        {
            var m = LeastCommonMultiple(x._denominator, y._denominator);
            return new Fraction(m * x._numerator / x._denominator + m * y._numerator / y._denominator, m).Reduce();
        }

        public static Fraction operator -(Fraction x, Fraction y)
        {
            var m = LeastCommonMultiple(x._denominator, y._denominator);
            return new Fraction(m * x._numerator / x._denominator - m * y._numerator / y._denominator, m).Reduce();
        }

        public static Fraction operator *(Fraction x, Fraction y)
        {
            return new Fraction(x._numerator * y._numerator, x._denominator * y._denominator).Reduce();
        }

        public static Fraction operator *(Fraction x, int m)
        {
            return new Fraction(x._numerator * m, x._denominator).Reduce();
        }

        public static Fraction operator /(Fraction x, Fraction y)
        {
            if (y._numerator == 0)
                throw new DivideByZeroException();
            return new Fraction(x._numerator * y._denominator, x._denominator * y._numerator).Reduce();
        }

        public static Fraction operator /(Fraction x, int m)
        {
            if (m == 0)
                throw new DivideByZeroException();
            return new Fraction(x._numerator, x._denominator * m).Reduce();
        }

        public static Fraction operator %(Fraction x, Fraction y)
        {
            if (y._numerator == 0)
                throw new DivideByZeroException();

            return new Fraction((x._numerator * y._denominator) % (x._denominator * y._numerator), x._denominator * y._denominator).Reduce();
        }

        public static bool operator <(Fraction x, Fraction y)
        {
            bool negx = x._numerator < 0;
            bool negy = y._numerator < 0;

            if ((negx && !negy) || (!negx && negy))
                return (x._numerator * y._denominator) < (x._denominator * y._numerator);
            else
                return (x._numerator * y._denominator) > (x._denominator * y._numerator);
        }

        public static bool operator >(Fraction x, Fraction y)
        {
            return y < x;
        }

        public static bool operator <=(Fraction x, Fraction y)
        {
            return (x < y) || (x == y);
        }

        public static bool operator >=(Fraction x, Fraction y)
        {
            return y <= x;
        }

        public static bool operator ==(Fraction x, Fraction y)
        {
            var xr = x.Reduce();
            var yr = y.Reduce();
            return (x._numerator == y._numerator) && (x._denominator == y._denominator);
        }

        public static bool operator !=(Fraction x, Fraction y)
        {
            return !(x == y);
        }

        public static explicit operator decimal(Fraction f)
        {
            return (decimal)f._numerator / (decimal)f._denominator;
        }

        public bool Equals(Fraction f)
        {
            return this == f;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(Fraction))
                return this == (Fraction)obj;
            return false;
        }

        public static bool Equals(Fraction x, Fraction y)
        {
            return x == y;
        }

        public override int GetHashCode()
        {
            return _numerator ^ _denominator;
        }
    }
}
