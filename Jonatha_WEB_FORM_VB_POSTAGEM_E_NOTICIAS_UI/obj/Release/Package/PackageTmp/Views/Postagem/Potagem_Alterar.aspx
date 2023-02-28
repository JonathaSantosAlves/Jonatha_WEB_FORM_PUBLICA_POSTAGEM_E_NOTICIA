<%@ Page Debug="true" Async="true" Title="Home Page" Language="vb" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="false" CodeBehind="Potagem_Alterar.aspx.vb" Inherits="Jonatha_WEB_FORM_VB_POSTAGEM_E_NOTICIAS_UI.Potagem_Alterar" %>

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
            '
                <div class="modal-content">
                    <div class="container">
                        <div class="modal-header">
                            <label runat="server" id="temp_lbl"></label>
                            <h4 class="modal-title">
                                <label id="id_post" runat="server" class="form-label"></label>
                                - Alterar um Post</h4>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" arial-label="Close" onclick="location.href='../Postagem/Potagem_Pagina_Inicial.aspx'"></button>
                        </div>
                        <% For Each postagem_item In view_postagem %>
                        <div class="modal-body">
                            <div class="col">
                                <label class="form-label">Titulo</label>
                                <textarea id="txtTITULO" class="form-control editortexto" type="text" required="required"><%=postagem_item.TITULO%></textarea>
                            </div>
                            <div class="col">
                                <label class="form-label">Descrição</label>
                                <textarea id="txtDESCRICAO" class="form-control editortexto" type="text" required="required"><%=postagem_item.DESCRICAO%></textarea>
                            </div>
                            <div class="col">
                                <label class="form-label">Escolha o Tipo do Arquivo</label>
                                <select class="form-select" required="required">
                                    <option value="IMAGEM">IMAGEM</option>
                                    <option value="VIDEO">VIDEO</option>
                                    <option value="YOUTUBE">YOUTUBE</option>
                                </select>
                            </div>
                        </div>
                        <% Next %>
                        <hr />
                        <div class="col-12">
                            <div class="d-grid gap-2">
                                <button OnClick="Unnamed1_Click" runat="server" type="submit" class="btn btn-success">
                                    Salvar
                                </button>
                                <br />
                            </div>
                        </div>
                        <div asp-validation-summary="All" class="text-danger"></div>
                    </div>
                </div>
        </div>
    </div>




</asp:Content>
