<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="WebApplication2.Forget_Password" EnableEventValidation="false" %>

<!DOCTYPE html5>
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




    <link href="../chkValidationData/validationEngine.jquery.css" rel="stylesheet" />
    <script src="../chkValidationData/jquery-1.8.2.min.js"></script>
    <script src="../assets/js/bootstrap.min.js"></script>
    <script src="../chkValidationData/jquery.validationEngine-en.js"></script>
    <script src="../chkValidationData/jquery.validationEngine.js"></script>
 
    <script>
        jQuery(document).ready(function () {
            // binds form submission and fields to the validation engine
            jQuery("#contactForm").validationEngine('attach', { promptPosition: "topRight" });
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
            <div class="row text-center  ">
                <div class="col-md-12">
                    <br />
                    <br />
                    <h2>SMIU Accounts System : Forget Password</h2>

                    <h5>( Register User to get access )</h5>
                    <br />
                </div>
            </div>
            <div class="row">

                <div class="col-md-4 col-md-offset-4 col-sm-6 col-sm-offset-3 col-xs-10 col-xs-offset-1">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <strong>User Password ? Recovery   </strong>
                        </div>
                        <div class="panel-body">

                            <br />
                            <div class="form-group input-group">
                                <asp:RadioButton ID="byUserName" runat="server" GroupName="RetrivePassBy" Text="By UserName " AutoPostBack="True" Checked="True" />&nbsp;<asp:RadioButton ID="byEmail" runat="server" GroupName="RetrivePassBy" Text=" By EmailId" AutoPostBack="True" />
                            </div>
                            <div class="form-group input-group">
                                <span class="input-group-addon"><i class="fa fa-circle-o-notch"></i></span>
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control input-lg validate[groupRequired[gettingdata]]" placeholder="User Name"
                                    Width="290px" TabIndex="1" OnTextChanged="txtUserName_TextChanged" AutoPostBack="True"> </asp:TextBox>
                            </div>
                            <div class="form-group input-group">
                                <span class="input-group-addon"><i class="fa fa-circle-o-notch"></i></span>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control input-lg validate[groupRequired[gettingdata],custom[email]]" placeholder="Email Address"
                                    Width="290px" TabIndex="1" OnTextChanged="txtUserEmail_TextChanged" AutoPostBack="True" Enabled="false"> </asp:TextBox>
                            </div>
                            <div class="form-group input-group">
                                <span class="input-group-addon"><i class="fa fa-circle-o-notch"></i></span>
                                <input id="txtQuestion1" name="txtQuestion1" class="form-control input-lg" placeholder="Question 1" type="text" runat="server" width="290px" />

                                <%--<asp:TextBox ID="txtQuestion1" runat="server" CssClass="form-control input-lg" placeholder="Question 1"
                                        Width="290px" TabIndex="1"></asp:TextBox>--%>
                            </div>
                            <div class="form-group input-group">
                                <span class="input-group-addon"><i class="fa fa-circle-o-notch"></i></span>
                                <input id="txtAnswer1" name="txtAnswer1" class="form-control input-lg validate[condRequired[txtQuestion1]]" placeholder="Your Answer here" type="text" runat="server" width="290px" />
                                <%--<asp:TextBox ID="txtAnswer1" runat="server" CssClass="form-control input-lg " placeholder="Your Answer here"
                                        Width="290px" TabIndex="1"></asp:TextBox>--%>
                            </div>
                            <div class="form-group input-group">
                                <span class="input-group-addon"><i class="fa fa-tag"></i></span>
                                <input class="form-control input-lg" type="text" name="txtQuestion2" id="txtQuestion2" width="290px" placeholder="Question 2" runat="server" />
                                <%--<asp:TextBox ID="txtQuestion2" runat="server" CssClass="form-control input-lg validate[required]" placeholder="Question 2"
                                        Width="290px" TabIndex="1"></asp:TextBox>--%>
                            </div>
                            &nbsp;<div class="form-group input-group">
                                <span class="input-group-addon"><i class="fa fa-tag"></i></span>
                                <input class="form-control input-lg validate[condRequired[txtQuestion2]]" type="text" name="txtAnswer2" id="txtAnswer2" width="290px" placeholder="Your Answer here" runat="server" />
                                <%--<asp:TextBox ID="txtAnswer2" runat="server" CssClass="form-control input-lg validate[condRequired[txtQuestion2]]" placeholder="Your Answer here"
                                        Width="290px" TabIndex="1"></asp:TextBox>--%>
                            </div>
                            <asp:Button ID="Button1" runat="server" CssClass=" btn btn-success" Text="Submit" OnClick="Button1_Click" />

                            &nbsp;

                            Already Registered ?  <a href="Login.aspx">Login here</a>



                        </div>

                    </div>
                </div>





            </div>
        </div>
    </form>

</body>

</html>
