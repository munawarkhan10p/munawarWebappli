<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="frmIncomeStatement.aspx.cs" Inherits="WebApplication2.Reports.frmIncomeStatement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Container" runat="server">

    <div class="row" style="background-color:cadetblue">
        <div class="col-sm-10 col-md-offset-1" style="background-color:chocolate">

                        <br />
                                    <h3><strong>Income Statement</strong> </h3>
 
            <hr />
            <br />
             <hr />
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>













            <br />
            <br />
            </div>
         </div>

</asp:Content>
