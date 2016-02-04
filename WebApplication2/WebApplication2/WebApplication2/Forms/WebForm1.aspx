<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication5.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="../assets/css/bootstrap.css" rel="stylesheet" />
    <script src="../assets/jquery-1.12.0.js"></script>
    <link href="../assets/css/jquery.Jcrop.css" rel="stylesheet" />
    <script src="../assets/jquery.Jcrop.js"></script>
   
   

            <script language="javascript">
                $(document).ready(function () {
                    $('#<%=imgUpload.ClientID%>').Jcrop({
                        bgColor: 'black',
                        bgOpacity: .4,
                        setSelect: [0, 0,300, 400],
                        width: 150, height: 150,
                        allowSelect: false,
                        allowMove: true,
                        allowResize: false,
                        onSelect: SelectCropArea
                    });
                });
                function SelectCropArea(c) {
                    $('#<%=X.ClientID%>').val(parseInt(c.x));
                    $('#<%=Y.ClientID%>').val(parseInt(c.y));
                    $('#<%=W.ClientID%>').val(parseInt(c.w));
                    $('#<%=H.ClientID%>').val(parseInt(c.h));
                }
            </script>


            


    </head>
<body>
   <form id="form1" runat="server">
        

       
              <table >
                    <tr>
                       
                        <td>
                            <asp:FileUpload ID="FU1" runat="server" class="btn btn-default btn-file btn btn-info" />
                        </td>
                        <td>
                            &nbsp;<asp:Button ID="btnUpload" CssClass="btn btn-success" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                                <asp:Button ID="btnCrop" CssClass="btn btn-danger" runat="server" Text="Crop & Save" OnClick="btnCrop_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Label ID="lblMsg" runat="server" ForeColor="Red" />
                        </td>
                    </tr>
                </table>
                <asp:Panel ID="panCrop" runat="server" Visible="false">
                    <table>
                        <tr>
                            <td>
                             <asp:Image  ID="imgUpload" runat="server" CssClass="img-responsive"/>  
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%-- Hidden field for store cror area --%>
                                <asp:HiddenField ID="X" runat="server" />
                                <asp:HiddenField ID="Y" runat="server" />
                                <asp:HiddenField ID="W" runat="server" />
                                <asp:HiddenField ID="H" runat="server" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>

      
    </form>
</body>
</html>
