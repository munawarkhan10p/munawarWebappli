<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="frmJournalVoucher.aspx.cs" Inherits="WebApplication2.frmJournalVoucher" %>
<asp:Content ID="content2" ContentPlaceHolderID="contentHeader" runat="server">
   <link type="text/css" href="../assets/css/smoothness/jquery-ui-1.7.1.custom.css" rel="stylesheet" />
     <script src="../assets/_scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
     <script src="../assets/_scripts/jquery-ui-1.7.1.custom.min.js" type="text/javascript"></script>
                <script type="text/javascript">
                    $(document).ready(function () {
                        $("#txtDate").datepicker();
                    });
                </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Container" runat="server">



    <div class="row" style="background-color: cadetblue">
        <div class="col-sm-10 col-md-offset-1" style="background-color: chocolate">
            <br />
            <h3><strong>Journal Voucher</strong> </h3>

            <hr />
            <br />
            <%-- TextBox Voucher Number--%>
            <div class="form-group input-group">
                <span class="input-group-addon"><i class="fa fa-circle-o-notch"></i></span>
                <asp:TextBox ID="txtVoucherNo" runat="server" CssClass="form-control input-lg" placeholder="Auto Generated Voucher NO"
                    Width="290px" TabIndex="1" ReadOnly="True"></asp:TextBox>



                <%-- DatetTime Picker --%>

                 <span class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span>
                <asp:TextBox ID="txtDate" runat="server" CssClass="form-control input-lg" placeholder="Select Date" ClientIDMode="Static"
                    Width="290px"></asp:TextBox>


            </div>

            <%-- Label Message 1--%>
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>


            <%-- GridView Of JV --%>

            <div class="form-group input-group">

                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="600px" Height="200px" ShowFooter="true" OnRowDataBound="GridView1_RowDataBound" OnRowCreated="GridView1_RowCreated" BorderColor="Chocolate" BorderStyle="Double">
                    <Columns>
                        <asp:TemplateField HeaderText="A/C CODE">
                            <FooterTemplate>
                                <asp:Button ID="btnAddNewRow" runat="server" Text="ADD NEW ROW" OnClick="btnAddNewRow_Click" />
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlAccountCode" runat="server" OnSelectedIndexChanged="ddlAccountCode_SelectedIndexChanged">
                                    <asp:ListItem>Select A/C Code</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="A/C NAME">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlAccountName" runat="server">
                                    <asp:ListItem>Select A/C Name</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DESCRIPTION">
                            <ItemTemplate>
                                <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CREDIT">
                            <ItemTemplate>
                                <asp:TextBox ID="txtCredit" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DEBIT">
                            <ItemTemplate>
                                <asp:TextBox ID="txtDebit" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TRANSACTION NO">
                            <ItemTemplate>
                                <asp:TextBox ID="txtTransaction" runat="server" ReadOnly="True"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbRemove" runat="server" ForeColor="White" OnClick="lbRemove_Click">Remove</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>
            <%-- button saveall --%>
            <div class="form-group input-group">
                <asp:Button ID="btnSaveAll" runat="server" TabIndex="3" Text="Save All" CssClass="btn-primary alert-success" OnClick="btnSaveAll_Click" />
                <asp:Button ID="btnPrintreport" runat="server" CssClass="btn-primary alert-success" Text="Print Report" Visible="false" OnClick="btnPrintreport_Click" />
                <asp:Button ID="btnNewvoucher" runat="server" CssClass="btn-primary alert-success" Text="New Vouvher" Visible="false" OnClick="btnNewvoucher_Click" />
            </div>
            <%-- textbox totalcredit --%>
            <div class="form-group input-group">
                <span class="label label-default">Credit </span>
                <asp:TextBox ID="txtTotalCredit" runat="server" TabIndex="4" ReadOnly="True" CssClass="input-sm" placeholder="Total Credit Amount">
                                        <%-- textbox totaldebit --%>
                </asp:TextBox>

                <span class="label label-default">Debit </span>
                <asp:TextBox ID="txtTotalDebit" runat="server" TabIndex="5" ReadOnly="True" CssClass="input-sm" placeholder="Total Debit Amount"></asp:TextBox>


                <%-- textbox difference --%>
                <span class="label label-default">Difference </span>
                <asp:TextBox ID="txtDifference" runat="server" TabIndex="6" ReadOnly="True" CssClass="input-sm" placeholder="Difference In Amount"></asp:TextBox>
            </div>

            <asp:Label ID="lblMessage2" runat="server" Text=""></asp:Label>
            <hr />
        </div>

    </div>
</asp:Content>
