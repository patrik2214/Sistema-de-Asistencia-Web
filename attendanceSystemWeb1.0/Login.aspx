﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="attendanceSystemWeb1._0.WebForm1" %>

<!DOCTYPE html>
<html lang="es">
  <head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Sistema de Asistencia! | Iniciar Sesión</title>    
    <!-- Estilo de Tema Personalizado -->
    <link href="../librerias/animate/animate.css" rel="stylesheet"/>
    <link href="../css/custom.min.css" rel="stylesheet">

  </head>

  <body class="login" style="background-color: #1C4E80" >
    <div class="container">
      <div class="login_wrapper animate-pop-in">
        <div class="animate form login_form">
          <section class="login_content">
              <div class="row m-o p-0 ">
                    <img src="Resources/innovation__monochromatic.png" width="70%" />
               </div>
            <form id="formIncio" class="container" runat="server">
                
                <h1 style="color: #ffffff">Iniciar Sesión</h1>
                <div class="container" >                   
                    
                    <asp:TextBox ID="txtNombreUsuario" CssClass="form-control" runat="server" placeholder=" Usuario" Height="30px"></asp:TextBox> <br/>                    
                    <asp:TextBox ID="txtContraseña" CssClass="form-control" runat="server" TextMode="Password" placeholder=" Contraseña" Height="30px"></asp:TextBox><br />
                    <asp:Label runat="server" ForeColor="White" ID="lblMensaje"></asp:Label><br /><br />
                    <asp:Button ID="btnLogin" Text="Ingresar" runat="server" BorderStyle="None" style="center" Width="108px" Height="34px" BackColor="#2A75BF" ForeColor="White" Font-Bold="True" Font-Size="Medium"/><br/>
                </div>
                <div class="clearfix"><br /></div>
                <div class="container">
                   <p style="color: #FFFFFF">© 2020 Todos los derechos reservados.</p>
                </div>                
            </form>         
          </section>
        </div>       
       </div>
     </div>
  </body>
</html>
