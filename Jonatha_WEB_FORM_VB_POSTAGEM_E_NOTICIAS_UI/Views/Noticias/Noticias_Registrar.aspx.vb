Imports Jonatha_WEB_FORM_VB_POSTAGEM_E_NOTICIAS_DOMAIN
Imports Jonatha_WEB_FORM_VB_POSTAGEM_E_NOTICIAS_REPOSITORIE

Public Class Noticias_Registrar
    Inherits System.Web.UI.Page

    Public injector_noticias As New Noticias_Injecao
    Public view_noticias As IEnumerable(Of Noticias)
    Public mensagem As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        mensagem = ""
    End Sub
    Public Class Noticias_Injecao

        Public Function Resultados_Noticias() As INoticia
            Return New Noticias_Repositorie()
        End Function

    End Class

    Protected Async Sub Cadastrar_Click(sender As Object, e As EventArgs)
        Dim entidade_noticias = New Noticias()

        entidade_noticias.USUARIO = "SISTEMA"
        entidade_noticias.TITULO = txtTITULO.Value
        entidade_noticias.ARQUIVO = txtARQUIVO.Value
        entidade_noticias.TIPO = slttipo.Value

        Await injector_noticias.Resultados_Noticias.Registro(entidade_noticias)

        MsgBox("NOTICIA CADASTRADA COM SUCESSO!!!")

        Response.Redirect("../Noticias/Noticias_Pagina_Inicial.aspx")
    End Sub
End Class