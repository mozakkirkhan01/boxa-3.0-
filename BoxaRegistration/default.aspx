<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="BoxaRegistration._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/css/default.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hfMemberData" runat="server" />

    <div class="about-area default-padding">
        <div class="container">
            <div class="row align-items-center">

                <!-- LEFT CONTENT -->
                <div class="col-md-4 info">
                    <div class="site-heading text-left">
                        <h2>BOXA DIAMOND JUBILEE CELEBRATION</h2>
                        <p>
                            The Bokaro Old Xaverians Association (BOXA) proudly invites all BOXANS
                        to celebrate its <b>Diamond Jubilee</b>, marking 60 glorious years of legacy,
                        fellowship, and excellence. Join us on <b>26th, 27th & 28th December 2026</b>
                            at <b>St. Xavier’s School</b> for a grand reunion filled with memories,
                        culture, and lifelong bonds.
                        </p>
                        <h4 class="mb-0">Important Instruction:</h4>
                        <ul class="instruction-list">
                            <li>All fields marked with <span class="text-danger">*</span> are mandatory and must be filled correctly.</li>

                            <li>Please enter your <b>Full Name</b>, <b>Mobile Number</b>, and <b>Email ID</b> carefully, as these details will be used for all official communication and confirmation.</li>

                            <li>Mobile number should be a valid <b>10-digit WhatsApp number</b> starting with 6–9.</li>

                            <li>Select your correct <b>Year of Passing (12th or equivalent)</b> from the dropdown.</li>

                            <li>Choose the appropriate <b>T-Shirt Size</b>. Once submitted, the size <b>cannot be changed</b>.</li>

                            <li>Upload a recent passport-size photograph:
                            <ul>
                                <li>Maximum file size: <b>50 KB</b></li>
                                <li>Allowed formats: <b>.jpg, .jpeg, .png</b></li>
                                <li>Please click the <b>Upload Photo</b> button after selecting the file.</li>
                            </ul>
                            </li>

                            <li>You may add <b>Spouse / Children</b> details using the <b>“Add Spouse / Children”</b> button. Applicable charges will be calculated automatically.</li>

                            <li>The <b>Total Amount</b> will update automatically based on the selected members.</li>

                            <li>Please read and accept the <b>Terms & Conditions</b> before proceeding with payment.</li>

                            <li>Once payment is completed successfully, registration details <b>cannot be edited</b>.</li>

                            <li>Ensure a stable internet connection while submitting the form and making payment.</li>
                        </ul>

                    </div>
                </div>

                <!-- FORM CARD -->
                <div class="col-md-8">
                    <div class="form-card">

                        <h2 class="text-center">Registration Form</h2>
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                        <div class="row">

                            <!-- Full Name -->
                            <div class="col-md-6 form-group">
                                <label>Full Name <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" placeholder="Full Name"></asp:TextBox>
                                <div class="field-error">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFullName"
                                        ErrorMessage="Full Name is required." Display="Dynamic" ForeColor="Red" ValidationGroup="n1" />
                                </div>
                            </div>
                            <!-- Mobile -->
                            <div class="col-md-6 form-group">
                                <label>Mobile No. (WhatsApp) <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control" placeholder="Mobile No." MaxLength="10"></asp:TextBox>
                                <div class="field-error">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMobileNo"
                                        ErrorMessage="Mobile number is required." Display="Dynamic" ForeColor="Red" ValidationGroup="n1" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMobileNo"
                                        ValidationExpression="^[6-9]\d{9}$"
                                        ErrorMessage="Enter valid 10-digit mobile number." Display="Dynamic" ForeColor="Red" ValidationGroup="n1" />
                                </div>
                            </div>
                            <!-- Gender -->
                            <div class="col-md-6 form-group">
                                <label>Gender <span class="text-danger">*</span></label>
                                <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <div class="field-error">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlGender"
                                        InitialValue="0" ErrorMessage="Gender is required." Display="Dynamic" ForeColor="Red" ValidationGroup="n1" />
                                </div>
                            </div>

                            <!-- Year of Passing -->
                            <div class="col-md-6 form-group">
                                <label>Year of Passing (12<sup>th</sup>) or equivalent <span class="text-danger">*</span></label>
                                <asp:DropDownList ID="ddlYearPassing" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <div class="field-error">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlYearPassing"
                                        InitialValue="0" ErrorMessage="Year is required." Display="Dynamic" ForeColor="Red" ValidationGroup="n1" />
                                </div>
                            </div>



                            <!-- Email -->
                            <div class="col-md-6 form-group">
                                <label>Email ID<span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email Address"></asp:TextBox>
                                <div class="field-error">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtEmail"
                                        ErrorMessage="Email is required." Display="Dynamic" ForeColor="Red" ValidationGroup="n1" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail"
                                        ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
                                        ErrorMessage="Enter valid email address." Display="Dynamic" ForeColor="Red" ValidationGroup="n1" />
                                </div>
                            </div>

                            <!-- City -->
                            <div class="col-md-6 form-group">
                                <label>City <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" placeholder="City"></asp:TextBox>
                                <div class="field-error">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCity"
                                        ErrorMessage="City is required." Display="Dynamic" ForeColor="Red" ValidationGroup="n1" />
                                </div>
                            </div>

                            <!-- State -->
                            <div class="col-md-6 form-group">
                                <label>State <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtState" runat="server" CssClass="form-control" placeholder="State"></asp:TextBox>
                                <div class="field-error">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtState"
                                        ErrorMessage="State is required." Display="Dynamic" ForeColor="Red" ValidationGroup="n1" />
                                </div>
                            </div>

                            <!-- Country -->
                            <div class="col-md-6 form-group">
                                <label>Country <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtCountry" runat="server" CssClass="form-control" placeholder="Country"></asp:TextBox>
                                <div class="field-error">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCountry"
                                        ErrorMessage="Country is required." Display="Dynamic" ForeColor="Red" ValidationGroup="n1" />
                                </div>
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
                            <%--   <div class="col-md-6 form-group">
                                <label>No. of Persons <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtPersons" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPersons"
                                    ErrorMessage="Number of persons is required." Display="Dynamic" ForeColor="Red" />
                            </div>--%>

                            <!-- T-Shirt Size -->
                            <div class="col-md-6 form-group">
                                <label>T-Shirt Size <span class="text-danger">*</span></label>
                                <asp:DropDownList ID="ddlTshirtSize" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <div class="field-error">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlTshirtSize"
                                        InitialValue="0" ErrorMessage="T-Shirt size is required." Display="Dynamic" ForeColor="Red" ValidationGroup="n1" />
                                </div>
                            </div>

                            <%-- Add Images --%>

                            <div class="col-md-12 form-group">
                                <div class="row photo-upload-wrapper">

                                    <div class="col-md-3">
                                        <div class="preview-section">
                                            <asp:Image ID="imgPhoto"
                                                runat="server"
                                                CssClass="profile-preview"
                                                ImageUrl="~/images/noimage.png" />
                                        </div>
                                    </div>

                                    <div class="col-md-6">
                                        <div class="upload-section">


                                            <div class="upload-status mt-3">
                                                <asp:Image ID="imgPhotoSuccessError"
                                                    runat="server"
                                                    CssClass="status-pic" />

                                            </div>
                                            <label class="photo-label">Applicant Photo</label>
                                            <asp:FileUpload ID="fuMemberPhoto"
                                                runat="server"
                                                CssClass="form-control mb-2" />
                                            <asp:Label ID="lblPHotoMsg"
                                                runat="server"
                                                CssClass="photo-msg"></asp:Label>
                                            <p style="margin-bottom: 0px; color: #000">Photo size should be less than <b>50 KB</b></p>
                                            <p style="color: #000">Photo format should be <b>.jpg, .jpeg, .png</b></p>

                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <label class="photo-label">Action</label>
                                        <asp:Button ID="btnUpload"
                                            runat="server"
                                            CssClass="btn btn-success"
                                            Text="Upload Photo"
                                            OnClick="btnUpload_Click" />
                                    </div>


                                </div>
                            </div>

                            <%-- Add Images --%>

                            <%-- Add Member --%>
                            <!-- ADD MEMBER BUTTON -->
                            <div class="col-md-12 text-left mt-2">
                                <button type="button" class="btn btn-theme effect btn-md" onclick="showMemberForm()">
                                    + Add Spouse / Children
                                </button>
                            </div>

                            <!-- MEMBER FORM -->
                            <div>

                                <div class="col-md-3 form-group mt-2">
                                    <label>Relation <span class="text-danger">*</span></label>
                                    <asp:DropDownList ID="ddlRelation" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlRelation_SelectedIndexChanged">
                                    </asp:DropDownList>

                                    <asp:RequiredFieldValidator ID="rfvRelation" runat="server"
                                        ControlToValidate="ddlRelation"
                                        InitialValue="0"
                                        ErrorMessage="Relation is required"
                                        ForeColor="Red" Display="Dynamic" ValidationGroup="r1" />
                                </div>

                                <div class="col-md-4 form-group">
                                    <label>Name <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtMemberName" runat="server" CssClass="form-control" />

                                    <asp:RequiredFieldValidator ID="rfvName" runat="server"
                                        ControlToValidate="txtMemberName"
                                        ErrorMessage="Name is required"
                                        ForeColor="Red" Display="Dynamic" ValidationGroup="r1" />
                                </div>

                                <div class="col-md-3 form-group">
                                    <label>Amount (₹)</label>
                                    <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control" ReadOnly="true" />
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                        ControlToValidate="txtAmount"
                                        ErrorMessage="Amount is required"
                                        ForeColor="Red" Display="Dynamic" ValidationGroup="r1" />
                                </div>

                                <div class="col-md-2 form-group">
                                    <label>Action</label>
                                    <asp:Button ID="btnAddMember" runat="server" class="btn btn-success" OnClick="btnAddMember_Click" validationgroup="r1" Text="add"  />
                                    <%--<asp:Button ID="btnAddMember" runat="server" class="btn btn-success" OnClientClick="addMember(); return false;" UseSubmitBehavior="false" Text="add" />--%>
                                    <%--<button type="button" class="btn btn-success" validationgroup="r1" onclick="addMember()">Add</button>--%>
                                </div>

                            </div>

                            <div class="col-md-12 form-group mt-2">
                                <table class="table table-sm table-bordered member-table" id="memberTable" style="margin-bottom: 0px;">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>Relation</th>
                                            <th>Name</th>
                                            <th>Amount (₹)</th>
                                            <th>Action</th>
                                        </tr>
                                    </thead>
                                    <tbody id="memberTableBody" runat="server"></tbody>
                                </table>
                            </div>

                            <div class="col-md-12 form-group mt-2">
                                <label class="font-weight-bold">Total Amount (₹)</label>
                                <asp:TextBox ID="txtTotalAmount" runat="server"
                                    CssClass="form-control total-amount-box"
                                    Text="0" ReadOnly="true" />
                            </div>


                            <%-- add member --%>


                            <div class="col-md-12 form-group mt-2">
                                <label class="checkbox-inline terms-line">
                                    <asp:CheckBox ID="cbTermCond" runat="server" />

                                    <span>I have read and agree to the  <a href="/terms-conditions" target="_blank">Terms and Conditions</a>
                                    </span>

                                </label>
                            </div>

                            <div class="col-md-12 text-center mt-4">
                                <asp:Button ID="btnRegister" runat="server"
                                    Text="Pay to Register"
                                    CssClass="btn btn-theme effect btn-md"
                                    OnClick="btnRegister_Click" ValidationGroup="n1" />



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
    <%--<script>
    let members = [];

    function addMember() {
        let ddl = document.getElementById("<%=ddlRelation.ClientID%>");
        let relationType = parseInt(ddl.value);
        let relationText = ddl.options[ddl.selectedIndex].text;
        let name = document.getElementById("<%=txtMemberName.ClientID%>").value;

        if (relationType === 0 || name.trim() === "") {
            alert("Please fill all member details");
            return;
        }

        members.push({
            RelationType: relationType,
            Name: name
        });

        document.getElementById("<%=hfMemberData.ClientID%>").value =
            JSON.stringify(members);

        renderTable();
        clearForm();
    }

    function renderTable() {
        let tbody = document.querySelector("#memberTable tbody");
        tbody.innerHTML = "";

        members.forEach((m, i) => {
            tbody.innerHTML += `
            <tr>
                <td>${i + 1}</td>
                <td>${m.RelationType == 1 ? 'Spouse' : 'Child'}</td>
                <td>${m.Name}</td>
                <td>Calculated on server</td>
                <td>
                    <button type="button" class="btn btn-sm btn-danger" onclick="removeMember(${i})">
                        Remove
                    </button>
                </td>
            </tr>`;
        });
    }

    function removeMember(index) {
        members.splice(index, 1);
        document.getElementById("<%=hfMemberData.ClientID%>").value =
            JSON.stringify(members);
        renderTable();
    }

    function clearForm() {
        document.getElementById("<%=ddlRelation.ClientID%>").value = "0";
        document.getElementById("<%=txtMemberName.ClientID%>").value = "";
    }
</script>--%>

    <%--<script>
        let memberCount = 0;
        let baseAmount = 3000;
        let totalAmount = baseAmount;

        document.addEventListener("DOMContentLoaded", function () {
            updateTotal();
        });

        function showMemberForm() {
            document.getElementById("memberForm").style.display = "block";
        }

        function setAmount() {
            let relationValue = document.getElementById("<%=ddlRelation.ClientID%>").value;
            let amount = 0;

           
            if (relationValue === "1") {  
                amount = 2000;
            }
            else if (relationValue === "2") { 
                amount = 0;
            }

            document.getElementById("<%=txtAmount.ClientID%>").value = amount;
        }

        function addMember() {
            let ddl = document.getElementById("<%=ddlRelation.ClientID%>");
            let relationValue = ddl.value;
            let relationText = ddl.options[ddl.selectedIndex].text;
            let name = document.getElementById("<%=txtMemberName.ClientID%>").value;
            let amount = parseInt(document.getElementById("<%=txtAmount.ClientID%>").value || 0);

            if (relationValue === "0" || name.trim() === "") {
                alert("Please fill all member details");
                return;
            }

            memberCount++;
            totalAmount += amount;

            let row = `
        <tr data-amount="${amount}">
            <td>${memberCount}</td>
            <td>${relationText}</td>
            <td>${name}</td>
            <td>${amount}</td>
            <td>
                <button type="button" class="btn btn-sm btn-danger" onclick="removeRow(this)">Remove</button>
            </td>
        </tr>`;

            document.querySelector("#memberTable tbody")
                .insertAdjacentHTML("beforeend", row);

            updateTotal();

            ddl.value = "0";
            document.getElementById("<%=txtMemberName.ClientID%>").value = "";
            document.getElementById("<%=txtAmount.ClientID%>").value = "";
            document.getElementById("memberForm").style.display = "none";
        }

        function removeRow(btn) {
            let row = btn.closest("tr");
            let amount = parseInt(row.getAttribute("data-amount")) || 0;

            row.remove();
            totalAmount -= amount;

            updateTotal();
            recalculateSerial();
        }

        function updateTotal() {
            document.getElementById("<%=txtTotalAmount.ClientID%>").value = totalAmount;
            document.getElementById("<%=btnRegister.ClientID%>").value =
                "Pay ₹" + totalAmount + " to Register";
        }

        function recalculateSerial() {
            memberCount = 0;
            document.querySelectorAll("#memberTable tbody tr").forEach(row => {
                memberCount++;
                row.cells[0].innerText = memberCount;
            });
        }
    </script>--%>


    <%-- <asp:Button ID="PayTest" runat="server"
                                    Text="Pay"
                                    CssClass="btn btn-theme effect btn-md"
                                    OnClick="PayTest_Click" />--%>
</asp:Content>
