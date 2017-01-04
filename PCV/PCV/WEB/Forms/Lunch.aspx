<%@ Page Title="" Language="C#" MasterPageFile="~/WEB/Master/master.Master" AutoEventWireup="true" CodeBehind="Lunch.aspx.cs" Inherits="PCV.WEB.Forms.Lunch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
    
    
<div class="row">
    <div class="col-md-2">
        <img src='<%= ResolveUrl("~/Resources/Images/user2-160x160.jpg") %>' />
    </div>
    <div class="col-md-10">
        
        <div class="row">
            <div class="col-md-12">
                <p class="h2">Comedor P & G México City GO PG MXCC-376</p>
            </div>
        </div>
        
        <div class="row">
            <div class="col-md-4">
                <asp:TextBox ID="txtPlantaDesc" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
            <div class="col-md-4">
                <div class="input-group">
                    <span class="input-group-addon">Terminal</span>
                    <asp:TextBox runat="server" CssClass="form-control" ReadOnly="true" Text="1"/>
                </div>
            </div>
            <div class="col-md-4">
                <div class="input-group">
                    <span class="input-group-addon">Ventas</span>
                    <asp:TextBox ID="txtVentas" runat="server" CssClass="form-control" ReadOnly="true"/>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-4">
                <div class="input-group">
                    <span class="input-group-addon">Horario</span>
                    <asp:TextBox ID="txtHorario" ReadOnly="true" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-4">
                <div class="input-group">
                    <span class="input-group-addon">Subsidio</span>
                    <asp:TextBox ID="txtSubsidio" ReadOnly="true" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-2">
                <div class="input-group">
                    <span class="">Número SAP</span>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-3">
                <div class="input-group">
                    <span class="input-group-addon">Hora</span>
                    <asp:TextBox CssClass="form-control" runat="server" ID="txtFecha" Width="100%" ForeColor="Black" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-4">
                <span>DIA</span>
            </div>
            <div class="col-md-5">
                <div class="input-group">
                    <span class="input-group-addon">Tipo de empleado</span>
                    <asp:TextBox ID="txtTipoEmpleado" ReadOnly="true" runat="server" CssClass="form-control" Width="100%" ></asp:TextBox>
                </div>
            </div>
        </div>
     </div>
</div>

<p class="h2">Datos del empleado</p>

<div class="row">
    <div class="col-md-6">
        <div class="input-group">
            <span class="input-group-addon">Nombre</span>
            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
         </div>
    </div>
    <div class="col-md-6">
        <div class="input-group">
            <span class="input-group-addon">Credencial</span>
            <asp:TextBox ID="txtCredencial" CssClass="form-control" runat="server" MaxLength="10" placeholder="Identificador"></asp:TextBox>
            <div class="input-group-btn">
                    <asp:LinkButton ID="lnkValidarCredencial" OnClick="lnkValidarCredencial_Click" runat="server" CssClass="btn btn-info">
                        <span class="glyphicon glyphicon-search"></span>
                    </asp:LinkButton>
            </div>
         </div>
    </div>
</div>

<br />

<div class="">
    <div class="panel panel-primary">
        <div class="panel-heading">
            <h3 class="panel-title">Ventas</h3>
        </div>
        <div class="panel-body">
            <asp:GridView ID="grdVentas" runat="server" AutoGenerateColumns="false" Width="100%" Height="100px" >
                <Columns>
                    <asp:BoundField DataField="Producto" HeaderText="Producto" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad / Kgs." />
                    <asp:BoundField DataField="Precio" HeaderText="Precio / U." />
                    <asp:BoundField DataField="Recuperacion" HeaderText="Recuperacion" />
                    <asp:BoundField DataField="Total" HeaderText="Total" />
                    <asp:BoundField DataField="SUBI" HeaderText="SUBI" />
                    <asp:BoundField DataField="IVA" HeaderText="IVA" />
                </Columns>
                <EmptyDataTemplate>
                    <span>No se encontró informacion</span>
                </EmptyDataTemplate>
            </asp:GridView>

            <div>
                <div class="row">
                    <div class="col-md-1">
                        <span>Limit</span>
                        <br />
                        <label>SI</label>
                    </div>
                    <div class="col-md-1">
                        <span>PERC.(%)</span>
                        <br />
                        <label>50.00</label>
                    </div>
                    <div class="col-md-1">
                        <span>S.xCLAS</span>
                        <br />
                        <label></label>
                    </div>
                    <div class="col-md-2">
                        <span>SUBS.xTurno($)</span>
                        <br />
                        <label>0.00</label>
                    </div>
                    <div class="col-md-1">
                        <span>SUBS. A BLO.($)</span>
                        <br />
                        <label>0.00</label>
                    </div>
                    <div class="col-md-1">
                        <span>SUBS. C. BLO.($)</span>
                        <br />
                        <label>0.00</label>
                    </div>
                    <div class="col-md-1">
                        <span>SUBS. TOT.($)</span>
                        <br />
                        <label>0.00</label>
                    </div>
                    <div class="col-md-1">
                        <span>SUBS LATA</span>
                        <br />
                        <label style="color:greenyellow">0.00</label>
                    </div>
                    <div class="col-md-3">
                        <div class="input-group">
                            <span class="input-group-addon">Subtotal</span>
                            <input type="text" class="form-control" style="color:greenyellow" value="0.00" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<div>
    <div class="row">
        <div class="col-md-5">
            <div class="input-group">
                <label class="input-group-addon">Catálogo de comidas</label>
                <asp:DropDownList ID="ddlCodigosComidas" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <div class="col-md-2">
            <div class="input-group">
                <label class="input-group-addon">Cantidad</label>
                <asp:TextBox ID="txtCantidad" runat="server" class="form-control" Text="1" />
            </div>
        </div>
        <div class="col-md-2">
            <asp:Button ID="btnAgregar" Text="Agregar" runat="server" CssClass="btn btn-success" OnClick="btnAgregar_Click" />
        </div>
        <div class="col-md-3">
            <div class="input-group">
                <label class="input-group-addon">IVA</label>
                <asp:TextBox runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
    </div>
</div>

<div>
    <div class="row">
        <div class="col-md-2">
            <asp:Button runat="server" CssClass="btn" Text="Venta y cambio" />
        </div>
        <div class="col-md-1">
            <asp:Button runat="server" CssClass="btn" Text="Cancelar" />
        </div>
        <div class="col-md-1">
            <asp:Button runat="server" CssClass="btn" Text="Precios" />
        </div>
        <div class="col-md-4"></div>
        <div class="col-md-1">
            <asp:Button runat="server" CssClass="btn" Text="Salir" />
        </div>
        <div class="col-md-3">
            <div class="input-group">
                <label class="input-group-addon">Total</label>
                <input class="form-control" type="text" style="color:greenyellow" value="0.00" />
            </div>
        </div>
    </div>
</div>

<script type="text/javascript">
    function updateTime()
    {
        var now = new Date().format("HH:mm");
        document.getElementById("<%= txtFecha.ClientID %>").value = now.toString();            
    }

    setInterval(updateTime, 10000); // 5 * 1000 miliseconds

</script>

</asp:Content>
