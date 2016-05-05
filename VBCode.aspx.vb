Imports System.Web
Imports System.Web.UI
Imports System.Data
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.html.simpleparser
Partial Class VBCode
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindGridview()
        End If
    End Sub
    Protected Sub BindGridview()
        Dim dt As New DataTable()
        dt.Columns.Add("UserId", GetType(Int32))
        dt.Columns.Add("UserName", GetType(String))
        dt.Columns.Add("Education", GetType(String))
        dt.Columns.Add("Location", GetType(String))
        Dim dtrow As DataRow = dt.NewRow()
        ' Create New Row
        dtrow("UserId") = 1
        'Bind Data to Columns
        dtrow("UserName") = "SureshDasari"
        dtrow("Education") = "B.Tech"
        dtrow("Location") = "Chennai"
        dt.Rows.Add(dtrow)
        dtrow = dt.NewRow()
        ' Create New Row
        dtrow("UserId") = 2
        'Bind Data to Columns
        dtrow("UserName") = "MadhavSai"
        dtrow("Education") = "MBA"
        dtrow("Location") = "Nagpur"
        dt.Rows.Add(dtrow)
        dtrow = dt.NewRow()
        ' Create New Row
        dtrow("UserId") = 3
        'Bind Data to Columns
        dtrow("UserName") = "MaheshDasari"
        dtrow("Education") = "B.Tech"
        dtrow("Location") = "Nuzividu"
        dt.Rows.Add(dtrow)
        gvDetails.DataSource = dt
        gvDetails.DataBind()
    End Sub

    Public Overrides Sub VerifyRenderingInServerForm(control As Control)
        ' Verifies that the control is rendered 

    End Sub
    Protected Sub btnPDF_Click(sender As Object, e As EventArgs)
        Response.ContentType = "application/pdf"
        Response.AddHeader("content-disposition", "attachment;filename=UserDetails.pdf")
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Dim sw As New StringWriter()
        Dim hw As New HtmlTextWriter(sw)
        Me.Page.RenderControl(hw)
        Dim sr As New StringReader(sw.ToString())
        Dim pdfDoc As New Document(PageSize.A4, 10.0F, 10.0F, 100.0F, 0.0F)
        Dim htmlparser As New HTMLWorker(pdfDoc)
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream)
        pdfDoc.Open()
        htmlparser.Parse(sr)
        pdfDoc.Close()
        Response.Write(pdfDoc)
        Response.[End]()
    End Sub
End Class
