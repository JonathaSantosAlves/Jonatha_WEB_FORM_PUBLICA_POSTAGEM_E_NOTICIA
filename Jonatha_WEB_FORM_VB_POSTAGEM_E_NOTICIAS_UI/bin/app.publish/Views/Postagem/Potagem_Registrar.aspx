<%@ Page ValidateRequest="false" Debug="true" Async="true" Title="Home Page" Language="vb" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="false" CodeBehind="Potagem_Registrar.aspx.vb" Inherits="Jonatha_WEB_FORM_VB_POSTAGEM_E_NOTICIAS_UI.Potagem_Registrar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid">
        <% If mensagem <> "" Then %>
        <script>
            alert(<%=mensagem%>);
        </script>

        <div class="alert alert-success alert-dismissable">
            <strong><%=mensagem%></strong>
        </div>
        <% End If %>

        <% If mensagem <> "" Then %>
        <script>
            alert(<%=mensagem%>);
        </script>

        <div class="alert alert-danger alert-dismissable">
            <strong><%=mensagem%></strong>
        </div>
        <% End If %>

        <div class="modal-header">
            <h4 class="modal-title">Criar um Post</h4>
        </div>
        <div class="modal-body">
            <div class="col">
                <label class="form-label">Titulo</label>
                <textarea id="txtTITULO" runat="server" class="form-control editortexto" type="text" required="required"></textarea>
            </div>
            <div class="col">
                <label class="form-label">Descrição</label>
                <textarea id="txtDESCRICAO" runat="server" class="form-control editortexto" type="text" required="required"></textarea>
            </div>
            <div class="col">
                <label class="form-label">Escolha o Tipo do Arquivo</label>
                <select id="slttipo" runat="server" class="form-select" required="required">
                    <option value="IMAGEM">IMAGEM</option>
                    <option value="VIDEO">VIDEO</option>
                    <option value="YOUTUBE">YOUTUBE</option>
                </select>
            </div>
            <div class="col">
                <label class="form-label">Link do Arquivo - (IMAGEM-VIDEO-PDF)</label>
                <input id="txtARQUIVO" runat="server" autocomplete="off" class="form-control" type="text" required="required">
            </div>
        </div>
        <hr />
        <div class="col">
            <div class="d-grid gap-2">
                <asp:Button id="btcadastrar" runat="server" Text="Salvar" type="submit" class="btn btn-success" OnClick="Cadastrar_Click"></asp:Button>
            </div>
        </div>
        <div asp-validation-summary="All" class="text-danger"></div>

    </div>
</asp:Content>
