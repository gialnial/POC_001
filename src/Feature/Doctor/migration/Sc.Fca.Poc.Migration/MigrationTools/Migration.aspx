<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Migration.aspx.cs" Inherits="Sc.Fca.Poc.Migration.MigrationTools.Migration1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" method="post" enctype="multipart/form-data">
        <div>
            <input type="file" id="File1" name="File1" runat="server" />
            <br />
            <asp:Button ID="btnUpload" Text="Upload" runat="server" OnClick="btnUpload_Click" />
        </div>
        <div>
            <asp:Literal ID="litFeedback" runat="server" />
        </div>
    </form>
</body>
</html>
