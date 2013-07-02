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
        public static void IsTrue(bool condition)
        {
            Check.IsTrue(condition, string.Empty, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void IsTrue(bool condition, string message)
        {
            Check.IsTrue(condition, message, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void IsTrue(bool condition, string message, params object[] parameters)
        {
            if (condition)
                return;
            Check.HandleFail("Check.IsTrue", message, parameters);
        }

        [Conditional("DEBUG")]
        public static void IsFalse(bool condition)
        {
            Check.IsFalse(condition, string.Empty, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void IsFalse(bool condition, string message)
        {
            Check.IsFalse(condition, message, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void IsFalse(bool condition, string message, params object[] parameters)
        {
            if (!condition)
                return;
            Check.HandleFail("Check.IsFalse", message, parameters);
        }

        [Conditional("DEBUG")]
        public static void IsNull(object value)
        {
            Check.IsNull(value, string.Empty, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void IsNull(object value, string message)
        {
            Check.IsNull(value, message, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void IsNull(object value, string message, params object[] parameters)
        {
            if (value == null)
                return;
            Check.HandleFail("Check.IsNull", message, parameters);
        }

        [Conditional("DEBUG")]
        public static void IsNotNull(object value)
        {
            Check.IsNotNull(value, string.Empty, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void IsNotNull(object value, string message)
        {
            Check.IsNotNull(value, message, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void IsNotNull(object value, string message, params object[] parameters)
        {
            if (value != null)
                return;
            Check.HandleFail("Check.IsNotNull", message, parameters);
        }

        [Conditional("DEBUG")]
        public static void AreSame(object expected, object actual)
        {
            Check.AreSame(expected, actual, string.Empty, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void AreSame(object expected, object actual, string message)
        {
            Check.AreSame(expected, actual, message, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void AreSame(object expected, object actual, string message, params object[] parameters)
        {
            if (object.ReferenceEquals(expected, actual))
                return;
            string message1 = message;
            if (expected is ValueType && actual is ValueType)
                message1 = (string)FrameworkMessages.AreSameGivenValues(message == null ? (object)string.Empty : (object)Check.ReplaceNulls((object)message));
            Check.HandleFail("Check.AreSame", message1, parameters);
        }

        [Conditional("DEBUG")]
        public static void AreNotSame(object notExpected, object actual)
        {
            Check.AreNotSame(notExpected, actual, string.Empty, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void AreNotSame(object notExpected, object actual, string message)
        {
            Check.AreNotSame(notExpected, actual, message, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void AreNotSame(object notExpected, object actual, string message, params object[] parameters)
        {
            if (!object.ReferenceEquals(notExpected, actual))
                return;
            Check.HandleFail("Check.AreNotSame", message, parameters);
        }

        [Conditional("DEBUG")]
        public static void AreEqual<T>(T expected, T actual)
        {
            Check.AreEqual<T>(expected, actual, string.Empty, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void AreEqual<T>(T expected, T actual, string message)
        {
            Check.AreEqual<T>(expected, actual, message, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void AreEqual<T>(T expected, T actual, string message, params object[] parameters)
        {
            if (object.Equals((object)expected, (object)actual))
                return;
            Check.HandleFail("Check.AreEqual", (object)actual == null || (object)expected == null || actual.GetType().Equals(expected.GetType()) ? (string)FrameworkMessages.AreEqualFailMsg(message == null ? (object)string.Empty : (object)Check.ReplaceNulls((object)message), (object)Check.ReplaceNulls((object)expected), (object)Check.ReplaceNulls((object)actual)) : (string)FrameworkMessages.AreEqualDifferentTypesFailMsg(message == null ? (object)string.Empty : (object)Check.ReplaceNulls((object)message), (object)Check.ReplaceNulls((object)expected), (object)expected.GetType().FullName, (object)Check.ReplaceNulls((object)actual), (object)actual.GetType().FullName), parameters);
        }

        [Conditional("DEBUG")]
        public static void AreNotEqual<T>(T notExpected, T actual)
        {
            Check.AreNotEqual<T>(notExpected, actual, string.Empty, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void AreNotEqual<T>(T notExpected, T actual, string message)
        {
            Check.AreNotEqual<T>(notExpected, actual, message, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void AreNotEqual<T>(T notExpected, T actual, string message, params object[] parameters)
        {
            if (!object.Equals((object)notExpected, (object)actual))
                return;
            Check.HandleFail("Check.AreNotEqual", (string)FrameworkMessages.AreNotEqualFailMsg(message == null ? (object)string.Empty : (object)Check.ReplaceNulls((object)message), (object)Check.ReplaceNulls((object)notExpected), (object)Check.ReplaceNulls((object)actual)), parameters);
        }

        [Conditional("DEBUG")]
        public static void AreEqual(object expected, object actual)
        {
            Check.AreEqual(expected, actual, string.Empty, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void AreEqual(object expected, object actual, string message)
        {
            Check.AreEqual(expected, actual, message, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void AreEqual(object expected, object actual, string message, params object[] parameters)
        {
            Check.AreEqual<object>(expected, actual, message, parameters);
        }

        [Conditional("DEBUG")]
        public static void AreNotEqual(object notExpected, object actual)
        {
            Check.AreNotEqual(notExpected, actual, string.Empty, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void AreNotEqual(object notExpected, object actual, string message)
        {
            Check.AreNotEqual(notExpected, actual, message, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void AreNotEqual(object notExpected, object actual, string message, params object[] parameters)
        {
            Check.AreNotEqual<object>(notExpected, actual, message, parameters);
        }

        [Conditional("DEBUG")]
        public static void AreEqual(float expected, float actual, float epsilon)
        {
            Check.AreEqual(expected, actual, epsilon, string.Empty, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void AreEqual(float expected, float actual, float epsilon, string message)
        {
            Check.AreEqual(expected, actual, epsilon, message, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void AreEqual(float expected, float actual, float epsilon, string message, params object[] parameters)
        {
            if ((double)Math.Abs(expected - actual) <= (double)epsilon)
                return;
            Check.HandleFail("Check.AreEqual", (string)FrameworkMessages.AreEqualDeltaFailMsg(message == null ? (object)string.Empty : (object)Check.ReplaceNulls((object)message), (object)expected.ToString((IFormatProvider)CultureInfo.CurrentCulture.NumberFormat), (object)actual.ToString((IFormatProvider)CultureInfo.CurrentCulture.NumberFormat), (object)epsilon.ToString((IFormatProvider)CultureInfo.CurrentCulture.NumberFormat)), parameters);
        }

        [Conditional("DEBUG")]
        public static void AreNotEqual(float notExpected, float actual, float epsilon)
        {
            Check.AreNotEqual(notExpected, actual, epsilon, string.Empty, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void AreNotEqual(float notExpected, float actual, float epsilon, string message)
        {
            Check.AreNotEqual(notExpected, actual, epsilon, message, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void AreNotEqual(float notExpected, float actual, float epsilon, string message, params object[] parameters)
        {
            if ((double)Math.Abs(notExpected - actual) > (double)epsilon)
                return;
            Check.HandleFail("Check.AreNotEqual", (string)FrameworkMessages.AreNotEqualDeltaFailMsg(message == null ? (object)string.Empty : (object)Check.ReplaceNulls((object)message), (object)notExpected.ToString((IFormatProvider)CultureInfo.CurrentCulture.NumberFormat), (object)actual.ToString((IFormatProvider)CultureInfo.CurrentCulture.NumberFormat), (object)epsilon.ToString((IFormatProvider)CultureInfo.CurrentCulture.NumberFormat)), parameters);
        }

        [Conditional("DEBUG")]
        public static void AreEqual(double expected, double actual, double epsilon)
        {
            Check.AreEqual(expected, actual, epsilon, string.Empty, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void AreEqual(double expected, double actual, double epsilon, string message)
        {
            Check.AreEqual(expected, actual, epsilon, message, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void AreEqual(double expected, double actual, double epsilon, string message, params object[] parameters)
        {
            if (Math.Abs(expected - actual) <= epsilon)
                return;
            Check.HandleFail("Check.AreEqual", (string)FrameworkMessages.AreEqualDeltaFailMsg(message == null ? (object)string.Empty : (object)Check.ReplaceNulls((object)message), (object)expected.ToString((IFormatProvider)CultureInfo.CurrentCulture.NumberFormat), (object)actual.ToString((IFormatProvider)CultureInfo.CurrentCulture.NumberFormat), (object)epsilon.ToString((IFormatProvider)CultureInfo.CurrentCulture.NumberFormat)), parameters);
        }

        [Conditional("DEBUG")]
        public static void AreNotEqual(double notExpected, double actual, double epsilon)
        {
            Check.AreNotEqual(notExpected, actual, epsilon, string.Empty, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void AreNotEqual(double notExpected, double actual, double epsilon, string message)
        {
            Check.AreNotEqual(notExpected, actual, epsilon, message, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void AreNotEqual(double notExpected, double actual, double epsilon, string message, params object[] parameters)
        {
            if (Math.Abs(notExpected - actual) > epsilon)
                return;
            Check.HandleFail("Check.AreNotEqual", (string)FrameworkMessages.AreNotEqualDeltaFailMsg(message == null ? (object)string.Empty : (object)Check.ReplaceNulls((object)message), (object)notExpected.ToString((IFormatProvider)CultureInfo.CurrentCulture.NumberFormat), (object)actual.ToString((IFormatProvider)CultureInfo.CurrentCulture.NumberFormat), (object)epsilon.ToString((IFormatProvider)CultureInfo.CurrentCulture.NumberFormat)), parameters);
        }

        [Conditional("DEBUG")]
        public static void AreEqual(string expected, string actual, bool ignoreCase)
        {
            Check.AreEqual(expected, actual, ignoreCase, string.Empty, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void AreEqual(string expected, string actual, bool ignoreCase, string message)
        {
            Check.AreEqual(expected, actual, ignoreCase, message, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void AreEqual(string expected, string actual, bool ignoreCase, string message, params object[] parameters)
        {
            Check.AreEqual(expected, actual, ignoreCase, CultureInfo.InvariantCulture, message, parameters);
        }

        [Conditional("DEBUG")]
        public static void AreEqual(string expected, string actual, bool ignoreCase, CultureInfo culture)
        {
            Check.AreEqual(expected, actual, ignoreCase, culture, string.Empty, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void AreEqual(string expected, string actual, bool ignoreCase, CultureInfo culture, string message)
        {
            Check.AreEqual(expected, actual, ignoreCase, culture, message, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void AreEqual(string expected, string actual, bool ignoreCase, CultureInfo culture, string message, params object[] parameters)
        {
            Check.CheckParameterNotNull((object)culture, "Check.AreEqual", "culture", string.Empty, new object[0]);
            if (string.Compare(expected, actual, ignoreCase, culture) == 0)
                return;
            Check.HandleFail("Check.AreEqual", ignoreCase || string.Compare(expected, actual, true, culture) != 0 ? (string)FrameworkMessages.AreEqualFailMsg(message == null ? (object)string.Empty : (object)Check.ReplaceNulls((object)message), (object)Check.ReplaceNulls((object)expected), (object)Check.ReplaceNulls((object)actual)) : (string)FrameworkMessages.AreEqualCaseFailMsg(message == null ? (object)string.Empty : (object)Check.ReplaceNulls((object)message), (object)Check.ReplaceNulls((object)expected), (object)Check.ReplaceNulls((object)actual)), parameters);
        }

        [Conditional("DEBUG")]
        public static void AreNotEqual(string notExpected, string actual, bool ignoreCase)
        {
            Check.AreNotEqual(notExpected, actual, ignoreCase, string.Empty, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void AreNotEqual(string notExpected, string actual, bool ignoreCase, string message)
        {
            Check.AreNotEqual(notExpected, actual, ignoreCase, message, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void AreNotEqual(string notExpected, string actual, bool ignoreCase, string message, params object[] parameters)
        {
            Check.AreNotEqual(notExpected, actual, ignoreCase, CultureInfo.InvariantCulture, message, parameters);
        }

        [Conditional("DEBUG")]
        public static void AreNotEqual(string notExpected, string actual, bool ignoreCase, CultureInfo culture)
        {
            Check.AreNotEqual(notExpected, actual, ignoreCase, culture, string.Empty, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void AreNotEqual(string notExpected, string actual, bool ignoreCase, CultureInfo culture, string message)
        {
            Check.AreNotEqual(notExpected, actual, ignoreCase, culture, message, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void AreNotEqual(string notExpected, string actual, bool ignoreCase, CultureInfo culture, string message, params object[] parameters)
        {
            Check.CheckParameterNotNull((object)culture, "Check.AreNotEqual", "culture", string.Empty, new object[0]);
            if (string.Compare(notExpected, actual, ignoreCase, culture) != 0)
                return;
            Check.HandleFail("Check.AreNotEqual", (string)FrameworkMessages.AreNotEqualFailMsg(message == null ? (object)string.Empty : (object)Check.ReplaceNulls((object)message), (object)Check.ReplaceNulls((object)notExpected), (object)Check.ReplaceNulls((object)actual)), parameters);
        }

        [Conditional("DEBUG")]
        public static void IsInstanceOfType(object value, Type expectedType)
        {
            Check.IsInstanceOfType(value, expectedType, string.Empty, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void IsInstanceOfType(object value, Type expectedType, string message)
        {
            Check.IsInstanceOfType(value, expectedType, message, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void IsInstanceOfType(object value, Type expectedType, string message, params object[] parameters)
        {
            if (expectedType == null)
                Check.HandleFail("Check.IsInstanceOfType", message, parameters);
            if (expectedType.IsInstanceOfType(value))
                return;
            Check.HandleFail("Check.IsInstanceOfType", (string)FrameworkMessages.IsInstanceOfFailMsg(message == null ? (object)string.Empty : (object)Check.ReplaceNulls((object)message), (object)expectedType.ToString(), value == null ? (object)(string)FrameworkMessages.Common_NullInMessages : (object)value.GetType().ToString()), parameters);
        }

        [Conditional("DEBUG")]
        public static void IsNotInstanceOfType(object value, Type wrongType)
        {
            Check.IsNotInstanceOfType(value, wrongType, string.Empty, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void IsNotInstanceOfType(object value, Type wrongType, string message)
        {
            Check.IsNotInstanceOfType(value, wrongType, message, (object[])null);
        }

        [Conditional("DEBUG")]
        public static void IsNotInstanceOfType(object value, Type wrongType, string message, params object[] parameters)
        {
            if (wrongType == null)
                Check.HandleFail("Check.IsNotInstanceOfType", message, parameters);
            if (value == null || !wrongType.IsInstanceOfType(value))
                return;
            Check.HandleFail("Check.IsNotInstanceOfType", (string)FrameworkMessages.IsNotInstanceOfFailMsg(message == null ? (object)string.Empty : (object)Check.ReplaceNulls((object)message), (object)wrongType.ToString(), (object)value.GetType().ToString()), parameters);
        }

        public new static bool Equals(object objA, object objB)
        {
            throw new InvalidOperationException("Do not use Check.Equals");
        }

        internal static void HandleFail(string assertionName, string message, params object[] parameters)
        {
            string str = string.Empty;
            if (!string.IsNullOrEmpty(message))
                str = parameters != null ? string.Format(CultureInfo.CurrentCulture, Check.ReplaceNulls(message), parameters) : Check.ReplaceNulls(message);
            throw new AssertFailedException(string.Format(CultureInfo.CurrentCulture, "{0}: {1}", assertionName, str));
        }

        internal static void CheckParameterNotNull(object param, string assertionName, string parameterName, string message, params object[] parameters)
        {
            if (param != null)
                return;
            Check.HandleFail(assertionName, FrameworkMessages.NullParameterToAssert(parameterName, message), parameters);
        }

        internal static string ReplaceNulls(object input)
        {
            if (input == null)
                return FrameworkMessages.Common_NullInMessages.ToString();
            string input1 = input.ToString();
            if (input1 == null)
                return FrameworkMessages.Common_ObjectString.ToString();
            else
                return Check.ReplaceNullChars(input1);
        }

        public static string ReplaceNullChars(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            List<int> list = new List<int>();
            for (int index = 0; index < input.Length; ++index)
            {
                if ((int)input[index] == 0)
                    list.Add(index);
            }
            if (list.Count <= 0)
                return input;
            StringBuilder stringBuilder = new StringBuilder(input.Length + list.Count);
            int startIndex = 0;
            foreach (int num in list)
            {
                stringBuilder.Append(input.Substring(startIndex, num - startIndex));
                stringBuilder.Append("\\0");
                startIndex = num + 1;
            }
            stringBuilder.Append(input.Substring(startIndex));
            return ((object)stringBuilder).ToString();
        }
    }

    [Serializable]
    public class AssertFailedException : Exception
    {
        public AssertFailedException()
        {
        }

        public AssertFailedException(string msg)
            : base(msg)
        {
        }

        public AssertFailedException(string msg, Exception ex)
            : base(msg, ex)
        {
        }

        protected AssertFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}