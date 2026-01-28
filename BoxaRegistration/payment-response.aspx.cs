using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Boxa;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.tool.xml;



namespace BoxaRegistration
{
    public partial class payment_response : System.Web.UI.Page
    {
        Encryption sabPaisa = new Encryption();
        public PaymentTransactions payment;
        public string paymentMessage = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["download"] == "1")
            {
                GenerateReceiptPDF();
                return;
            }
            if (!IsPostBack)
            {
                try
                {
                    string encResponse = Request.Form["encResponse"];
                    if (string.IsNullOrEmpty(encResponse))
                    {
                        lblStatus.Text = "No response received from payment gateway.";
                        return;
                    }

                    // SabPaisa keys
                    //string authKey = "DaC+Y5IqSXn6znxzmO/3yQ+OyRzEM136lYHpPkfvfCc=";
                    //string authIV = "Cw/YZyY+Xl9RovVn1Rh1fcxyPOyzaLMLdUaqZ/LA+CrCQsSKQ79N1ifb/t1MxA5e";

                    string authKey = "ISTrmmDC2bTvkxzlDRrVguVwetGS8xC/UFPsp6w+Itg=";
                    string authIV = "M+aUFgRMPq7ci+Cmoytp3KJ2GPBOwO72Z2Cjbr55zY7++pT9mLES2M5cIblnBtaX";
                    // URL decode & decrypt
                    string decoded = HttpUtility.UrlDecode(encResponse).Replace("%2B", "+").Replace("%2F", "/").Replace("%3D", "=");
                    string decrypted = sabPaisa.DecryptString(authKey, authIV, decoded);

                    // Parse response
                    Dictionary<string, string> dictParams = sabPaisa.queryParser(decrypted);

                    // Map to payment object safely
                    payment = MapResponseToPaymentObject(dictParams);

                    // Show received data for debugging
                    lblStatus.Text = $"Received TxnId: {payment.ClientTxnId} <br/> Status: {payment.Status}";

                    // Validate payment
                    if (string.Equals(payment.Status?.Trim(), "SUCCESS", StringComparison.OrdinalIgnoreCase) && payment.StatusCode.Trim() == "0000") // exactly match SabPaisa
                    {
                        bool saved = SavePaymentToDatabase(payment);

                    }
                    else
                    {
                        paymentMessage = "❌ Payment failed or invalid response!";
                    }
                }
                catch (Exception ex)
                {
                    paymentMessage = "❌ Error processing response: " + ex.Message;
                }
            }
        }

        private PaymentTransactions MapResponseToPaymentObject(Dictionary<string, string> data)
        {
            decimal amount = 0, paidAmount = 0;

            decimal.TryParse(GetValue(data, "amount"), out amount);
            decimal.TryParse(GetValue(data, "paidAmount"), out paidAmount);

            return new PaymentTransactions
            {
                ClientTxnId = GetValue(data, "clientTxnId"),
                SabPaisaTxnId = GetValue(data, "sabpaisaTxnId"),
                PayerName = GetValue(data, "payerName"),
                PayerEmail = GetValue(data, "payerEmail"),
                PayerMobile = GetValue(data, "payerMobile"),
                PayerAddress = GetValue(data, "payerAddress"),
                Amount = amount,
                PaidAmount = paidAmount,
                PaymentMode = GetValue(data, "paymentMode"),
                BankName = GetValue(data, "bankName"),
                AmountType = GetValue(data, "amountType"),
                Status = GetValue(data, "status"),
                StatusCode = GetValue(data, "statusCode"), // keep it exactly as SabPaisa sends
                RRN = GetValue(data, "rrn"),
                BankTxnId = GetValue(data, "bankTxnId"),
                ClientCode = GetValue(data, "clientCode"),
                TransDate = DateTime.Now
            };
        }

        private string GetValue(Dictionary<string, string> dict, string key)
        {
            return dict.ContainsKey(key) ? dict[key].Trim() : string.Empty;
        }


        private string GetReceiptHTML(ReceiptUserModel reg, Transaction txn)

        {
            string logoPath = Server.MapPath("~/images/boxa-logo.png");

            return $@"
<html>
<head>
<style>
    body {{ font-family: Arial; font-size: 13px; }}
    table {{ width: 100%; border-collapse: collapse; }}

    .border td,
    .border th {{
        border: 1px solid #000;
        padding: 6px;
        text-align: left;
    }}

    th {{
        background-color: #f2f2f2;
        font-weight: bold;
    }}

    .center {{ text-align: center; }}
</style>
</head>
<body>

<!-- HEADER -->
<table>
    <tr>
        <td style='width:15%;'>
            <img src='{logoPath}' width='50' />
        </td>
        <td style='width:85%; text-align:center; margin-left:-20px;'>
            <h2>BOKARO OLD XAVERIANS ASSOCIATION</h2>
            <p>Diamond Jubilee Celebration</p>
            <b>Payment Receipt</b>
        </td>
    </tr>
</table>

<br/>

<p>This is to acknowledge that your payment was <b>successfully</b> received.</p>

<!-- DETAILS TABLE -->
<table class='border'>
    <tr>
        <td><b>Registration No</b></td>
        <td>{reg.MemberRegNo}</td>
    </tr>
    <tr>
        <td><b>Name</b></td>
        <td>{reg.MemberFullName}</td>
    </tr>
    <tr>
        <td><b>Email</b></td>
        <td>{reg.Email}</td>
    </tr>
    <tr>
        <td><b>Mobile</b></td>
        <td>{reg.MobileNo}</td>
    </tr>
    <tr>
        <td><b>T-Shirt Size</b></td>
        <td>{reg.TshirtName}</td>

    </tr>
    <tr>
        <td><b>Transaction ID</b></td>
        <td>{txn.sabpaisaTxnld}</td>
    </tr>
    <tr>
        <td><b>Transaction Date</b></td>
        <td>{txn.transDate:dd-MM-yyyy}</td>
    </tr>
    <tr>
        <td><b>Amount</b></td>
        <td>₹{txn.paidAmount}</td>
    </tr>
    <tr>
        <td><b>Payment Mode</b></td>
        <td>{txn.paymentMode}</td>
    </tr>
</table>

<br/>

<!-- INVOICE TABLE -->
<table class='border'>
    <tr>
        <th>Invoice No</th>
        <th>Invoice Date</th>
        <th>Amount</th>
        <th>Description</th>
    </tr>
    <tr>
        <td>{txn.InvoiceNumber}</td>
        <td>{txn.transDate:dd-MM-yyyy}</td>
        <td>₹{txn.paidAmount}</td>
        <td>Diamond Jubilee Celebration</td>
    </tr>
</table>

<br/>

<p class='center'>
    Computer Generated Receipt. Signature not required.<br/>
    Please preserve this document for future use.
</p>

</body>
</html>";
        }





        protected void btnDownloadReceipt_Click(object sender, EventArgs e)
        {
            GenerateReceiptPDF();
        }



        private void AddRow(PdfPTable table, string label, string value)
        {
            table.AddCell(new PdfPCell(new Phrase(label)) { Border = 0 });
            table.AddCell(new PdfPCell(new Phrase(value)) { Border = 0 });
        }
        public class ReceiptUserModel
        {
            public int MemberRegId { get; set; }
            public string MemberRegNo { get; set; }
            public string MemberFullName { get; set; }
            public string Email { get; set; }
            public string MobileNo { get; set; }
            public string TshirtName { get; set; }
        }



        private void GenerateReceiptPDF()
        {
            using (BoxaDiamondRegDataContext db = new BoxaDiamondRegDataContext())
            {
                var txn = db.Transactions
                            .OrderByDescending(x => x.TransactionId)
                            .FirstOrDefault();

                var reg = (from r in db.MemberRegs
                           join t in db.TshirtSizes
                               on r.TshirtSize equals t.TshirtSizeId
                           where r.MemberRegId == txn.MemberRegId
                           select new ReceiptUserModel
                           {
                               MemberRegId = r.MemberRegId,
                               MemberRegNo = r.MemberRegNo,
                               MemberFullName = r.MemberFullName,
                               Email = r.Email,
                               MobileNo = r.MobileNo,
                               TshirtName = t.TshirtSizeName
                           }).FirstOrDefault();



                string html = GetReceiptHTML(reg, txn);

                using (MemoryStream ms = new MemoryStream())
                {
                    Document doc = new Document(PageSize.A4);
                    PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                    doc.Open();

                    using (var sr = new StringReader(html))
                    {
                        iTextSharp.tool.xml.XMLWorkerHelper.GetInstance()
                            .ParseXHtml(writer, doc, sr);
                    }

                    doc.Close();

                    //Response.Clear();
                    //Response.ContentType = "application/pdf";
                    //Response.AddHeader("content-disposition", "attachment;filename=BOXA_Receipt.pdf");
                    //Response.BinaryWrite(ms.ToArray());
                    //Response.End();
                    // ✅ OPEN PDF IN NEW TAB (NOT DOWNLOAD)
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "inline;filename=BOXA_Receipt.pdf");
                    Response.BinaryWrite(ms.ToArray());
                    Response.End();
                }
            }
        }



        private string GenerateInvoiceNumber()
        {
            using (BoxaDiamondRegDataContext db = new BoxaDiamondRegDataContext())
            {
                string year = DateTime.Now.ToString("yy"); // 26

                // Get last invoice for current year
                var lastInvoice = db.Transactions
                    .Where(x => x.InvoiceNumber.StartsWith("BOXA" + year))
                    .OrderByDescending(x => x.InvoiceNumber)
                    .Select(x => x.InvoiceNumber)
                    .FirstOrDefault();

                int nextNumber = 1;

                if (!string.IsNullOrEmpty(lastInvoice))
                {
                    // Extract last 4 digits
                    string lastDigits = lastInvoice.Substring(lastInvoice.Length - 4);
                    nextNumber = int.Parse(lastDigits) + 1;
                }

                return $"BOXA{year}{nextNumber.ToString("D4")}";
            }
        }


        public bool SavePaymentToDatabase(PaymentTransactions pModel)
        {
            try
            {
                using (BoxaDiamondRegDataContext db = new BoxaDiamondRegDataContext())
                {
                    // Lookup registration by ClientTxnId
                    MemberReg reg = db.MemberRegs.FirstOrDefault(x => x.ClientTxnId == pModel.ClientTxnId);
                    if (reg == null)
                        return false;

                    // Update registration
                    reg.PaymentStatus = "SUCCESS";
                    reg.TotalAmountPaid = pModel.PaidAmount;
                    reg.RegistrationDate = DateTime.Now;
                    db.SubmitChanges();

                    //generate invoice number
                    string invoiceNo = GenerateInvoiceNumber();

                    // Insert transaction record
                    Transaction txn = new Transaction
                    {
                        MemberRegId = reg.MemberRegId,
                        InvoiceNumber = invoiceNo,
                        payerName = pModel.PayerName,
                        payerEmail = pModel.PayerEmail,
                        payerMobile = pModel.PayerMobile,
                        payerAddress = pModel.PayerAddress,
                        clientTxnId = pModel.ClientTxnId,
                        sabpaisaTxnld = pModel.SabPaisaTxnId,
                        amount = pModel.Amount,
                        paidAmount = pModel.PaidAmount,
                        paymentMode = pModel.PaymentMode,
                        bankName = pModel.BankName,
                        amounttype = pModel.AmountType,
                        Status = pModel.Status,
                        statusCode = pModel.StatusCode,
                        //statusCode = int.Parse(pModel.StatusCode),
                        //statusCode = int.TryParse(pModel.StatusCode, out var sc) ? sc : 0,
                        rrn = pModel.RRN,
                        Description = "Diamond Jubilee Celebration",
                        bankTxnld = pModel.BankTxnId,
                        sabpaisaMessage = "SUCCESS",
                        sabpaisaErrorCode = "",
                        bankMessage = "",
                        bankErrorCode = "",
                        transDate = DateTime.Now,
                        clientCode = pModel.ClientCode,
                        mcc = ""
                    };

                    db.Transactions.InsertOnSubmit(txn);
                    db.SubmitChanges();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public class PaymentTransactions
        {
            public string ClientTxnId { get; set; }
            public string SabPaisaTxnId { get; set; }
            public string PayerName { get; set; }
            public string PayerEmail { get; set; }
            public string PayerMobile { get; set; }
            public string PayerAddress { get; set; }
            public decimal Amount { get; set; }
            public decimal PaidAmount { get; set; }
            public string PaymentMode { get; set; }
            public string BankName { get; set; }
            public string AmountType { get; set; }
            public string Status { get; set; }
            public string StatusCode { get; set; } // string for display
            public string RRN { get; set; }
            public string BankTxnId { get; set; }
            public string ClientCode { get; set; }
            public DateTime TransDate { get; set; }
        }
    }
}
