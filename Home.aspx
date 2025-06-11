<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="GovPortal.Home" EnableSessionState="True" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Home</title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script type="text/javascript">
        setInterval(function () {
            $.ajax({
                type: "POST",
                url: "Home.aspx/UpdateLastActive",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: "{}", // critical for [WebMethod] even if no params
                success: function () {
                    console.log("Updated at " + new Date().toLocaleTimeString());
                },
                error: function (xhr) {
                    console.error("Error:", xhr.responseText);
                }
            });
        }, 30000); // 30 sec
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <h2>Welcome! Your session is active.</h2>
        <p>Session is being updated every 30 seconds in the database.</p>
    </form>
</body>
</html>
