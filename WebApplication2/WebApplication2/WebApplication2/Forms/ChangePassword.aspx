<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="WebApplication2.ChangePassword" EnableEventValidation="false" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html5>
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
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
    <!--FOr Image Preview -->
    <script src="~/assets/js/morris/jquery-1.10.2.js" type="text/javascript"></script>
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


</head>
<body>
    <form runat="server">
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
                            &nbsp;<asp:Image ID="UserImg" runat="server" Height="118px" ImageUrl="~/assets/img/defaultUser.jpg" Width="144px" ImageAlign="Middle" />

                            &nbsp;<br />
                            <br />
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                            &nbsp;<asp:Button ID="browseImg" runat="server" Text="Browse Image" OnClick="browseImg_Click" Height="23px" Width="148px" />
                            &nbsp;
                            
                            <%--  --%>
                            <ajaxToolkit:ModalPopupExtender id="mp1" runat="server" popupcontrolid="Panl1" targetcontrolid="browseImg"
                                cancelcontrolid="Button2" backgroundcssclass="Background" ></ajaxToolkit:ModalPopupExtender>
                          
                            <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" Style="display: none; width: 850px; height:650px" >
                                <iframe style="width: 800px; height:600px" id="irm1" src="WebForm1.aspx" runat="server">
                                   
                                </iframe>
                                <br />
                                <asp:Button ID="Button2" runat="server" Text="Close" OnClick="Button2_Click" OnClientClick="myFunction()"/>
                            </asp:Panel>

                            <asp:Button ID="btnUseDefault" runat="server" Height="22px" OnClick="btnUseDefault_Click" Text="Use Default" Width="128px" />
                            <br />

                            <br />


                            <form role="form">


                                <br />


                                <div class="form-group input-group">
                                    <span class="input-group-addon"><i class="fa fa-tag"></i></span>
                                    <asp:DropDownList ID="ddlQuestion1" runat="server" CssClass="form-control input-lg" placeholder="Question 1">
                                        <asp:ListItem>Select Role</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group input-group">
                                    <span class="input-group-addon"><i class="fa fa-circle-o-notch"></i></span>
                                    <asp:TextBox ID="txtAnswer1" runat="server" CssClass="form-control input-lg" placeholder="Your Answer here"
                                        Width="290px" TabIndex="1"></asp:TextBox>
                                </div>
                                <div class="form-group input-group">
                                    <span class="input-group-addon"><i class="fa fa-tag"></i></span>
                                    <asp:DropDownList ID="ddlQuestion2" runat="server" CssClass="form-control input-lg" placeholder="Question 2">
                                        <asp:ListItem>Select Role</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <div class="form-group input-group">
                                    <span class="input-group-addon"><i class="fa fa-tag"></i></span>
                                    <asp:TextBox ID="txtAnswer2" runat="server" CssClass="form-control input-lg" placeholder="Your Answer here"
                                        Width="290px" TabIndex="1"></asp:TextBox>
                                </div>
                                <div class="form-group input-group">
                                    <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                                    <asp:TextBox ID="txtnewpass" runat="server" CssClass="form-control input-lg" placeholder="Enter Password"
                                        Width="290px" TabIndex="1"></asp:TextBox>
                                </div>
                                <div class="form-group input-group">
                                    <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                                    <asp:TextBox ID="txtconfirmnewpass" runat="server" CssClass="form-control input-lg" placeholder="Retype Password"
                                        Width="290px" TabIndex="1"></asp:TextBox>

                                </div>


                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" Text="Submit" OnClick="Button1_Click" />
                                <hr />
                                Already Registered ?  <a href="login.html">Login here</a>
                            </form>
                        </div>

                    </div>
                </div>




            </div>
        </div>
    </form>

    <!-- SCRIPTS -AT THE BOTOM TO REDUCE THE LOAD TIME-->
    <!-- JQUERY SCRIPTS -->
    <script src="../assets/js/jquery-1.10.2.js"></script>
    <!-- BOOTSTRAP SCRIPTS -->
    <script src="../assets/js/bootstrap.min.js"></script>
    <!-- METISMENU SCRIPTS -->
    <script src="../assets/js/jquery.metisMenu.js"></script>
    <!-- CUSTOM SCRIPTS -->
    <script src="../assets/js/custom.js"></script>

</body>
</html>
