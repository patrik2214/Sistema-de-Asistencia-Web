﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="OprLicencias.aspx.vb" Inherits="attendanceSystemWeb1._0.OprLicencias" %>

<!DOCTYPE html>
<html lang="es">
  <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>

    <title>Sistema de Asistencia! | Licencias</title>

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
    <form runat="server">
    <div class="container body">
      <div class="main_container">
        <div class="col-md-3 left_col">
          <div class="left_col scroll-view" style="background-color: #1C4E80">
            <div class="navbar nav_title" style="border: 0;background-color: #1C4E80">
              <a href="Index.aspx" class="site_title"><i class="fa fa-calendar"></i> <span>Asistencia Panchito</span></a>
            </div>

            <div class="clearfix"></div>

            <!-- menu profile quick info -->
            <div class="profile clearfix">
              <div class="profile_pic">
              </div>
              <div class="profile_info">
                <span>Bienvenido,</span>
                <h2><%Response.Write(Session("usuario")) %></h2>
              </div>
            </div>
            <!-- /menu profile quick info -->

            <br />

            <!-- sidebar menu -->
            
            <div id="sidebar-menu" class="main_menu_side hidden-print main_menu">
              <div class="menu_section">
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
                      <li><asp:LinkButton runat="server" ID="ManTipoLicencia" OnClick="Redirect_TipoLicencia">Mantenimiento</asp:LinkButton></li>                     
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
        <div class="top_nav">
          <div class="nav_menu">
              <div class="nav toggle">
                <a id="menu_toggle"><i class="fa fa-bars"></i></a>
              </div>
              <nav class="nav navbar-nav">
              <ul class=" navbar-right">
                <li class="nav-item dropdown open" style="padding-left: 15px;">
                  <a href="javascript:;" class="user-profile dropdown-toggle" aria-haspopup="true" id="navbarDropdown" data-toggle="dropdown" aria-expanded="false"><%Response.Write(Session("usuario")) %></a>
                  <div class="dropdown-menu dropdown-usermenu pull-right" aria-labelledby="navbarDropdown">
                      <asp:LinkButton runat="server" class="dropdown-item" ID="Logout" OnClick="Redirect_Login">Cerrar sesion</asp:LinkButton>
                  </div>
                </li>
              </ul>
            </nav>
          </div>
        </div>
        <!-- /top navigation -->

        <!-- page content -->
        <div class="right_col " role="main">
          <div class="container">
            <div class="page-title container">
              <div class="title_left">
                <h3>Licencias</h3>
              </div>
            </div>
            <div class="clearfix"></div>
            <div class="row container">
              <div class="col-md-12 col-sm-12 container">
                <div class="x_panel container">
                  <div class="x_title">
                    <h2><small>Operación</small></h2>
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content container">
                    <br />
                      <div class="item form-group">
                        <label class="col-form-label col-md-3 col-sm-3 label-align">DNI Empleado:</label>
                        <div class="col-md-6 col-sm-6 ">
                          <asp:TextBox ID="TxtDni" CssClass="form-control" runat="server" Height="30px"></asp:TextBox>
                        </div>
                      </div>
                      <div class="item form-group">
                        <label class="col-form-label col-md-3 col-sm-3 label-align">Tipo de Licencia<span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 ">
                          <asp:DropDownList ID="CbxTypeLicense" CssClass="form-control" runat="server" Height="30px"></asp:DropDownList>
                        </div>
                      </div>
                      <div class="item form-group">
                        <label class="col-form-label col-md-3 col-sm-3 label-align">Seleccionar Fecha de Presentación<span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 ">
                          <asp:TextBox ID="DtpPresentation" textmode="Date" CssClass="form-control" runat="server" Height="30px"></asp:TextBox>
                        </div>
                      </div>
                      <div class="item form-group">
                        <label class="col-form-label col-md-3 col-sm-3 label-align">Seleccionar Fecha de Inicio</label>
                        <div class="col-md-6 col-sm-6 ">
                          <asp:TextBox ID="DtpStartDate" textmode="Date" CssClass="form-control" runat="server" Height="30px"></asp:TextBox>
                        </div>
                      </div>
                      <div class="item form-group">
                        <label class="col-form-label col-md-3 col-sm-3 label-align">Seleccionar Fecha de Fin<span class="required">*</span>
                        </label>
                        <div class="col-md-6 col-sm-6 ">
                          <asp:TextBox ID="DtpEndDate" textmode="Date" CssClass="form-control" runat="server"  Height="30px"></asp:TextBox>
                        </div>
                      </div>
                      <div class="item form-group">
                        <label class="col-form-label col-md-3 col-sm-3 label-align">Documento</label>
                        <div class="col-md-6 col-sm-6 ">
                          <asp:TextBox ID="TxtDocument" CssClass="form-control" runat="server"  Height="30px"></asp:TextBox>
                        </div>
                      </div>
                      <div class="ln_solid"></div>
                      <label runat="server" ID="lblAviso" class="label-align"></label>
                      <div class="item form-group">
                        <div class="col-md-6 col-sm-6 offset-md-3">
                          <asp:Button  runat="server" CssClass="btn btn-danger" ID="BtnClear" Text="Cancelar" />
                          <asp:Button  runat="server" CssClass="btn btn-success" ID="BtnRegisterLicense" Text="Guardar" />
                        </div>
                      </div>
                  </div>
                </div>
              </div>
            </div>
              <div class="row container">
                  <div class="col-md-12 col-sm-12 container">
                  <div class="x_panel container">                    
                      <div class="table-responsive col-md-12 col-sm-12 ">
                        <asp:GridView 
                            runat="server" ID="DgvLicense" CssClass="table" 
                            GridLines="None"
                            AutoGenerateColumns="False">
 
                            <RowStyle CssClass="even"/>
                            <HeaderStyle CssClass="header" />
                            <AlternatingRowStyle CssClass="odd"/>
 
                            <Columns>
                                <asp:BoundField HeaderText="Id" DataField="lincenseId"/>
                                <asp:BoundField HeaderText="Empleado" DataField="employee.name"/>
                                <asp:BoundField HeaderText="Apellido" DataField="employee.lastname"/>
                                <asp:BoundField HeaderText="Tipo" DataField="licenseType.description"/>
                                <asp:BoundField HeaderText="Fin de la licencia" DataField="endDate"/>
                            </Columns>
 
                        </asp:GridView>
                        </div>
                    </div>
                  </div>
              </div>
            </div>
          </div>
        </div>
        <!-- /page content -->

        <!-- footer content -->
        <footer>
          <div class="pull-right ">
            Plataforma Asistencia Panchito -  by Us
          </div>
          <div class="clearfix"></div>
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