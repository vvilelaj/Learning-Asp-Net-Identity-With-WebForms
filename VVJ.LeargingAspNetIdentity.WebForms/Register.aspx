<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="VVJ.LearningAspNetIdentity.WebForms.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="font-family: Arial, Helvetica, sans-serif; font-size: small">
    <form id="form1" runat="server">
        <div>
            <h4 style="font-size: medium">Register a new user</h4>
            <hr />
            <p>
                <asp:Literal runat="server" ID="StatusMessage" />
            </p>
            <div style="margin-top: 10px">
                <asp:Label runat="server" AssociatedControlID="UserName" Text="User Name" />
                <div>
                    <asp:TextBox runat="server" ID="UserName" />
                </div>
            </div>
            <div style="margin-top: 10px">
                <asp:Label runat="server" AssociatedControlID="Password" Text="Password" />
                <div>
                    <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                </div>
            </div>
            <div style="margin-top: 10px">
                <asp:Label runat="server" AssociatedControlID="ConfirmPassword" Text="Confirm Password" />
                <div>
                    <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" />
                </div>
            </div>
            <div>
                <div>
                    <asp:Button Text="Register" runat="server" OnClick="CreateUser_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
