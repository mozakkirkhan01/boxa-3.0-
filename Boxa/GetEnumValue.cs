using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxa
{
    public class GetEnumValue
    {
        public static SortedList<int, string> GetEnumDataSource<T>(int[] skip) where T : struct
        {
            return GetEnumDataSource<T>(skip, false);
        }
        public static SortedList<int, string> GetEnumDataSource<T>(int[] skip, bool startStringRequired) where T : struct
        {
            Type myEnumType = typeof(T);
            if (myEnumType.BaseType != typeof(Enum))
            {
                throw new ArgumentException("Type T must inherit from System.Enum.");
            }

            SortedList<int, string> returnCollection = new SortedList<int, string>();
            Array enumVals = Enum.GetValues(myEnumType);
            for (int i = 0; i < enumVals.Length; i++)
            {
                returnCollection.Add((int)enumVals.GetValue(i), StringUtils.FromCamelCase((Enum.Parse(myEnumType, enumVals.GetValue(i).ToString())).ToString()));
            }
            if (skip != null && skip.Length != 0)
            {
                foreach (int toremove in skip)
                {
                    returnCollection.Remove(toremove);
                }
            }
            if (startStringRequired && !returnCollection.ContainsKey(0))
            {
                returnCollection.Add(0, "Select");
            }
            return returnCollection;
        }

        public static SortedList<string, string> GetEnumValuedDataSource<T>(string[] skip, bool startStringRequired) where T : struct
        {
            Type myEnumType = typeof(T);
            if (myEnumType.BaseType != typeof(Enum))
            {
                throw new ArgumentException("Type T must inherit from System.Enum.");
            }

            SortedList<string, string> returnCollection = new SortedList<string, string>();
            Array enumVals = Enum.GetValues(myEnumType);
            for (int i = 0; i < enumVals.Length; i++)
            {
                returnCollection.Add(StringUtils.FromCamelCase((Enum.Parse(myEnumType, enumVals.GetValue(i).ToString())).ToString()), StringUtils.FromCamelCase((Enum.Parse(myEnumType, enumVals.GetValue(i).ToString())).ToString()));
            }
            if (skip != null && skip.Length != 0)
            {
                foreach (string toremove in skip)
                {
                    returnCollection.Remove(toremove);
                }
            }
            if (startStringRequired && !returnCollection.ContainsValue("Select"))
            {
                returnCollection.Add("0", "Select");
            }
            return returnCollection;
        }

        public static SortedList<int, string> GetEnumDataSourceForParticular<T>(int[] values) where T : struct
        {
            return GetEnumDataSourceForParticular<T>(values, false);
        }
        public static SortedList<int, string> GetEnumDataSourceForParticular<T>(int[] values, bool startStringRequired) where T : struct
        {
            Type myEnumType = typeof(T);
            if (myEnumType.BaseType != typeof(Enum))
            {
                throw new ArgumentException("Type T must inherit from System.Enum.");
            }

            SortedList<int, string> returnCollection = new SortedList<int, string>();
            if (values != null && values.Length != 0)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    returnCollection.Add(values[i], StringUtils.FromCamelCase((Enum.Parse(myEnumType, values[i].ToString())).ToString()));
                }
            }
            if (startStringRequired && !returnCollection.ContainsKey(0))
            {
                returnCollection.Add(0, "Select");
            }
            return returnCollection;
        }
        public static bool EnumIsDefined(Type enumType, object value)
        {
            Int32 temp;
            if (value.GetType() == typeof(SByte) ||
                value.GetType() == typeof(Int16) ||
                value.GetType() == typeof(Int32) ||
                value.GetType() == typeof(Int64) ||
                value.GetType() == typeof(Byte) ||
                value.GetType() == typeof(UInt16) ||
                value.GetType() == typeof(UInt32) ||
                value.GetType() == typeof(UInt64))
                return Enum.IsDefined(enumType, value);
            if (value.GetType() == typeof(String))
            {
                return (Enum.IsDefined(enumType, value) || (Int32.TryParse((string)value, out temp) && Enum.IsDefined(enumType, temp)));
            }
            return false;
        }

        public static SortedList<int, string> GetEnumDictionary<T>(int[] skip, bool startStringRequired) where T : struct
        {
            Type myEnumType = typeof(T);
            if (myEnumType.BaseType != typeof(Enum))
            {
                throw new ArgumentException("Type T must inherit from System.Enum.");
            }

            SortedList<int, string> returnCollection = new SortedList<int, string>();
            Array enumVals = Enum.GetValues(myEnumType);

            for (int i = 0; i < enumVals.Length; i++)
            {
                returnCollection.Add(Convert.ToInt32(enumVals.GetValue(i)), StringUtils.FromCamelCase(enumVals.GetValue(i).ToString()));
            }
            if (skip != null && skip.Length != 0)
            {
                foreach (int toremove in skip)
                {
                    returnCollection.Remove(toremove);
                }
            }
            if (startStringRequired && !returnCollection.ContainsKey(0))
            {
                returnCollection.Add(0, "Select");
            }
            return returnCollection;
        }
    }
}
