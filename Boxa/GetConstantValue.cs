using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxa
{
    public class GetConstantValue
    {
        public static SortedList<int, string> GetArrayDataSource(string[] array)
        {
            return GetArrayDataSource(array, true);
        }
        public static SortedList<int, string> GetArrayDataSource(string[] array, int[] notToShow)
        {
            return GetArrayDataSource(array, notToShow, true);
        }

        public static SortedList<int, string> GetArrayDataSource(string[] array, int[] notToShow, bool startStringRequired)
        {
            SortedList<int, string> returnCollection = new SortedList<int, string>();

            Array myArrayType = array.ToArray();
            for (int i = 0; i < myArrayType.Length; i++)
            {
                returnCollection.Add(i, myArrayType.GetValue(i).ToString());
            }

            if (notToShow != null && notToShow.Length != 0)
            {
                foreach (int toremove in notToShow)
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

        public static SortedList<int, string> GetArrayDataSource(string[] array, bool startStringRequired)
        {
            SortedList<int, string> returnCollection = new SortedList<int, string>();

            Array myArrayType = array.ToArray();
            for (int i = 0; i < myArrayType.Length; i++)
            {
                returnCollection.Add(i, myArrayType.GetValue(i).ToString());
            }

            if (startStringRequired && !returnCollection.ContainsKey(0))
            {
                returnCollection.Add(0, "Select");
            }
            return returnCollection;
        }

    }
}
