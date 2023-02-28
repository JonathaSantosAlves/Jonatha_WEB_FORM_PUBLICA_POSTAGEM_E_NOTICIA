Imports Jonatha_WEB_FORM_VB_POSTAGEM_E_NOTICIAS_DOMAIN
Imports Jonatha_WEB_FORM_VB_POSTAGEM_E_NOTICIAS_REPOSITORIE

Public Class Noticias_Alterar
    Inherits System.Web.UI.Page

    Public injector_noticias As New Noticias_Injecao
    Public view_noticias As IEnumerable(Of Noticias)
    Public mensagem As String

    Protected Async Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        mensagem = ""

        If Server.HtmlEncode(Request.QueryString("ID")) <> "" Then
            id_post.InnerHtml = Server.HtmlEncode(Request.QueryString("ID"))
            view_noticias = Await injector_noticias.Resultados_Noticias.Coletar_Dados_Noticias_ID(Server.HtmlEncode(Request.QueryString("ID")))
        End If
    End Sub

    Public Class Noticias_Injecao

        Public Function Resultados_Noticias() As INoticia
            Return New Noticias_Repositorie()
        End Function

    End Class

    Protected Async Sub Atualizar_Click(sender As Object, e As EventArgs)
        Dim entidade_noticias = New Noticias()

        entidade_noticias.TITULO = txtTITULO.Value
        entidade_noticias.TIPO = slcTIPO.Value
        entidade_noticias.ID = Server.HtmlEncode(Request.QueryString("ID"))

        Await injector_noticias.Resultados_Noticias.Alterar(entidade_noticias)

        MsgBox("NOTICIA ATUALIZADA COM SUCESSO!!!")

        Response.Redirect("../Noticias/Noticias_Pagina_Inicial.aspx")
    End Sub

End Class