﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ConAsistencia.aspx.vb" Inherits="attendanceSystemWeb1._0.ConAsistencia" EnableEventValidation="true" %>

<!DOCTYPE html>
<html lang="es">
  <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>

    <title>Sistema de Asistencia! | </title>

    <!-- Bootstrap -->
    <link rel="stylesheet" href="Content/bootstrap.min.css"/>
    <!-- Font Awesome -->
    <link href="../librerias/font-awesome/css/font-awesome.min.css" rel="stylesheet"/>
    <!-- NProgress -->
    <link rel="stylesheet" href="https://unpkg.com/nprogress@0.2.0/nprogress.css"/>
    <!-- FullCalendar -->
    <link href="../librerias/fullcalendar/dist/fullcalendar.min.css" rel="stylesheet"/>
    <link href="../librerias/fullcalendar/dist/fullcalendar.print.css" rel="stylesheet" media="print"/>
    <!-- Estilo de Tema Personalizado -->
    <link href="../librerias/build/css/custom.min.css" rel="stylesheet"/>
  </head>

  <body class="nav-md" style="background-color: #1C4E80">
    <form id="form1" runat="server">
    <div class="container body">
      <div class="main_container animate-pop-in">
        <div class="col-md-3 left_col animate-pop-in">
          <div class="left_col scroll-view animate-pop-in" style="background-color: #1C4E80">
            <div class="navbar nav_title animate-pop-in" style="border: 0;background-color: #1C4E80">
              <a href="Index.aspx" class="site_title"><i class="fa fa-calendar"></i> <span>Asistencia Panchito</span></a>
            </div>

            <div class="clearfix animate-pop-in"></div>

            <!-- menu profile quick info -->
            <div class="profile clearfix animate-pop-in">
              <div class="profile_pic animate-pop-in">
              </div>
              <div class="profile_info animate-pop-in">
                <span>Bienvenido,</span>
                <h2> <%Response.Write(Session("usuario"))%></h2>
              </div>
            </div>
            <!-- /menu profile quick info -->

            <br />

            <!-- sidebar menu -->
            
            <div id="sidebar-menu" class="main_menu_side hidden-print main_menu animate-pop-in">
              <div class="menu_section animate-pop-in">
                <ul class="nav side-menu">
                  <li><a><i class="fa fa-child"></i>Empleado<span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                      <li><asp:LinkButton runat="server" ID="ManUsuario" OnClick="Redirect_Usuario">Usuario</asp:LinkButton></li>
                      <li><asp:LinkButton runat="server" ID="ManEmpleado" OnClick="Redirect_Empleado">Mantenimiento</asp:LinkButton></li>
                    </ul>
                  </li>
                  <li><a><i class="fa fa-file-text-o"></i>Contratos<span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                      <li><asp:LinkButton runat="server" ID="ManContratos" OnClick="Redirect_Contrato">Mantenimiento</asp:LinkButton></li>                     
                    </ul>
                  </li>
                  <li><a><i class="fa fa-table"></i>Horarios<span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                      <li><asp:LinkButton runat="server" ID="ManHorario" OnClick="Redirect_Horario">Mantenimiento</asp:LinkButton></li>   
                        <li><asp:LinkButton runat="server" ID="ModHorario" OnClick="Redirect_ModHorario">Modificar horario</asp:LinkButton></li>                     
                    </ul>
                  </li>
                  <li><a><i class="fa fa-folder"></i>Licencias<span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                      <li><asp:LinkButton runat="server" ID="ManTipoLicencia" OnClick="Redirect_TipoLicencia">Tipo Licencia</asp:LinkButton></li>                     
                    </ul>
                  </li>
                  <li><a><i class="fa fa-desktop"></i>Operaciones<span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                      <li><asp:LinkButton runat="server" ID="OprAsistencia" OnClick="Redirect_OprAsistencia">Asistencia</asp:LinkButton></li>
                      <li><asp:LinkButton runat="server" ID="OprJustificacion" OnClick="Redirect_OprJustificacion">Justificación</asp:LinkButton></li>
                      <li><asp:LinkButton runat="server" ID="OprPermisos" OnClick="Redirect_OprPermisos">Permisos</asp:LinkButton></li>
                      <li><asp:LinkButton runat="server" ID="OprLicencias" OnClick="Redirect_OprLicencias">Licencias</asp:LinkButton></li>                       
                    </ul>
                  </li>
                  <li><a><i class="fa fa-clone"></i>Consultas<span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                      <li><asp:LinkButton runat="server" ID="ConAsistencia" OnClick="Redirect_ConAsistencia">Asistencia</asp:LinkButton></li>
                    </ul>
                  </li>
                  <li><a><i class="fa fa-bar-chart-o"></i>Reportes<span class="fa fa-chevron-down"></span></a>
                    <ul class="nav child_menu">
                      <li><asp:LinkButton runat="server" ID="Asistencia" OnClick="Redirect_Asistencia">Asistencia</asp:LinkButton></li>
                      <li><asp:LinkButton runat="server" ID="Faltas" OnClick="Redirect_Faltas">Faltas</asp:LinkButton></li>
                      <li><asp:LinkButton runat="server" ID="Licencias" OnClick="Redirect_Licencias">Licencias</asp:LinkButton></li>
                      <li><asp:LinkButton runat="server" ID="Tardanzas" OnClick="Redirect_Tardanzas">Tardanzas</asp:LinkButton></li>
                    </ul>
                  </li>
                </ul>
              </div>
            </div>
            
            
          </div>
        </div>
        <!-- end sidebar menu -->

        <!-- top navigation -->
        <div class="top_nav animate-pop-in">
          <div class="nav_menu animate-pop-in">
              <div class="nav toggle animate-pop-in">
                <a id="menu_toggle"><i class="fa fa-bars"></i></a>
              </div>
              <nav class="nav navbar-nav">
              <ul class=" navbar-right">
                <li class="nav-item dropdown open" style="padding-left: 15px;">
                  <a href="javascript:;" class="user-profile dropdown-toggle" aria-haspopup="true" id="navbarDropdown" data-toggle="dropdown" aria-expanded="false"><%Response.Write(Session("usuario")) %></a>
                  <div class="dropdown-menu dropdown-usermenu pull-right" aria-labelledby="navbarDropdown">
                      <a class="dropdown-item"  href="javascript:;">
                        <span>Settings</span>
                      </a>
                    <a class="dropdown-item"  href="login.html"><i class="fa fa-sign-out pull-right"></i> Log Out</a>
                  </div>
                </li>
              </ul>
            </nav>
          </div>
        </div>
        <!-- /top navigation -->

        <!-- page content -->
          <div class="right_col animate-pop-in" role="main">
          <div class="animate-pop-in">
            <div class="page-title animate-pop-in">
              <div class="title_left animate-pop-in">
                <h3>Asistencia</h3>
              </div>
            </div>
            <div class="clearfix animate-pop-in"></div>
            <div class="row animate-pop-in">
              <div class="col-md-12 col-sm-12 animate-pop-in">
                <div class="x_panel animate-pop-in">
                  <div class="x_title animate-pop-in">
                    <h2><small>Consulta</small></h2>
                    <div class="clearfix animate-pop-in"></div>
                  </div>
                    <label runat="server" ID="lblAviso" class="label-align">_</label>
                  <div class="x_content animate-pop-in">
                    <br />
                      <div class="item form-group animate-pop-in"> 
                         <asp:TextBox ID="txtDni" CssClass="form-control" placeholder="Ingrese un dni" runat="server"  Width="1200px" Height="40px"></asp:TextBox>
                         <asp:Button  runat="server" CssClass="btn btn-primary" ID="BtnSearchDni" Text="Buscar" />
                      </div>
                  </div>
                </div>
              </div>
            </div>
                 
            </div>
          </div>
        
        <div class="row">
             <div class="col-md-12 col-sm-12 animate-pop-in">
                      <asp:GridView 
                            runat="server" ID="DgvAssitance" CssClass="table"
                            GridLines="None"
                            AutoGenerateColumns="False"
                            >
 
                            <RowStyle CssClass="even"/>
                            <HeaderStyle CssClass="header" />
                            <AlternatingRowStyle CssClass="odd"/>
 
                            <Columns>
                                <asp:BoundField HeaderText="Fecha" DataField="fecha"/>
                                <asp:BoundField HeaderText="Hora de Entrada" DataField="inhour"/>
                                <asp:BoundField HeaderText="Hora de Salida" DataField="outhour"/>
                                <asp:BoundField HeaderText="Dni" DataField="dni"/>
                            </Columns>
 
                        </asp:GridView>
                   
                  </div>
              </div>
           </div>
        <!-- /page content -->

        <!-- footer content -->
        <footer>
          <div class="pull-right animate-pop-in">
            Plataforma Asistencia Panchito -  by Us
          </div>
          <div class="clearfix animate-pop-in"></div>
        </footer>
        <!-- /footer content -->
       
      </div>
    
    <!-- jQuery -->
    <script src="../librerias/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap -->
    <script src="../librerias/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
    <!-- FastClick -->
    <script src="../librerias/fastclick/lib/fastclick.js"></script>
    <!-- NProgress -->
    <script src="../librerias/nprogress/nprogress.js"></script>
    <!-- FullCalendar -->
    <script src="../librerias/moment/min/moment.min.js"></script>
    <script src="../librerias/fullcalendar/dist/fullcalendar.min.js"></script>
    <!--Scripts de Tema Personalizado-->
    <script src="../librerias/build/js/custom.min.js"></script>
</form>
  </body>
</html>

