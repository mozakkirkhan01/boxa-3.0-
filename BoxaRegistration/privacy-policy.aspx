<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="privacy-policy.aspx.cs" Inherits="BoxaRegistration.privacy_policy" %>
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
                    <h1>Privacy Policy</h1>
                    <ul class="breadcrumb">
                        <li><a href="/home"><i class="fas fa-home"></i>Home</a></li>
                        <li class="active">Privacy Policy</li>
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

                    <h2>Privacy Policy</h2>
                    <h5><b>Bokaro Old Xaverians Association (BOXA)</b></h5>
                    <h5><i>Diamond Jubilee Celebration Registration</i></h5>

                    <p>
                        Bokaro Old Xaverians Association (BOXA) is committed to protecting the privacy of all members (Boxans) 
                        who register for the Diamond Jubilee Celebration through our website. This Privacy Policy explains how 
                        we collect, use, and safeguard your personal information.
                    </p>

                    <hr class="hrline" />

                    <h4>1. Information We Collect</h4>
                    <p>During the registration process, we may collect the following information:</p>
                    <ul>
                        <li>Full Name</li>
                        <li>Contact Number</li>
                        <li>Email Address</li>
                        <li>Batch / Year of Passing</li>
                        <li>Address (if required)</li>
                        <li>Payment transaction details (Transaction ID, payment status)</li>
                    </ul>
                    <p>
                        <b>Note:</b> We do not store sensitive payment information such as debit/credit card numbers, CVV, or net banking credentials.
                    </p>

                    <hr class="hrline" />

                    <h4>2. Use of Collected Information</h4>
                    <p>The information collected is used for:</p>
                    <ul>
                        <li>Event registration and confirmation</li>
                        <li>Communication regarding the Diamond Jubilee Celebration</li>
                        <li>Verification of payments and issuance of receipts</li>
                        <li>Internal record keeping of BOXA members</li>
                        <li>Improving event management and member experience</li>
                    </ul>

                    <hr class="hrline" />

                    <h4>3. Payment Security</h4>
                    <ul>
                        <li>All online payments are processed through a secure and trusted payment gateway.</li>
                        <li>BOXA does not have access to or store your banking or card details.</li>
                        <li>Payment gateway providers follow industry-standard security practices.</li>
                    </ul>

                    <hr class="hrline" />

                    <h4>4. Information Sharing</h4>
                    <ul>
                        <li>Personal information will not be sold, traded, or shared with third parties.</li>
                        <li>Information may be shared only with:</li>
                        <ul>
                            <li>Payment gateway service providers (for transaction processing)</li>
                            <li>Event organizing committee members, strictly for official purposes</li>
                            <li>Legal or regulatory authorities if required by law</li>
                        </ul>
                    </ul>

                    <hr class="hrline" />

                    <h4>5. Data Protection</h4>
                    <ul>
                        <li>Reasonable security measures are implemented to protect personal data from unauthorized access, misuse, or disclosure.</li>
                        <li>Access to member data is restricted to authorized BOXA personnel only.</li>
                    </ul>

                    <hr class="hrline" />

                    <h4>6. Cookies</h4>
                    <ul>
                        <li>The website may use basic cookies to enhance user experience.</li>
                        <li>Cookies do not collect personally identifiable information.</li>
                    </ul>

                    <hr class="hrline" />

                    <h4>7. Accuracy of Information</h4>
                    <ul>
                        <li>Members are responsible for providing accurate and correct information during registration.</li>
                        <li>BOXA shall not be responsible for issues arising due to incorrect details submitted by the member.</li>
                    </ul>

                    <hr class="hrline" />

                    <h4>8. Data Retention</h4>
                    <ul>
                        <li>Personal data will be retained only for as long as necessary for event management, legal, or administrative purposes.</li>
                        <li>After completion of the event, data may be securely archived or deleted as per organizational policy.</li>
                    </ul>

                    <hr class="hrline" />

                    <h4>9. Consent</h4>
                    <p>
                        By registering on the website and making a payment, you consent to the collection and use of your information 
                        in accordance with this Privacy Policy.
                    </p>

                    <hr class="hrline" />

                    <h4>10. Policy Updates</h4>
                    <ul>
                        <li>BOXA reserves the right to modify or update this Privacy Policy at any time.</li>
                        <li>Any changes will be posted on the website and will be effective immediately.</li>
                    </ul>

                    <hr class="hrline" />

                    <h4>11. Contact Information</h4>
                    <p>
                        For any privacy-related concerns or queries, please contact:<br />
                        <b>Bokaro Old Xaverians Association (BOXA)</b><br />
                        <a href="mailto:Officialboxabokaro@gmail.com">Officialboxabokaro@gmail.com</a>
                    </p>

                </div>

            </div>
        </div>
    </div>
</div>

</asp:Content>
