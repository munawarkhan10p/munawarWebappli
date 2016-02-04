<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="changepasswordinside.aspx.cs" Inherits="WebApplication2.changepasswordinside" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Container" runat="server">

     <div class="container">
        <div class="row text-center ">
            <div class="col-md-12">
                <br /><br />
                <h2> SMIU Accounts System</h2>
               
                <h5>( Login yourself to get access )</h5>
                 <br />
            </div>
        </div>
         <div class="row ">
               
                  <div class="col-md-4 col-md-offset-4 col-sm-6 col-sm-offset-3 col-xs-10 col-xs-offset-1">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                        <strong>   Enter Details To Change Password </strong>  
                            </div>
                            <div class="panel-body">
                                <form role="form">
                                       <br />
                                     <div class="form-group input-group">
                                            <span class="input-group-addon"><i class="fa fa-tag"  ></i></span>
                                            <asp:TextBox ID="txtOldPassword" runat="server" CssClass="form-control input-lg" placeholder="Old Password"
                                            Width="290px" TabIndex="1"></asp:TextBox>
                                        </div>
                                      <div class="form-group input-group">
                                            <span class="input-group-addon"><i class="fa fa-lock"  ></i></span>
                                             <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control input-lg" placeholder="New Password"
                                            Width="290px" TabIndex="2"></asp:TextBox>
                                        </div>
                                    <div class="form-group input-group">
                                            <span class="input-group-addon"><i class="fa fa-lock"  ></i></span>
                                             <asp:TextBox ID="txtReTypePassword" runat="server" CssClass="form-control input-lg" placeholder="ReType Password"
                                            Width="290px" TabIndex="3"></asp:TextBox>
                                        </div>
                                    <div class="form-group">
                                        
                                            <span class="pull-right">
                                                   <a href="#" >Forget password ? </a> 
                                            </span>
                                        </div>
                                     
                                    <asp:Button ID="btnLogin"   runat="server" TabIndex="4" CssClass="btn btn-success" Text="Submit"  />
                                    <hr />
                                    Not register ? <a href="registeration.html" >click here </a> 
                                    </form>
                            </div>
                           
                        </div>
                    </div>
                
                
        </div>
    </div>

</asp:Content>
