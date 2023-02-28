<%@ Page Debug="true" Async="true" Title="Home Page" Language="vb" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="false" CodeBehind="Pagina_Inicial.aspx.vb" Inherits="Jonatha_WEB_FORM_VB_POSTAGEM_E_NOTICIAS_UI.Pagina_Inicial" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid bg-white">
        <div class="row">
            <div class="col">
                <div class="border">
                    <h1 style="font-size: 3vmin; text-align: center">Publicações</h1>
                </div>
                <hr />

                <% If view_postagem.Count > 0 Then %>
                <% For each postagem_item In view_postagem %>
                <div class="card">
                    <div class="border">
                        <h5 style="font-size: 2.8vmin">
                            <span class="badge rounded-pill bg-primary">
                                <i class="far fa-user-circle"></i>Publicado por: <%=postagem_item.USUARIO%>
                            </span><small><span class="text-end"><%=Convert.ToDateTime(postagem_item.DATA_REGISTRO).ToString("dd-MM-yyyy")%></span></small>
                        </h5>

                        <div class="card-header">
                            <h2 style="font-size: 2.8vmin; text-align: center">
                                <span class=""><%=postagem_item.TITULO%>
                                </span>
                            </h2>
                        </div>
                        <div class="card-body">
                            <h3 style="font-size: 2.3vmin; text-align: center"><%=postagem_item.DESCRICAO%>
                            </h3>

                            <% If postagem_item.TIPO = "IMAGEM" Then %>
                            <center>
                                <img src="<%=postagem_item.ARQUIVO%>" class="img-fluid" alt="...">
                            </center>
                            <% End If %>
                            <% If postagem_item.TIPO = "VIDEO" Then %>
                            <center>
                                <div class="ratio ratio-21x9">
                                    <video controls>
                                        <source src="<%=postagem_item.ARQUIVO%>" type="video/mp4">
                                        Your browser does not support the video tag.
                                    </video>
                                </div>
                            </center>
                            <% End If %>
                            <% If postagem_item.TIPO = "YOUTUBE" Then %>
                            <center>
                                <div class="ratio ratio-21x9">
                                    <iframe src="<%=postagem_item.ARQUIVO%>" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" allowfullscreen></iframe>
                                </div>
                            </center>
                            <% End If %>
                        </div>
                    </div>
                </div>
                <hr />
                <% Next %>
                <% else %>
                <h5 class="text-center"><i class="far fa-sad-tear"></i>Não há post publicado</h5>
                <% End if %>
                <br />
            </div>

            <div class="col-3">
                <div class="border">
                    <h1 style="font-size: 3vmin; text-align: center">Noticias</h1>
                </div>
                <hr />

                <% If view_postagem.Count > 0 Then %>
                <% For each postagem_item In view_postagem %>
                <div class="card">
                    <div class="border">
                        <h5 style="font-size: 2.8vmin">
                            <span class="badge rounded-pill bg-primary">
                                <i class="far fa-user-circle"></i>Publicado por: <%=postagem_item.USUARIO%>
                            </span><small><span class="text-end"><%=Convert.ToDateTime(postagem_item.DATA_REGISTRO).ToString("dd-MM-yyyy")%></span></small>
                        </h5>

                        <div class="card-header">
                            <h2 style="font-size: 2.8vmin; text-align: center">
                                <span class=""><%=postagem_item.TITULO%>
                                </span>
                            </h2>
                        </div>
                        <div class="card-body">
                            <h3 style="font-size: 2.3vmin; text-align: center"><%=postagem_item.DESCRICAO%>
                            </h3>

                            <% If postagem_item.TIPO = "IMAGEM" Then %>
                            <center>
                                <img src="<%=postagem_item.ARQUIVO%>" class="img-fluid" alt="...">
                            </center>
                            <% End If %>
                            <% If postagem_item.TIPO = "VIDEO" Then %>
                            <center>
                                <div class="ratio ratio-21x9">
                                    <video controls>
                                        <source src="<%=postagem_item.ARQUIVO%>" type="video/mp4">
                                        Your browser does not support the video tag.
                                    </video>
                                </div>
                            </center>
                            <% End If %>
                            <% If postagem_item.TIPO = "YOUTUBE" Then %>
                            <center>
                                <div class="ratio ratio-21x9">
                                    <iframe src="<%=postagem_item.ARQUIVO%>" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" allowfullscreen></iframe>
                                </div>
                            </center>
                            <% End If %>
                        </div>
                    </div>
                </div>
                <hr />
                <% Next %>
                <% else %>
                <h5 class="text-center"><i class="far fa-sad-tear"></i>Não há Noticias publicada</h5>
                <% End if %>
                <br />
            </div>
        </div>
    </div>
</asp:Content>
