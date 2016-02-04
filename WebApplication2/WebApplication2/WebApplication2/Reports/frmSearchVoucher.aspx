<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="frmSearchVoucher.aspx.cs" Inherits="WebApplication2.Reports.frmReports" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Container" runat="server">

     <div class="row" style="background-color:cadetblue">
        <div class="col-sm-10 col-md-offset-1" style="background-color:chocolate">

                        <br />
                                    <h3><strong>SEARCH VOUCHER</strong> </h3>
 
            <hr />
            <br />
            <CR:CrystalReportViewer ID="CrystalReportViewer" runat="server" AutoDataBind="true" />
            <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                <Report FileName="CrystalReport.rpt">
                </Report>
            </CR:CrystalReportSource>

            
             <div class="form-group input-group">
                <span class="input-group-addon"><i class="fa fa-circle-o-notch"></i></span>
                <asp:TextBox ID="txtAccountName" runat="server" CssClass="form-control input-lg" placeholder="Enter Account Name"
                    Width="290px" TabIndex="3"></asp:TextBox>



                

                <span class="input-group-addon"><i class="fa fa-circle-o-notch"></i></span>
                 <asp:TextBox ID="txtAccountCode" runat="server" CssClass="form-control input-lg" placeholder="Enter Account Code"
                     Width="290px" TabIndex="4"></asp:TextBox>
         

            </div>
                        <%-- panel End --%>
            <asp:Panel ID="Panel1" Visible="false" runat="server">
                <div class="form-group input-group">
                    <span class="input-group-addon"><i class="fa fa-circle-o-notch"></i></span>
                    <asp:TextBox ID="txtDate1" runat="server" CssClass="form-control input-lg" placeholder="Enter Date From"
                        Width="290px" TabIndex="1"></asp:TextBox>



                    <%-- DatetTime Picker --%>

                    <span class="input-group-addon"><i class="fa fa-circle-o-notch"></i></span>
                    <asp:TextBox ID="txtDate2" runat="server" CssClass="form-control input-lg" placeholder="Enter Date To"
                        Width="290px" TabIndex="2" OnTextChanged="txtDate2_TextChanged"></asp:TextBox>


                </div>
            </asp:Panel>
            <%-- panel End --%>
             <div class="form-group input-group">
                 <asp:Button ID="btnSearch" runat="server" TabIndex="5" Text="Search" CssClass="btn-primary alert-success" OnClick="btnSearch_Click" />
                 <asp:Button ID="btnDate" runat="server" TabIndex="5" Text="Date" CssClass="btn-primary alert-success"  OnClick="Button1_Click"  />
                   <asp:Button ID="btnPrint" runat="server" TabIndex="5" Text="PRINT" CssClass="btn-primary alert-success" OnClick="btnPrint_Click1"  />

                 </div>
            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnSelectedIndexChanging="GridView1_SelectedIndexChanging" OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Account Name">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("AccountName") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAccountName" runat="server" Text='<%# Bind("AccountName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Account Code">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("AccountCode") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAccountCode" runat="server" Text='<%# Bind("AccountCode") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                                  <asp:ButtonField Text="Print" CommandName="Print" />

                    

                    <%--<asp:TemplateField HeaderText="Print Report">
                        <ItemTemplate>--%>
                           <%-- <asp:Button ID="btnPrint" runat="server" Height="43px" OnClick="btnPrint_Click" Text="PRINT" Width="85px" />--%>
                       <%-- </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
                        </asp:GridView>


            <hr />
            <br />
            <br />
            </div>
         </div>







</asp:Content>
