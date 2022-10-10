<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="update.aspx.cs" Inherits="ConsumoClima.update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="main-content">
				<div class="container">
					<div class="breadcrumb">
						<a href="Admin.aspx">Home</a>
						
						<a href="Update.aspx">Update</a>
						
						<a href="Insert.aspx">Insert</a>
						
						<span><asp:Button ID="BtnCerrar" runat="server" Text="Logout"  OnClick="BtnCerrar_Click"/></span>
					</div>
					
				</div>

				<div class="fullwidth-block">
					<div class="container">
					
						<div class="col-md-8 col-md-offset-1">
							<h2 class="section-title"><asp:Label ID="lblBienvenida" runat="server" Text=""></asp:Label></h2>
							
									<div class="contact-form">
								<div class="row">
									<div class="col-md-6"><asp:DropDownList ID="DL_City" runat="server" OnSelectedIndexChanged="DL_City_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></div>
									<div class="col-md-6"><asp:DropDownList ID="Ddl_clima" runat="server">
                                        <asp:ListItem Value="0">Seleccione Tipo Clima</asp:ListItem>
                                        <asp:ListItem Value="1">Soleado</asp:ListItem>
                                        <asp:ListItem Value="2">Nublado</asp:ListItem>
                                        <asp:ListItem Value="3">Lloviznas</asp:ListItem>
                                        <asp:ListItem Value="4">Tormentas Electricas</asp:ListItem>
                                        </asp:DropDownList></div>
								</div>
								<div class="row">
									<div class="col-md-6"><input type="text" id="txt_Temperatura" runat="server" placeholder="Temperatura">
										<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_Temperatura" ErrorMessage="La temperatura debe ser mayor a 1 e inferior a 50" MaximumValue="50" MinimumValue="1" ForeColor="Red"></asp:RangeValidator>
									</div>
									
									<div class="col-md-6"><input type="text" id="txt_velocidad_viento" runat="server" placeholder="Velocidad del Viento">
										<asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txt_velocidad_viento" ErrorMessage="La velocidad debe ser mayor a 1 e inferior a 300" MaximumValue="300" MinimumValue="1" ForeColor="Red"></asp:RangeValidator>
									</div>
									
								</div>
										<div class="row">
									<div class="col-md-6"><input type="text" id="txt_posibilidad_lluvia" runat="server" placeholder="Posibilidad de lluvia ">
										<asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txt_posibilidad_lluvia" ErrorMessage="La velocidad debe ser mayor a 1 e inferior a 100" MaximumValue="100" MinimumValue="1" ForeColor="Red"></asp:RangeValidator>
									</div>
									<div class="col-md-6"><asp:DropDownList ID="Ddl_direccion_viento" runat="server">
                                        <asp:ListItem Value="0">Seleccione</asp:ListItem>
                                        <asp:ListItem Value="Norte">Norte</asp:ListItem>
                                        <asp:ListItem Value="Sur">Sur</asp:ListItem>
                                        <asp:ListItem Value="Este">Este</asp:ListItem>
                                        <asp:ListItem Value="Oeste">Oeste</asp:ListItem>
                                        </asp:DropDownList></div>
								</div>
								
		 <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true">
            <Columns>
                <asp:BoundField ItemStyle-Width="150px" DataField="id_ciudad" HeaderText="id_ciudad" />
                <asp:BoundField ItemStyle-Width="150px" DataField="nombre_ciudad" HeaderText="nombre_ciudad" />
                <asp:BoundField ItemStyle-Width="150px" DataField="tipo_clima" HeaderText="tipo_clima" />
                <asp:BoundField ItemStyle-Width="150px" DataField="temperatura" HeaderText="temperatura" />
				 <asp:BoundField ItemStyle-Width="150px" DataField="velocidad_viento" HeaderText="velocidad_viento" />
                <asp:BoundField ItemStyle-Width="150px" DataField="posibilidad_lluvia" HeaderText="posibilidad_lluvia" />
				  <asp:BoundField ItemStyle-Width="150px" DataField="direccion_viento" HeaderText="direccion_viento" />
            </Columns>
        </asp:GridView>
    </div>
								<div class="text-right">
									<asp:Button ID="Btn_save" runat="server" OnClick="Btn_save_Click" Text="Guardar" />
&nbsp;</div>
						</div>

						</div>
					</div>
				</div>
				
			</main> <!-- .main-content -->
</asp:Content>
