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
            <asp:GridView ID="grdVentas" runat="server" AutoGenerateColumns="false" Width="100%" Height="100px"
                AlternatingRowStyle-BackColor="#C2D69B" 
                OnRowEditing="grdVentas_RowEditing" 
                OnRowDataBound="grdVentas_RowDataBound" 
                OnRowCreated="grdVentas_RowCreated"
                CssClass="table table-bordered bs-table"
                
                >
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <span>Producto</span>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:DropDownList ID="ddlCodigosComidas" runat="server" AutoPostBack="true" CssClass="form-control" 
                                OnSelectedIndexChanged="ddlCodigosComidas_SelectedIndexChanged"></asp:DropDownList>     
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <span>Cantidad / Kgs.</span>
                        </HeaderTemplate>
                        <ItemTemplate>
                           <asp:TextBox ID="txtCantidad" CssClass="form-control" runat="server" Text='<%# Eval("Cantidad") %>' MaxLength="2"></asp:TextBox> 
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <span>Precio / U.</span>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtPrecio" runat="server" ReadOnly="true" CssClass="form-control" Text='<%# Eval("Precio") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <span>Recuperación</span>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtRecuperacion" runat="server" CssClass="form-control" ReadOnly="true" Text='<%# Eval("Recuperacion") %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <span>Total</span>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control" ReadOnly="true"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="SUBI" HeaderText="SUBI" />
                    <asp:BoundField DataField="IVA" HeaderText="IVA" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnDeleteProducto" CssClass="btn btn-danger" Text="Eliminar" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <span>No se encontró informacion</span>
                    
                    <asp:Button runat="server" ID="btnInsertar" Text="insertar" CommandName="Insert" />
                </EmptyDataTemplate>
            </asp:GridView>
            
            <div class="row">
                <div class="col-md-5"></div>
                <div class="col-md-4">
                    <asp:Button ID="btnAgregar" Text="Agregar" runat="server" CssClass="btn btn-success" OnClick="btnAgregar_Click" />
                </div>
                <div class="col-md-3"></div>
            </div>
            

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
            </div>
        </div>
        <div class="col-md-2">
           
        </div>
        <div class="col-md-2">
            
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
