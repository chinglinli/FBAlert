<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FB.aspx.cs" Inherits="FBAlert.FB" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <script>
    
    
    //var AlertMessage = "<%=AlertMessage %>";

    window.fbAsyncInit = function() {
        FB.init({
                  //appId      : '1661319984144428', as 李景霖
				  appId      : '1114058885271795', //as Lee Ian 1114058885271795
				  xfbml      : true,
                  version    : 'v2.5'
        });

        // Now that we've initialized the JavaScript SDK, we call 
        // FB.getLoginStatus().  This function gets the state of the
        // person visiting this page and can return one of three states to
        // the callback you provide.  They can be:
        //
        // 1. Logged into your app ('connected')
        // 2. Logged into Facebook, but not your app ('not_authorized')
        // 3. Not logged into Facebook and can't tell if they are logged into
        //    your app or not.
        //
        // These three cases are handled in the callback function.

        
		
		var AlertMessage = "<%=AlertMessage %>";
		
		FB.api(
                    "/1814237745469656/feed",
                    "POST", {
                        //"message": "user access token會過期嗎?會過期無誤.不behafe時 可以發訊息嗎? Again ",
                        "message": AlertMessage,
                        //"access_token": "1114058885271795|56850b9860848ecac8c8d73a663ad9a5"
                        "access_token": "CAAP1OwwdkPMBAISznJTHEoog08V6Vv313ku1iZCn0hEsJUfqHvaLMcduAh73adf2MT6qTaNjTpCCSzBu33eQB3NnQtwCLrZCZBdF6ZB93eQ2lvblQn7conCcISUPS8bxobFQQdRC033TMzpmrQ68U60O8CbT4lxQAoQEobdJPMbNbr8NmKdlDWRH3YAHTZBdEFEfHytZATtwZDZD"
                        
                    },
                    function(response) {
                        if (response.error) {
                            console.log(response.error);
                        }
                        setTimeout(postOrFinish, delay * 1000);
                    });
		

    };

    // Load the SDK asynchronously
    (function(d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) return;
        js = d.createElement(s);
        js.id = id;
        js.src = "//connect.facebook.net/en_US/sdk.js";
        fjs.parentNode.insertBefore(js, fjs);
    }(document, 'script', 'facebook-jssdk'));

    // Here we run a very simple test of the Graph API after login is
    // successful.  See statusChangeCallback() for when this call is made.
    
</script>
<!--
   Below we include the Login Button social plugin. This button uses
   the JavaScript SDK to present a graphical Login button that triggers
   the FB.login() function when clicked.
   -->


</body>
</html>
