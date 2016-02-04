<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="frmEditJvCbBb.aspx.cs" Inherits="WebApplication2.Forms.frmJvReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Container" runat="server">


    <div class="row" style="background-color:cadetblue">
        <div class="col-sm-10 col-md-offset-1" style="background-color:chocolate">
           <br />
                                    <h3><strong>Journal Voucher Reports Management</strong> </h3>
 
            <hr />
            <br />  
             <div class="form-group input-group" >
              
           <span class="input-group-addon"><i class="fa fa-circle-o-notch"  ></i></span>
            <asp:TextBox ID="txtVoucherNo" runat="server" CssClass="input-lg" placeholder="Enter Voucher No To Edit"></asp:TextBox>
                 <asp:Button ID="btnEdit" runat="server" Text="Search" CssClass="btn btn-success" OnClick="Button1_Click" />

                  
            <span class="input-group-addon"><i class="fa fa-circle-o-notch"  ></i></span>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="input-lg" placeholder="Enter Voucher No To Print"></asp:TextBox>
                  <asp:Button ID="btnPrint" runat="server" Text="Search" CssClass="btn btn-success" OnClick="Button1_Click" />
                 </div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" Height="217px" Width="897px">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                    <asp:BoundField DataField="TransactionId" HeaderText="TransactionId" SortExpression="TransactionId" />
                    <asp:BoundField DataField="AccountName" HeaderText="AccountName" SortExpression="AccountName" />
                    <asp:BoundField DataField="AccountCode" HeaderText="AccountCode" SortExpression="AccountCode" />
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                    <asp:BoundField DataField="Credit" HeaderText="Credit" SortExpression="Credit" />
                    <asp:BoundField DataField="Debit" HeaderText="Debit" SortExpression="Debit" />
                    <asp:BoundField DataField="VoucherNumber" HeaderText="VoucherNumber" SortExpression="VoucherNumber" />
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
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAllEmployes" TypeName="WebApplication2.Businesslayer.EmployeDataAccess" UpdateMethod="UpdateEmployees" OldValuesParameterFormatString="original_{0}" OnSelecting="ObjectDataSource1_Selecting" DeleteMethod="DeleteEmploye">
              
               <SelectParameters>
                   <asp:ControlParameter ControlID="txtVoucherNo" Name="VoucherNumber" PropertyName="Text" Type="String" />
               </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="TransactionId" Type="Int32" />
                    <asp:Parameter Name="AccountName" Type="String" />
                    <asp:Parameter Name="AccountCode" Type="Int32" />
                    <asp:Parameter Name="Description" Type="String" />
                    <asp:Parameter Name="Credit" Type="Int32" />
                    <asp:Parameter Name="Debit" Type="Int32" />
                    <asp:Parameter Name="VoucherNumber" Type="String" />
                </UpdateParameters>
                  <DeleteParameters>
                    <asp:ControlParameter ControlID="txtVoucherNo" Name="VoucherNumber" PropertyName="Text" Type="String" />
                </DeleteParameters>
            </asp:ObjectDataSource>
            <br />

            </div>
        </div>








</asp:Content>
