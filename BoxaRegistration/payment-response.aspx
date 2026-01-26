<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="payment-response.aspx.cs" Inherits="BoxaRegistration.payment_response" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h3>
            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label></h3>
    </div>

    <% if (payment != null && payment.Status.Trim().ToUpper() == "SUCCESS" && payment.StatusCode.Trim() == "0000")
        { %>
    <div class="success-box">
        <h2 class="text-success">🎉 Registration Successful</h2>
        <p><b>Name:</b> <%= payment.PayerName %></p>
        <p><b>Transaction ID:</b> <%= payment.ClientTxnId %></p>
        <p><b>Amount Paid:</b> ₹<%= payment.PaidAmount %></p>
        <p><b>Status:</b> SUCCESS</p>
        <hr />
        <p class="text-muted">Thank you for registering for BOXA Diamond Jubilee Celebration.</p>
    </div>
    <% }
    else
    { %>
    <div class="fail-box">
        <h2 class="text-danger">❌ Payment Failed</h2>
        <p><%= paymentMessage %></p>
    </div>
    <% } %>
</asp:Content>
