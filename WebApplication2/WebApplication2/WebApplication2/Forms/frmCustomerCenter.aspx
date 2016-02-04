<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="frmCustomerCenter.aspx.cs" Inherits="WebApplication2.frmCustomerCenter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Container" runat="server">
     <div class="row" style="background-color:cadetblue">
        <div class="col-sm-10 col-md-offset-1" style="background-color:chocolate">

  <br />
                                    <h3><strong> CUSTOMER CENTER </strong> </h3>
 
            <hr />
            <br />
              <asp:Button ID="btnAddNewCustomer" runat="server" CssClass="btn btn-success" Text="ADD New Customer" OnClick="Button1_Click" />
  <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="1077px" CellSpacing="2" Height="154px" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CustomerId") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblCustomerId" runat="server" Text='<%# Bind("CustomerId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CustomerCode" HeaderText="Account Code" />
                    <asp:BoundField DataField="CutomerName" HeaderText="Customer Name" />
                    <asp:BoundField DataField="MobileNumber" HeaderText="Mobile Number" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Designation" HeaderText="Designation" />
                    <asp:TemplateField HeaderText="IsActive">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("IsActive") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1"  runat="server" Checked='<%# Eval("IsActive") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:HyperLink ID="hypCustomer" runat="server" NavigateUrl="frmCreateCustomer.aspx">Edit</asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                <SortedDescendingHeaderStyle BackColor="#93451F" />
            </asp:GridView>


            <br />
            <br />
            <hr />
            </div>
         </div>
</asp:Content>
