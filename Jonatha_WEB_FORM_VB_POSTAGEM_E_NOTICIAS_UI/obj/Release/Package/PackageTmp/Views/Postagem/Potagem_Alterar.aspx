<%@ Page ValidateRequest="false" Debug="true" Async="true" Title="Home Page" Language="vb" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="false" CodeBehind="Potagem_Alterar.aspx.vb" Inherits="Jonatha_WEB_FORM_VB_POSTAGEM_E_NOTICIAS_UI.Potagem_Alterar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

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

    <div class="container">
        <br />
        <br />
        <div class="modal-dialog modal-xl modal-dialog-centere">
            <div class="modal-content">
                <div class="container">
                    <div class="modal-header">
                        <label runat="server" id="temp_lbl"></label>
                        <h4 class="modal-title">
                            <label id="id_post" runat="server" class="form-label"></label>
                            - Alterar um Post</h4>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" arial-label="Close" onclick="location.href='../Postagem/Potagem_Pagina_Inicial.aspx'"></button>
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
                            <select id="slcTIPO" runat="server" class="form-select" required="required">
                                <option value="IMAGEM">IMAGEM</option>
                                <option value="VIDEO">VIDEO</option>
                                <option value="YOUTUBE">YOUTUBE</option>
                            </select>
                        </div>
                    </div>
                    <hr />
                    <div class="col-12">
                        <div class="d-grid gap-2">
                            <asp:Button ID="btatualizar" runat="server" Text="Salvar" type="submit" class="btn btn-success" OnClick="Atualizar_Click"></asp:Button>
                            <br />
                        </div>
                    </div>
                    <div asp-validation-summary="All" class="text-danger"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
