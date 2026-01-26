using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;
using System.Collections;
using Boxa;

namespace BoxaRegistration
{
    public class LoadData
    {
        public static void GetValues<T>(DropDownList dList, int[] notToShow, bool showSelect) where T : struct
        {
            SortedList<int, string> list = GetEnumValue.GetEnumDataSource<T>(notToShow, showSelect);
            dList.DataSource = list;
            dList.DataTextField = "Value";
            dList.DataValueField = "Key";
            dList.DataBind();
        }
        public static void LoadPassingYear(DropDownList ddlPassingYear, bool isSelect, string selectString)
        {
            ddlPassingYear.Items.Clear();
            if (isSelect)
                ddlPassingYear.Items.Add(new ListItem("Select Year", "0"));
            BoxaDiamondRegDataContext dataContext = new BoxaDiamondRegDataContext();
            var session = (from s1 in dataContext.PassingYears
                           select s1);
            foreach (var sn in session)
                ddlPassingYear.Items.Add(new ListItem(sn.PassingYearName.ToString(), sn.PassingYearId.ToString()));
            ddlPassingYear.SelectedIndex = 0;
        }
        public static void LoadTshirtSize(DropDownList ddlTshirtSize, bool isSelect, string selectString)
        {
            ddlTshirtSize.Items.Clear();
            if (isSelect)
                ddlTshirtSize.Items.Add(new ListItem("Select T-shirt Size", "0"));
            BoxaDiamondRegDataContext dataContext = new BoxaDiamondRegDataContext();
            var session = (from s1 in dataContext.TshirtSizes
                           select s1);
            foreach (var sn in session)
                ddlTshirtSize.Items.Add(new ListItem(sn.TshirtSizeName, sn.TshirtSizeId.ToString()));
            ddlTshirtSize.SelectedIndex = 0;
        }
        //public static void LoadSubject(DropDownList ddlSubject, bool isSelect, string selectString)
        //{
        //    ddlSubject.Items.Clear();
        //    if (isSelect)
        //        ddlSubject.Items.Add(new ListItem("Select Subject", "0"));
        //    MbdBedCollegeDataContext dataContext = new MbdBedCollegeDataContext();
        //    var session = (from s1 in dataContext.Subjects
        //                   select s1);
        //    foreach (var sn in session)
        //        ddlSubject.Items.Add(new ListItem(sn.SubjectName, sn.SubjectId.ToString()));
        //    ddlSubject.SelectedIndex = 0;
        //}
        //public static void LoadSession(DropDownList ddlSession, bool isSelect, string selectString)
        //{
        //    ddlSession.Items.Clear();
        //    if (isSelect)
        //        ddlSession.Items.Add(new ListItem("Select Session", "0"));
        //    MbdBedCollegeDataContext dataContext = new MbdBedCollegeDataContext();
        //    var session = (from s1 in dataContext.Sessions
        //                   select s1);
        //    foreach (var sn in session)
        //        ddlSession.Items.Add(new ListItem(sn.SessionName, sn.SessionId.ToString()));
        //    ddlSession.SelectedIndex = 0;
        //}
        //public static void LoadDesignation(DropDownList ddlDesignation, bool isSelect, string selectString)
        //{
        //    ddlDesignation.Items.Clear();
        //    if (isSelect)
        //        ddlDesignation.Items.Add(new ListItem("Select Designation", "0"));
        //    MbdBedCollegeDataContext dataContext = new MbdBedCollegeDataContext();
        //    var session = (from s1 in dataContext.Designations
        //                   select s1);
        //    foreach (var sn in session)
        //        ddlDesignation.Items.Add(new ListItem(sn.DesignationTitle, sn.DesignationId.ToString()));
        //    ddlDesignation.SelectedIndex = 0;
        //}
        public static void GetConstantValues(String[] array, DropDownList dList, bool showSelect)
        {
            SortedList<int, string> list = GetConstantValue.GetArrayDataSource(array, showSelect);
            dList.DataSource = list;
            dList.DataTextField = "Value";
            dList.DataValueField = "Key";
            dList.DataBind();
        }

        public static void GetConstantValues(String[] array, DropDownList dList, int[] notToShow, bool showSelect)
        {
            SortedList<int, string> list = GetConstantValue.GetArrayDataSource(array, notToShow, showSelect);
            dList.DataSource = list;
            dList.DataTextField = "Value";
            dList.DataValueField = "Key";
            dList.DataBind();
        }

        public static void GetValuedValues<T>(DropDownList dList, string[] notToShow, bool showSelect) where T : struct
        {
            SortedList<string, string> list = GetEnumValue.GetEnumValuedDataSource<T>(notToShow, showSelect);
            dList.DataSource = list;
            dList.DataTextField = "Value";
            dList.DataValueField = "Key";
            dList.DataBind();
        }



        public static void GetValues<T>(ListBox dList, int[] notToShow, bool showSelect) where T : struct
        {
            SortedList<int, string> list = GetEnumValue.GetEnumDataSource<T>(notToShow, showSelect);
            dList.DataSource = list;
            dList.DataTextField = "Value";
            dList.DataValueField = "Key";
            dList.DataBind();
        }
        public static void GetValues<T>(CheckBoxList dList, int[] notToShow, bool showSelect) where T : struct
        {
            SortedList<int, string> list = GetEnumValue.GetEnumDataSource<T>(notToShow, showSelect);
            dList.DataSource = list;
            dList.DataTextField = "Value";
            dList.DataValueField = "Key";
            dList.DataBind();
        }
        public static void GetValues<T>(RadioButtonList dList, int[] notToShow, bool showSelect) where T : struct
        {
            SortedList<int, string> list = GetEnumValue.GetEnumDataSource<T>(notToShow, showSelect);
            dList.DataSource = list;
            dList.DataTextField = "Value";
            dList.DataValueField = "Key";
            dList.DataBind();
        }
        public static string LoadDate(DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy").Replace('-', '/');
        }
        public static string LoadDateYMD(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }
        public static void LoadTransactionYear(DropDownList ddlYear)
        {
            for (int y = 2013; y <= LoadData.GetDateTime().Year; y++)
                ddlYear.Items.Add(new ListItem(y.ToString(), y.ToString()));
            ddlYear.SelectedValue = LoadData.GetDateTime().Year.ToString();
        }

        public static string LoadMoney(decimal amount)
        {
            return amount.ToString("N");
        }

        //public static void LoadSession(DropDownList ddlSession, bool isSelect, string selectString)
        //{
        //    ddlSession.Items.Clear();
        //    if (isSelect)
        //        ddlSession.Items.Add(new ListItem("Select Session", "0"));
        //    MbdBedCollegeDataContext dataContext = new MbdBedCollegeDataContext();
        //    var session = (from s1 in dataContext.Sessions
        //                   where s1.AllowRegistration == true
        //                   select s1);
        //    foreach (var sn in session)
        //        ddlSession.Items.Add(new ListItem(sn.SessionName, sn.SessionId.ToString()));
        //    ddlSession.SelectedIndex = 0;
        //}
        public static void LoadDate(DropDownList ddlDays, DropDownList ddlMonth, DropDownList ddlYear)
        {
            ddlDays.Items.Clear();
            ListItem lis = new ListItem("Select", "0");
            ddlDays.Items.Add(lis);
            for (int i = 1; i <= 31; i++)
                ddlDays.Items.Add(new ListItem(i.ToString(), i.ToString()));
            ddlDays.SelectedValue = "0";

            ddlMonth.Items.Clear();
            GetValues<Month>(ddlMonth, new int[] { }, true);

            ddlYear.Items.Clear();
            ddlYear.Items.Add(lis);
            for (int i = DateTime.Now.Year + 2; i >= (1940); i--)
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            ddlYear.SelectedValue = "0";
        }
        public static string LoadToday()
        {
            return LoadDate(DateTime.Now);
        }


        public static void LoadDate(DropDownList ddlDays, DropDownList ddlMonth, DropDownList ddlYear, int year, bool isSelectedToday)
        {
            ListItem list = new ListItem("Select", "0");
            ddlDays.Items.Clear();
            ddlDays.Items.Add(list);
            for (int i = 1; i <= 31; i++)
                ddlDays.Items.Add(new ListItem(i.ToString(), i.ToString()));

            ddlMonth.Items.Clear();
            GetValues<Month>(ddlMonth, new int[] { }, true);

            ddlYear.Items.Clear();
            ddlYear.Items.Add(list);
            for (int i = DateTime.Now.Year; i >= DateTime.Now.Year - year; i--)
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));

            if (isSelectedToday)
            {
                ddlDays.SelectedValue = DateTime.Now.Day.ToString();
                ddlMonth.SelectedValue = DateTime.Now.Month.ToString();
                ddlYear.SelectedValue = DateTime.Now.Year.ToString();
            }
            else
            {
                ddlDays.SelectedValue = "0";
                ddlMonth.SelectedValue = "0";
                ddlYear.SelectedValue = "0";
            }
        }


        public static DateTime CheckDate(DropDownList ddlDay, DropDownList ddlMonth, DropDownList ddlYear)
        {
            string sdoj = ddlMonth.SelectedValue.Trim() + "/" + ddlDay.SelectedValue.Trim() + "/" + ddlYear.SelectedValue.Trim();
            DateTime doj;
            if (!DateTime.TryParse(sdoj, out doj))
                throw new ArgumentException("Invalid Date Format.");
            return doj;
        }
        public static decimal CheckMoney(string amount)
        {
            decimal dc;
            if (!decimal.TryParse(amount, out dc))
                throw new ArgumentException("Invalid Format of Amount."); ;
            return dc;
        }
        public static decimal CheckMoney(string amount, string errMsg)
        {
            decimal dc;
            if (!decimal.TryParse(amount, out dc))
                throw new ArgumentException(errMsg);
            return dc;
        }
        public static int CheckInt(string n, string errMsg)
        {
            int dc;
            if (!int.TryParse(n, out dc))
                throw new ArgumentException(errMsg);
            return dc;
        }
        public static string GeneratePassword(int size)
        {
            Random rdm = new Random();
            int n = rdm.Next();
            string pass = n.ToString();
            pass = pass.Substring(0, size);
            return pass;
        }

        //public static string GenerateEncryptedPassword(int size)
        //{
        //    string password = CryptoEngine.Encrypt(GeneratePassword(size));
        //    return password;
        //}
        public static DateTime CheckDate(string date, string errMsg)
        {
            DateTime parsed;
            if (!DateTime.TryParseExact(date, "dd'/'MM'/'yyyy",
                CultureInfo.CurrentCulture, DateTimeStyles.None, out parsed))
                throw new ArgumentException(errMsg);
            return parsed;
        }

        public static DateTime CheckDateYMD(string date, string errMsg)
        {
            DateTime parsed;
            if (!DateTime.TryParseExact(date, "yyyy'-'MM'-'dd",
                CultureInfo.CurrentCulture, DateTimeStyles.None, out parsed))
                throw new ArgumentException(errMsg);
            return parsed;
        }


        /// Loads Date of Birth
        /// </summary>
        /// <param name="ddlDays">Day</param>
        /// <param name="ddlMonth">Month</param>
        /// <param name="ddlYear">Year</param>
        public static void LoadDateOfBirth(DropDownList ddlDays, DropDownList ddlMonth, DropDownList ddlYear)
        {
            ddlDays.Items.Clear();
            ListItem lis = new ListItem("Select", "0");
            ddlDays.Items.Add(lis);
            for (int i = 1; i <= 31; i++)
            {
                ddlDays.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            ddlDays.SelectedValue = "0";

            ddlMonth.Items.Clear();
            GetValues<Month>(ddlMonth, new int[] { }, true);

            ddlYear.Items.Clear();
            ddlYear.Items.Add(lis);
            for (int i = DateTime.Now.Year - 2; i >= (DateTime.Now.Year - 70); i--)
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            ddlYear.SelectedValue = "0";
        }

        /// <summary>
        /// Loads Today
        /// </summary>
        /// <param name="ddlDays">Day</param>
        /// <param name="ddlMonth">Month</param>
        /// <param name="ddlYear">Year</param>
        public static void LoadTodayTenYear(DropDownList ddlDays, DropDownList ddlMonth, DropDownList ddlYear)
        {
            ddlDays.Items.Clear();
            ListItem li = new ListItem("Select", "0");
            ddlDays.Items.Add(li);
            for (int i = 1; i <= 31; i++)
                ddlDays.Items.Add(new ListItem(i.ToString(), i.ToString()));
            ddlDays.SelectedValue = DateTime.Now.Day.ToString();

            ddlMonth.Items.Clear();
            GetValues<Month>(ddlMonth, new int[] { }, true);
            ddlMonth.SelectedValue = DateTime.Now.Month.ToString();

            ddlYear.Items.Clear();
            ddlYear.Items.Add(li);
            for (int i = DateTime.Now.Year - 10; i <= DateTime.Now.Year; i++)
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            ddlYear.SelectedValue = DateTime.Now.Year.ToString();
        }

        /// <summary>
        /// Loads Today
        /// </summary>
        /// <param name="ddlDays">Day</param>
        /// <param name="ddlMonth">Month</param>
        /// <param name="ddlYear">Year</param>
        public static void LoadJoiningDate(DropDownList ddlDays, DropDownList ddlMonth, DropDownList ddlYear)
        {
            ddlDays.Items.Clear();
            SortedList yearList = new SortedList();
            ListItem li = new ListItem();
            for (int i = 1; i <= 31; i++)
                ddlDays.Items.Add(new ListItem(i.ToString(), i.ToString()));
            ddlDays.SelectedValue = DateTime.Now.Day.ToString();

            ddlMonth.Items.Clear();
            GetValues<Month>(ddlMonth, new int[] { }, false);
            ddlMonth.SelectedValue = DateTime.Now.Month.ToString();

            ddlYear.Items.Clear();
            for (int i = DateTime.Now.Year - 10; i <= DateTime.Now.Year; i++)
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            ddlYear.SelectedValue = DateTime.Now.Year.ToString();
        }

        public static string GetFileName(string filename)
        {
            return filename.Substring(0, filename.LastIndexOf('.')).ToString();
        }

        public static DateTime GetDateTime()
        {
            DateTime currentDate = DateTime.Now;
            currentDate = currentDate.AddMinutes(328);
            return currentDate;
        }

        /// <summary>
        /// Calculate Compund Interest
        /// </summary>
        /// <param name="principal">Principal Amount</param>
        /// <param name="interestRate">Rate of Interest</param>
        /// <param name="timeInYear">Time</param>
        /// <returns>Compound Interest</returns>
        public static double CompoundInterest(double principal, double interestRate, double timeInYear)
        {
            double amount;
            amount = (principal * Math.Pow((1 + (interestRate / 100)), timeInYear)) - principal;
            return amount;
        }

        public static double RDCompoundInterest(double principal, double interest, double timeInYear)
        {
            double amountInAYear = principal * 12;
            double simpleInterest, total = amountInAYear;
            for (int i = 1; i <= timeInYear; i++)
            {
                simpleInterest = (total * interest) / 100;
                total += simpleInterest + amountInAYear;
            }
            return total - amountInAYear;
        }
        public static string GenerateRandomString(int length)
        {
            //It will generate string with combination of small,capital letters and numbers
            char[] charArr = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".ToCharArray();
            string randomString = string.Empty;
            Random objRandom = new Random();
            for (int i = 0; i < length; i++)
            {
                //Don't Allow Repetation of Characters
                int x = objRandom.Next(1, charArr.Length);
                if (!randomString.Contains(charArr.GetValue(x).ToString()))
                    randomString += charArr.GetValue(x);
                else
                    i--;
            }
            return randomString;
        }

        public static void ResetFields(System.Web.UI.Control parent)
        {
            foreach (System.Web.UI.Control x in parent.Controls)
            {
                if ((x.GetType() == typeof(TextBox)))
                    ((TextBox)(x)).Text = "";
                else if ((x.GetType() == typeof(DropDownList)))
                    ((DropDownList)(x)).SelectedIndex = 0;
                if (x.HasControls())
                    ResetFields(x);
            }
        }
        public static string GenerateImageName(string name, string extension)
        {
            name = GenerateSeoUrl(name);
            if (name.Length > 40)
                name = name.Substring(0, 40);
            return name + extension;
        }
        public static string GenerateSeoUrl(string strTitle)
        {
            #region Generate SEO Friendly URL based on Title
            //Trim Start and End Spaces.
            //string  = productName + " " + subtitle + " " + productCode;
            strTitle = strTitle.Trim();

            //Trim "-" Hyphen
            strTitle = strTitle.Trim('-');

            strTitle = strTitle.ToLower();
            char[] chars = @"$%#@!*?;:~`+=()[]{}|\'<>,/^&"".".ToCharArray();
            strTitle = strTitle.Replace("c#", "C-Sharp");
            strTitle = strTitle.Replace("vb.net", "VB-Net");
            strTitle = strTitle.Replace("asp.net", "Asp-Net");

            //Replace . with - hyphen
            strTitle = strTitle.Replace(".", "-");

            //Replace Special-Characters
            for (int i = 0; i < chars.Length; i++)
            {
                string strChar = chars.GetValue(i).ToString();
                if (strTitle.Contains(strChar))
                {
                    strTitle = strTitle.Replace(strChar, string.Empty);
                }
            }

            //Replace all spaces with one "-" hyphen
            strTitle = strTitle.Replace(" ", "-");

            //Replace multiple "-" hyphen with single "-" hyphen.
            strTitle = strTitle.Replace("--", "-");
            strTitle = strTitle.Replace("---", "-");
            strTitle = strTitle.Replace("----", "-");
            strTitle = strTitle.Replace("-----", "-");
            strTitle = strTitle.Replace("----", "-");
            strTitle = strTitle.Replace("---", "-");
            strTitle = strTitle.Replace("--", "-");

            //Run the code again...
            //Trim Start and End Spaces.
            strTitle = strTitle.Trim();

            //Trim "-" Hyphen
            strTitle = strTitle.Trim('-');
            #endregion

            //Append ID at the end of SEO Friendly URL            
            //if (strTitle.Length > 50)
            //    strTitle = strTitle.Substring(0, 50);
            return strTitle;
        }




        public static string GetSizeId(int lastId, int size)
        {
            string empCode = lastId.ToString();
            while (empCode.Length < size)
                empCode = "0" + empCode;
            return empCode;
        }

        public static void OpenPopup(System.Web.UI.Page page, string url)
        {
            string queryString = queryString = "print-maturity-list.aspx";
            string jquery = "window.open('" + url + "');";
            System.Web.UI.ScriptManager.RegisterStartupScript(page, page.GetType(), "pop", jquery, true);
        }
        //public static void LoadWard(DropDownList ddlWard)
        //{
        //    ddlWard.Items.Clear();
        //    ddlWard.Items.Add(new ListItem("Select Ward", "0"));
        //    MbdBedCollegeDataContext datacontext = new MbdBedCollegeDataContext();
        //    var wardNo = (from w1 in datacontext.Wards
        //                  select w1);
        //    foreach (var w in wardNo)
        //        ddlWard.Items.Add(new ListItem(w.WardName, w.WardId.ToString()));
        //    ddlWard.SelectedIndex = 0;
        //}
    }

}