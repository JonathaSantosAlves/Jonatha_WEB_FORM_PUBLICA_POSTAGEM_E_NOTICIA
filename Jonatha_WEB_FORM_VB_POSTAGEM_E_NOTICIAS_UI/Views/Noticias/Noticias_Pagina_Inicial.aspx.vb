Imports Jonatha_WEB_FORM_VB_POSTAGEM_E_NOTICIAS_DOMAIN
Imports Jonatha_WEB_FORM_VB_POSTAGEM_E_NOTICIAS_REPOSITORIE

Public Class Noticias_Pagina_Inicial
    Inherits System.Web.UI.Page

    Public injector_noticias As New Noticias_Injecao
    Public view_noticias As IEnumerable(Of Noticias)
    Public mensagem As String

    Protected Async Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        view_noticias = Await injector_noticias.Resultados_Noticias.Coletar_Dados_Noticias
        mensagem = ""

        If Server.HtmlEncode(Request.QueryString("ID")) <> "" Then
            injector_noticias.Resultados_Noticias.Deletar(Server.HtmlEncode(Request.QueryString("ID")))
            Response.Redirect("../Noticias/Noticias_Pagina_Inicial.aspx")
        End If
    End Sub

    Public Class Noticias_Injecao

        Public Function Resultados_Noticias() As INoticia
            Return New Noticias_Repositorie()
        End Function

    End Class

End Class