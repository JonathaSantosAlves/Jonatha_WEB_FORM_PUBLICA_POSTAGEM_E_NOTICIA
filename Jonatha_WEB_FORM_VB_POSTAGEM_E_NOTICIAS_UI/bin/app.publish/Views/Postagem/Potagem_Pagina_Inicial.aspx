<%@ Page Debug="true" Async="true" Title="Home Page" Language="vb" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="false" CodeBehind="Potagem_Pagina_Inicial.aspx.vb" Inherits="Jonatha_WEB_FORM_VB_POSTAGEM_E_NOTICIAS_UI.Potagem_Pagina_Inicial" %>

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
                        <label>Lista de Post</label>
                        <button type="button" class="btn btn-outline-primary float-end" onclick="location.href='../Postagem/Potagem_Registrar.aspx'">Novo Post</button>
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
                                    <th>DESCRICAO</th>
                                    <th>TIPO</th>
                                </tr>
                            </thead>
                            <tbody>
                                <% If view_postagem.Count > 0 Then %>
                                <% For each postagem_item In view_postagem %>
                                <tr>
                                    <td><%=Convert.ToDateTime(postagem_item.DATA_REGISTRO).ToString("dd-MM-yyyy")%></td>
                                    <td><%=postagem_item.USUARIO%></td>
                                    <td><%=postagem_item.TITULO%></td>
                                    <td><%=postagem_item.ARQUIVO%></td>
                                    <td><%=postagem_item.DESCRICAO%></td>
                                    <td><%=postagem_item.TIPO%></td>
                                    <td>
                                        <button type="button" class="btn btnAlterar" data-id="<%=postagem_item.ID%>"><i class="fas fa-pen"></i></button>
                                    </td>
                                    <td>
                                        <button type="button" class="btn btnExcluir" data-id="<%=postagem_item.ID%>"><i class="far fa-trash-alt"></i></button>
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
            var Url = '../Postagem/Potagem_Alterar.aspx?ID=';
            var id_alterar = $(this).attr("data-id");
            $('.modal').load(Url + id_alterar, function () {
                $('.modal').modal('show');
            }); 
            $('.modal').modal('show');
        });

        //$(".btnAlterar").click(function () {
        //    var id_delete = $(this).attr("data-id");
        //    window.location.href = '../Postagem/Potagem_Alterar.aspx?ID=' + id_delete;;
        //});

        $(".btnExcluir").click(function () {
            var id_delete = $(this).attr("data-id");
            /*alert(id_delete);*/

            if (confirm("Realmente deseja excluir este Post?")) {

                alert("Post excluido com sucesso!");
                window.location.href = '../Postagem/Potagem_Pagina_Inicial.aspx?ID=' + id_delete;;
            }
        });
    </script>

    <%--    $("#<%=id_post.ClientID%>").html(id_alterar);
            alert(<%=id_post.InnerHtml%>);
            $('.modal').modal('show');--%>
</asp:Content>

