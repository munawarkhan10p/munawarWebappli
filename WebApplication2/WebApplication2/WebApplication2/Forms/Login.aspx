<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication2.Login" EnableEventValidation="false" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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

    
    <link href="../assets/ValidationEngine.css" rel="stylesheet" />
    <script src="../assets/jquery.min.js"></script>
    <script src="../assets/jquery.validationEngine-en.js"></script>
    <script src="../assets/jquery.validationEngine.js"></script>
    
    
    <script type="text/javascript">
        $(function () {
            $("#contactForm").validationEngine('attach', { promptPosition: "topRight" });
        });
     
    </script>
    <script src="../assets/jquery-1.12.0.js"></script>
    <script src="../assets/js/bootstrap.min.js"></script>
    <script src="../chkValidationData/jquery.validationEngine-en.js"></script>
    <script src="../chkValidationData/jquery.validationEngine.js"></script>
</head>
<body>
    
     
    <form runat="server" data-toggle="validator" role="form" id="contactForm">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <!-- Bootstrap Modal Dialog -->
        <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title">
                                    <asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                            </div>
                            <div class="modal-body">
                                <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="modal-footer">
                                <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <!-- Bootstrap Modal End -->
        <div class="container">
            <div class="row text-center ">
                <div class="col-md-12">
                    <br />
                    <br />
                    <h2>SMIU Accounts System : Login</h2>

                    <h5>( Login yourself to get access )</h5>
                    <br />
                </div>
            </div>
            <div class="row ">

                <div class="col-md-4 col-md-offset-4 col-sm-6 col-sm-offset-3 col-xs-10 col-xs-offset-1">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <strong>Enter Details To Login </strong>
                        </div>
                        <div class="panel-body">
                            <form role="form">
                                <br />

                                <div class="form-group input-group">
                                    
                                    <span class="input-group-addon"><i class="fa fa-tag"></i></span>
                                    <asp:TextBox ID="txtLoginName" runat="server" CssClass="form-control input-lg text-box text-danger validate[required]" placeholder="Your Username"
                                        Width="290px" TabIndex="1"></asp:TextBox>

                                </div>

                                <div class="form-group input-group">
                                    <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                                    <asp:TextBox ID="txtLoginPassword" TextMode="Password" runat="server" CssClass="form-control input-lg validate[required]" placeholder="Your Password"
                                        Width="290px" TabIndex="1"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <%--<label class="checkbox-inline">
                                                <input type="checkbox" /> Remember me
                                            </label>--%>
                                    <span class="pull-right">
                                        <a href="ForgetPassword.aspx">Forget password ? </a>
                                    </span>
                                </div>
                                <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-success" Text="Login Now" OnClick="btnLogin_Click" />
                                <hr />
                                Not register ? <a href="Registeration.aspx">click here </a>
                                
                            </form>
                        </div>
                        
                    </div>
                </div>


            </div>
        </div>
       
    </form>
  <%--  <!-- SCRIPTS -AT THE BOTOM TO REDUCE THE LOAD TIME-->
    <!-- JQUERY SCRIPTS -->
    <script src="~/assets/js/jquery-1.10.2.js"></script>
    <!-- BOOTSTRAP SCRIPTS -->
    <script src="~/assets/js/bootstrap.min.js"></script>
    <!-- METISMENU SCRIPTS -->
    <script src="~/assets/js/jquery.metisMenu.js"></script>
    <!-- CUSTOM SCRIPTS -->
    <script src="~/assets/js/custom.js"></script>--%>

</body>
</html>
