<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="frmBankBook.aspx.cs" Inherits="WebApplication2.Forms.frmBankBook" %>
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
            <h3><strong>Bank Book</strong> </h3>

            <hr />
            <br />


            <div class="form-group input-group">
                <span class="input-group-addon"><i class="fa fa-circle-o-notch"></i></span>
                <asp:TextBox ID="txtVoucherNo" runat="server" CssClass="form-control input-lg" placeholder="Auto Generated Voucher NO"
                    Width="290px" TabIndex="1" ReadOnly="True"></asp:TextBox>




                <span class="input-group-addon"><i class="glyphicon glyphicon-th"></i></span>
                <asp:TextBox ID="txtDate" runat="server" CssClass="form-control input-lg" placeholder="Select Date" ClientIDMode="Static"
                    Width="290px"></asp:TextBox>


            </div>

            <div class="form-group input-group">


                <span class="input-group-addon"><i class="fa fa-tag"></i></span>
                <asp:DropDownList ID="ddlCashAccount" runat="server" CssClass="form-control input-lg" placeholder="Account Type"
                    Width="290px" TabIndex="3">
                    <asp:ListItem Value="-1">Select Account Type</asp:ListItem>

                </asp:DropDownList>
                <%-- buttons payments and receipt --%>
            </div>
            <div class="form-group input-group">
                <span class="input-group-addon"><i class="fa fa-circle-o-notch"></i></span>
                <asp:TextBox ID="txtDescriptionCashAccount" runat="server" CssClass="form-control input-lg" placeholder="Add description"
                    Width="290px" Height="47px" TabIndex="4"></asp:TextBox>
            </div>

            <div class="form-group input-group">

                <div class="checkbox">
                    <label class="btn btn-default">
                        <asp:RadioButton CssClass=" validate[required] radio" ID="rbReceipt" Text="Receipt" GroupName="1" runat="server" AutoPostBack="True" OnCheckedChanged="rbReceipt_CheckedChanged" />
                    </label>
                </div>
                <div class="checkbox">
                    <label class="btn btn-default">
                        <asp:RadioButton CssClass="validate[required] radio" ID="rbPayment" Text="Payment" GroupName="1" runat="server" AutoPostBack="True" OnCheckedChanged="rbPayment_CheckedChanged" />
                    </label>
                    <br />
                    <br />
                    <asp:Label ID="lblMessage1" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="form-group input-group">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="700px" Height="150px" ShowFooter="True" BorderColor="Chocolate" OnRowCreated="GridView1_RowCreated" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="A/C CODE">
                            <FooterTemplate>
                                <asp:Button ID="btnAddNewRow" runat="server" Text="Add New Row" OnClick="btnAddNewRow_Click" />
                            </FooterTemplate>
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlAccountCode" runat="server">
                                    <asp:ListItem>Select A/C CODE</asp:ListItem>
                                    <asp:ListItem Value="1">Assets</asp:ListItem>

                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="A/C NAME">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlAccountName" runat="server">
                                    <asp:ListItem>Select A/C NAME</asp:ListItem>
                                    <asp:ListItem Value="1">Assets</asp:ListItem>

                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DESCRIPTION">
                            <ItemTemplate>
                                <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TYPE">
                            <ItemTemplate>
                                <asp:TextBox ID="txtType" runat="server" ReadOnly="True" AutoPostBack="True"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="AMOUNT">
                            <ItemTemplate>
                                <asp:TextBox ID="txtAmount" runat="server" AutoPostBack="True" OnTextChanged="txtAmount_TextChanged"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="TRANSACTION">
                            <ItemTemplate>
                                <asp:TextBox ID="txtTransaction" runat="server" ReadOnly="true"></asp:TextBox>
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


            <div class="form-group input-group">
                <asp:Button ID="btnSaveAll" runat="server" TabIndex="3" Text="Save All" CssClass="btn-primary alert-success" OnClick="btnSaveAll_Click" />
                <asp:Button ID="btnPrintReport" runat="server" Text="Print Report" CssClass="btn-primary alert-success" Visible="false" />
                <asp:Button ID="btnNewBankBook" runat="server" Text="New Book" CssClass="btn-primary alert-success" Visible="false" OnClick="btnNewBankBook_Click" />
                <span class="label label-default">TOTAL AMOUNT </span>
                <asp:TextBox ID="txtTotal" runat="server" TabIndex="6" ReadOnly="True" CssClass="input-sm" placeholder=" Amount "></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblMessage2" runat="server" Text=""></asp:Label>
            </div>












            <br />
            <hr />
            <br />

        </div>
    </div>








</asp:Content>
