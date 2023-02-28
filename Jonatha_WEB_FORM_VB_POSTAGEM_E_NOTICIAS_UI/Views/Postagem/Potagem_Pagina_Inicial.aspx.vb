Imports System.Threading.Tasks
Imports System.Web.Services
Imports System.Web.Services.Description
Imports Jonatha_WEB_FORM_VB_POSTAGEM_E_NOTICIAS_DOMAIN
Imports Jonatha_WEB_FORM_VB_POSTAGEM_E_NOTICIAS_REPOSITORIE

Public Class Potagem_Pagina_Inicial
    Inherits System.Web.UI.Page

    Public injector_postagem As New Postagem_Injecao
    Public view_postagem As IEnumerable(Of Postagem)
    Public mensagem As String

    Protected Async Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        view_postagem = Await injector_postagem.Resultados_Postagem.Coletar_Dados_Postagem
        mensagem = ""

        If Server.HtmlEncode(Request.QueryString("ID")) <> "" Then
            injector_postagem.Resultados_Postagem.Deletar(Server.HtmlEncode(Request.QueryString("ID")))
            Response.Redirect("../Postagem/Potagem_Pagina_Inicial.aspx")
        End If
    End Sub

    Public Class Postagem_Injecao

        Public Function Resultados_Postagem() As IPostagem
            Return New Postagem_Repositorie()
        End Function

    End Class
End Class