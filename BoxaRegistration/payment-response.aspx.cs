using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Boxa;

namespace BoxaRegistration
{
    public partial class payment_response : System.Web.UI.Page
    {
        Encryption sabPaisa = new Encryption();
        public PaymentTransactions payment;
        public string paymentMessage = "";

        protected void Page_Load(object sender, EventArgs e)
        {
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
                    if (string.Equals(payment.Status?.Trim(), "SUCCESS", StringComparison.OrdinalIgnoreCase)  && payment.StatusCode.Trim() == "0000") // exactly match SabPaisa
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

                    // Insert transaction record
                    Transaction txn = new Transaction
                    {
                        MemberRegId = reg.MemberRegId,
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
                        statusCode = int.Parse(pModel.StatusCode),
                        //statusCode = int.TryParse(pModel.StatusCode, out var sc) ? sc : 0,
                        rrn = pModel.RRN,
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
