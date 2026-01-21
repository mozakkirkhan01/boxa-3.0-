<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="BoxaRegistration._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <style>
        .site-heading {
            margin-bottom: 10px;
            margin-top: -5px;
            overflow: hidden;
        }

        .nice-select {
            -webkit-tap-highlight-color: transparent;
            background-color: #fff;
            border: solid 1px #e8e8e8;
            box-sizing: border-box;
            clear: both;
            cursor: pointer;
            display: block;
            float: left;
            font-family: inherit;
            font-size: 14px;
            font-weight: normal;
            height: 50px;
            line-height: 30px;
            outline: none;
            padding-left: 18px;
            padding-right: 30px;
            position: relative;
            text-align: left !important;
            -webkit-transition: all 0.2s ease-in-out;
            transition: all 0.2s ease-in-out;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
            white-space: nowrap;
            width: 100%;
            margin-bottom: 15px;
            z-index: auto;
        }
    </style>
    <style>
        .about-area.default-padding {
            background: linear-gradient(120deg, #fff6e5 0%, #fbeaff 50%, #eaf2ff 100%);
        }

        .site-heading h2 {
            font-weight: 800;
            color: #2c387e;
            font-size: 24px;
        }

        .site-heading p {
            font-size: 15px;
            line-height: 1.8;
            color: #555;
        }


        .form-card {
            background: #ffffff;
            border-radius: 18px;
            padding: 35px;
            box-shadow: 0 18px 45px rgba(0, 0, 0, 0.08);
            border-top: 6px solid #3f51b5;
        }


            .form-card h2 {
                font-size: 22px;
                font-weight: 700;
                color: #3f51b5;
                margin-bottom: 25px;
            }


            .form-card label {
                font-size: 14px;
                font-weight: 600;
                color: #333;
            }

            .form-card .form-control,
            .form-card select {
                height: 46px;
                border-radius: 10px;
                border: 2px solid #d6dcff;
                background: #f7f9ff;
                font-size: 14px;
                transition: 0.3s ease;
            }

                .form-card .form-control::placeholder {
                    color: #999;
                }

                .form-card .form-control:focus,
                .form-card select:focus {
                    border-color: #3f51b5;
                    background: #ffffff;
                    box-shadow: 0 0 0 3px rgba(63, 81, 181, 0.15);
                }


            .form-card select {
                width: 100%;
            }


            .form-card .btn-theme {
                background: linear-gradient(135deg, #3f51b5, #5c6bc0);
                border-radius: 30px;
                padding: 12px 45px;
                font-size: 16px;
                font-weight: 600;
                border: none;
                transition: 0.3s;
            }

                .form-card .btn-theme:hover {
                    background: linear-gradient(135deg, #303f9f, #3f51b5);
                    transform: translateY(-2px);
                }


        .text-danger {
            font-size: 13px;
        }

        .terms-line {
            display: flex;
            align-items: center;
            gap: 8px;
            font-size: 14px;
            color: #333;
            cursor: pointer;
        }

            .terms-line input[type="checkbox"] {
                width: 16px;
                height: 16px;
                margin-top: 0;
            }

            .terms-line a {
                color: #3f51b5;
                font-weight: 600;
                text-decoration: none;
            }

                .terms-line a:hover {
                    text-decoration: underline;
                }

        .disabled-btn {
            opacity: 0.55;
            cursor: not-allowed;
            pointer-events: none; /* 🚫 THIS BLOCKS ALL CLICKS */
        }

        /* Enabled button */
        .enabled-btn {
            opacity: 1;
            cursor: pointer;
            pointer-events: auto;
            box-shadow: 0 8px 20px rgba(63,81,181,0.35);
        }

        @media (max-width: 768px) {
            .form-card {
                padding: 25px;
                margin-top: 30px;
            }
        }
    </style>



</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <div class="about-area default-padding">
        <div class="container">
            <div class="row align-items-center">

                <!-- LEFT CONTENT -->
                <div class="col-md-5 info">
                    <div class="site-heading text-left">
                        <h2>BOXA DIAMOND JUBILEE CELEBRATION</h2>
                        <p>
                            The Bokaro Old Xaverians Association (BOXA) proudly invites all BOXANS
                        to celebrate its <b>Diamond Jubilee</b>, marking 60 glorious years of legacy,
                        fellowship, and excellence. Join us on <b>26th, 27th & 28th December 2026</b>
                            at <b>St. Xavier’s School</b> for a grand reunion filled with memories,
                        culture, and lifelong bonds.
                        </p>
                    </div>
                </div>

                <!-- FORM CARD -->
                <div class="col-md-7">
                    <div class="form-card">

                        <h2 class="text-center">Registration Form</h2>

                        <div class="row">

                            <!-- Full Name -->
                            <div class="col-md-12 form-group">
                                <label>Full Name <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" placeholder="Full Name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFullName"
                                    ErrorMessage="Full Name is required." Display="Dynamic" ForeColor="Red" />
                            </div>

                            <!-- Gender -->
                            <div class="col-md-6 form-group">
                                <label>Gender <span class="text-danger">*</span></label>
                                <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="">Select Gender</asp:ListItem>
                                    <asp:ListItem>Male</asp:ListItem>
                                    <asp:ListItem>Female</asp:ListItem>
                                    <asp:ListItem>Other</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlGender"
                                    InitialValue="" ErrorMessage="Gender is required." Display="Dynamic" ForeColor="Red" />
                            </div>

                            <!-- Year of Passing -->
                            <div class="col-md-6 form-group">
                                <label>Year of Passing (12<sup>th</sup>) or equivalent <span class="text-danger">*</span></label>
                                <asp:DropDownList ID="ddlYearPassing" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="">Select Year</asp:ListItem>
                                    <asp:ListItem>1990</asp:ListItem>
                                    <asp:ListItem>1995</asp:ListItem>
                                    <asp:ListItem>2000</asp:ListItem>
                                    <asp:ListItem>2005</asp:ListItem>
                                    <asp:ListItem>2010</asp:ListItem>
                                    <asp:ListItem>2015</asp:ListItem>
                                    <asp:ListItem>2020</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlYearPassing"
                                    InitialValue="" ErrorMessage="Year of passing is required." Display="Dynamic" ForeColor="Red" />
                            </div>

                            <!-- Mobile -->
                            <div class="col-md-6 form-group">
                                <label>Mobile No. (WhatsApp) <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control" placeholder="Mobile No." MaxLength="10"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMobileNo"
                                    ErrorMessage="Mobile number is required." Display="Dynamic" ForeColor="Red" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMobileNo"
                                    ValidationExpression="^[6-9]\d{9}$"
                                    ErrorMessage="Enter valid 10-digit mobile number." Display="Dynamic" ForeColor="Red" />
                            </div>

                            <!-- Email -->
                            <div class="col-md-6 form-group">
                                <label>Email ID</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email Address"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail"
                                    ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
                                    ErrorMessage="Enter valid email address." Display="Dynamic" ForeColor="Red" />
                            </div>

                            <!-- City -->
                            <div class="col-md-12 form-group">
                                <label>City <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" placeholder="City"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCity"
                                    ErrorMessage="City is required." Display="Dynamic" ForeColor="Red" />
                            </div>

                            <!-- State -->
                            <div class="col-md-6 form-group">
                                <label>State <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtState" runat="server" CssClass="form-control" placeholder="State"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtState"
                                    ErrorMessage="State is required." Display="Dynamic" ForeColor="Red" />
                            </div>

                            <!-- Country -->
                            <div class="col-md-6 form-group">
                                <label>Country <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtCountry" runat="server" CssClass="form-control" placeholder="Country"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCountry"
                                    ErrorMessage="Country is required." Display="Dynamic" ForeColor="Red" />
                            </div>

                            <!-- Profession -->
                            <div class="col-md-6 form-group">
                                <label>Current Profession / Occupation</label>
                                <asp:TextBox ID="txtProfession" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <!-- Organization -->
                            <div class="col-md-6 form-group">
                                <label>Organization / Business</label>
                                <asp:TextBox ID="txtOrg" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <!-- No of Persons -->
                            <div class="col-md-6 form-group">
                                <label>No. of Persons <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtPersons" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPersons"
                                    ErrorMessage="Number of persons is required." Display="Dynamic" ForeColor="Red" />
                            </div>

                            <!-- T-Shirt Size -->
                            <div class="col-md-6 form-group">
                                <label>T-Shirt Size <span class="text-danger">*</span></label>
                                <asp:DropDownList ID="ddlTshirt" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="">Select Size</asp:ListItem>
                                    <asp:ListItem>S</asp:ListItem>
                                    <asp:ListItem>M</asp:ListItem>
                                    <asp:ListItem>L</asp:ListItem>
                                    <asp:ListItem>XL</asp:ListItem>
                                    <asp:ListItem>XXL</asp:ListItem>
                                    <asp:ListItem>XXXL</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlTshirt"
                                    InitialValue="" ErrorMessage="T-Shirt size is required." Display="Dynamic" ForeColor="Red" />
                            </div>

                            <div class="col-md-12 form-group">
                                <label class="checkbox-inline terms-line">
                                    <asp:CheckBox ID="cbTermCond" runat="server" />

                                    <span>I have read and agree to the  <a href="/terms-conditions" target="_blank">Terms and Conditions</a>
                                    </span>

                                </label>
                            </div>

                            <!-- Submit -->
                            <div class="col-md-12 text-center mt-4">
                                <asp:Button ID="btnRegister" runat="server"
                                    CssClass="btn btn-theme effect btn-md disabled-btn"
                                    Text="Pay to Register"
                                    CausesValidation="true" />
                            </div>

                        </div>
                    </div>
                </div>


            </div>
        </div>
    </div>
    <script>
        document.addEventListener("DOMContentLoaded", function () {
            var cb = document.getElementById('<%= cbTermCond.ClientID %>');
           var btn = document.getElementById('<%= btnRegister.ClientID %>');

           // Disable on load
           btn.classList.add('disabled-btn');
           btn.classList.remove('enabled-btn');

           cb.addEventListener('change', function () {
               if (this.checked) {
                   btn.classList.remove('disabled-btn');
                   btn.classList.add('enabled-btn');
               } else {
                   btn.classList.remove('enabled-btn');
                   btn.classList.add('disabled-btn');
               }
           });
       });
    </script>

</asp:Content>
