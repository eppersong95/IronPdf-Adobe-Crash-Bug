using IronPdf;

var baseDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
var fileIdentifier = DateTime.UtcNow.Ticks;

//License key in email
IronPdf.License.LicenseKey = "";
IronPdf.Logging.Logger.EnableDebugging = true;
IronPdf.Logging.Logger.LogFilePath = $"{baseDirectory}\\Logs\\Logs-{fileIdentifier}.txt";
IronPdf.Logging.Logger.LoggingMode = IronPdf.Logging.Logger.LoggingModes.All;

var invoicePdf = new PdfDocument(File.ReadAllBytes($"{baseDirectory}\\Invoice-7766196.pdf"));
var backupDoc1Pdf = new PdfDocument(File.ReadAllBytes($"{baseDirectory}\\Backup-Doc-1.pdf"));
var backupDoc2Pdf = new PdfDocument(File.ReadAllBytes($"{baseDirectory}\\Backup-Doc-2.pdf"));

var mergedPdf = PdfDocument.Merge(new List<PdfDocument> { invoicePdf, backupDoc1Pdf, backupDoc2Pdf });

var outputPath = $"{baseDirectory}\\Output\\Adobe-Crash-Pdf-{fileIdentifier}.pdf";
File.WriteAllBytes(outputPath, mergedPdf.BinaryData);