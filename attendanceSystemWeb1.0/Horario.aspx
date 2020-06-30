<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Horario.aspx.vb" Inherits="attendanceSystemWeb1._0.Horario" %>

<!DOCTYPE html>
<html lang="es">
     <head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>

    <title>Sistema de Asistencia! | </title>
    <!-- jQuery -->
    <script src="../librerias/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap -->
    <link rel="stylesheet" href="Content/bootstrap.min.css"/>
    <!-- Font Awesome -->
    <link href="../librerias/font-awesome/css/font-awesome.min.css" rel="stylesheet"/>
    <!-- NProgress -->
    <link rel="stylesheet" href="https://unpkg.com/nprogress@0.2.0/nprogress.css"/>
    <!-- FullCalendar -->
    <link href="../librerias/fullcalendar/dist/fullcalendar.min.css" rel="stylesheet"/>
    <link href="../librerias/fullcalendar/dist/fullcalendar.print.css" rel="stylesheet" media="print"/>
    <script  type="text/javascript">
        var dias = [];
        $(document).ready(function () {
            // page is now ready, initialize the calendar...
            $('#calendar').fullCalendar('destroy');
            $('#calendar').fullCalendar({
                // put your options and callbacks here
                contentHeight: 400,
                defaultView: 'agendaWeek'                
            })
        });
        function agregarDia() {
            var hinicio = $('#hora_inicio').val();
            var hfin = $('#hora_fin').val();
            var select = $('#dias').val();
            if (isNaN(hinicio) || isNaN(hfin)) {
                alert("Ingrese numeros por favor");
            } else if (hinicio > 24 || hinicio < 0 || hfin > 24 || hfin < 0) {
                alert("Coloque las horas en un formato de 24 horas");
            } else {
                hinicio = Math.floor(hinicio);
                hfin = Math.floor(hfin);
                dias.push({ select, hinicio, hfin });
                var hoy = new Date();
                var dd = hoy.getDate();
                var n = hoy.getUTCDay();
                if (n == 0) {
                    n = 7;
                };
                var sobrante = select - n;
                if (sobrante < 0) {
                    hoy.setDate(dd - sobrante);
                } else if (sobrante > 0) {
                    hoy.setDate(dd + sobrante);
                }
                hoy = hoy.toISOString().slice(0, 10);
                hinicio = (hinicio < 10) ? "0" + hinicio : hinicio;
                var starting = moment(hoy + "T" + hinicio + ":00:00");
                var ending = moment(hoy + "T" + hfin + ":00:00");

                $("#calendar").fullCalendar('renderEvent', {
                    title: 'Horario laboral',
                    start: starting,
                    end: ending
                }, true);
                $('#closemodal').click();
                alert(starting);
                alert(ending);
            };
            
        };
        
    </script>
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
              <a href="index.html" class="site_title"><i class="fa fa-calendar"></i> <span>Asistencia Panchito</span></a>
            </div>

            <div class="clearfix"></div>

            <!-- menu profile quick info -->
            <div class="profile clearfix">
              <div class="profile_pic">
              </div>
              <div class="profile_info">
                <span>Bienvenido,</span>
                <h2>Marina</h2>
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
        <div class="top_nav">
          <div class="nav_menu">
              <div class="nav toggle">
                <a id="menu_toggle"><i class="fa fa-bars"></i></a>
              </div>
              <nav class="nav navbar-nav">
              <ul class=" navbar-right">
                <li class="nav-item dropdown open" style="padding-left: 15px;">
                  <a href="javascript:;" class="user-profile dropdown-toggle" aria-haspopup="true" id="navbarDropdown" data-toggle="dropdown" aria-expanded="false">Marina</a>
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
        <div class="right_col" role="main">
          <div class="">
            <div class="page-title">
              <div class="title_left">
                <h3>Horario</h3>
              </div>
            </div>
              <div class="clearfix"></div>

            <div class="row">
              <div class="col-md-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2><small>Horario</small></h2>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <div class="item form-group">
                            <label class="col-form-label col-md-3 col-sm-3 label-align">Dni Empleado:</label>
                            <div class="col-md-6 col-sm-6 ">
                              <asp:TextBox ID="TxtDni" CssClass="form-control" runat="server"  Width="400px" Height="30px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="item form-group">
                            <label class="col-form-label col-md-3 col-sm-3 label-align">Seleccionar Fecha de Inicio</label>
                            <div class="col-md-6 col-sm-6 ">
                                <asp:TextBox ID="DtpStartDate" textmode="Date" CssClass="form-control" runat="server"  Width="400px" Height="30px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="item form-group">
                            <label class="col-form-label col-md-3 col-sm-3 label-align">Seleccionar Fecha de Fin<span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 ">
                              <asp:TextBox ID="DtpEndDate" textmode="Date" CssClass="form-control" runat="server"  Width="400px" Height="30px"></asp:TextBox>
                            </div>
                        </div>
                        <button type="button" class="btn btn-success" data-toggle="modal" data-target="#myModalSave" >Agregar dia</button>
                        <div class="ln_solid"></div>
                        <asp:HiddenField ID="HiddenDias" runat="server" value=""/>
                      <div class="item form-group">
                        <div class="col-md-6 col-sm-6 offset-md-3">
                          <asp:Button  runat="server" CssClass="btn btn-danger" ID="BtnClear" Text="Cancelar" />
                            <button type="button" id="suicidio" onclick="setDias()" class="btn btn-success">dia</button>
                          <asp:Button  runat="server" CssClass="btn btn-success" ID="BtnRegisterSchedule" Text="Registrar" />
                        </div>
                      </div>
                        <div id="calendar">
                            
                        </div>
                        <!-- modal -->
                        <div id="myModalSave" class="modal fade" role="dialog">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h4 class="modal-title">Agregar dia</h4>
                                        <button type="button" class="close" id="closemodal" data-dismiss="modal">&times;</button>
                                    </div>
                                    <div class="modal-body">
                                        <form class="form-horizontal">
                                            <div class="form-group">
                                                <label>Dia</label>
                                                <div class="input-group date" >
                                                    <select id="dias" name="dias">
                                                        <option value="" disabled selected>Seleccione un dia...</option>
                                                        <option value="1">Lunes</option>
                                                        <option value="2">Martes</option>
                                                        <option value="3">Miercoles</option>
                                                        <option value="4">Jueves</option>
                                                        <option value="5">Viernes</option>
                                                        <option value="6">Sabado</option>
                                                        <option value="7">Domingo</option>
                                                    </select>
                                                </div>
                                            </div>
                                            
                                            <div class="form-group">
                                                <label>Hora inicio (24h) *Solo se aceptan horas exactas</label>
                                                <div class="input-group date" >
                                                    <input type="text" class="form-control" id="hora_inicio">
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label>Hora salida (24h) *Solo se aceptan horas exactas</label>
                                                <div class="input-group date" id="dtp2">
                                                    <input type="text" class="form-control" id="hora_fin">
                                                </div>
                                            </div>
                                            <button type="button" id="btnSave" onclick="agregarDia()" class="btn btn-success">Save</button>
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                        </form>
                                    </div>
                                </div>
                            </div>
                        </div> 
                        <!-- /modal -->
                    </div>
                </div>
              </div>
            </div>
          </div>
        </div>
        <!-- /page content -->

        <!-- footer content -->
        <footer>
          <div class="pull-right">
            Plataforma Asistencia Panchito -  by Us
          </div>
          <div class="clearfix"></div>
        </footer>
        <!-- /footer content -->
        
      </div>
    </div>
    
    
    <!-- Bootstrap -->
    <script src="../librerias/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
    <!-- FastClick -->
    <script src="../librerias/fastclick/lib/fastclick.js"></script>
    <!-- NProgress -->
    <script src="../librerias/nprogress/nprogress.js"></script>
    <!-- FullCalendar -->
    <script src="../librerias/moment/min/moment.min.js"></script>
    <script src="../librerias/fullcalendar/dist/fullcalendar.js"></script>
 
    <!--Scripts de Tema Personalizado-->
    <script src="../librerias/build/js/custom.min.js"></script>
       <script type="text/javascript">
           function setDias() {
               alert('no te suicides');
               $('#<%= HiddenDias.ClientID %>').val(dias);
           }
       </script>
    </form>
  </body>
</html>
