using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Neopic
{
    public static class Check
    {
        [Conditional("DEBUG")]
        public static void ArgumentSatisfies(bool condition, string name = null)
        {
            if (!condition)
                throw new ArgumentException(string.Format("Check Argument.Satisfies condition failed."));
        }

        [Conditional("DEBUG")]
        public static void ArgumentIsNotNull<T>(T arg, string name = null) where T : class
        {
            if (arg == null)
                throw new ArgumentNullException(name, "Check Argument.IsNotNull failed.");
        }

        [Conditional("DEBUG")]
        public static void ArgumentIsNotEqual<T>(T arg, T value, string name = null) where T : IEquatable<T>
        {
            if (arg == null && value == null)
                return;
            if (!arg.Equals(value))
                throw new ArgumentException(string.Format("Check Argument.IsNotEqual failed.  Expected anything except:<{0}>  Actual:<{1}>", value, arg), name);
        }

        [Conditional("DEBUG")]
        public static void ArgumentIsLessThan<T>(T arg, T value, string name = null) where T : IComparable<T>
        {
            if (arg.CompareTo(value) >= 0)
                throw new ArgumentOutOfRangeException(string.Format("Check Argument.IsLessThan failed.  Expected anything less than:<{0}>  Actual:<{1}>", value, arg), name);
        }

        [Conditional("DEBUG")]
        public static void ArgumentIsLessThanOrEqual<T>(T arg, T value, string name = null) where T : IComparable<T>
        {
            if (arg.CompareTo(value) > 0)
                throw new ArgumentOutOfRangeException(string.Format("Check Argument.IsLessThanOrEqual failed.  Expected anything less than or equal to:<{0}>  Actual:<{1}>", value, arg), name);
        }

        [Conditional("DEBUG")]
        public static void ArgumentIsGreaterThan<T>(T arg, T value, string name = null) where T : IComparable<T>
        {
            if (arg.CompareTo(value) <= 0)
                throw new ArgumentOutOfRangeException(string.Format("Check Argument.IsGreaterThan failed.  Expected anything greater than:<{0}>  Actual:<{1}>", value, arg), name);
        }

        [Conditional("DEBUG")]
        public static void ArgumentIsGreaterThanOrEqual<T>(T arg, T value, string name = null) where T : IComparable<T>
        {
            if (arg.CompareTo(value) < 0)
                throw new ArgumentOutOfRangeException(string.Format("Check Argument.IsLessThanOrEqual failed.  Expected anything greater than or equal to:<{0}>  Actual:<{1}>", value, arg), name);
        }



        [Conditional("DEBUG")]
        public static void IndexIsInRange<T>(T arg, T min, T max) where T : IComparable<T>
        {
            if (arg.CompareTo(min) < 0)
                throw new IndexOutOfRangeException(string.Format("Check Index.IsInRange failed.  Expected anything greater than or equal to:<{0}>  Actual:<{1}>", min, arg));
            if (arg.CompareTo(max) >= 0)
                throw new IndexOutOfRangeException(string.Format("Check Index.IsInRange failed.  Expected anything less than:<{0}>  Actual:<{1}>", max, arg));
        }




        [Conditional("DEBUG")]
        public static void CollectionIsNotEmpty<T>(IEnumerable<T> collection, string name = null)
        {
            if (!collection.Any())
                throw new ArgumentException(string.Format("Check Collection.IsNotEmpty failed."));
        }

        [Conditional("DEBUG")]
        public static void CollectionElementsSatisfy<T>(IEnumerable<T> collection, Func<T, bool> condition, string name = null)
        {
            int index = 0;
            foreach (T element in collection)
            {
                if (!condition(element))
                    throw new ArgumentException(string.Format("Check Collection.ElementsSatisfy failed.  Actual element at {0} fails condition:<{1}>", index, element), name);
                index++;
            }
        }



        [Conditional("DEBUG")]
        public static void Condition(bool condition, string message = null)
        {
            Condition<CheckException>(condition, () => new CheckException(message));
        }

        [Conditional("DEBUG")]
        public static void Condition<TException>(bool condition, Func<TException> exception) where TException : Exception
        {
            if (!condition)
                throw exception();
        }
    }


    [Serializable]
    public class CheckException : Exception
    {
        public CheckException()
        {
        }

        public CheckException(string message)
            : base(message)
        {
        }

        public CheckException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected CheckException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}