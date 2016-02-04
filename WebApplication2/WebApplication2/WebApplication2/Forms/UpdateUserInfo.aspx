<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="UpdateUserInfo.aspx.cs" Inherits="WebApplication2.UpdateUserInfo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>



<asp:Content ID="Content2" ContentPlaceHolderID="contentHeader" runat="server">

    <!--FOr Image Preview -->
   
    <script type="text/javascript">
        function ShowPreview(input) {
            if (input.files && input.files[0]) {
                var ImageDir = new FileReader();
                ImageDir.onload = function (e) {
                    $('#UserImg').attr('src', e.target.result);
                }
                ImageDir.readAsDataURL(input.files[0]);
            }
        }
    </script>
    <!-- END----- FOr Image Preview -->
    <!-- Start Ifram ----- Styles -->
    <style type="text/css">
        .Background {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .Popup {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 400px;
            height: 350px;
        }

        .lbl {
            font-size: 16px;
            font-style: italic;
            font-weight: bold;
        }
    </style>
    <!-- End Ifram ----- Styles -->
    <script>
        function myFunction() {
            location.reload();
        }
    </script>

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Container" runat="server">
    <div class="row" style="background-color: cadetblue">
        <div class="col-sm-10 col-md-offset-1" style="background-color: chocolate">

            <br />
            <h3><strong>Update UserInformation...</strong></h3>
            <hr />


            &nbsp;<asp:Image ID="UserImg" runat="server" Height="150px" ImageUrl="~/assets/img/defaultUser.jpg" Width="150px" ImageAlign="Middle" />

            &nbsp;<br />
            <br />


            &nbsp;<asp:Button ID="browseImg" runat="server" Text="Browse Image" OnClick="browseImg_Click" Height="23px" Width="148px" />
            &nbsp;
                          
                    
                           
            <ajaxToolkit:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="browseImg"
                                CancelControlID="Button2" BackgroundCssClass="Background"></ajaxToolkit:ModalPopupExtender>

            <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" Style="display: none; width: 850px; height: 650px">
                <iframe style="width: 800px; height: 600px" id="irm1" src="WebForm1.aspx" runat="server"></iframe>
                <br />
                <asp:Button ID="Button2" CssClass="btn btn-success" runat="server" Text="Close" OnClick="Button2_Click" OnClientClick="myFunction()" />
            </asp:Panel>

            <asp:Button ID="btnUseDefault" runat="server" Height="22px" OnClick="btnUseDefault_Click" Text="Use Default" Width="128px" />
            <br />
            <br />


            <br />

            <div class="form-group input-group">
                <span class="input-group-addon"><i class="fa fa-circle-o-notch"></i></span>
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control input-lg validate[required]" placeholder="First Name"
                    Width="290px" TabIndex="1"></asp:TextBox>

                <span class="input-group-addon"><i class="fa fa-circle-o-notch"></i></span>
                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control input-lg validate[required]" placeholder="LastName"
                    Width="290px" TabIndex="2"></asp:TextBox>

            </div>
            <br />

            <div class="form-group input-group">


                <span class="input-group-addon"><i class="fa fa-tag"></i></span>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control input-lg validate[required,custom[email]]" placeholder="Email Adddress"
                    Width="290px" TabIndex="2"></asp:TextBox>


                <span class="input-group-addon">@</span>
                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control input-lg validate[required]" placeholder="Phone Number"
                    Width="290px" TabIndex="2"></asp:TextBox>

            </div>
            <br />

            <div class="form-group input-group">

                <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control input-lg validate[required]" TextMode="Password" placeholder="Password"
                    Width="290px" TabIndex="7" ClientIDMode="Static"></asp:TextBox>

                <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                <asp:TextBox ID="txtConfirmPass" runat="server" CssClass="form-control input-lg validate[required,equals[txtPassword]]" TextMode="Password" placeholder="Confirm Password"
                    Width="290px" TabIndex="8"></asp:TextBox>

            </div>
            <br />

            <div class="form-group input-group">
                <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                <asp:DropDownList ID="ddlQuestion1" Width="290px" runat="server" CssClass="form-control input-lg" placeholder="Question 1">
                    <asp:ListItem>Select Question</asp:ListItem>
                </asp:DropDownList>


                <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                <asp:TextBox ID="txtAnswer1" runat="server" CssClass="form-control input-lg validate[required]" placeholder="your Answer 1"
                    Width="290px" TabIndex="12"></asp:TextBox>

            </div>
            <br />
            <div class="form-group input-group">

                <span class="input-group-addon"><i class="fa fa-lock"></i></span>

                <asp:DropDownList ID="ddlQuestion2" Width="290px" runat="server" CssClass="form-control input-lg" placeholder="Question 2">
                    <asp:ListItem>Select Question</asp:ListItem>
                </asp:DropDownList>

                <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                <asp:TextBox ID="txtAnswer2" runat="server" CssClass="form-control input-lg validate[required]" placeholder="your Answer 2"
                    Width="290px" TabIndex="11"></asp:TextBox>
            </div>
            <br />
            <hr />
            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-success" Text="Update" OnClick="btnSubmit_Click1" />
        </div>

    </div>

</asp:Content>
<%--  --%>