using System;
using System.Data;
using iText.Kernel.Font;
using Aspose.Cells;
using GemBox.Document;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Npgsql;

namespace ConsoleApp2
{
    class Program
    {
        static void Main()
        {
            connection con = new connection();
            string sql = "SELECT * FROM driver";
            using (NpgsqlConnection connection = new NpgsqlConnection(con.GetConnectionString()))
            {
                connection.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sql, connection);
                DataTable ds = new DataTable();
                adapter.Fill(ds);
                DataSet setOne = new DataSet();
                setOne.Tables.Add(ds);
                setOne.WriteXml("Drivers.xml");
                Document document = new Document(new PdfDocument(new PdfWriter("Drivers.pdf")));
                Table table = new Table(ds.Columns.Count);
                String FONT = "C:\\Windows\\Fonts\\arial.ttf";
                PdfFont f1 = PdfFontFactory.CreateFont(FONT, "Cp1251");
                for (int j = 0; j < ds.Columns.Count; j++)
                {
                    iText.Layout.Element.Cell cell = new iText.Layout.Element.Cell();
                    cell.Add(new iText.Layout.Element.Paragraph(ds.Columns[j].ColumnName).SetFont(f1));
                    table.AddCell(cell);
                }
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    for (int k = 0; k < ds.Columns.Count; k++)
                    {
                        table.AddCell(new iText.Layout.Element.Paragraph(ds.Rows[i].ItemArray[k].ToString()).SetFont(f1));                        
                    }
                }
                document.Add(table);
                document.Close();
                ComponentInfo.SetLicense("FREE-LIMITED-KEY");
                DocumentModel docWord = DocumentModel.Load("Drivers.pdf",
                    new PdfLoadOptions()
                    {
                        LoadType = PdfLoadType.HighFidelity
                    });
                docWord.Save("Drivers.docx");
                Workbook workbookOne = new Workbook();
                
                workbookOne.ImportXml("Drivers.xml", "Sheet1", 0, 0);
                workbookOne.Save("Drivers.xlsx", SaveFormat.Auto);

                ////////////////////////////////////////////////////////////////////////////////////////////
                

                string sqlTwo = "SELECT dr.first_name, dr.last_name, rc.name " +
                                "FROM driver_rights_category " +
                                "INNER JOIN driver dr on driver_rights_category.id_driver = dr.id " +
                                "INNER JOIN rights_category rc on rc.id = driver_rights_category.id_rights_category ";
                adapter = new NpgsqlDataAdapter(sqlTwo, connection);
                DataTable dt = new DataTable();
                Document documentTwo = new Document(new PdfDocument(new PdfWriter("DriversRights.pdf")));
                adapter.Fill(dt);
                
                DataSet set = new DataSet();
                set.Tables.Add(dt);
                set.WriteXml("DriversRights.xml");
                PdfFont f2 = PdfFontFactory.CreateFont(FONT, "Cp1251");
                Table tableTwo = new Table(dt.Columns.Count);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    iText.Layout.Element.Cell cell = new iText.Layout.Element.Cell();
                    cell.Add(new iText.Layout.Element.Paragraph(dt.Columns[j].ColumnName).SetFont(f2));
                    tableTwo.AddCell(cell);
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int k = 0; k < dt.Columns.Count; k++)
                    {
                        tableTwo.AddCell(new iText.Layout.Element.Paragraph(dt.Rows[i].ItemArray[k].ToString()).SetFont(f2));                        
                    }
                }
                documentTwo.Add(tableTwo);
                documentTwo.Close(); ;
                DocumentModel docWordTwo = DocumentModel.Load("DriversRights.pdf",
                    new PdfLoadOptions()
                    {
                        LoadType = PdfLoadType.HighFidelity
                    });
                docWordTwo.Save("DriversRights.docx");
                Workbook workbook = new Workbook();
                workbook.ImportXml("DriversRights.xml", "Sheet1", 0, 0);
                workbook.Save("DriversRights.xlsx", SaveFormat.Auto);
            }
        }

       
    }
}