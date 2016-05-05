using System;
using System.Web;
using System.Web.UI;
using System.Data;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridview();
        }
    }
    protected void BindGridview()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("UserId", typeof(Int32));
        dt.Columns.Add("UserName", typeof(string));
        dt.Columns.Add("Education", typeof(string));
        dt.Columns.Add("Location", typeof(string));
        DataRow dtrow = dt.NewRow();    // Create New Row
        dtrow["UserId"] = 1;            //Bind Data to Columns
        dtrow["UserName"] = "SureshDasari";
        dtrow["Education"] = "B.Tech";
        dtrow["Location"] = "Chennai";
        dt.Rows.Add(dtrow);
        dtrow = dt.NewRow();               // Create New Row
        dtrow["UserId"] = 2;               //Bind Data to Columns
        dtrow["UserName"] = "MadhavSai";
        dtrow["Education"] = "MBA";
        dtrow["Location"] = "Nagpur";
        dt.Rows.Add(dtrow);
        dtrow = dt.NewRow();              // Create New Row
        dtrow["UserId"] = 3;              //Bind Data to Columns
        dtrow["UserName"] = "MaheshDasari";
        dtrow["Education"] = "B.Tech";
        dtrow["Location"] = "Nuzividu";
        dt.Rows.Add(dtrow);
        gvDetails.DataSource = dt;
        gvDetails.DataBind();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void btnPDF_Click(object sender, EventArgs e)
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=UserDetails.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        this.Page.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0.0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
    }
}