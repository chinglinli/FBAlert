<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CallFBAlerterWebService.aspx.cs" Inherits="FBAlert.CallFBAlerterWebService" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>

    
        <form id="form1" runat="server">

    
        發送Alert 訊息到Facebook Group(Call <a href="http://fbalerter.azurewebsites.net/FBAlerter.asmx?op=FBAlert" target="_blank">WebService</a>)<table bordercolor="#dcdcdc" cellpadding="4" cellspacing="0" frame="box" rules="none" style="border-collapse: collapse;">
            <tr>
                <td background="http://fbalerter.azurewebsites.net/FBAlerter.asmx?op=FBAlert#dcdcdc" class="frmHeader" style="color: rgb(0, 0, 0); font-family: Verdana; font-size: 0.7em; font-weight: normal; border-bottom-width: 1px; border-bottom-style: solid; border-bottom-color: rgb(220, 220, 220); padding-top: 2px; padding-bottom: 2px; border-right-width: 2px; border-right-style: solid; border-right-color: white; background: rgb(220, 220, 220);">Parameter</td>
                <td background="http://fbalerter.azurewebsites.net/FBAlerter.asmx?op=FBAlert#dcdcdc" class="frmHeader" style="color: rgb(0, 0, 0); font-family: Verdana; font-size: 0.7em; font-weight: normal; border-bottom-width: 1px; border-bottom-style: solid; border-bottom-color: rgb(220, 220, 220); padding-top: 2px; padding-bottom: 2px; background: rgb(220, 220, 220);">Value</td>
            </tr>
            <tr>
                <td class="frmText" style="color: rgb(0, 0, 0); font-family: Verdana; font-size: 0.7em; margin-top: 12px; margin-bottom: 0px; margin-left: 32px; font-weight: normal;">System:</td>
                <td style="color: rgb(0, 0, 0); font-family: Verdana; font-size: 0.7em;">
                    <asp:TextBox ID="TextBox1" runat="server" Height="18px" Width="139px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="frmText" style="color: rgb(0, 0, 0); font-family: Verdana; font-size: 0.7em; margin-top: 8px; margin-bottom: 0px; margin-left: 32px; font-weight: normal;">MessageCata:</td>
                <td style="color: rgb(0, 0, 0); font-family: Verdana; font-size: 0.7em;">
                    <asp:TextBox ID="TextBox2" runat="server" Height="22px" Width="141px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="frmText" style="color: rgb(0, 0, 0); font-family: Verdana; font-size: 0.7em; margin-top: 8px; margin-bottom: 0px; margin-left: 32px; font-weight: normal;">AlertMessage:</td>
                <td style="color: rgb(0, 0, 0); font-family: Verdana; font-size: 0.7em;">
                    <asp:TextBox ID="TextBox3" runat="server" Height="22px" Width="835px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="frmText" style="color: rgb(0, 0, 0); font-family: Verdana; font-size: 0.7em; margin-top: 8px; margin-bottom: 0px; margin-left: 32px; font-weight: normal;">Priority:</td>
                <td style="color: rgb(0, 0, 0); font-family: Verdana; font-size: 0.7em;">
                    <asp:TextBox ID="TextBox4" runat="server" Height="20px" Width="143px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="color: rgb(0, 0, 0); font-family: Verdana; font-size: 0.7em;"></td>
                <td align="right" style="color: rgb(0, 0, 0); font-family: Verdana; font-size: 0.7em;">&nbsp;</td>
            </tr>
        </table>

        <div>
    
            <br />
            <asp:Button ID="Button1" runat="server" Height="27px" OnClick="Button1_Click" Text="PostToFacebook" Width="190px" />
            <br />
            <br />
            <br />
            <a href="Arch.aspx" target="_blank">Arch</a><br />
            <br />
    
    </div>
        
        
   
        </form>
        
        
   
</body>
</html>
