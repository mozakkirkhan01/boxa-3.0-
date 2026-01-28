using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using Boxa;
using System.IO;
using System.Drawing;
using Newtonsoft.Json;
namespace BoxaRegistration
{
    public partial class _default : System.Web.UI.Page
    {


        Encryption enc = new Encryption();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData.GetValues<Gender>(ddlGender, new int[] { }, true);
                LoadData.GetValues<Relation>(ddlRelation, new int[] { }, true);
                LoadData.LoadPassingYear(ddlYearPassing, true, "Select Year");
                LoadData.LoadTshirtSize(ddlTshirtSize, true, "Select T-shirt Size");
                txtTotalAmount.Text = "3";
            }
                RestoreMemberTable();

        }
        public class MemberRegModel
        {
            public string FullName { get; set; }
            public string Mobile { get; set; }
            public string Email { get; set; }
            public int Gender { get; set; }
            public int YearPassing { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public string Profession { get; set; }
            public string Organization { get; set; }
            public int TshirtSize { get; set; }
            public decimal TotalAmount { get; set; }
            public string PhotoBase64 { get; set; }
            public string ClientTxnId { get; set; }
        }

        public class MemberDetailModel
        {
            public byte RelationType { get; set; }
            public string Name { get; set; }
            public decimal Amount { get; set; }
        }
        public static string GenerateRegNo()
        {
            Random rnd = new Random();
            return rnd.Next(100000, 999999).ToString();
        }
        private int SavePendingRegistration(string clientTxnId)
        {
            using (BoxaDiamondRegDataContext db = new BoxaDiamondRegDataContext())
            {
                MemberReg memberReg = new MemberReg
                {
                    MemberRegNo = GenerateRegNo(),
                    MemberFullName = txtFullName.Text.Trim(),
                    MobileNo = txtMobileNo.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Gender = Convert.ToByte(ddlGender.SelectedValue),
                    YearofPassing = Convert.ToInt32(ddlYearPassing.SelectedValue),
                    City = txtCity.Text.Trim(),
                    State = txtState.Text.Trim(),
                    Country = txtCountry.Text.Trim(),
                    CurrentProfession = txtProfession.Text.Trim(),
                    OrganizationName = txtOrg.Text.Trim(),
                    TshirtSize = Convert.ToByte(ddlTshirtSize.SelectedValue),
                    TotalAmountPaid = Convert.ToDecimal(txtTotalAmount.Text),
                    RegistrationDate = DateTime.Now
                };

                db.MemberRegs.InsertOnSubmit(memberReg);
                db.SubmitChanges();

                int memberRegId = memberReg.MemberRegId;

                // Save Members
                var members = JsonConvert.DeserializeObject<List<MemberDetailModel>>(hfMemberData.Value ?? "[]");

                foreach (var m in members)
                {
                    db.MemberDetails.InsertOnSubmit(new MemberDetail
                    {
                        MemberRegId = memberRegId,
                        RelationType = m.RelationType,
                        Name = m.Name,
                        Amount = m.Amount
                    });
                }

                db.SubmitChanges();

                return memberRegId;
            }
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                // Generate unique transaction ID
                string clientTxnId = enc.randomTxnId();

                // 1️⃣ Save Registration with PENDING status
                MemberReg reg = new MemberReg
                {
                    MemberFullName = txtFullName.Text.Trim(),
                    MemberRegNo = GenerateRegNo(),
                    MobileNo = txtMobileNo.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Gender = Convert.ToByte(ddlGender.SelectedValue),
                    YearofPassing = Convert.ToInt32(ddlYearPassing.SelectedValue),
                    City = txtCity.Text.Trim(),
                    State = txtState.Text.Trim(),
                    Country = txtCountry.Text.Trim(),
                    CurrentProfession = txtProfession.Text.Trim(),
                    OrganizationName = txtOrg.Text.Trim(),
                    TshirtSize = Convert.ToByte(ddlTshirtSize.SelectedValue),
                    TotalAmountPaid = 3, // base amount, members will be added next
                    ClientTxnId = clientTxnId,
                    PaymentStatus = "PENDING",
                    RegistrationDate = DateTime.Now
                };

                using (BoxaDiamondRegDataContext db = new BoxaDiamondRegDataContext())
                {
                    db.MemberRegs.InsertOnSubmit(reg);
                    db.SubmitChanges();
                }

                // 2️⃣ Save member details (children/spouse) if any
                List<MemberDetailModel> members =
                    string.IsNullOrEmpty(hfMemberData.Value)
                    ? new List<MemberDetailModel>()
                    : Newtonsoft.Json.JsonConvert.DeserializeObject<List<MemberDetailModel>>(hfMemberData.Value);

                using (BoxaDiamondRegDataContext db = new BoxaDiamondRegDataContext())
                {
                    foreach (var m in members)
                    {
                        MemberDetail detail = new MemberDetail
                        {
                            MemberRegId = reg.MemberRegId,
                            Name = m.Name,
                            RelationType = m.RelationType,
                            Amount = GetMemberAmount(m.RelationType)
                        };
                        db.MemberDetails.InsertOnSubmit(detail);

                        reg.TotalAmountPaid += detail.Amount; // update total
                    }
                    db.SubmitChanges();
                }

                // 3️⃣ Redirect to payment gateway
                int payableAmount = Convert.ToInt32(reg.TotalAmountPaid);

                //string clientCode = "BOKA94";
                //string transUserName = "officialboxabokaro@gmail.com";
                //string transUserPassword = "BOKA94_SP24989";
                //string authKey = "DaC+Y5IqSXn6znxzmO/3yQ+OyRzEM136lYHpPkfvfCc=";
                //string authIV = "Cw/YZyY+Xl9RovVn1Rh1fcxyPOyzaLMLdUaqZ/LA+CrCQsSKQ79N1ifb/t1MxA5e";

                string clientCode = "DJ020";
                string transUserName = "DJL754@sp";
                string transUserPassword = "4q3qhgmJNM4m";
                string authKey = "ISTrmmDC2bTvkxzlDRrVguVwetGS8xC/UFPsp6w+Itg=";
                string authIV = "M+aUFgRMPq7ci+Cmoytp3KJ2GPBOwO72Z2Cjbr55zY7++pT9mLES2M5cIblnBtaX";

                string query =
                    "payerName=" + reg.MemberFullName +
                    "&payerEmail=" + reg.Email +
                    "&payerMobile=" + reg.MobileNo +
                    "&clientCode=" + clientCode +
                    "&transUserName=" + transUserName +
                    "&transUserPassword=" + transUserPassword +
                    "&payerAddress=" + reg.City +
                    "&clientTxnId=" + clientTxnId +
                    "&amount=" + payableAmount +
                    "&amountType=INR" +
                    "&channelId=W" +
                    "&mcc=8795" +
                    "&callbackUrl=http://localhost:18997/payment-response";

                string encdata = enc.EncryptString(authKey, authIV, query);

                string html = $@"
        <html>
        <body onload='document.forms[0].submit();'>
            <form method='post' action='https://stage-securepay.sabpaisa.in/SabPaisa/sabPaisaInit?v=1'>
                <input type='hidden' name='encData' value='{encdata}' />
                <input type='hidden' name='clientCode' value='{clientCode}' />
            </form>
        </body>
        </html>";

                Response.Clear();
                Response.Write(html);
                Response.End();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        public static byte[] ImageToByte(System.Drawing.Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            lblPHotoMsg.Text = "";
            imgPhotoSuccessError.ImageUrl = "";

            // 1️⃣ Check if file selected
            if (!fuMemberPhoto.HasFile)
            {
                lblPHotoMsg.Text = "Please select an image first.";
                lblPHotoMsg.ForeColor = System.Drawing.Color.Red;
                imgPhotoSuccessError.ImageUrl = "~/images/error.png";
                return;
            }

            // 2️⃣ Check file size (50 KB = 51200 bytes)
            if (fuMemberPhoto.PostedFile.ContentLength > 51200)
            {
                lblPHotoMsg.Text = "Image size must be 50 KB or less.";
                lblPHotoMsg.ForeColor = System.Drawing.Color.Red;
                imgPhotoSuccessError.ImageUrl = "~/images/error.png";
                return;
            }

            // 3️⃣ Check file extension
            string extension = Path.GetExtension(fuMemberPhoto.FileName).ToLower();
            if (extension != ".jpg" && extension != ".jpeg" && extension != ".png")
            {
                lblPHotoMsg.Text = "Only JPG, JPEG or PNG images allowed.";
                lblPHotoMsg.ForeColor = System.Drawing.Color.Red;
                imgPhotoSuccessError.ImageUrl = "~/images/error.png";
                return;
            }

            // 4️⃣ Upload image
            byte[] imageBytes = fuMemberPhoto.FileBytes;
            string base64 = Convert.ToBase64String(imageBytes);

            imgPhoto.ImageUrl = "data:image/png;base64," + base64;

            Session["Photo"] = base64;

            lblPHotoMsg.Text = "Photo uploaded successfully!";
            lblPHotoMsg.ForeColor = System.Drawing.Color.Green;
            imgPhotoSuccessError.ImageUrl = "~/images/success.png";
        }



        protected void ddlRelation_SelectedIndexChanged(object sender, EventArgs e)
        {
            int relationType = Convert.ToInt32(ddlRelation.SelectedValue);
            txtAmount.Text = GetMemberAmount(relationType).ToString();
            // Restore members so table doesn’t disappear
            RestoreMemberTable();
        }
        private decimal GetMemberAmount(int relationType)
        {
            switch (relationType)
            {
                case 1: return 2;
                case 2: return 0;
                default: return 0;
            }
        }

        protected void btnAddMember_Click(object sender, EventArgs e)
        {
            // Get existing members from hidden field
            List<MemberDetailModel> members = string.IsNullOrEmpty(hfMemberData.Value)
                ? new List<MemberDetailModel>()
                : Newtonsoft.Json.JsonConvert.DeserializeObject<List<MemberDetailModel>>(hfMemberData.Value);

            int relationType = Convert.ToInt32(ddlRelation.SelectedValue); // 1=Spouse, 2=Child
            string name = txtMemberName.Text.Trim();

            if (relationType == 0 || string.IsNullOrEmpty(name))
            {
                lblMsg.Text = "Please select relation and enter name.";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Calculate amount based on relation
            decimal amount = GetMemberAmount(relationType);

            // Optional: show amount in txtAmount
            txtAmount.Text = amount.ToString();

            // Create member object
            MemberDetailModel member = new MemberDetailModel
            {
                RelationType = Convert.ToByte(relationType),
                Name = name,
                Amount = amount
            };

            members.Add(member);

            // Update hidden field JSON
            hfMemberData.Value = Newtonsoft.Json.JsonConvert.SerializeObject(members);

            // Update total amount
            decimal baseAmount = 3;
            decimal totalAmount = baseAmount + members.Sum(m => m.Amount);
            txtTotalAmount.Text = totalAmount.ToString();

            // Render member table
            RenderMemberTable(members);

            // Clear form fields
            ddlRelation.SelectedValue = "0";
            txtMemberName.Text = "";
            txtAmount.Text = ""; // clear amount
        }
        private void RenderMemberTable(List<MemberDetailModel> members)
        {
            memberTableBody.Controls.Clear(); // tbody runat="server"

            for (int i = 0; i < members.Count; i++)
            {
                var m = members[i];
                TableRow tr = new TableRow();

                tr.Cells.Add(new TableCell { Text = (i + 1).ToString() });
                tr.Cells.Add(new TableCell { Text = m.RelationType == 1 ? "Spouse" : "Child" });
                tr.Cells.Add(new TableCell { Text = m.Name });
                tr.Cells.Add(new TableCell { Text = m.Amount.ToString() });

                Button btnRemove = new Button();
                btnRemove.ID = "btnRemove_" + i;   // 🔥 THIS LINE FIXES EVERYTHING
                btnRemove.Text = "Remove";
                btnRemove.CssClass = "btn btn-sm btn-danger";
                btnRemove.CommandArgument = i.ToString();
                btnRemove.CausesValidation = false;
                btnRemove.UseSubmitBehavior = false;
                btnRemove.Click += BtnRemove_Click;



                TableCell actionCell = new TableCell();
                actionCell.Controls.Add(btnRemove);
                tr.Cells.Add(actionCell);

                memberTableBody.Controls.Add(tr);
            }
        }

        protected void BtnRemove_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int index = Convert.ToInt32(btn.CommandArgument);

            // Get list
            List<MemberDetailModel> members =
                string.IsNullOrEmpty(hfMemberData.Value)
                ? new List<MemberDetailModel>()
                : JsonConvert.DeserializeObject<List<MemberDetailModel>>(hfMemberData.Value);

            // REMOVE FROM LIST
            if (index >= 0 && index < members.Count)
                members.RemoveAt(index);

            // UPDATE hidden field (MOST IMPORTANT)
            hfMemberData.Value = JsonConvert.SerializeObject(members);

            // Recalculate total
            decimal baseAmount = 3;
            txtTotalAmount.Text = (baseAmount + members.Sum(m => m.Amount)).ToString();

            // Re-render table
            RenderMemberTable(members);
        }

        private void RestoreMemberTable()
        {
            List<MemberDetailModel> members = string.IsNullOrEmpty(hfMemberData.Value)
                ? new List<MemberDetailModel>()
                : Newtonsoft.Json.JsonConvert.DeserializeObject<List<MemberDetailModel>>(hfMemberData.Value);

            // Update total
            decimal baseAmount = 3;
            decimal totalAmount = baseAmount + members.Sum(m => m.Amount);
            txtTotalAmount.Text = totalAmount.ToString();

            // Render table
            RenderMemberTable(members);
        }
        //protected void PayTest_Click(object sender, EventArgs e)
        //{

        //}


    }
}