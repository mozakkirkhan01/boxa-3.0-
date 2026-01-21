<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="terms-conditions.aspx.cs" Inherits="BoxaRegistration.terms_conditions" %>
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
                    <h1>Terms and Conditions</h1>
                    <ul class="breadcrumb">
                        <li><a href="/home"><i class="fas fa-home"></i>Home</a></li>
                        <li class="active">Terms and Conditions</li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div class="about-area default-padding">
    <div class="container">
        <div class="row">
            <div class="about-info">

                <div class="col-md-12 info">

                    <h2>Terms & Conditions for Online Payment</h2>
                    <h5><b>Bokaro Old Xaverians Association (BOXA)</b></h5>

                    <p>
                        Welcome to the official website of Bokaro Old Xaverians Association (BOXA). By accessing this website 
                        and making any payment through our online payment gateway, you agree to be bound by the following 
                        Terms & Conditions. Please read them carefully before proceeding with any transaction.
                    </p>

                    <hr class="hrline" />

                    <h4>1. About BOXA</h4>
                    <p>
                        Bokaro Old Xaverians Association (BOXA) is an alumni association formed to connect former students 
                        (“Old Xaverians / Boxans”) and organize events, celebrations, and welfare activities, including the 
                        Diamond Jubilee Celebration and other association-related programs.
                    </p>

                    <hr class="hrline" />

                    <h4>2. Online Payments</h4>
                    <ul>
                        <li>All payments made on this website are voluntary contributions, registration fees, event charges, or membership-related fees as decided by BOXA.</li>
                        <li>Payments are processed through a secure third-party payment gateway.</li>
                        <li>BOXA does not store or process sensitive payment details such as card numbers, CVV, or banking credentials.</li>
                    </ul>

                    <hr class="hrline" />

                    <h4>3. Purpose of Payment</h4>
                    <p>Payments collected through this website may be used for:</p>
                    <ul>
                        <li>Event registration or renewal</li>
                        <li>Event participation (Diamond Jubilee Celebration)</li>
                        <li>Administrative and operational expenses of BOXA</li>
                        <li>Welfare and development activities approved by the association</li>
                    </ul>

                    <hr class="hrline" />

                    <h4>4. Payment Confirmation</h4>
                    <ul>
                        <li>Upon successful payment, a confirmation message/receipt will be generated.</li>
                        <li>If the payment is debited but confirmation is not received, members are advised to contact BOXA with transaction details for verification.</li>
                    </ul>

                    <hr class="hrline" />

                    <h4>5. Refund & Cancellation Policy</h4>
                    <ul>
                        <li>Fees paid towards event registration, event participation, or donations are generally non-refundable, unless otherwise specified for a particular event.</li>
                        <li>In case of duplicate payment, refunds (if approved) will be processed after verification and may take 10–15 working days.</li>
                        <li>Any approved refund will be credited back to the original payment method.</li>
                        <li>For Refund Policy, please refer the Refund Policy on the website menu.</li>
                    </ul>

                    <hr class="hrline" />

                    <h4>6. Failed or Incomplete Transactions</h4>
                    <ul>
                        <li>BOXA shall not be held responsible for payment failures due to technical issues, network problems, incorrect payment details, or bank-related errors.</li>
                        <li>In case of failed transactions where the amount is debited, the refund will be handled as per the payment gateway/bank’s policy.</li>
                    </ul>

                    <hr class="hrline" />

                    <h4>7. User Responsibility</h4>
                    <p>By making a payment, you confirm that:</p>
                    <ul>
                        <li>The information provided by you is accurate and complete.</li>
                        <li>You are authorized to use the selected payment method.</li>
                        <li>You understand and agree to the applicable charges and policies.</li>
                    </ul>

                    <hr class="hrline" />

                    <h4>8. Event Changes or Cancellation</h4>
                    <ul>
                        <li>BOXA reserves the right to reschedule, modify, or cancel any event due to unavoidable circumstances.</li>
                        <li>In such cases, decisions regarding refunds or adjustments will be taken by the association and will be final.</li>
                    </ul>

                    <hr class="hrline" />

                    <h4>9. Limitation of Liability</h4>
                    <ul>
                        <li>BOXA shall not be liable for any direct or indirect loss arising from the use of this website or online payment services.</li>
                        <li>BOXA is not responsible for delays or failures caused by third-party service providers, including payment gateways and banks.</li>
                    </ul>

                    <hr class="hrline" />

                    <h4>10. Privacy & Data Usage</h4>
                    <ul>
                        <li>Personal information collected during registration or payment will be used only for association-related communication and records.</li>
                        <li>BOXA does not sell or share personal data with third parties, except where required by law or payment processing partners.</li>
                    </ul>

                    <hr class="hrline" />

                    <h4>11. Intellectual Property</h4>
                    <p>
                        All content on this website, including logos, text, images, and design, is the property of Bokaro Old 
                        Xaverians Association (BOXA) and may not be used without prior permission.
                    </p>

                    <hr class="hrline" />

                    <h4>12. Governing Law</h4>
                    <p>
                        These Terms & Conditions shall be governed and interpreted in accordance with the laws of India. Any 
                        disputes shall be subject to the jurisdiction of competent courts in Bokaro, Jharkhand, India.
                    </p>

                    <hr class="hrline" />

                    <h4>13. Changes to Terms</h4>
                    <p>
                        BOXA reserves the right to modify these Terms & Conditions at any time without prior notice. Updated 
                        terms will be effective immediately upon posting on the website.
                    </p>

                    <hr class="hrline" />

                    <h4>14. BOXAN/Student/Invitee</h4>
                    <p>
                        I am BOXAN/Student/Invitee and agree to show my identity proof any time requested during the event days.
                    </p>

                    <hr class="hrline" />

                    <h4>14. Contact Information</h4>
                    <p>
                        For any queries related to payments, membership, or events, please contact:<br />
                        <b>Bokaro Old Xaverians Association (BOXA)</b><br />
                       <a href="mailto:Officialboxabokaro@gmail.com">Officialboxabokaro@gmail.com</a>
                    </p>

                </div>

            </div>
        </div>
    </div>
</div>

</asp:Content>
