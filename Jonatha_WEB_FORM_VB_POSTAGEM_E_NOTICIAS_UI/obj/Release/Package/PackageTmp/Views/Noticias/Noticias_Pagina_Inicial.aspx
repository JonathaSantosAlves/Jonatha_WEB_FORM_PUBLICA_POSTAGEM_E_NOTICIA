<%@ Page Debug="true" Async="true" Title="Home Page" Language="vb" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="false" CodeBehind="Noticias_Pagina_Inicial.aspx.vb" Inherits="Jonatha_WEB_FORM_VB_POSTAGEM_E_NOTICIAS_UI.Noticias_Pagina_Inicial" %>

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

    <div class="container-fluid bg-white">
        <div class="row">
            <div class="col">
                <div class="card">
                    <div class="card-header">
                        <label>Lista de Noticias</label>
                        <button type="button" class="btn btn-outline-primary float-end" onclick="location.href='../Noticias/Noticias_Registrar.aspx'">Nova Noticia</button>
                        <br />
                        <hr />
                    </div>
                    <div class="card-body">
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>DATA</th>
                                    <th>USUARIO</th>
                                    <th>TITULO</th>
                                    <th>ARQUIVO</th>
                                    <th>TIPO</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% If view_noticias.Count > 0 Then %>
                                <% For each noticia_item In view_noticias %>
                                <tr>
                                    <td><%=Convert.ToDateTime(noticia_item.DATA_REGISTRO).ToString("dd-MM-yyyy")%></td>
                                    <td><%=noticia_item.USUARIO%></td>
                                    <td><%=noticia_item.TITULO%></td>
                                    <td><%=noticia_item.ARQUIVO%></td>
                                    <td><%=noticia_item.TIPO%></td>
                                    <td>
                                        <button type="button" class="btn btnAlterar" data-id="<%=noticia_item.ID%>"><i class="fas fa-pen"></i></button>
                                    </td>
                                    <td>
                                        <button type="button" class="btn btnExcluir" data-id="<%=noticia_item.ID%>"><i class="far fa-trash-alt"></i></button>
                                    </td>
                                </tr>

                                <% Next %>
                                <% else %>
                                <template>Não há Post publicado</template>
                                <% End if %>
                            </tbody>
                        </table>
                        <div asp-validation-summary="All" class="text-danger"></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal" tabindex="-1" role="dialog" arial-hidden="true">
    </div>
    <script>

        $(".btnAlterar").click(function () {
            var Url = '../Noticias/Noticias_Alterar.aspx?ID=';
            var id_alterar = $(this).attr("data-id");
            $('.modal').load(Url + id_alterar, function () {
                $('.modal').modal('show');
            }); 
            $('.modal').modal('show');
        });

        $(".btnExcluir").click(function () {
            var id_delete = $(this).attr("data-id");

            if (confirm("Realmente deseja excluir esta Noticia?")) {

                alert("Noticia excluido com sucesso!");
                window.location.href = '../Noticias/Noticias_Pagina_Inicial.aspx?ID=' + id_delete;;
            }
        });
    </script>
</asp:Content>
