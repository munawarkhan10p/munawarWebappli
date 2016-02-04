<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="frmCreateCustomer.aspx.cs" Inherits="WebApplication2.frmCreateCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Container" runat="server">
     <div class="row" style="background-color:cadetblue">
        <div class="col-sm-10 col-md-offset-1" style="background-color:chocolate">

  <br />
                                    <h3><strong>CREATE CUSTOMER</strong> </h3>
           
            <hr />
            
            
  <br />
            <br />
               <%-- buttons payments and receipt --%>
                                            <div class="form-group input-group" >
                                            <span class="input-group-addon"><i class="fa fa-circle-o-notch"  ></i></span>
                                            <asp:TextBox ID="txtAccountCode" runat="server" CssClass="form-control input-lg" placeholder="Enter Account Code"
                                            Width="290px" TabIndex="1"></asp:TextBox>
                                                <asp:Label ID="lblSourceID" runat="server" Text=""></asp:Label>

                                     <%-- buttons payments and receipt --%>
                                           
                                            <span class="input-group-addon"><i class="fa fa-circle-o-notch"  ></i></span>
                                            <asp:TextBox ID="TxtAccountName" runat="server" CssClass="form-control input-lg" placeholder="Enter Account Name"
                                            Width="290px" TabIndex="2"></asp:TextBox>

                                                
                                        </div>
              
 
            
           
             
                                      <div class="form-group input-group">

                                          <%-- textbox Mobile Number --%>
                                            <span class="input-group-addon"><i class="fa fa-lock"  ></i></span>
                                           <asp:TextBox ID="txtMobileNumber" runat="server"  CssClass="form-control input-lg" placeholder="Please Enter Mobile Number"
                                            Width="290px" TabIndex="7"></asp:TextBox>  <%-- Mobile Number Validation --%>              
                                     
                                           <%-- textbox Fax Number --%>
                                           <span class="input-group-addon"><i class="fa fa-lock"  ></i></span>
                                           <asp:TextBox ID="txtFaxNumber" runat="server"  CssClass="form-control input-lg" placeholder="Please Enter Fax Number"
                                            Width="290px" TabIndex="8"></asp:TextBox>
                      <%-- Fax number Validation --%>      
                                        </div>
            <br />

                              <div class="form-group input-group">
                                      <%-- textbox cnic --%>
                                      <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                                      <asp:TextBox ID="txtCnic" runat="server" CssClass="form-control input-lg" placeholder="Please Enter CNIC"
                                          Width="290px" TabIndex="9"></asp:TextBox>
                                     
                                    <%-- textbox Email --%>
                                      <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                                      <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control input-lg" placeholder="Please Enter Email"
                                          Width="290px" TabIndex="10"></asp:TextBox>
                                     
                                    </div>

            <br />

                          <div class="form-group input-group">
                                                 <%-- textbox Person Name --%>
                                            <span class="input-group-addon"><i class="fa fa-lock"  ></i></span>
                                           <asp:TextBox ID="txtContactPersonName" runat="server"  CssClass="form-control input-lg" placeholder="Please Enter Contact Person Name"
                                            Width="290px" TabIndex="11"></asp:TextBox>  
                                           <%-- textbox Designation --%>
                                                  <span class="input-group-addon"><i class="fa fa-lock"  ></i></span>
                                           <asp:TextBox ID="txtDesignation" runat="server"  CssClass="form-control input-lg" placeholder="Please Enter Designation"
                                            Width="290px" TabIndex="12"></asp:TextBox> 
                                 </div>
            <br />
                               <div class="form-group input-group">
                                            <%-- textbox city --%>
                                            <span class="input-group-addon"><i class="fa fa-lock"  ></i></span>
                                           <asp:TextBox ID="txtCity" runat="server"  CssClass="form-control input-lg" placeholder="Please Enter City"  
                                            Width="290px" TabIndex="13"></asp:TextBox> 


                                    <span class="input-group-addon"><i class="fa fa-circle-o-notch"  ></i></span>
                                              <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control input-lg" placeholder="Enter Address"
                                                  Width="290px" TabIndex="4" TextMode="MultiLine"></asp:TextBox>
                                        </div>
            <br />

                                  <div class="form-group input-group">
                                           
                                            
                                           <%-- chechbox IsActive --%>
                                            <asp:CheckBox ID="cbIsActive" runat="server" Checked="true"  placeholder="IsActive"
                                            Width="92px" TabIndex="1" Text="IsActive" TextAlign="Left" BorderColor="White" BorderStyle="Solid" CssClass="alert-dismissible" Height="49px"></asp:CheckBox>

                                        </div>
                                    <asp:Button ID="btnSubmit"   runat="server" CssClass="btn btn-success" Text="Submit" OnClick="btnSubmit_Click1" Visible="False"  /> 
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-success" Text="Update" OnClick="btnUpdate_Click" Visible="False" />    
                                    <asp:Button ID="bntBack" runat="server" CssClass="btn btn-success" Text="Back" OnClick="bntBack_Click" />
                                    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
               <hr />
                                    Already Registered ?  <a href="login.html" >Search here</a>
                                    
                            </div>













            </div>
        



</asp:Content>
