<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="ConsumoClima.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="subscribe-form" >
        <div>
            
        </div>
        <div>
            
        </div>
       </div>
    <main class="main-content">
				<div class="container">
					<div class="breadcrumb">
					
						<span><asp:Button ID="BtnCerrar" runat="server" Text="Logout"  OnClick="BtnCerrar_Click"/></span>
					</div>
					
				</div>

				<div class="fullwidth-block">
					<div class="container">
					
						<div class="col-md-8 col-md-offset-1">
							<h2 class="section-title"><asp:Label ID="lblBienvenida" runat="server" Text=""></asp:Label></h2>
							
								<div class="contact-form">
								<div class="row">
									<div class="col-md-6"><input type="text" placeholder="Your name..."></div>
									<div class="col-md-6"><input type="text" placeholder="Email Addresss..."></div>
								</div>
								<div class="row">
									<div class="col-md-6"><input type="text" placeholder="Company name..."></div>
									<div class="col-md-6"><input type="text" placeholder="Website..."></div>
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
									<input type="submit" placeholder="Send message">
								</div>
						</div>

						</div>
					</div>
				</div>
				
			</main> <!-- .main-content -->
</asp:Content>
