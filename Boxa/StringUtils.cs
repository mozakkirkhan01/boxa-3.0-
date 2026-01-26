using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Boxa
{
    public class StringUtils
    {
        /// <summary>
        /// Tries to create a phrase string from CamelCase text.
        /// Will place spaces before capitalized letters.
        /// 
        /// Note that this method may not work for round tripping 
        /// ToCamelCase calls, since ToCamelCase strips more characters
        /// than just spaces.
        /// </summary>
        /// <param name="camelCase"></param>
        /// <returns></returns>
        public static string FromCamelCase(string camelCase)
        {
            if (camelCase == null)
                throw new ArgumentException("Null is not allowed for StringUtils.FromCamelCase");

            StringBuilder sb = new StringBuilder(camelCase.Length + 10);
            bool first = true;
            char lastChar = '\0';

            foreach (char ch in camelCase)
            {
                if (!first &&
                     (char.IsUpper(ch) ||
                       char.IsDigit(ch) && !char.IsDigit(lastChar)))
                    sb.Append(' ');

                sb.Append(ch);
                first = false;
                lastChar = ch;
            }

            return sb.ToString(); ;
        }
        /// <summary>
        /// Takes a phrase and turns it into CamelCase text.
        /// White Space, punctuation and separators are stripped
        /// </summary>
        /// <param name="phrase"></param>
        /// <returns></returns>
        public static string ToCamelCase(string phrase)
        {
            if (phrase == null)
                return string.Empty;

            StringBuilder sb = new StringBuilder(phrase.Length);

            // First letter is always upper case
            bool nextUpper = true;

            foreach (char ch in phrase)
            {
                if (char.IsWhiteSpace(ch) || char.IsPunctuation(ch) || char.IsSeparator(ch))
                {
                    nextUpper = true;
                    continue;
                }

                if (nextUpper)
                    sb.Append(char.ToUpper(ch));
                else
                    sb.Append(char.ToLower(ch));

                nextUpper = false;
            }

            return sb.ToString();
        }

        /// <summary>
        /// Takes a phrase and turns it into CamelCase text.
        /// White Space, punctuation and separators are not stripped
        /// </summary>
        /// <param name="phrase"></param>
        /// <returns></returns>
        public static string ToCamelCaseWithSpace(string phrase)
        {
            if (phrase == null)
                return string.Empty;

            StringBuilder sb = new StringBuilder(phrase.Length);

            // First letter is always upper case
            bool nextUpper = true;

            foreach (char ch in phrase)
            {
                if (char.IsWhiteSpace(ch) || char.IsPunctuation(ch) || char.IsSeparator(ch))
                {
                    nextUpper = true;
                    sb.Append(ch);
                    continue;
                }

                if (nextUpper)
                    sb.Append(char.ToUpper(ch));
                else
                    sb.Append(char.ToLower(ch));

                nextUpper = false;
            }

            return sb.ToString();
        }
        public static string ConvertListToXml<T>(List<T> listOfValues)
        {
            if (listOfValues != null && listOfValues.Count != 0)
            {
                StringBuilder xmlValue = new StringBuilder();
                XmlWriterSettings setting = new XmlWriterSettings();
                setting.ConformanceLevel = ConformanceLevel.Fragment;
                XmlWriter xmlWriter = XmlTextWriter.Create(xmlValue, setting);
                xmlWriter.WriteStartElement("r"); //Root Element
                foreach (T val in listOfValues)
                {
                    xmlWriter.WriteStartElement("v"); //Value Element
                    xmlWriter.WriteString((Convert.ToInt32(val)).ToString()); //Inner Text
                    xmlWriter.WriteEndElement(); //End of Value Element
                }
                xmlWriter.WriteEndElement(); //End of Root Element
                xmlWriter.Flush();
                xmlWriter.Close();
                return xmlValue.ToString();
            }
            else
            {
                return null;
            }
        }
        public static List<int> ConvertXmlToIntList(string xmlValue)
        {
            List<int> listOfValues = new List<int>();
            // Create an instance of XmlTextReader and call Read method to read the string
            if (xmlValue != null)
            {
                XmlTextReader textReader = new XmlTextReader(xmlValue, XmlNodeType.Document, null);
                textReader.Read();
                // If the node has value
                while (textReader.Read())
                    if (textReader.NodeType == XmlNodeType.Text)
                        try
                        {
                            listOfValues.Add(Int32.Parse(textReader.Value));
                        }
                        catch (Exception)
                        {
                            //Audit.Add(EventType.StringUtility, Severity.High, "0", "Could Not Convert Value " + textReader.Value + " To Int; Error - " + Ex.Message, null);
                        }
            }
            return listOfValues;
        }
        public static List<byte> ConvertXmlToByteList(string xmlValue)
        {
            List<byte> listOfValues = new List<byte>();
            // Create an instance of XmlTextReader and call Read method to read the string
            if (xmlValue != null)
            {
                XmlTextReader textReader = new XmlTextReader(xmlValue, XmlNodeType.Document, null);
                textReader.Read();
                // If the node has value
                while (textReader.Read())
                    if (textReader.NodeType == XmlNodeType.Text)
                        try
                        {
                            listOfValues.Add(byte.Parse(textReader.Value));
                        }
                        catch (Exception)
                        {
                            //Audit.Add(EventType.StringUtility, Severity.High, "0", "Could Not Convert Value " + textReader.Value + " To byte; Error - " + Ex.Message, null);
                        }
            }
            return listOfValues;
        }
        public static List<T> ConvertXmlToList<T>(string xmlValue)
        {
            List<T> listOfValues = new List<T>();
            // Create an instance of XmlTextReader and call Read method to read the string
            if (xmlValue != null)
            {
                XmlTextReader textReader = new XmlTextReader(xmlValue, XmlNodeType.Document, null);
                textReader.Read();
                // If the node has value
                while (textReader.Read())
                    if (textReader.NodeType == XmlNodeType.Text)
                        try
                        {
                            listOfValues.Add((T)Enum.Parse(typeof(T), textReader.Value));
                        }
                        catch (Exception)
                        {
                            //Audit.Add(EventType.StringUtility, Severity.High, "0", "Could Not Convert Value " + textReader.Value + " To Type " + typeof(T).ToString() + "; Error - " + Ex.Message, null);
                        }
            }
            return listOfValues;
        }
        public static SqlParameter GenerateXmlParameter(string parameterName, string xmlValue)
        {
            SqlParameter retVal = new SqlParameter(parameterName, SqlDbType.Xml);
            if (xmlValue != null)
                retVal.Value = new SqlXml(new XmlTextReader(xmlValue, XmlNodeType.Document, null));

            return retVal;
        }
        public static T GetDataReaderValue<T>(SqlDataReader reader, string columnName)
        {
            T value;
            try
            {
                value = (reader[columnName] != DBNull.Value ? (T)reader[columnName] : default(T));
            }
            catch (IndexOutOfRangeException)
            {
                value = default(T);
            }
            return value;
        }
        public static Decimal GetDataReaderDecimalValue<T>(SqlDataReader reader, string columnName)
        {
            Decimal value;
            try
            {
                value = (reader[columnName] != DBNull.Value ? Convert.ToDecimal(reader[columnName]) : default(Decimal));
            }
            catch (IndexOutOfRangeException)
            {
                value = default(Decimal);
            }
            return value;
        }
        public static string GetTrimmedValue(string baseValue)
        {
            if (baseValue != null)
            {
                string retVal = baseValue.Trim();
                if (retVal.Length == 0)
                {
                    return null;
                }
                else
                {
                    return retVal;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
