Imports Jonatha_WEB_FORM_VB_POSTAGEM_E_NOTICIAS_DOMAIN
Imports Jonatha_WEB_FORM_VB_POSTAGEM_E_NOTICIAS_REPOSITORIE

Public Class Potagem_Alterar
    Inherits System.Web.UI.Page

    Public injector_postagem As New Postagem_Injecao
    Public view_postagem As IEnumerable(Of Postagem)
    Public mensagem As String
    Public TITULO As String
    Public DESCRICAO As String
    Public TIPO As String

    Protected Async Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        mensagem = ""

        If Server.HtmlEncode(Request.QueryString("ID")) <> "" Then
            id_post.InnerHtml = Server.HtmlEncode(Request.QueryString("ID"))
            view_postagem = Await injector_postagem.Resultados_Postagem.Coletar_Dados_Postagem_ID(Server.HtmlEncode(Request.QueryString("ID")))

            For Each postagem_item In view_postagem
                TITULO = postagem_item.TITULO
                DESCRICAO = postagem_item.DESCRICAO
                TIPO = postagem_item.TIPO
            Next

        End If
    End Sub

    Public Class Postagem_Injecao

        Public Function Resultados_Postagem() As IPostagem
            Return New Postagem_Repositorie()
        End Function

    End Class

    Protected Async Sub Atualizar_Click(sender As Object, e As EventArgs)
        Dim entidade_postagem = New Postagem()

        entidade_postagem.TITULO = txtTITULO.Value
        entidade_postagem.DESCRICAO = txtDESCRICAO.Value
        entidade_postagem.TIPO = slcTIPO.Value
        entidade_postagem.ID = Server.HtmlEncode(Request.QueryString("ID"))

        Await injector_postagem.Resultados_Postagem.Alterar(entidade_postagem)

        MsgBox("POST ATUALIZADO COM SUCESSO!!!")

        Response.Redirect("../Postagem/Potagem_Pagina_Inicial.aspx")
    End Sub
End Class