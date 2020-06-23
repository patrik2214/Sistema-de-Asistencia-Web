<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="attendanceSystemWeb1._0.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
  <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sistema de Asistencia PanchitoLovers</title>

    <!-- Bootstrap -->
    <link rel="stylesheet" href="Content/bootstrap.min.css"/>
    <!-- Font Awesome -->
    <link rel="stylesheet" href="../vendors/font-awesome/css/font-awesome.min.css"/>
    <!-- NProgress -->
    <link rel="stylesheet" href="https://unpkg.com/nprogress@0.2.0/nprogress.css"/>
    <!-- Animate.css -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/4.0.0/animate.min.css"/>
    <!-- Custom Theme Style -->
    <link rel="stylesheet" href="../vendors/build/css/custom.min.css"/>

  </head>

  <body class="login">
      

    <div>
      <a class="hiddenanchor" id="signup"></a>
      <a class="hiddenanchor" id="signin"></a>

      <div class="login_wrapper">
        <div class="animate form login_form">
          <section class="login_content">
            <form id="form1" runat="server">
              <h1>Iniciar Sesión</h1>
              <div class="">
                <h3>Usuario</h3>
                <asp:TextBox ID="txtNombreUsuario" CssClass="form-control" runat="server" Width="180px" Height="30px"></asp:TextBox>
              </div>
              <div class="">
                <h3>Contraseña</h3>
                <asp:TextBox ID="txtContraseña" CssClass="form-control" runat="server" TextMode="Password" Width="180px" Height="30px"></asp:TextBox>
              </div>
              <div class="">
                <br />
                <asp:Button ID="btnLogin" CssClass="btn btn-primary center" runat="server" Width="100px" Text="Ingresar"/>
              </div>
                <br/>
    
              <div class="clearfix"></div>

              <div class="separator">
                <div class="clearfix"></div>
                <br />
                <div>
                  <p>© 2020 Todos los derechos reservados.</p>
                </div>
              </div>
               <asp:ScriptManager runat="server" ID="smPageScriptManage" ScriptMode="Release" >
                  <Scripts>
                      <asp:ScriptReference Path="~/Scripts/jquery-3.0.0.min.js" />
                      <asp:ScriptReference Path="~/Scripts/bootstrap.min.js" />
                  </Scripts>
              </asp:ScriptManager>
              <script src="https://use.fontawesome.com/a7abbb6dd9.js"></script>
            </form>
          </section>
        </div>
      </div>
    </div>
      
  </body>
</html>
