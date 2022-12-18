// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
// using QuestPDF.ReportSample;
// using QuestPDF.ReportSample.Layouts;

//ImagePlaceholder.Solid = true;

// var model = DataSource.GetReport();
// var report = new StandardReport(model);
// report.ShowInPreviewer();
//
// return;

class Program
{
    static void Main()
    {
        Document
        .Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(20));
    
                page.Header()
                    .AlignCenter()
                    .Text("SoftwareDesign Final Project Presentation")
                    .SemiBold().FontSize(30).FontColor(Colors.Blue.Darken3);
    
                page.Content()
                    .PaddingVertical(1, Unit.Centimetre)
                    .Column(x =>
                    {
                        x.Spacing(20);
    
                        x.Item().Table(t =>
                        {
                            t.ColumnsDefinition(c =>
                            {
                                c.RelativeColumn();
                                c.RelativeColumn(2);
                                c.RelativeColumn(2);
                                c.RelativeColumn(2);
                            });

                            t.Header(Header => {
                                Header.Cell().Border(1).AlignCenter().Text("ID");
                                Header.Cell().Border(1).AlignCenter().Text("Name");
                                Header.Cell().Border(1).AlignCenter().Text("B-Day");
                                Header.Cell().Border(1).AlignCenter().Text("Email");
                            });

                            t.Content(Content => {
                                foreach(var i in Enumerable.Range(1,15)) {
                                    var year = Placeholders.Random.Next(1980, 2015);
                                    var month = Placeholders.Random.Next(1, 12);
                                    var day = Placeholders.Random.Next(1, 30);
                                    Content.Cell().Border(1).Background(Colors.Grey.Lighten3).Padding(5).Text(i).FontSize(15);
                                    Content.Cell().Border(1).Padding(5).Text(Placeholders.Name()).FontSize(15);
                                    Content.Cell().Border(1).Background(Colors.Grey.Lighten3).Padding(5).Text($"{year}/{month}/{day}").FontSize(15);
                                    Content.Cell().Border(1).Padding(5).Text(Placeholders.Email()).FontSize(15);
                                }

                                Content.Cell().Column(2).Row(3).Background(Colors.Blue.Lighten3).Text("Samuel");
                            });
                            
                        });
    
                        x.Item().Text("Modify this line and the preview should show your changes instantly.");
                    });
    
                page.Footer()
                    .AlignCenter()
                    .Text(x =>
                    {
                        x.Span("Page ").FontColor("888777");
                        x.CurrentPageNumber();
                    });
            });
        })
        .ShowInPreviewer();       
    }
}
