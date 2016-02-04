<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Main.Master" AutoEventWireup="true" CodeBehind="frmReports.aspx.cs" Inherits="WebApplication2.Forms.frmReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Container" runat="server">
     <div class="row" style="background-color:cadetblue">
        <div class="col-sm-10 col-md-offset-1" style="background-color:chocolate">

                        <br />
                                    <h3><strong>Reports Management</strong> </h3>
 
            <hr />
            <br />

            
                                            <div class="form-group input-group" >
                                           
                                                <asp:Button ID="btnDisplayReport" runat="server" CssClass="btn-primary alert-success" Text="Show Report" OnClick="btnDisplayReport_Click" />

                                                <asp:TextBox ID="txtAccountCode" runat="server"></asp:TextBox>
                                           
                                                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                                                
                                        </div>






            <hr />
            <br />
            <br />
            </div>
         </div>


</asp:Content>
