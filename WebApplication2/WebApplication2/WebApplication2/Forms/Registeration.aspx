<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registeration.aspx.cs" Inherits="WebApplication2.Registeration" EnableEventValidation="false" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Free Bootstrap Admin Template : Binary Admin</title>
    <!-- BOOTSTRAP STYLES-->
    <link href="../assets/css/bootstrap.css" rel="stylesheet" />
    <!-- FONTAWESOME STYLES-->
    <link href="../assets/css/font-awesome.css" rel="stylesheet" />
    <!-- CUSTOM STYLES-->
    <link href="../assets/css/custom.css" rel="stylesheet" />
    <!-- GOOGLE FONTS-->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />


   <link href="../assets/ValidationEngine.css" rel="stylesheet" />
    <script src="../assets/jquery.min.js"></script>
    <script src="../assets/jquery.validationEngine-en.js"></script>
    <script src="../assets/jquery.validationEngine.js"></script>
    
    
    <script type="text/javascript">
        $(function () {
            $("#contactForm").validationEngine('attach', { promptPosition: "topRight" });
        });
    </script>


</head>
<body>
    <form runat="server" id="contactForm" role="form" data-toggle="validator" > 
        <div class="container">
            <div class="row text-center  ">
                <div class="col-md-12">
                    <br />
                    <br />
                    <h2>SMIU Accounts System : Register</h2>

                    <h5>( Register User to get access )</h5>
                    <br />
                </div>
            </div>
            <div class="row">

                <div class="col-md-4 col-md-offset-4 col-sm-6 col-sm-offset-3 col-xs-10 col-xs-offset-1">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <strong>New User ? Registeration  </strong>
                        </div>
                        <div class="panel-body">
                            <br />


                            <div class="form-group input-group">
                                <span class="input-group-addon"><i class="fa fa-circle-o-notch"></i></span>
                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="validate[required] form-control input-lg " placeholder="First Name"
                                    Width="290px" TabIndex="1"></asp:TextBox>
                            </div>
                            <div class="form-group input-group">
                                <span class="input-group-addon"><i class="fa fa-circle-o-notch"></i></span>
                                <asp:TextBox ID="txtLastName" runat="server" CssClass="validate[required] form-control input-lg" placeholder="Last Name"
                                    Width="290px" TabIndex="1"></asp:TextBox>
                            </div>
                            <div class="form-group input-group">
                                <span class="input-group-addon"><i class="fa fa-tag"></i></span>
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="validate[required] form-control input-lg " placeholder="Desired Useruame"
                                    Width="290px" TabIndex="1"></asp:TextBox>
                            </div>
                            <div class="form-group input-group">
                                <span class="input-group-addon"><i class="fa fa-tag"></i></span>
                                <asp:DropDownList ID="ddlRole" runat="server" CssClass="validate[required] form-control input-lg" placeholder="Select Role">
                                    <asp:ListItem>Select Role</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group input-group">
                                <span class="input-group-addon">@</span>
                                <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control input-lg validate[required]" placeholder="Your Mobile No"
                                    Width="290px" TabIndex="1"></asp:TextBox>
                            </div>
                            <div class="form-group input-group">
                                <span class="input-group-addon">@</span>
                                <asp:TextBox ID="txtPhoneNo" runat="server" CssClass="validate[required,custom[integer],maxSize[11],minSize[11]] form-control input-lg" placeholder="Your Phone No E.g 03222944044"
                                    Width="290px" TabIndex="1"></asp:TextBox>
                            </div>

                            <div class="form-group input-group">
                                <span class="input-group-addon">@</span>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control input-lg validate[required,custom[email]]" placeholder="Your Email"
                                    Width="290px" TabIndex="1"></asp:TextBox>
                            </div>
                            <div class="form-group input-group">
                                <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control input-lg validate[required]" placeholder="Enter Password"
                                    Width="290px" TabIndex="1"></asp:TextBox>
                            </div>
                            <div class="form-group input-group">
                                <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                                <asp:TextBox ID="txtRetypePassword" runat="server" TextMode="Password" CssClass="form-control input-lg validate[required,equals[txtPassword]]" placeholder="Retype Password"
                                    Width="290px" TabIndex="1"></asp:TextBox>

                            </div>


                            <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-success" Text="Register Me" OnClick="btnRegister_Click" />
                            <hr />
                            Already Registered ?  <a href="Login.aspx">Login here</a>

                        </div>

                    </div>
                </div>




            </div>
        </div>
    </form>


 <script src="~/assets/js/jquery-1.10.2.js"></script>
    <!-- BOOTSTRAP SCRIPTS -->
    <script src="~/assets/js/bootstrap.min.js"></script>
    <!-- METISMENU SCRIPTS -->
    <script src="~/assets/js/jquery.metisMenu.js"></script>
    <!-- CUSTOM SCRIPTS -->
    <script src="~/assets/js/custom.js"></script>

</body>
</html>
