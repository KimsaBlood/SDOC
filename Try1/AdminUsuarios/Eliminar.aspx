<%@ Page Title="" Language="C#" MasterPageFile="~/MyMaster.master" AutoEventWireup="true" CodeFile="Eliminar.aspx.cs" Inherits="Eliminar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <h2>Eliminar cuenta</h2>
                <hr />
                <h3>¡Advertencia!</h3>
                <p>Al eliminar tu cuenta todos tus datos y avances serán eliminados incluyendo tu progreso</p>
                <p>Si eliminas tu cuenta no podrás crear una nueva con el mismo correo o nombre de usuario</p>
                <hr />
                <h3>¿Deseas eliminar tu cuenta?</h3>
                <asp:LinkButton runat="server" ID="delete" Text="Eliminar" CausesValidation="true" OnClientClick="Delete();" OnClick="Delete_Click" CssClass="btn btn-info" />
            </div>
            <div class="col-lg-1"></div>
        </div>
        
    </div>
    <script>
        function Delete() {
             event.preventDefault();
            var post = 0;
            $.confirm({
    title: 'Confirm!',
    content: 'Simple confirm!',
    buttons: {
        confirm: function () {
            __doPostBack('delete','1');
        },
        cancel: function () {
            $.alert('Canceled!');
        
        },
        
    }
            });
         
        }
    </script>
</asp:Content>

