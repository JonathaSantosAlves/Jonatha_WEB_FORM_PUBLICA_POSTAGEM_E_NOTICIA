Imports System.Threading.Tasks
Imports System.Web.Services.Description
Imports Jonatha_WEB_FORM_VB_POSTAGEM_E_NOTICIAS_DOMAIN
Imports Jonatha_WEB_FORM_VB_POSTAGEM_E_NOTICIAS_REPOSITORIE

Public Class Pagina_Inicial
    Inherits System.Web.UI.Page

    Public injector_postagem As New Postagem_Injecao
    Public view_postagem As IEnumerable(Of Postagem)
    Public injector_noticias As New Noticias_Injecao
    Public view_noticias As IEnumerable(Of Noticias)

    Protected Async Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        view_postagem = Await injector_postagem.Resultados_Postagem.Coletar_Dados_Postagem
        view_noticias = Await injector_noticias.Resultados_Noticias.Coletar_Dados_Noticias
    End Sub

End Class

Public Class Postagem_Injecao

    Public Function Resultados_Postagem() As IPostagem
        Return New Postagem_Repositorie()
    End Function

End Class

Public Class Noticias_Injecao

    Public Function Resultados_Noticias() As INoticia
        Return New Noticias_Repositorie()
    End Function

End Class