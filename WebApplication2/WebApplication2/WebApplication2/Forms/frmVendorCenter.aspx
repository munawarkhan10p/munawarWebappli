<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="frmVendorCenter.aspx.cs" Inherits="WebApplication2.Forms.frmVendorCenter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Container" runat="server">
    <div class="row" style="background-color:cadetblue">
        <div class="col-sm-10 col-md-offset-1" style="background-color:chocolate">

  <br />
                                    <h3><strong> VENDOR CENTER </strong> </h3>
 
            <hr />
            <br />
                    <asp:Button ID="btnAddNewVendors" runat="server"  CssClass="btn btn-success" Text="Add New Vendors" OnClick="btnAddNewVendors_Click" />

             <br />
            <br />
            



            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" Height="157px" Width="1065px">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("VendorId") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblVendorId" runat="server" Text='<%# Bind("VendorId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="VendorCode" HeaderText="Account Code" />
                    <asp:BoundField DataField="VendorName" HeaderText="Vendor Name" />
                    <asp:BoundField DataField="MobileNumber" HeaderText="Mobile Number" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Designation" HeaderText="Designation" />
                    <asp:TemplateField HeaderText="IsActive">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("IsActive") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Eval("IsActive") %>' Enabled="False" OnCheckedChanged="CheckBox1_CheckedChanged" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:HyperLink ID="hypVendor" runat="server" NavigateUrl="frmCreateVendors.aspx" Enabled="False">Edit</asp:HyperLink>
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

















            <hr />

            <br />



            </div>
        </div>










</asp:Content>
