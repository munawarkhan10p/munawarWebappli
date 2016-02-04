<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="frmCreateChartAccounts.aspx.cs" Inherits="WebApplication2.frmChartOA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Container" runat="server">
      <div class="row" style="background-color:cadetblue">
        <div class="col-sm-10 col-md-offset-1" style="background-color:chocolate">


              <br />
                                    <h3><strong>CHART OF ACCOUNTS</strong> </h3>
 
            <hr />
            <%-- <asp:RegularExpressionValidator ID="AccoutnCodeRegularExpressionValidator" runat="server" BackColor="#FFFF99" BorderColor="White" ControlToValidate="txtAccountCode" ErrorMessage="" ValidationExpression="\d+"></asp:RegularExpressionValidator>--%>
            <br />
              <%-- buttons payments and receipt --%>
        
            <br />
              <div class="form-group input-group">

                                        <%-- dropdownlist Account Type --%>
                                            <span class="input-group-addon"><i class="fa fa-tag"  ></i></span>
                                          <asp:DropDownList ID="ddlAccountType" runat="server" CssClass="form-control input-lg" placeholder="Account Type"
                                            Width="290px" TabIndex="3" AutoPostBack="True" OnSelectedIndexChanged="ddlAccountType_SelectedIndexChanged">
                                              <asp:ListItem Value="1">Select Account Type</asp:ListItem>
                                            
                                            </asp:DropDownList>  
                 
                                        <%-- Dropdownlist ChildOf --%>
                                            <span class="input-group-addon">@</span>
                                         <asp:DropDownList ID="ddlChildOf" runat="server" CssClass="form-control input-lg" placeholder="Child Of"
                                            Width="290px" TabIndex="4" AutoPostBack="True" OnSelectedIndexChanged="ddlChildOf_SelectedIndexChanged">
                                                  <asp:ListItem Value="1">Select Child Of</asp:ListItem>
                                               
                                             </asp:DropDownList>
                   <asp:Label ID="lblSourceID" runat="server" Text=""></asp:Label>
                                        </div>

            <br />
                <div class="form-group input-group">
                <span class="input-group-addon"><i class="fa fa-circle-o-notch"></i></span>
                <asp:TextBox ID="txtAccountCode" runat="server" CssClass="form-control input-lg" placeholder="Enter Account Code"
                    Width="290px" TabIndex="1"></asp:TextBox>

                <span class="input-group-addon"><i class="fa fa-circle-o-notch"></i></span>
                <asp:TextBox ID="TxtAccountName" runat="server" CssClass="form-control input-lg" placeholder="Enter Account Name"
                    Width="290px" TabIndex="2"></asp:TextBox>

            </div>  
            <%-- **************************************************Panel Start************************************************** --%>
                         <asp:Panel ID="Panel1" runat="server" Visible="False">
                
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
                        </asp:Panel>
            <div class="form-group input-group">
                                           
                                            <asp:CheckBox ID="cbParent" runat="server"  placeholder="IsParent"
                                            Width="92px" TabIndex="5" Text="IsParent " TextAlign="Left" BorderColor="White" BorderStyle="Solid" CssClass="alert-dismissible" Height="49px"></asp:CheckBox>
                 <asp:CheckBox ID="cbIsActive" runat="server"  placeholder="IsParent"
                                            Width="92px" TabIndex="5" Text="IsActive"  TextAlign="Left" BorderColor="White" BorderStyle="Solid" CssClass="alert-dismissible" Height="49px"></asp:CheckBox>
                                        </div>
                                    <asp:Button ID="btnSubmit"   runat="server" TabIndex="6" CssClass="btn btn-success" Text="Submit" OnClick="btnSubmit_Click" Visible="False"  />
                                   <asp:Button ID="btnMoreControl" runat="server" CssClass="btn btn-success" Text="Details" OnClick="btnMoreControl_Click"  />
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-success" Text="Update" OnClick="btnUpdate_Click" Visible="False"  />
            <asp:Button ID="btnBack" runat="server" CssClass="btn btn-success" Text="Back" OnClick="btnBack_Click" Visible="False" />

            <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                                    <hr />
                                    Already Registered ?  <a href="login.html" >Search here</a>
                                    
                            </div>








            </div>
        
</asp:Content>
