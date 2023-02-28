Imports Jonatha_WEB_FORM_VB_POSTAGEM_E_NOTICIAS_DOMAIN
Imports Jonatha_WEB_FORM_VB_POSTAGEM_E_NOTICIAS_REPOSITORIE

Public Class Potagem_Registrar
    Inherits System.Web.UI.Page

    Public injector_postagem As New Postagem_Injecao
    Public view_postagem As IEnumerable(Of Postagem)
    Public mensagem As String

    Protected Async Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'view_postagem = Await injector_postagem.Resultados_Postagem.Registro()
        mensagem = ""
    End Sub

    Public Class Postagem_Injecao

        Public Function Resultados_Postagem() As IPostagem
            Return New Postagem_Repositorie()
        End Function
    End Class

    Protected Async Sub Cadastrar_Click(sender As Object, e As EventArgs)
        Dim entidade_postagem = New Postagem()

        entidade_postagem.USUARIO = "SISTEMA"
        entidade_postagem.TITULO = txtTITULO.Value
        entidade_postagem.ARQUIVO = txtARQUIVO.Value
        entidade_postagem.CURTIDA = 0
        entidade_postagem.DESCRICAO = txtDESCRICAO.Value
        entidade_postagem.TIPO = slttipo.Value

        Await injector_postagem.Resultados_Postagem.Registro(entidade_postagem)

        MsgBox("REGISTRO CONCLUIDO COM SUCESSO!!!")

        Response.Redirect("../Postagem/Potagem_Pagina_Inicial.aspx")
    End Sub
End Class