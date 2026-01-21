<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="refund-policy.aspx.cs" Inherits="BoxaRegistration.refund_policy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .about-area .info h5 {
            color: #000;
            font-size: 18px;
            text-transform: initial;
        }

        .about-area .info p {
            color: #000;
        }

        .hrline {
            border: solid 0.5px #d3d3d3;
            margin-top: 10px;
            margin-bottom: 10px;
        }

        .about-area .info h4 {
            margin-top: 10px;
            margin-bottom: 0px;
        }

        .about-area ul {
            list-style-type: disc !important;
            padding-left: 25px !important;
            margin-bottom: 15px;
        }

            .about-area ul li {
                display: list-item !important;
                margin-bottom: 8px;
                line-height: 1.7;
                color: #333;
            }

            /* For nested lists */
            .about-area ul ul {
                list-style-type: circle !important;
                padding-left: 20px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="breadcrumb-area shadow dark text-left text-light" style="background-image: url(/images/banner.jpg);">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h1>Refund Policy</h1>
                    <ul class="breadcrumb">
                        <li><a href="/home"><i class="fas fa-home"></i>Home</a></li>
                        <li class="active">Refund Policy</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div class="about-area default-padding">
        <div class="container">
            <div class="row">
                <div class="about-info">

                    <div class="col-md-12 info title">

                        <h2>Refund Policy</h2>
                        <h5><b>Bokaro Old Xaverians Association (BOXA)</b></h5>
                        <h5><i>Diamond Jubilee Celebration Registration</i></h5>

                        <p>
                            Bokaro Old Xaverians Association (BOXA) is organizing the 
                        <b>Diamond Jubilee Celebration</b>, for which registration is open to all 
                        <b>BOXANS</b> upon payment of a prescribed registration fee through the website.
                        </p>

                        <p>Please read the refund policy carefully before making any payment.</p>

                        <hr class="hrline" />

                        <h4>1. Registration Fee</h4>
                        <ul>
                            <li>The registration fee collected is meant to cover event-related expenses and administrative costs.</li>
                            <li>Payment convenience/payment gateway charges based upon mode of payment may be applicable at the time of payment.</li>
                            <li>Once paid, the registration fee is considered confirmation of participation.</li>
                        </ul>

                        <hr class="hrline" />

                        <h4>2. Refund Eligibility</h4>
                        <ul>
                            <li>Registration fees are generally non-refundable.</li>
                            <li>Refunds will be considered only under exceptional circumstances, such as:</li>
                            <ul>
                                <li>Duplicate payment due to technical error.</li>
                                <li>Event cancellation by the organizing committee.</li>
                            </ul>
                        </ul>

                        <hr class="hrline" />

                        <h4>3. Non-Refundable Cases</h4>
                        <p>No refund will be provided in the following cases:</p>
                        <ul>
                            <li>First successful registration</li>
                            <li>Inability to attend the event for personal reasons</li>
                            <li>Incorrect details entered by the member during registration</li>
                            <li>Failure to attend the event after registration</li>
                        </ul>

                        <hr class="hrline" />

                        <h4>4. Duplicate / Failed Transactions</h4>
                        <ul>
                            <li>If a member’s account is debited multiple times for the same registration, the excess amount will be refunded after confirmation by Bank and Payment Gateway verification.</li>
                            <li>If payment is deducted and payment received in BOXA Bank Account but registration is not confirmed, the matter will be reviewed and resolved accordingly.</li>
                        </ul>

                        <hr class="hrline" />

                        <h4>5. Refund Process</h4>
                        <ul>
                            <li>All refund requests must be submitted in writing via email with the following details:</li>
                            <ul>
                                <li>Registered member name</li>
                                <li>Registered mobile number / email ID</li>
                                <li>Transaction ID</li>
                                <li>Mode of Payment</li>
                                <li>Date and Time of payment</li>
                                <li>Reason for refund request</li>
                                <li>Transaction Amount</li>
                            </ul>
                            <li>Refund requests will be reviewed by the BOXA organizing committee and decision of committee will be final.</li>
                        </ul>

                        <hr class="hrline" />

                        <h4>6. Refund Timeline</h4>
                        <ul>
                            <li>Approved refunds will be processed within 10–15 working days.</li>
                            <li>The refunded amount will be credited to the original mode of payment.</li>
                            <li>Payment gateway charges, if any, may be deducted from the refund amount.</li>
                        </ul>

                        <hr class="hrline" />

                        <h4>7. Event Cancellation</h4>
                        <ul>
                            <li>In case the Diamond Jubilee Celebration is cancelled or postponed due to unavoidable circumstances, refund decisions will be taken by the BOXA Committee and communicated to registered members.</li>
                        </ul>

                        <hr class="hrline" />

                        <h4>8. Final Authority</h4>
                        <ul>
                            <li>Bokaro Old Xaverians Association (BOXA) reserves the right to accept or reject any refund request.</li>
                            <li>The decision of the BOXA organizing committee shall be final and binding.</li>
                        </ul>

                        <hr class="hrline" />

                        <h4>9. Contact Information</h4>
                        <p>
                            For refund-related queries, please contact:<br />
                            <b>Bokaro Old Xaverians Association (BOXA)</b><br />
                            <a href="mailto:Officialboxabokaro@gmail.com">Officialboxabokaro@gmail.com</a>
                        </p>

                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
