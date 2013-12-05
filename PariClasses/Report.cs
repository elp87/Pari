using DocumentFormat.OpenXml.Packaging;
using Ap = DocumentFormat.OpenXml.ExtendedProperties;
using Vt = DocumentFormat.OpenXml.VariantTypes;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using A = DocumentFormat.OpenXml.Drawing;
using M = DocumentFormat.OpenXml.Math;
using Ovml = DocumentFormat.OpenXml.Vml.Office;
using V = DocumentFormat.OpenXml.Vml;
using System;
using sw = System.Windows;

namespace PariClasses
{
    public class Report
    {
        // Creates a WordprocessingDocument.
        public void CreatePackage(string filePath, person Person, ListChildClass children, famStatusList famStatuses, famTypeList famTypes, childProblemList childProblems)
        {
            try
            {
                using (WordprocessingDocument package = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
                {
                    CreateParts(package, Person, children, famStatuses, famTypes, childProblems);
                }
            }
            catch (System.IO.IOException ex)
            {
                sw.MessageBox.Show(ex.Message); 
            }
        }

        // Adds child parts and generates content of the specified part.
        private void CreateParts(WordprocessingDocument document, person Person, ListChildClass children, famStatusList famStatuses, famTypeList famTypes, childProblemList childProblems)
        {
            ExtendedFilePropertiesPart extendedFilePropertiesPart1 = document.AddNewPart<ExtendedFilePropertiesPart>("rId3");
            GenerateExtendedFilePropertiesPart1Content(extendedFilePropertiesPart1);

            MainDocumentPart mainDocumentPart1 = document.AddMainDocumentPart();
            GenerateMainDocumentPart1Content(mainDocumentPart1, Person, children, famStatuses, famTypes, childProblems);

            ThemePart themePart1 = mainDocumentPart1.AddNewPart<ThemePart>("rId8");
            GenerateThemePart1Content(themePart1);

            DocumentSettingsPart documentSettingsPart1 = mainDocumentPart1.AddNewPart<DocumentSettingsPart>("rId3");
            GenerateDocumentSettingsPart1Content(documentSettingsPart1);

            FontTablePart fontTablePart1 = mainDocumentPart1.AddNewPart<FontTablePart>("rId7");
            GenerateFontTablePart1Content(fontTablePart1);

            StylesWithEffectsPart stylesWithEffectsPart1 = mainDocumentPart1.AddNewPart<StylesWithEffectsPart>("rId2");
            GenerateStylesWithEffectsPart1Content(stylesWithEffectsPart1);

            StyleDefinitionsPart styleDefinitionsPart1 = mainDocumentPart1.AddNewPart<StyleDefinitionsPart>("rId1");
            GenerateStyleDefinitionsPart1Content(styleDefinitionsPart1);

            EndnotesPart endnotesPart1 = mainDocumentPart1.AddNewPart<EndnotesPart>("rId6");
            GenerateEndnotesPart1Content(endnotesPart1);

            FootnotesPart footnotesPart1 = mainDocumentPart1.AddNewPart<FootnotesPart>("rId5");
            GenerateFootnotesPart1Content(footnotesPart1);

            WebSettingsPart webSettingsPart1 = mainDocumentPart1.AddNewPart<WebSettingsPart>("rId4");
            GenerateWebSettingsPart1Content(webSettingsPart1);

            SetPackageProperties(document);
        }

        // Generates content of extendedFilePropertiesPart1.
        private void GenerateExtendedFilePropertiesPart1Content(ExtendedFilePropertiesPart extendedFilePropertiesPart1)
        {
            Ap.Properties properties1 = new Ap.Properties();
            properties1.AddNamespaceDeclaration("vt", "http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes");
            Ap.Template template1 = new Ap.Template();
            template1.Text = "Normal";
            Ap.TotalTime totalTime1 = new Ap.TotalTime();
            totalTime1.Text = "170";
            Ap.Pages pages1 = new Ap.Pages();
            pages1.Text = "3";
            Ap.Words words1 = new Ap.Words();
            words1.Text = "162";
            Ap.Characters characters1 = new Ap.Characters(); 
            characters1.Text = "928";
            Ap.Application application1 = new Ap.Application();
            application1.Text = "Microsoft Office Word";
            Ap.DocumentSecurity documentSecurity1 = new Ap.DocumentSecurity();
            documentSecurity1.Text = "0";
            Ap.Lines lines1 = new Ap.Lines();
            lines1.Text = "7";
            Ap.Paragraphs paragraphs1 = new Ap.Paragraphs();
            paragraphs1.Text = "2";
            Ap.ScaleCrop scaleCrop1 = new Ap.ScaleCrop();
            scaleCrop1.Text = "false";

            Ap.HeadingPairs headingPairs1 = new Ap.HeadingPairs();

            Vt.VTVector vTVector1 = new Vt.VTVector() { BaseType = Vt.VectorBaseValues.Variant, Size = (UInt32Value)2U };

            Vt.Variant variant1 = new Vt.Variant();
            Vt.VTLPSTR vTLPSTR1 = new Vt.VTLPSTR();
            vTLPSTR1.Text = "Название";

            variant1.Append(vTLPSTR1);

            Vt.Variant variant2 = new Vt.Variant();
            Vt.VTInt32 vTInt321 = new Vt.VTInt32();
            vTInt321.Text = "1";

            variant2.Append(vTInt321);

            vTVector1.Append(variant1);
            vTVector1.Append(variant2);

            headingPairs1.Append(vTVector1);

            Ap.TitlesOfParts titlesOfParts1 = new Ap.TitlesOfParts();

            Vt.VTVector vTVector2 = new Vt.VTVector() { BaseType = Vt.VectorBaseValues.Lpstr, Size = (UInt32Value)1U };
            Vt.VTLPSTR vTLPSTR2 = new Vt.VTLPSTR();
            vTLPSTR2.Text = "";

            vTVector2.Append(vTLPSTR2);

            titlesOfParts1.Append(vTVector2);
            Ap.Company company1 = new Ap.Company();
            company1.Text = "";
            Ap.LinksUpToDate linksUpToDate1 = new Ap.LinksUpToDate();
            linksUpToDate1.Text = "false";
            Ap.CharactersWithSpaces charactersWithSpaces1 = new Ap.CharactersWithSpaces();
            charactersWithSpaces1.Text = "1088";
            Ap.SharedDocument sharedDocument1 = new Ap.SharedDocument();
            sharedDocument1.Text = "false";
            Ap.HyperlinksChanged hyperlinksChanged1 = new Ap.HyperlinksChanged();
            hyperlinksChanged1.Text = "false";
            Ap.ApplicationVersion applicationVersion1 = new Ap.ApplicationVersion();
            applicationVersion1.Text = "14.0000";

            properties1.Append(template1);
            properties1.Append(totalTime1);
            properties1.Append(pages1);
            properties1.Append(words1);
            properties1.Append(characters1);
            properties1.Append(application1);
            properties1.Append(documentSecurity1);
            properties1.Append(lines1);
            properties1.Append(paragraphs1);
            properties1.Append(scaleCrop1);
            properties1.Append(headingPairs1);
            properties1.Append(titlesOfParts1);
            properties1.Append(company1);
            properties1.Append(linksUpToDate1);
            properties1.Append(charactersWithSpaces1);
            properties1.Append(sharedDocument1);
            properties1.Append(hyperlinksChanged1);
            properties1.Append(applicationVersion1);

            extendedFilePropertiesPart1.Properties = properties1;
        }

        // Generates content of mainDocumentPart1.
        private void GenerateMainDocumentPart1Content(MainDocumentPart mainDocumentPart1, person Person, ListChildClass children, famStatusList famStatuses, famTypeList famTypes, childProblemList childProblems)
        {
            Document document1 = new Document() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 wp14" } };
            document1.AddNamespaceDeclaration("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
            document1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            document1.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
            document1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            document1.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
            document1.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
            document1.AddNamespaceDeclaration("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
            document1.AddNamespaceDeclaration("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
            document1.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
            document1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            document1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            document1.AddNamespaceDeclaration("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
            document1.AddNamespaceDeclaration("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
            document1.AddNamespaceDeclaration("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
            document1.AddNamespaceDeclaration("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");

            Body body1 = new Body();

            Paragraph paragraph1 = new Paragraph() { RsidParagraphMarkRevision = "00867E42", RsidParagraphAddition = "00851418", RsidParagraphProperties = "005C2EF3", RsidRunAdditionDefault = "005C2EF3" };

            ParagraphProperties paragraphProperties1 = new ParagraphProperties();
            Justification justification1 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties1 = new ParagraphMarkRunProperties();
            RunFonts runFonts1 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold1 = new Bold();
            FontSize fontSize1 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript1 = new FontSizeComplexScript() { Val = "28" };

            paragraphMarkRunProperties1.Append(runFonts1);
            paragraphMarkRunProperties1.Append(bold1);
            paragraphMarkRunProperties1.Append(fontSize1);
            paragraphMarkRunProperties1.Append(fontSizeComplexScript1);

            paragraphProperties1.Append(justification1);
            paragraphProperties1.Append(paragraphMarkRunProperties1);

            Run run1 = new Run() { RsidRunProperties = "005C2EF3" };

            RunProperties runProperties1 = new RunProperties();
            RunFonts runFonts2 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold2 = new Bold();
            FontSize fontSize2 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript2 = new FontSizeComplexScript() { Val = "28" };

            runProperties1.Append(runFonts2);
            runProperties1.Append(bold2);
            runProperties1.Append(fontSize2);
            runProperties1.Append(fontSizeComplexScript2);
            Text text1 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text1.Text = "Отчет о тесте по методике ";

            run1.Append(runProperties1);
            run1.Append(text1);

            Run run2 = new Run() { RsidRunProperties = "005C2EF3" };

            RunProperties runProperties2 = new RunProperties();
            RunFonts runFonts3 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold3 = new Bold();
            FontSize fontSize3 = new FontSize() { Val = "28" };
            FontSizeComplexScript fontSizeComplexScript3 = new FontSizeComplexScript() { Val = "28" };
            Languages languages1 = new Languages() { Val = "en-US" };

            runProperties2.Append(runFonts3);
            runProperties2.Append(bold3);
            runProperties2.Append(fontSize3);
            runProperties2.Append(fontSizeComplexScript3);
            runProperties2.Append(languages1);
            Text text2 = new Text();
            text2.Text = "PARI";

            run2.Append(runProperties2);
            run2.Append(text2);

            paragraph1.Append(paragraphProperties1);
            paragraph1.Append(run1);
            paragraph1.Append(run2);

            Paragraph paragraph2 = new Paragraph() { RsidParagraphAddition = "005C2EF3", RsidParagraphProperties = "005C2EF3", RsidRunAdditionDefault = "00867E42" };

            ParagraphProperties paragraphProperties2 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties2 = new ParagraphMarkRunProperties();
            RunFonts runFonts4 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize4 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript4 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties2.Append(runFonts4);
            paragraphMarkRunProperties2.Append(fontSize4);
            paragraphMarkRunProperties2.Append(fontSizeComplexScript4);

            paragraphProperties2.Append(paragraphMarkRunProperties2);

            Run run3 = new Run();

            RunProperties runProperties3 = new RunProperties();
            RunFonts runFonts5 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize5 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript5 = new FontSizeComplexScript() { Val = "24" };

            runProperties3.Append(runFonts5);
            runProperties3.Append(fontSize5);
            runProperties3.Append(fontSizeComplexScript5);
            Text text3 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text3.Text = "Фамилия – ";

            run3.Append(runProperties3);
            run3.Append(text3);

            Run run4 = new Run() { RsidRunAddition = "00CF6174" };

            RunProperties runProperties4 = new RunProperties();
            RunFonts runFonts6 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize6 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript6 = new FontSizeComplexScript() { Val = "24" };

            runProperties4.Append(runFonts6);
            runProperties4.Append(fontSize6);
            runProperties4.Append(fontSizeComplexScript6);
            Text text4 = new Text();
            text4.Text = Person.surname;

            run4.Append(runProperties4);
            run4.Append(text4);

            paragraph2.Append(paragraphProperties2);
            paragraph2.Append(run3);
            paragraph2.Append(run4);

            Paragraph paragraph3 = new Paragraph() { RsidParagraphAddition = "005C2EF3", RsidParagraphProperties = "005C2EF3", RsidRunAdditionDefault = "00867E42" };

            ParagraphProperties paragraphProperties3 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties3 = new ParagraphMarkRunProperties();
            RunFonts runFonts7 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize7 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript7 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties3.Append(runFonts7);
            paragraphMarkRunProperties3.Append(fontSize7);
            paragraphMarkRunProperties3.Append(fontSizeComplexScript7);

            paragraphProperties3.Append(paragraphMarkRunProperties3);

            Run run5 = new Run();

            RunProperties runProperties5 = new RunProperties();
            RunFonts runFonts8 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize8 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript8 = new FontSizeComplexScript() { Val = "24" };

            runProperties5.Append(runFonts8);
            runProperties5.Append(fontSize8);
            runProperties5.Append(fontSizeComplexScript8);
            Text text5 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text5.Text = "Имя – ";

            run5.Append(runProperties5);
            run5.Append(text5);

            Run run6 = new Run() { RsidRunAddition = "00CF6174" };

            RunProperties runProperties6 = new RunProperties();
            RunFonts runFonts9 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize9 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript9 = new FontSizeComplexScript() { Val = "24" };

            runProperties6.Append(runFonts9);
            runProperties6.Append(fontSize9);
            runProperties6.Append(fontSizeComplexScript9);
            Text text6 = new Text();
            text6.Text = Person.name;

            run6.Append(runProperties6);
            run6.Append(text6);

            paragraph3.Append(paragraphProperties3);
            paragraph3.Append(run5);
            paragraph3.Append(run6);

            Paragraph paragraph4 = new Paragraph() { RsidParagraphAddition = "005C2EF3", RsidParagraphProperties = "005C2EF3", RsidRunAdditionDefault = "00867E42" };

            ParagraphProperties paragraphProperties4 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties4 = new ParagraphMarkRunProperties();
            RunFonts runFonts10 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize10 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript10 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties4.Append(runFonts10);
            paragraphMarkRunProperties4.Append(fontSize10);
            paragraphMarkRunProperties4.Append(fontSizeComplexScript10);

            paragraphProperties4.Append(paragraphMarkRunProperties4);

            Run run7 = new Run();

            RunProperties runProperties7 = new RunProperties();
            RunFonts runFonts11 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize11 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript11 = new FontSizeComplexScript() { Val = "24" };

            runProperties7.Append(runFonts11);
            runProperties7.Append(fontSize11);
            runProperties7.Append(fontSizeComplexScript11);
            Text text7 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text7.Text = "Пол – ";

            run7.Append(runProperties7);
            run7.Append(text7);

            Run run8 = new Run() { RsidRunAddition = "00CF6174" };

            RunProperties runProperties8 = new RunProperties();
            RunFonts runFonts12 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize12 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript12 = new FontSizeComplexScript() { Val = "24" };

            runProperties8.Append(runFonts12);
            runProperties8.Append(fontSize12);
            runProperties8.Append(fontSizeComplexScript12);
            Text text8 = new Text();
            text8.Text = (Person.sex ? "муж" : "жен");

            run8.Append(runProperties8);
            run8.Append(text8);

            paragraph4.Append(paragraphProperties4);
            paragraph4.Append(run7);
            paragraph4.Append(run8);

            Paragraph paragraph5 = new Paragraph() { RsidParagraphAddition = "005C2EF3", RsidParagraphProperties = "005C2EF3", RsidRunAdditionDefault = "00867E42" };

            ParagraphProperties paragraphProperties5 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties5 = new ParagraphMarkRunProperties();
            RunFonts runFonts13 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize13 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript13 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties5.Append(runFonts13);
            paragraphMarkRunProperties5.Append(fontSize13);
            paragraphMarkRunProperties5.Append(fontSizeComplexScript13);

            paragraphProperties5.Append(paragraphMarkRunProperties5);

            Run run9 = new Run();

            RunProperties runProperties9 = new RunProperties();
            RunFonts runFonts14 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize14 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript14 = new FontSizeComplexScript() { Val = "24" };

            runProperties9.Append(runFonts14);
            runProperties9.Append(fontSize14);
            runProperties9.Append(fontSizeComplexScript14);
            Text text9 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text9.Text = "Возраст ";

            run9.Append(runProperties9);
            run9.Append(text9);

            Run run10 = new Run() { RsidRunAddition = "00C55AF9" };

            RunProperties runProperties10 = new RunProperties();
            RunFonts runFonts15 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize15 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript15 = new FontSizeComplexScript() { Val = "24" };

            runProperties10.Append(runFonts15);
            runProperties10.Append(fontSize15);
            runProperties10.Append(fontSizeComplexScript15);
            Text text10 = new Text();
            text10.Text = "–";

            run10.Append(runProperties10);
            run10.Append(text10);

            Run run11 = new Run();

            RunProperties runProperties11 = new RunProperties();
            RunFonts runFonts16 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize16 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript16 = new FontSizeComplexScript() { Val = "24" };

            runProperties11.Append(runFonts16);
            runProperties11.Append(fontSize16);
            runProperties11.Append(fontSizeComplexScript16);
            Text text11 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text11.Text = " ";

            run11.Append(runProperties11);
            run11.Append(text11);

            Run run12 = new Run() { RsidRunAddition = "00CF6174" };

            RunProperties runProperties12 = new RunProperties();
            RunFonts runFonts17 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize17 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript17 = new FontSizeComplexScript() { Val = "24" };

            runProperties12.Append(runFonts17);
            runProperties12.Append(fontSize17);
            runProperties12.Append(fontSizeComplexScript17);
            Text text12 = new Text();
            text12.Text = Convert.ToString(Person.age);

            run12.Append(runProperties12);
            run12.Append(text12);

            paragraph5.Append(paragraphProperties5);
            paragraph5.Append(run9);
            paragraph5.Append(run10);
            paragraph5.Append(run11);
            paragraph5.Append(run12);

            Paragraph paragraph6 = new Paragraph() { RsidParagraphAddition = "00C55AF9", RsidParagraphProperties = "005C2EF3", RsidRunAdditionDefault = "00C55AF9" };

            ParagraphProperties paragraphProperties6 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties6 = new ParagraphMarkRunProperties();
            RunFonts runFonts18 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize18 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript18 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties6.Append(runFonts18);
            paragraphMarkRunProperties6.Append(fontSize18);
            paragraphMarkRunProperties6.Append(fontSizeComplexScript18);

            paragraphProperties6.Append(paragraphMarkRunProperties6);

            Run run13 = new Run();

            RunProperties runProperties13 = new RunProperties();
            RunFonts runFonts19 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize19 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript19 = new FontSizeComplexScript() { Val = "24" };

            runProperties13.Append(runFonts19);
            runProperties13.Append(fontSize19);
            runProperties13.Append(fontSizeComplexScript19);
            Text text13 = new Text();
            text13.Text = "Семейное положение -";

            run13.Append(runProperties13);
            run13.Append(text13);

            Run run14 = new Run() { RsidRunAddition = "00CF6174" };

            RunProperties runProperties14 = new RunProperties();
            RunFonts runFonts20 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize20 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript20 = new FontSizeComplexScript() { Val = "24" };

            runProperties14.Append(runFonts20);
            runProperties14.Append(fontSize20);
            runProperties14.Append(fontSizeComplexScript20);
            Text text14 = new Text();
            text14.Text = famStatuses.getName(Person.familyStatus);

            run14.Append(runProperties14);
            run14.Append(text14);

            paragraph6.Append(paragraphProperties6);
            paragraph6.Append(run13);
            paragraph6.Append(run14);

            Paragraph paragraph7 = new Paragraph() { RsidParagraphAddition = "00C55AF9", RsidParagraphProperties = "005C2EF3", RsidRunAdditionDefault = "00C55AF9" };

            ParagraphProperties paragraphProperties7 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties7 = new ParagraphMarkRunProperties();
            RunFonts runFonts21 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize21 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript21 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties7.Append(runFonts21);
            paragraphMarkRunProperties7.Append(fontSize21);
            paragraphMarkRunProperties7.Append(fontSizeComplexScript21);

            paragraphProperties7.Append(paragraphMarkRunProperties7);

            Run run15 = new Run();

            RunProperties runProperties15 = new RunProperties();
            RunFonts runFonts22 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize22 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript22 = new FontSizeComplexScript() { Val = "24" };

            runProperties15.Append(runFonts22);
            runProperties15.Append(fontSize22);
            runProperties15.Append(fontSizeComplexScript22);
            Text text15 = new Text();
            text15.Text = "Категория семьи -";

            run15.Append(runProperties15);
            run15.Append(text15);

            Run run16 = new Run() { RsidRunAddition = "00CF6174" };

            RunProperties runProperties16 = new RunProperties();
            RunFonts runFonts23 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize23 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript23 = new FontSizeComplexScript() { Val = "24" };

            runProperties16.Append(runFonts23);
            runProperties16.Append(fontSize23);
            runProperties16.Append(fontSizeComplexScript23);
            Text text16 = new Text();
            text16.Text = famTypes.getName(Person.familyType);

            run16.Append(runProperties16);
            run16.Append(text16);

            paragraph7.Append(paragraphProperties7);
            paragraph7.Append(run15);
            paragraph7.Append(run16);

            Paragraph paragraph8 = new Paragraph() { RsidParagraphAddition = "00C55AF9", RsidParagraphProperties = "005C2EF3", RsidRunAdditionDefault = "00C55AF9" };

            ParagraphProperties paragraphProperties8 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties8 = new ParagraphMarkRunProperties();
            RunFonts runFonts24 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize24 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript24 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties8.Append(runFonts24);
            paragraphMarkRunProperties8.Append(fontSize24);
            paragraphMarkRunProperties8.Append(fontSizeComplexScript24);

            paragraphProperties8.Append(paragraphMarkRunProperties8);

            paragraph8.Append(paragraphProperties8);

            Paragraph paragraph9 = new Paragraph() { RsidParagraphAddition = "00C55AF9", RsidParagraphProperties = "005C2EF3", RsidRunAdditionDefault = "00C55AF9" };

            ParagraphProperties paragraphProperties9 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties9 = new ParagraphMarkRunProperties();
            RunFonts runFonts25 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize25 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript25 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties9.Append(runFonts25);
            paragraphMarkRunProperties9.Append(fontSize25);
            paragraphMarkRunProperties9.Append(fontSizeComplexScript25);

            paragraphProperties9.Append(paragraphMarkRunProperties9);

            Run run17 = new Run();

            RunProperties runProperties17 = new RunProperties();
            RunFonts runFonts26 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize26 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript26 = new FontSizeComplexScript() { Val = "24" };

            runProperties17.Append(runFonts26);
            runProperties17.Append(fontSize26);
            runProperties17.Append(fontSizeComplexScript26);
            Text text17 = new Text();
            text17.Text = "Дата заполнения:";

            run17.Append(runProperties17);
            run17.Append(text17);

            Run run18 = new Run() { RsidRunAddition = "00CF6174" };

            RunProperties runProperties18 = new RunProperties();
            RunFonts runFonts27 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize27 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript27 = new FontSizeComplexScript() { Val = "24" };

            runProperties18.Append(runFonts27);
            runProperties18.Append(fontSize27);
            runProperties18.Append(fontSizeComplexScript27);
            Text text18 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text18.Text = Convert.ToString(Person.testDate);

            run18.Append(runProperties18);
            run18.Append(text18);
            BookmarkStart bookmarkStart1 = new BookmarkStart() { Name = "_GoBack", Id = "0" };
            BookmarkEnd bookmarkEnd1 = new BookmarkEnd() { Id = "0" };

            paragraph9.Append(paragraphProperties9);
            paragraph9.Append(run17);
            paragraph9.Append(run18);
            paragraph9.Append(bookmarkStart1);
            paragraph9.Append(bookmarkEnd1);

            Paragraph paragraph10 = new Paragraph() { RsidParagraphAddition = "00FC0C7C", RsidParagraphProperties = "005C2EF3", RsidRunAdditionDefault = "00FC0C7C" };

            ParagraphProperties paragraphProperties10 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties10 = new ParagraphMarkRunProperties();
            RunFonts runFonts28 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize28 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript28 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties10.Append(runFonts28);
            paragraphMarkRunProperties10.Append(fontSize28);
            paragraphMarkRunProperties10.Append(fontSizeComplexScript28);

            paragraphProperties10.Append(paragraphMarkRunProperties10);

            paragraph10.Append(paragraphProperties10);

            Paragraph paragraph11 = new Paragraph() { RsidParagraphMarkRevision = "0077085F", RsidParagraphAddition = "003E3AA4", RsidParagraphProperties = "00FC0C7C", RsidRunAdditionDefault = "003E3AA4" };

            ParagraphProperties paragraphProperties11 = new ParagraphProperties();
            Justification justification2 = new Justification() { Val = JustificationValues.Center };

            ParagraphMarkRunProperties paragraphMarkRunProperties11 = new ParagraphMarkRunProperties();
            RunFonts runFonts29 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold4 = new Bold();
            FontSize fontSize29 = new FontSize() { Val = "32" };
            FontSizeComplexScript fontSizeComplexScript29 = new FontSizeComplexScript() { Val = "32" };

            paragraphMarkRunProperties11.Append(runFonts29);
            paragraphMarkRunProperties11.Append(bold4);
            paragraphMarkRunProperties11.Append(fontSize29);
            paragraphMarkRunProperties11.Append(fontSizeComplexScript29);

            paragraphProperties11.Append(justification2);
            paragraphProperties11.Append(paragraphMarkRunProperties11);

            Run run19 = new Run() { RsidRunProperties = "0077085F" };

            RunProperties runProperties19 = new RunProperties();
            RunFonts runFonts30 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold5 = new Bold();
            FontSize fontSize30 = new FontSize() { Val = "32" };
            FontSizeComplexScript fontSizeComplexScript30 = new FontSizeComplexScript() { Val = "32" };

            runProperties19.Append(runFonts30);
            runProperties19.Append(bold5);
            runProperties19.Append(fontSize30);
            runProperties19.Append(fontSizeComplexScript30);
            Text text19 = new Text();
            text19.Text = "Результаты тестирования:";

            run19.Append(runProperties19);
            run19.Append(text19);

            paragraph11.Append(paragraphProperties11);
            paragraph11.Append(run19);

            Paragraph paragraph12 = new Paragraph() { RsidParagraphMarkRevision = "0077085F", RsidParagraphAddition = "00DD4AEF", RsidParagraphProperties = "005C2EF3", RsidRunAdditionDefault = "007A34DB" };

            ParagraphProperties paragraphProperties12 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties12 = new ParagraphMarkRunProperties();
            RunFonts runFonts31 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold6 = new Bold();
            FontSize fontSize31 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript31 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties12.Append(runFonts31);
            paragraphMarkRunProperties12.Append(bold6);
            paragraphMarkRunProperties12.Append(fontSize31);
            paragraphMarkRunProperties12.Append(fontSizeComplexScript31);

            paragraphProperties12.Append(paragraphMarkRunProperties12);

            Run run20 = new Run() { RsidRunProperties = "0077085F" };

            RunProperties runProperties20 = new RunProperties();
            RunFonts runFonts32 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold7 = new Bold();
            FontSize fontSize32 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript32 = new FontSizeComplexScript() { Val = "24" };

            runProperties20.Append(runFonts32);
            runProperties20.Append(bold7);
            runProperties20.Append(fontSize32);
            runProperties20.Append(fontSizeComplexScript32);
            Text text20 = new Text();
            text20.Text = "ОТНОШЕНИЕ К СЕМЕЙНОЙ РОЛИ";

            run20.Append(runProperties20);
            run20.Append(text20);

            Run run21 = new Run() { RsidRunProperties = "0077085F", RsidRunAddition = "00DD4AEF" };

            RunProperties runProperties21 = new RunProperties();
            RunFonts runFonts33 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold8 = new Bold();
            FontSize fontSize33 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript33 = new FontSizeComplexScript() { Val = "24" };

            runProperties21.Append(runFonts33);
            runProperties21.Append(bold8);
            runProperties21.Append(fontSize33);
            runProperties21.Append(fontSizeComplexScript33);
            Text text21 = new Text();
            text21.Text = ":";

            run21.Append(runProperties21);
            run21.Append(text21);

            paragraph12.Append(paragraphProperties12);
            paragraph12.Append(run20);
            paragraph12.Append(run21);

            Paragraph paragraph13 = new Paragraph() { RsidParagraphMarkRevision = "0077085F", RsidParagraphAddition = "00DD4AEF", RsidParagraphProperties = "005C2EF3", RsidRunAdditionDefault = "00DD4AEF" };

            ParagraphProperties paragraphProperties13 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties13 = new ParagraphMarkRunProperties();
            RunFonts runFonts34 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold9 = new Bold();
            Italic italic1 = new Italic();
            FontSize fontSize34 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript34 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties13.Append(runFonts34);
            paragraphMarkRunProperties13.Append(bold9);
            paragraphMarkRunProperties13.Append(italic1);
            paragraphMarkRunProperties13.Append(fontSize34);
            paragraphMarkRunProperties13.Append(fontSizeComplexScript34);

            paragraphProperties13.Append(paragraphMarkRunProperties13);

            Run run22 = new Run() { RsidRunProperties = "0077085F" };

            RunProperties runProperties22 = new RunProperties();
            RunFonts runFonts35 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold10 = new Bold();
            Italic italic2 = new Italic();
            FontSize fontSize35 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript35 = new FontSizeComplexScript() { Val = "24" };

            runProperties22.Append(runFonts35);
            runProperties22.Append(bold10);
            runProperties22.Append(italic2);
            runProperties22.Append(fontSize35);
            runProperties22.Append(fontSizeComplexScript35);
            Text text22 = new Text();
            text22.Text = "Выше нормы:";

            run22.Append(runProperties22);
            run22.Append(text22);

            paragraph13.Append(paragraphProperties13);
            paragraph13.Append(run22);

            Paragraph paragraph14 = new Paragraph() { RsidParagraphAddition = "00DD4AEF", RsidParagraphProperties = "005C2EF3", RsidRunAdditionDefault = "0077085F" };

            ParagraphProperties paragraphProperties14 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties14 = new ParagraphMarkRunProperties();
            RunFonts runFonts36 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize36 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript36 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties14.Append(runFonts36);
            paragraphMarkRunProperties14.Append(fontSize36);
            paragraphMarkRunProperties14.Append(fontSizeComplexScript36);

            paragraphProperties14.Append(paragraphMarkRunProperties14);
            ProofError proofError1 = new ProofError() { Type = ProofingErrorValues.SpellStart };

            Run run23 = new Run();

            RunProperties runProperties23 = new RunProperties();
            RunFonts runFonts37 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize37 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript37 = new FontSizeComplexScript() { Val = "24" };

            runProperties23.Append(runFonts37);
            runProperties23.Append(fontSize37);
            runProperties23.Append(fontSizeComplexScript37);
            Text text23 = new Text();
            int familyRoleCount = 0;
            foreach (int i in person.lbFamilyRoleAspects)
            {
                if (Person.getAspect(i) >= 18)
                {
                    text23.Text = text23.Text + (familyRoleCount == 0 ? "" : ", ") + Person.getAspectName(i);
                    familyRoleCount++;
                }
            }

            run23.Append(runProperties23);
            run23.Append(text23);
            ProofError proofError2 = new ProofError() { Type = ProofingErrorValues.SpellEnd };

            Run run24 = new Run();

            RunProperties runProperties24 = new RunProperties();
            RunFonts runFonts38 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize38 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript38 = new FontSizeComplexScript() { Val = "24" };

            runProperties24.Append(runFonts38);
            runProperties24.Append(fontSize38);
            runProperties24.Append(fontSizeComplexScript38);
            Text text24 = new Text();
            text24.Text = "";

            run24.Append(runProperties24);
            run24.Append(text24);

            paragraph14.Append(paragraphProperties14);
            paragraph14.Append(proofError1);
            paragraph14.Append(run23);
            paragraph14.Append(proofError2);
            paragraph14.Append(run24);

            Paragraph paragraph15 = new Paragraph() { RsidParagraphMarkRevision = "0077085F", RsidParagraphAddition = "00DD4AEF", RsidParagraphProperties = "005C2EF3", RsidRunAdditionDefault = "00DD4AEF" };

            ParagraphProperties paragraphProperties15 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties15 = new ParagraphMarkRunProperties();
            RunFonts runFonts39 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold11 = new Bold();
            Italic italic3 = new Italic();
            FontSize fontSize39 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript39 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties15.Append(runFonts39);
            paragraphMarkRunProperties15.Append(bold11);
            paragraphMarkRunProperties15.Append(italic3);
            paragraphMarkRunProperties15.Append(fontSize39);
            paragraphMarkRunProperties15.Append(fontSizeComplexScript39);

            paragraphProperties15.Append(paragraphMarkRunProperties15);

            Run run25 = new Run() { RsidRunProperties = "0077085F" };

            RunProperties runProperties25 = new RunProperties();
            RunFonts runFonts40 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold12 = new Bold();
            Italic italic4 = new Italic();
            FontSize fontSize40 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript40 = new FontSizeComplexScript() { Val = "24" };

            runProperties25.Append(runFonts40);
            runProperties25.Append(bold12);
            runProperties25.Append(italic4);
            runProperties25.Append(fontSize40);
            runProperties25.Append(fontSizeComplexScript40);
            Text text25 = new Text();
            text25.Text = "Ниже нормы:";

            run25.Append(runProperties25);
            run25.Append(text25);

            paragraph15.Append(paragraphProperties15);
            paragraph15.Append(run25);

            Paragraph paragraph16 = new Paragraph() { RsidParagraphAddition = "00DD4AEF", RsidParagraphProperties = "005C2EF3", RsidRunAdditionDefault = "0077085F" };

            ParagraphProperties paragraphProperties16 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties16 = new ParagraphMarkRunProperties();
            RunFonts runFonts41 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize41 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript41 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties16.Append(runFonts41);
            paragraphMarkRunProperties16.Append(fontSize41);
            paragraphMarkRunProperties16.Append(fontSizeComplexScript41);

            paragraphProperties16.Append(paragraphMarkRunProperties16);

            Run run26 = new Run();

            RunProperties runProperties26 = new RunProperties();
            RunFonts runFonts42 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize42 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript42 = new FontSizeComplexScript() { Val = "24" };

            runProperties26.Append(runFonts42);
            runProperties26.Append(fontSize42);
            runProperties26.Append(fontSizeComplexScript42);
            Text text26 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            familyRoleCount = 0;
            foreach (int i in person.lbFamilyRoleAspects)
            {
                if (Person.getAspect(i) <= 8)
                {
                    text26.Text = text26.Text + (familyRoleCount == 0 ? "" : ", ") + Person.getAspectName(i);
                    familyRoleCount++;
                }
            }

            run26.Append(runProperties26);
            run26.Append(text26);
            ProofError proofError3 = new ProofError() { Type = ProofingErrorValues.GrammarStart };

            Run run27 = new Run();

            RunProperties runProperties27 = new RunProperties();
            RunFonts runFonts43 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize43 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript43 = new FontSizeComplexScript() { Val = "24" };

            runProperties27.Append(runFonts43);
            runProperties27.Append(fontSize43);
            runProperties27.Append(fontSizeComplexScript43);
            Text text27 = new Text();
            text27.Text = "";

            run27.Append(runProperties27);
            run27.Append(text27);
            ProofError proofError4 = new ProofError() { Type = ProofingErrorValues.GrammarEnd };

            Run run28 = new Run();

            RunProperties runProperties28 = new RunProperties();
            RunFonts runFonts44 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize44 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript44 = new FontSizeComplexScript() { Val = "24" };

            runProperties28.Append(runFonts44);
            runProperties28.Append(fontSize44);
            runProperties28.Append(fontSizeComplexScript44);
            Text text28 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text28.Text = "";

            run28.Append(runProperties28);
            run28.Append(text28);
            ProofError proofError5 = new ProofError() { Type = ProofingErrorValues.SpellStart };

            Run run29 = new Run();

            RunProperties runProperties29 = new RunProperties();
            RunFonts runFonts45 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize45 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript45 = new FontSizeComplexScript() { Val = "24" };

            runProperties29.Append(runFonts45);
            runProperties29.Append(fontSize45);
            runProperties29.Append(fontSizeComplexScript45);
            Text text29 = new Text();
            text29.Text = "";

            run29.Append(runProperties29);
            run29.Append(text29);
            ProofError proofError6 = new ProofError() { Type = ProofingErrorValues.SpellEnd };

            Run run30 = new Run();

            RunProperties runProperties30 = new RunProperties();
            RunFonts runFonts46 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize46 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript46 = new FontSizeComplexScript() { Val = "24" };

            runProperties30.Append(runFonts46);
            runProperties30.Append(fontSize46);
            runProperties30.Append(fontSizeComplexScript46);
            Text text30 = new Text();
            text30.Text = "";

            run30.Append(runProperties30);
            run30.Append(text30);

            paragraph16.Append(paragraphProperties16);
            paragraph16.Append(run26);
            paragraph16.Append(proofError3);
            paragraph16.Append(run27);
            paragraph16.Append(proofError4);
            paragraph16.Append(run28);
            paragraph16.Append(proofError5);
            paragraph16.Append(run29);
            paragraph16.Append(proofError6);
            paragraph16.Append(run30);

            Paragraph paragraph17 = new Paragraph() { RsidParagraphMarkRevision = "0077085F", RsidParagraphAddition = "00DD4AEF", RsidParagraphProperties = "005C2EF3", RsidRunAdditionDefault = "007A34DB" };

            ParagraphProperties paragraphProperties17 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties17 = new ParagraphMarkRunProperties();
            RunFonts runFonts47 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold13 = new Bold();
            Italic italic5 = new Italic();
            FontSize fontSize47 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript47 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties17.Append(runFonts47);
            paragraphMarkRunProperties17.Append(bold13);
            paragraphMarkRunProperties17.Append(italic5);
            paragraphMarkRunProperties17.Append(fontSize47);
            paragraphMarkRunProperties17.Append(fontSizeComplexScript47);

            paragraphProperties17.Append(paragraphMarkRunProperties17);

            Run run31 = new Run() { RsidRunProperties = "0077085F" };

            RunProperties runProperties31 = new RunProperties();
            RunFonts runFonts48 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold14 = new Bold();
            Italic italic6 = new Italic();
            FontSize fontSize48 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript48 = new FontSizeComplexScript() { Val = "24" };

            runProperties31.Append(runFonts48);
            runProperties31.Append(bold14);
            runProperties31.Append(italic6);
            runProperties31.Append(fontSize48);
            runProperties31.Append(fontSizeComplexScript48);
            Text text31 = new Text();
            text31.Text = "В норме";

            run31.Append(runProperties31);
            run31.Append(text31);

            paragraph17.Append(paragraphProperties17);
            paragraph17.Append(run31);

            Paragraph paragraph18 = new Paragraph() { RsidParagraphAddition = "007A34DB", RsidParagraphProperties = "005C2EF3", RsidRunAdditionDefault = "0077085F" };

            ParagraphProperties paragraphProperties18 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties18 = new ParagraphMarkRunProperties();
            RunFonts runFonts49 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize49 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript49 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties18.Append(runFonts49);
            paragraphMarkRunProperties18.Append(fontSize49);
            paragraphMarkRunProperties18.Append(fontSizeComplexScript49);

            paragraphProperties18.Append(paragraphMarkRunProperties18);

            Run run32 = new Run();

            RunProperties runProperties32 = new RunProperties();
            RunFonts runFonts50 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize50 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript50 = new FontSizeComplexScript() { Val = "24" };

            runProperties32.Append(runFonts50);
            runProperties32.Append(fontSize50);
            runProperties32.Append(fontSizeComplexScript50);
            Text text32 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            familyRoleCount = 0;
            foreach (int i in person.lbFamilyRoleAspects)
            {
                if ((Person.getAspect(i) > 8) && (Person.getAspect(i) < 18))
                {
                    text32.Text = text32.Text + (familyRoleCount == 0 ? "" : ", ") + Person.getAspectName(i);
                    familyRoleCount++;
                }
            }
            
            run32.Append(runProperties32);
            run32.Append(text32);
            ProofError proofError7 = new ProofError() { Type = ProofingErrorValues.GrammarStart };

            Run run33 = new Run();

            RunProperties runProperties33 = new RunProperties();
            RunFonts runFonts51 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize51 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript51 = new FontSizeComplexScript() { Val = "24" };

            runProperties33.Append(runFonts51);
            runProperties33.Append(fontSize51);
            runProperties33.Append(fontSizeComplexScript51);
            Text text33 = new Text();
            text33.Text = "";

            run33.Append(runProperties33);
            run33.Append(text33);
            ProofError proofError8 = new ProofError() { Type = ProofingErrorValues.GrammarEnd };

            Run run34 = new Run();

            RunProperties runProperties34 = new RunProperties();
            RunFonts runFonts52 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize52 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript52 = new FontSizeComplexScript() { Val = "24" };

            runProperties34.Append(runFonts52);
            runProperties34.Append(fontSize52);
            runProperties34.Append(fontSizeComplexScript52);
            Text text34 = new Text();
            text34.Text = "";

            run34.Append(runProperties34);
            run34.Append(text34);

            paragraph18.Append(paragraphProperties18);
            paragraph18.Append(run32);
            paragraph18.Append(proofError7);
            paragraph18.Append(run33);
            paragraph18.Append(proofError8);
            paragraph18.Append(run34);

            Paragraph paragraph19 = new Paragraph() { RsidParagraphAddition = "0077085F", RsidParagraphProperties = "005C2EF3", RsidRunAdditionDefault = "0077085F" };

            ParagraphProperties paragraphProperties19 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties19 = new ParagraphMarkRunProperties();
            RunFonts runFonts53 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize53 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript53 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties19.Append(runFonts53);
            paragraphMarkRunProperties19.Append(fontSize53);
            paragraphMarkRunProperties19.Append(fontSizeComplexScript53);

            paragraphProperties19.Append(paragraphMarkRunProperties19);

            paragraph19.Append(paragraphProperties19);

            Paragraph paragraph20 = new Paragraph() { RsidParagraphAddition = "007A34DB", RsidParagraphProperties = "005C2EF3", RsidRunAdditionDefault = "007A34DB" };

            ParagraphProperties paragraphProperties20 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties20 = new ParagraphMarkRunProperties();
            RunFonts runFonts54 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize54 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript54 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties20.Append(runFonts54);
            paragraphMarkRunProperties20.Append(fontSize54);
            paragraphMarkRunProperties20.Append(fontSizeComplexScript54);

            paragraphProperties20.Append(paragraphMarkRunProperties20);

            Run run35 = new Run();

            RunProperties runProperties35 = new RunProperties();
            RunFonts runFonts55 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize55 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript55 = new FontSizeComplexScript() { Val = "24" };

            runProperties35.Append(runFonts55);
            runProperties35.Append(fontSize55);
            runProperties35.Append(fontSizeComplexScript55);
            Text text35 = new Text();
            text35.Text = "ОТНОШЕНИЕ РОДИТЕЛЕЙ К РЕБЕНКУ";

            run35.Append(runProperties35);
            run35.Append(text35);

            paragraph20.Append(paragraphProperties20);
            paragraph20.Append(run35);

            Paragraph paragraph21 = new Paragraph() { RsidParagraphAddition = "007A34DB", RsidParagraphProperties = "005C2EF3", RsidRunAdditionDefault = "007A34DB" };

            ParagraphProperties paragraphProperties21 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties21 = new ParagraphMarkRunProperties();
            RunFonts runFonts56 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize56 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript56 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties21.Append(runFonts56);
            paragraphMarkRunProperties21.Append(fontSize56);
            paragraphMarkRunProperties21.Append(fontSizeComplexScript56);

            paragraphProperties21.Append(paragraphMarkRunProperties21);

            Run run36 = new Run();

            RunProperties runProperties36 = new RunProperties();
            RunFonts runFonts57 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize57 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript57 = new FontSizeComplexScript() { Val = "24" };

            runProperties36.Append(runFonts57);
            runProperties36.Append(fontSize57);
            runProperties36.Append(fontSizeComplexScript57);
            Text text36 = new Text();
            text36.Text = "Оптимальный эмоциональный контакт";

            run36.Append(runProperties36);
            run36.Append(text36);

            paragraph21.Append(paragraphProperties21);
            paragraph21.Append(run36);

            Paragraph paragraph22 = new Paragraph() { RsidParagraphMarkRevision = "0077085F", RsidParagraphAddition = "0077085F", RsidParagraphProperties = "0077085F", RsidRunAdditionDefault = "0077085F" };

            ParagraphProperties paragraphProperties22 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties22 = new ParagraphMarkRunProperties();
            RunFonts runFonts58 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold15 = new Bold();
            Italic italic7 = new Italic();
            FontSize fontSize58 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript58 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties22.Append(runFonts58);
            paragraphMarkRunProperties22.Append(bold15);
            paragraphMarkRunProperties22.Append(italic7);
            paragraphMarkRunProperties22.Append(fontSize58);
            paragraphMarkRunProperties22.Append(fontSizeComplexScript58);

            paragraphProperties22.Append(paragraphMarkRunProperties22);

            Run run37 = new Run() { RsidRunProperties = "0077085F" };

            RunProperties runProperties37 = new RunProperties();
            RunFonts runFonts59 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold16 = new Bold();
            Italic italic8 = new Italic();
            FontSize fontSize59 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript59 = new FontSizeComplexScript() { Val = "24" };

            runProperties37.Append(runFonts59);
            runProperties37.Append(bold16);
            runProperties37.Append(italic8);
            runProperties37.Append(fontSize59);
            runProperties37.Append(fontSizeComplexScript59);
            Text text37 = new Text();
            text37.Text = "Выше нормы:";

            run37.Append(runProperties37);
            run37.Append(text37);

            paragraph22.Append(paragraphProperties22);
            paragraph22.Append(run37);

            Paragraph paragraph23 = new Paragraph() { RsidParagraphAddition = "0077085F", RsidParagraphProperties = "0077085F", RsidRunAdditionDefault = "0077085F" };

            ParagraphProperties paragraphProperties23 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties23 = new ParagraphMarkRunProperties();
            RunFonts runFonts60 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize60 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript60 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties23.Append(runFonts60);
            paragraphMarkRunProperties23.Append(fontSize60);
            paragraphMarkRunProperties23.Append(fontSizeComplexScript60);

            paragraphProperties23.Append(paragraphMarkRunProperties23);
            ProofError proofError9 = new ProofError() { Type = ProofingErrorValues.SpellStart };

            Run run38 = new Run();

            RunProperties runProperties38 = new RunProperties();
            RunFonts runFonts61 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize61 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript61 = new FontSizeComplexScript() { Val = "24" };

            runProperties38.Append(runFonts61);
            runProperties38.Append(fontSize61);
            runProperties38.Append(fontSizeComplexScript61);
            Text text38 = new Text();
            int OptimalContactCount = 0;
            foreach (int i in person.lbOptimalContactAspects)
            {
                if (Person.getAspect(i) >= 18)
                {
                    text38.Text = text38.Text + (OptimalContactCount == 0 ? "" : ", ") + Person.getAspectName(i);
                    OptimalContactCount++;
                }
            }
            
            run38.Append(runProperties38);
            run38.Append(text38);
            ProofError proofError10 = new ProofError() { Type = ProofingErrorValues.SpellEnd };

            Run run39 = new Run();

            RunProperties runProperties39 = new RunProperties();
            RunFonts runFonts62 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize62 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript62 = new FontSizeComplexScript() { Val = "24" };

            runProperties39.Append(runFonts62);
            runProperties39.Append(fontSize62);
            runProperties39.Append(fontSizeComplexScript62);
            Text text39 = new Text();
            text39.Text = "";

            run39.Append(runProperties39);
            run39.Append(text39);

            paragraph23.Append(paragraphProperties23);
            paragraph23.Append(proofError9);
            paragraph23.Append(run38);
            paragraph23.Append(proofError10);
            paragraph23.Append(run39);

            Paragraph paragraph24 = new Paragraph() { RsidParagraphMarkRevision = "0077085F", RsidParagraphAddition = "0077085F", RsidParagraphProperties = "0077085F", RsidRunAdditionDefault = "0077085F" };

            ParagraphProperties paragraphProperties24 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties24 = new ParagraphMarkRunProperties();
            RunFonts runFonts63 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold17 = new Bold();
            Italic italic9 = new Italic();
            FontSize fontSize63 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript63 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties24.Append(runFonts63);
            paragraphMarkRunProperties24.Append(bold17);
            paragraphMarkRunProperties24.Append(italic9);
            paragraphMarkRunProperties24.Append(fontSize63);
            paragraphMarkRunProperties24.Append(fontSizeComplexScript63);

            paragraphProperties24.Append(paragraphMarkRunProperties24);

            Run run40 = new Run() { RsidRunProperties = "0077085F" };

            RunProperties runProperties40 = new RunProperties();
            RunFonts runFonts64 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold18 = new Bold();
            Italic italic10 = new Italic();
            FontSize fontSize64 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript64 = new FontSizeComplexScript() { Val = "24" };

            runProperties40.Append(runFonts64);
            runProperties40.Append(bold18);
            runProperties40.Append(italic10);
            runProperties40.Append(fontSize64);
            runProperties40.Append(fontSizeComplexScript64);
            Text text40 = new Text();
            text40.Text = "Ниже нормы:";

            run40.Append(runProperties40);
            run40.Append(text40);

            paragraph24.Append(paragraphProperties24);
            paragraph24.Append(run40);

            Paragraph paragraph25 = new Paragraph() { RsidParagraphAddition = "0077085F", RsidParagraphProperties = "0077085F", RsidRunAdditionDefault = "0077085F" };

            ParagraphProperties paragraphProperties25 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties25 = new ParagraphMarkRunProperties();
            RunFonts runFonts65 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize65 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript65 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties25.Append(runFonts65);
            paragraphMarkRunProperties25.Append(fontSize65);
            paragraphMarkRunProperties25.Append(fontSizeComplexScript65);

            paragraphProperties25.Append(paragraphMarkRunProperties25);

            Run run41 = new Run();

            RunProperties runProperties41 = new RunProperties();
            RunFonts runFonts66 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize66 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript66 = new FontSizeComplexScript() { Val = "24" };

            runProperties41.Append(runFonts66);
            runProperties41.Append(fontSize66);
            runProperties41.Append(fontSizeComplexScript66);
            Text text41 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            OptimalContactCount = 0;
            foreach (int i in person.lbOptimalContactAspects)
            {
                if (Person.getAspect(i) <= 8)
                {
                    text41.Text = text41.Text + (OptimalContactCount == 0 ? "" : ", ") + Person.getAspectName(i);
                    OptimalContactCount++;
                }
            } 

            run41.Append(runProperties41);
            run41.Append(text41);
            ProofError proofError11 = new ProofError() { Type = ProofingErrorValues.GrammarStart };

            Run run42 = new Run();

            RunProperties runProperties42 = new RunProperties();
            RunFonts runFonts67 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize67 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript67 = new FontSizeComplexScript() { Val = "24" };

            runProperties42.Append(runFonts67);
            runProperties42.Append(fontSize67);
            runProperties42.Append(fontSizeComplexScript67);
            Text text42 = new Text();
            text42.Text = "";

            run42.Append(runProperties42);
            run42.Append(text42);
            ProofError proofError12 = new ProofError() { Type = ProofingErrorValues.GrammarEnd };

            Run run43 = new Run();

            RunProperties runProperties43 = new RunProperties();
            RunFonts runFonts68 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize68 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript68 = new FontSizeComplexScript() { Val = "24" };

            runProperties43.Append(runFonts68);
            runProperties43.Append(fontSize68);
            runProperties43.Append(fontSizeComplexScript68);
            Text text43 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text43.Text = "";

            run43.Append(runProperties43);
            run43.Append(text43);
            ProofError proofError13 = new ProofError() { Type = ProofingErrorValues.SpellStart };

            Run run44 = new Run();

            RunProperties runProperties44 = new RunProperties();
            RunFonts runFonts69 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize69 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript69 = new FontSizeComplexScript() { Val = "24" };

            runProperties44.Append(runFonts69);
            runProperties44.Append(fontSize69);
            runProperties44.Append(fontSizeComplexScript69);
            Text text44 = new Text();
            text44.Text = "";

            run44.Append(runProperties44);
            run44.Append(text44);
            ProofError proofError14 = new ProofError() { Type = ProofingErrorValues.SpellEnd };

            Run run45 = new Run();

            RunProperties runProperties45 = new RunProperties();
            RunFonts runFonts70 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize70 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript70 = new FontSizeComplexScript() { Val = "24" };

            runProperties45.Append(runFonts70);
            runProperties45.Append(fontSize70);
            runProperties45.Append(fontSizeComplexScript70);
            Text text45 = new Text();
            text45.Text = "";

            run45.Append(runProperties45);
            run45.Append(text45);

            paragraph25.Append(paragraphProperties25);
            paragraph25.Append(run41);
            paragraph25.Append(proofError11);
            paragraph25.Append(run42);
            paragraph25.Append(proofError12);
            paragraph25.Append(run43);
            paragraph25.Append(proofError13);
            paragraph25.Append(run44);
            paragraph25.Append(proofError14);
            paragraph25.Append(run45);

            Paragraph paragraph26 = new Paragraph() { RsidParagraphMarkRevision = "0077085F", RsidParagraphAddition = "0077085F", RsidParagraphProperties = "0077085F", RsidRunAdditionDefault = "0077085F" };

            ParagraphProperties paragraphProperties26 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties26 = new ParagraphMarkRunProperties();
            RunFonts runFonts71 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold19 = new Bold();
            Italic italic11 = new Italic();
            FontSize fontSize71 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript71 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties26.Append(runFonts71);
            paragraphMarkRunProperties26.Append(bold19);
            paragraphMarkRunProperties26.Append(italic11);
            paragraphMarkRunProperties26.Append(fontSize71);
            paragraphMarkRunProperties26.Append(fontSizeComplexScript71);

            paragraphProperties26.Append(paragraphMarkRunProperties26);

            Run run46 = new Run() { RsidRunProperties = "0077085F" };

            RunProperties runProperties46 = new RunProperties();
            RunFonts runFonts72 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold20 = new Bold();
            Italic italic12 = new Italic();
            FontSize fontSize72 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript72 = new FontSizeComplexScript() { Val = "24" };

            runProperties46.Append(runFonts72);
            runProperties46.Append(bold20);
            runProperties46.Append(italic12);
            runProperties46.Append(fontSize72);
            runProperties46.Append(fontSizeComplexScript72);
            Text text46 = new Text();
            text46.Text = "В норме";

            run46.Append(runProperties46);
            run46.Append(text46);

            paragraph26.Append(paragraphProperties26);
            paragraph26.Append(run46);

            Paragraph paragraph27 = new Paragraph() { RsidParagraphAddition = "0077085F", RsidParagraphProperties = "0077085F", RsidRunAdditionDefault = "0077085F" };

            ParagraphProperties paragraphProperties27 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties27 = new ParagraphMarkRunProperties();
            RunFonts runFonts73 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize73 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript73 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties27.Append(runFonts73);
            paragraphMarkRunProperties27.Append(fontSize73);
            paragraphMarkRunProperties27.Append(fontSizeComplexScript73);

            paragraphProperties27.Append(paragraphMarkRunProperties27);

            Run run47 = new Run();

            RunProperties runProperties47 = new RunProperties();
            RunFonts runFonts74 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize74 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript74 = new FontSizeComplexScript() { Val = "24" };

            runProperties47.Append(runFonts74);
            runProperties47.Append(fontSize74);
            runProperties47.Append(fontSizeComplexScript74);
            Text text47 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            OptimalContactCount = 0;
            foreach (int i in person.lbOptimalContactAspects)
            {
                if ((Person.getAspect(i) > 8) && (Person.getAspect(i) < 18))
                {
                    text47.Text = text47.Text + (OptimalContactCount == 0 ? "" : ", ") + Person.getAspectName(i);
                    OptimalContactCount++;
                }
            }
            
            run47.Append(runProperties47);
            run47.Append(text47);
            ProofError proofError15 = new ProofError() { Type = ProofingErrorValues.GrammarStart };

            Run run48 = new Run();

            RunProperties runProperties48 = new RunProperties();
            RunFonts runFonts75 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize75 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript75 = new FontSizeComplexScript() { Val = "24" };

            runProperties48.Append(runFonts75);
            runProperties48.Append(fontSize75);
            runProperties48.Append(fontSizeComplexScript75);
            Text text48 = new Text();
            text48.Text = "";

            run48.Append(runProperties48);
            run48.Append(text48);
            ProofError proofError16 = new ProofError() { Type = ProofingErrorValues.GrammarEnd };

            Run run49 = new Run();

            RunProperties runProperties49 = new RunProperties();
            RunFonts runFonts76 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize76 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript76 = new FontSizeComplexScript() { Val = "24" };

            runProperties49.Append(runFonts76);
            runProperties49.Append(fontSize76);
            runProperties49.Append(fontSizeComplexScript76);
            Text text49 = new Text();
            text49.Text = "";

            run49.Append(runProperties49);
            run49.Append(text49);

            paragraph27.Append(paragraphProperties27);
            paragraph27.Append(run47);
            paragraph27.Append(proofError15);
            paragraph27.Append(run48);
            paragraph27.Append(proofError16);
            paragraph27.Append(run49);

            Paragraph paragraph28 = new Paragraph() { RsidParagraphAddition = "0077085F", RsidParagraphProperties = "0077085F", RsidRunAdditionDefault = "0077085F" };

            ParagraphProperties paragraphProperties28 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties28 = new ParagraphMarkRunProperties();
            RunFonts runFonts77 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize77 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript77 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties28.Append(runFonts77);
            paragraphMarkRunProperties28.Append(fontSize77);
            paragraphMarkRunProperties28.Append(fontSizeComplexScript77);

            paragraphProperties28.Append(paragraphMarkRunProperties28);

            paragraph28.Append(paragraphProperties28);

            Paragraph paragraph29 = new Paragraph() { RsidParagraphAddition = "007A34DB", RsidParagraphProperties = "005C2EF3", RsidRunAdditionDefault = "007A34DB" };

            ParagraphProperties paragraphProperties29 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties29 = new ParagraphMarkRunProperties();
            RunFonts runFonts78 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize78 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript78 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties29.Append(runFonts78);
            paragraphMarkRunProperties29.Append(fontSize78);
            paragraphMarkRunProperties29.Append(fontSizeComplexScript78);

            paragraphProperties29.Append(paragraphMarkRunProperties29);

            Run run50 = new Run();

            RunProperties runProperties50 = new RunProperties();
            RunFonts runFonts79 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize79 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript79 = new FontSizeComplexScript() { Val = "24" };

            runProperties50.Append(runFonts79);
            runProperties50.Append(fontSize79);
            runProperties50.Append(fontSizeComplexScript79);
            LastRenderedPageBreak lastRenderedPageBreak1 = new LastRenderedPageBreak();
            Text text50 = new Text();
            text50.Text = "Излишняя эмоциональная дистанция:";

            run50.Append(runProperties50);
            run50.Append(lastRenderedPageBreak1);
            run50.Append(text50);

            paragraph29.Append(paragraphProperties29);
            paragraph29.Append(run50);

            Paragraph paragraph30 = new Paragraph() { RsidParagraphMarkRevision = "0077085F", RsidParagraphAddition = "0077085F", RsidParagraphProperties = "0077085F", RsidRunAdditionDefault = "0077085F" };

            ParagraphProperties paragraphProperties30 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties30 = new ParagraphMarkRunProperties();
            RunFonts runFonts80 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold21 = new Bold();
            Italic italic13 = new Italic();
            FontSize fontSize80 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript80 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties30.Append(runFonts80);
            paragraphMarkRunProperties30.Append(bold21);
            paragraphMarkRunProperties30.Append(italic13);
            paragraphMarkRunProperties30.Append(fontSize80);
            paragraphMarkRunProperties30.Append(fontSizeComplexScript80);

            paragraphProperties30.Append(paragraphMarkRunProperties30);

            Run run51 = new Run() { RsidRunProperties = "0077085F" };

            RunProperties runProperties51 = new RunProperties();
            RunFonts runFonts81 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold22 = new Bold();
            Italic italic14 = new Italic();
            FontSize fontSize81 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript81 = new FontSizeComplexScript() { Val = "24" };

            runProperties51.Append(runFonts81);
            runProperties51.Append(bold22);
            runProperties51.Append(italic14);
            runProperties51.Append(fontSize81);
            runProperties51.Append(fontSizeComplexScript81);
            Text text51 = new Text();
            text51.Text = "Выше нормы:";

            run51.Append(runProperties51);
            run51.Append(text51);

            paragraph30.Append(paragraphProperties30);
            paragraph30.Append(run51);

            Paragraph paragraph31 = new Paragraph() { RsidParagraphAddition = "0077085F", RsidParagraphProperties = "0077085F", RsidRunAdditionDefault = "0077085F" };

            ParagraphProperties paragraphProperties31 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties31 = new ParagraphMarkRunProperties();
            RunFonts runFonts82 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize82 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript82 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties31.Append(runFonts82);
            paragraphMarkRunProperties31.Append(fontSize82);
            paragraphMarkRunProperties31.Append(fontSizeComplexScript82);

            paragraphProperties31.Append(paragraphMarkRunProperties31);
            ProofError proofError17 = new ProofError() { Type = ProofingErrorValues.SpellStart };

            Run run52 = new Run();

            RunProperties runProperties52 = new RunProperties();
            RunFonts runFonts83 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize83 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript83 = new FontSizeComplexScript() { Val = "24" };

            runProperties52.Append(runFonts83);
            runProperties52.Append(fontSize83);
            runProperties52.Append(fontSizeComplexScript83);
            Text text52 = new Text();
            int OverDistanceCount = 0;
            foreach (int i in person.lbOverDistanceAspects)
            {
                if (Person.getAspect(i) >= 18)
                {
                    text52.Text = text52.Text + (OverDistanceCount == 0 ? "" : ", ") + Person.getAspectName(i);
                    OverDistanceCount++;
                }
            }
            
            run52.Append(runProperties52);
            run52.Append(text52);
            ProofError proofError18 = new ProofError() { Type = ProofingErrorValues.SpellEnd };

            Run run53 = new Run();

            RunProperties runProperties53 = new RunProperties();
            RunFonts runFonts84 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize84 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript84 = new FontSizeComplexScript() { Val = "24" };

            runProperties53.Append(runFonts84);
            runProperties53.Append(fontSize84);
            runProperties53.Append(fontSizeComplexScript84);
            Text text53 = new Text();
            text53.Text = "";

            run53.Append(runProperties53);
            run53.Append(text53);

            paragraph31.Append(paragraphProperties31);
            paragraph31.Append(proofError17);
            paragraph31.Append(run52);
            paragraph31.Append(proofError18);
            paragraph31.Append(run53);

            Paragraph paragraph32 = new Paragraph() { RsidParagraphMarkRevision = "0077085F", RsidParagraphAddition = "0077085F", RsidParagraphProperties = "0077085F", RsidRunAdditionDefault = "0077085F" };

            ParagraphProperties paragraphProperties32 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties32 = new ParagraphMarkRunProperties();
            RunFonts runFonts85 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold23 = new Bold();
            Italic italic15 = new Italic();
            FontSize fontSize85 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript85 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties32.Append(runFonts85);
            paragraphMarkRunProperties32.Append(bold23);
            paragraphMarkRunProperties32.Append(italic15);
            paragraphMarkRunProperties32.Append(fontSize85);
            paragraphMarkRunProperties32.Append(fontSizeComplexScript85);

            paragraphProperties32.Append(paragraphMarkRunProperties32);

            Run run54 = new Run() { RsidRunProperties = "0077085F" };

            RunProperties runProperties54 = new RunProperties();
            RunFonts runFonts86 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold24 = new Bold();
            Italic italic16 = new Italic();
            FontSize fontSize86 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript86 = new FontSizeComplexScript() { Val = "24" };

            runProperties54.Append(runFonts86);
            runProperties54.Append(bold24);
            runProperties54.Append(italic16);
            runProperties54.Append(fontSize86);
            runProperties54.Append(fontSizeComplexScript86);
            Text text54 = new Text();
            text54.Text = "Ниже нормы:";

            run54.Append(runProperties54);
            run54.Append(text54);

            paragraph32.Append(paragraphProperties32);
            paragraph32.Append(run54);

            Paragraph paragraph33 = new Paragraph() { RsidParagraphAddition = "0077085F", RsidParagraphProperties = "0077085F", RsidRunAdditionDefault = "0077085F" };

            ParagraphProperties paragraphProperties33 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties33 = new ParagraphMarkRunProperties();
            RunFonts runFonts87 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize87 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript87 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties33.Append(runFonts87);
            paragraphMarkRunProperties33.Append(fontSize87);
            paragraphMarkRunProperties33.Append(fontSizeComplexScript87);

            paragraphProperties33.Append(paragraphMarkRunProperties33);

            Run run55 = new Run();

            RunProperties runProperties55 = new RunProperties();
            RunFonts runFonts88 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize88 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript88 = new FontSizeComplexScript() { Val = "24" };

            runProperties55.Append(runFonts88);
            runProperties55.Append(fontSize88);
            runProperties55.Append(fontSizeComplexScript88);
            Text text55 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            OverDistanceCount = 0;
            foreach (int i in person.lbOverDistanceAspects)
            {
                if (Person.getAspect(i) <= 8)
                {
                    text55.Text = text55.Text + (OverDistanceCount == 0 ? "" : ", ") + Person.getAspectName(i);
                    OverDistanceCount++;
                }
            }
            
            run55.Append(runProperties55);
            run55.Append(text55);
            ProofError proofError19 = new ProofError() { Type = ProofingErrorValues.GrammarStart };

            Run run56 = new Run();

            RunProperties runProperties56 = new RunProperties();
            RunFonts runFonts89 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize89 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript89 = new FontSizeComplexScript() { Val = "24" };

            runProperties56.Append(runFonts89);
            runProperties56.Append(fontSize89);
            runProperties56.Append(fontSizeComplexScript89);
            Text text56 = new Text();
            text56.Text = "";

            run56.Append(runProperties56);
            run56.Append(text56);
            ProofError proofError20 = new ProofError() { Type = ProofingErrorValues.GrammarEnd };

            Run run57 = new Run();

            RunProperties runProperties57 = new RunProperties();
            RunFonts runFonts90 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize90 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript90 = new FontSizeComplexScript() { Val = "24" };

            runProperties57.Append(runFonts90);
            runProperties57.Append(fontSize90);
            runProperties57.Append(fontSizeComplexScript90);
            Text text57 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text57.Text = "";

            run57.Append(runProperties57);
            run57.Append(text57);
            ProofError proofError21 = new ProofError() { Type = ProofingErrorValues.SpellStart };

            Run run58 = new Run();

            RunProperties runProperties58 = new RunProperties();
            RunFonts runFonts91 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize91 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript91 = new FontSizeComplexScript() { Val = "24" };

            runProperties58.Append(runFonts91);
            runProperties58.Append(fontSize91);
            runProperties58.Append(fontSizeComplexScript91);
            Text text58 = new Text();
            text58.Text = "";

            run58.Append(runProperties58);
            run58.Append(text58);
            ProofError proofError22 = new ProofError() { Type = ProofingErrorValues.SpellEnd };

            Run run59 = new Run();

            RunProperties runProperties59 = new RunProperties();
            RunFonts runFonts92 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize92 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript92 = new FontSizeComplexScript() { Val = "24" };

            runProperties59.Append(runFonts92);
            runProperties59.Append(fontSize92);
            runProperties59.Append(fontSizeComplexScript92);
            Text text59 = new Text();
            text59.Text = "";

            run59.Append(runProperties59);
            run59.Append(text59);

            paragraph33.Append(paragraphProperties33);
            paragraph33.Append(run55);
            paragraph33.Append(proofError19);
            paragraph33.Append(run56);
            paragraph33.Append(proofError20);
            paragraph33.Append(run57);
            paragraph33.Append(proofError21);
            paragraph33.Append(run58);
            paragraph33.Append(proofError22);
            paragraph33.Append(run59);

            Paragraph paragraph34 = new Paragraph() { RsidParagraphMarkRevision = "0077085F", RsidParagraphAddition = "0077085F", RsidParagraphProperties = "0077085F", RsidRunAdditionDefault = "0077085F" };

            ParagraphProperties paragraphProperties34 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties34 = new ParagraphMarkRunProperties();
            RunFonts runFonts93 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold25 = new Bold();
            Italic italic17 = new Italic();
            FontSize fontSize93 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript93 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties34.Append(runFonts93);
            paragraphMarkRunProperties34.Append(bold25);
            paragraphMarkRunProperties34.Append(italic17);
            paragraphMarkRunProperties34.Append(fontSize93);
            paragraphMarkRunProperties34.Append(fontSizeComplexScript93);

            paragraphProperties34.Append(paragraphMarkRunProperties34);

            Run run60 = new Run() { RsidRunProperties = "0077085F" };

            RunProperties runProperties60 = new RunProperties();
            RunFonts runFonts94 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold26 = new Bold();
            Italic italic18 = new Italic();
            FontSize fontSize94 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript94 = new FontSizeComplexScript() { Val = "24" };

            runProperties60.Append(runFonts94);
            runProperties60.Append(bold26);
            runProperties60.Append(italic18);
            runProperties60.Append(fontSize94);
            runProperties60.Append(fontSizeComplexScript94);
            Text text60 = new Text();
            text60.Text = "В норме";

            run60.Append(runProperties60);
            run60.Append(text60);

            paragraph34.Append(paragraphProperties34);
            paragraph34.Append(run60);

            Paragraph paragraph35 = new Paragraph() { RsidParagraphAddition = "0077085F", RsidParagraphProperties = "0077085F", RsidRunAdditionDefault = "0077085F" };

            ParagraphProperties paragraphProperties35 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties35 = new ParagraphMarkRunProperties();
            RunFonts runFonts95 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize95 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript95 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties35.Append(runFonts95);
            paragraphMarkRunProperties35.Append(fontSize95);
            paragraphMarkRunProperties35.Append(fontSizeComplexScript95);

            paragraphProperties35.Append(paragraphMarkRunProperties35);

            Run run61 = new Run();

            RunProperties runProperties61 = new RunProperties();
            RunFonts runFonts96 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize96 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript96 = new FontSizeComplexScript() { Val = "24" };

            runProperties61.Append(runFonts96);
            runProperties61.Append(fontSize96);
            runProperties61.Append(fontSizeComplexScript96);
            Text text61 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            OverDistanceCount = 0;
            foreach (int i in person.lbOverDistanceAspects)
            {
                if ((Person.getAspect(i) > 8) && (Person.getAspect(i) < 18))
                {
                    text61.Text = text61.Text + (OverDistanceCount == 0 ? "" : ", ") + Person.getAspectName(i);
                    OverDistanceCount++;
                }
            }
            
            run61.Append(runProperties61);
            run61.Append(text61);
            ProofError proofError23 = new ProofError() { Type = ProofingErrorValues.GrammarStart };

            Run run62 = new Run();

            RunProperties runProperties62 = new RunProperties();
            RunFonts runFonts97 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize97 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript97 = new FontSizeComplexScript() { Val = "24" };

            runProperties62.Append(runFonts97);
            runProperties62.Append(fontSize97);
            runProperties62.Append(fontSizeComplexScript97);
            Text text62 = new Text();
            text62.Text = "";

            run62.Append(runProperties62);
            run62.Append(text62);
            ProofError proofError24 = new ProofError() { Type = ProofingErrorValues.GrammarEnd };

            Run run63 = new Run();

            RunProperties runProperties63 = new RunProperties();
            RunFonts runFonts98 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize98 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript98 = new FontSizeComplexScript() { Val = "24" };

            runProperties63.Append(runFonts98);
            runProperties63.Append(fontSize98);
            runProperties63.Append(fontSizeComplexScript98);
            Text text63 = new Text();
            text63.Text = "";

            run63.Append(runProperties63);
            run63.Append(text63);

            paragraph35.Append(paragraphProperties35);
            paragraph35.Append(run61);
            paragraph35.Append(proofError23);
            paragraph35.Append(run62);
            paragraph35.Append(proofError24);
            paragraph35.Append(run63);

            Paragraph paragraph36 = new Paragraph() { RsidParagraphAddition = "0077085F", RsidParagraphProperties = "005C2EF3", RsidRunAdditionDefault = "0077085F" };

            ParagraphProperties paragraphProperties36 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties36 = new ParagraphMarkRunProperties();
            RunFonts runFonts99 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize99 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript99 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties36.Append(runFonts99);
            paragraphMarkRunProperties36.Append(fontSize99);
            paragraphMarkRunProperties36.Append(fontSizeComplexScript99);

            paragraphProperties36.Append(paragraphMarkRunProperties36);

            paragraph36.Append(paragraphProperties36);

            Paragraph paragraph37 = new Paragraph() { RsidParagraphAddition = "007A34DB", RsidParagraphProperties = "005C2EF3", RsidRunAdditionDefault = "007A34DB" };

            ParagraphProperties paragraphProperties37 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties37 = new ParagraphMarkRunProperties();
            RunFonts runFonts100 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize100 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript100 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties37.Append(runFonts100);
            paragraphMarkRunProperties37.Append(fontSize100);
            paragraphMarkRunProperties37.Append(fontSizeComplexScript100);

            paragraphProperties37.Append(paragraphMarkRunProperties37);

            Run run64 = new Run();

            RunProperties runProperties64 = new RunProperties();
            RunFonts runFonts101 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize101 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript101 = new FontSizeComplexScript() { Val = "24" };

            runProperties64.Append(runFonts101);
            runProperties64.Append(fontSize101);
            runProperties64.Append(fontSizeComplexScript101);
            Text text64 = new Text();
            text64.Text = "Излишняя концентрация на ребенке";

            run64.Append(runProperties64);
            run64.Append(text64);

            paragraph37.Append(paragraphProperties37);
            paragraph37.Append(run64);

            Paragraph paragraph38 = new Paragraph() { RsidParagraphMarkRevision = "0077085F", RsidParagraphAddition = "0077085F", RsidParagraphProperties = "0077085F", RsidRunAdditionDefault = "0077085F" };

            ParagraphProperties paragraphProperties38 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties38 = new ParagraphMarkRunProperties();
            RunFonts runFonts102 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold27 = new Bold();
            Italic italic19 = new Italic();
            FontSize fontSize102 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript102 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties38.Append(runFonts102);
            paragraphMarkRunProperties38.Append(bold27);
            paragraphMarkRunProperties38.Append(italic19);
            paragraphMarkRunProperties38.Append(fontSize102);
            paragraphMarkRunProperties38.Append(fontSizeComplexScript102);

            paragraphProperties38.Append(paragraphMarkRunProperties38);

            Run run65 = new Run() { RsidRunProperties = "0077085F" };

            RunProperties runProperties65 = new RunProperties();
            RunFonts runFonts103 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold28 = new Bold();
            Italic italic20 = new Italic();
            FontSize fontSize103 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript103 = new FontSizeComplexScript() { Val = "24" };

            runProperties65.Append(runFonts103);
            runProperties65.Append(bold28);
            runProperties65.Append(italic20);
            runProperties65.Append(fontSize103);
            runProperties65.Append(fontSizeComplexScript103);
            Text text65 = new Text();
            text65.Text = "Выше нормы:";

            run65.Append(runProperties65);
            run65.Append(text65);

            paragraph38.Append(paragraphProperties38);
            paragraph38.Append(run65);

            Paragraph paragraph39 = new Paragraph() { RsidParagraphAddition = "0077085F", RsidParagraphProperties = "0077085F", RsidRunAdditionDefault = "0077085F" };

            ParagraphProperties paragraphProperties39 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties39 = new ParagraphMarkRunProperties();
            RunFonts runFonts104 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize104 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript104 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties39.Append(runFonts104);
            paragraphMarkRunProperties39.Append(fontSize104);
            paragraphMarkRunProperties39.Append(fontSizeComplexScript104);

            paragraphProperties39.Append(paragraphMarkRunProperties39);
            ProofError proofError25 = new ProofError() { Type = ProofingErrorValues.SpellStart };

            Run run66 = new Run();

            RunProperties runProperties66 = new RunProperties();
            RunFonts runFonts105 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize105 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript105 = new FontSizeComplexScript() { Val = "24" };

            runProperties66.Append(runFonts105);
            runProperties66.Append(fontSize105);
            runProperties66.Append(fontSizeComplexScript105);
            Text text66 = new Text();
            int OverConcentrationCount = 0;
            foreach (int i in person.lbOverConcentrationAspects)
            {
                if (Person.getAspect(i) >= 18)
                {
                    text66.Text = text66.Text + (OverConcentrationCount == 0 ? "" : ", ") + Person.getAspectName(i);
                    OverConcentrationCount++;
                }
            }
            
            run66.Append(runProperties66);
            run66.Append(text66);
            ProofError proofError26 = new ProofError() { Type = ProofingErrorValues.SpellEnd };

            Run run67 = new Run();

            RunProperties runProperties67 = new RunProperties();
            RunFonts runFonts106 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize106 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript106 = new FontSizeComplexScript() { Val = "24" };

            runProperties67.Append(runFonts106);
            runProperties67.Append(fontSize106);
            runProperties67.Append(fontSizeComplexScript106);
            Text text67 = new Text();
            text67.Text = "";

            run67.Append(runProperties67);
            run67.Append(text67);

            paragraph39.Append(paragraphProperties39);
            paragraph39.Append(proofError25);
            paragraph39.Append(run66);
            paragraph39.Append(proofError26);
            paragraph39.Append(run67);

            Paragraph paragraph40 = new Paragraph() { RsidParagraphMarkRevision = "0077085F", RsidParagraphAddition = "0077085F", RsidParagraphProperties = "0077085F", RsidRunAdditionDefault = "0077085F" };

            ParagraphProperties paragraphProperties40 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties40 = new ParagraphMarkRunProperties();
            RunFonts runFonts107 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold29 = new Bold();
            Italic italic21 = new Italic();
            FontSize fontSize107 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript107 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties40.Append(runFonts107);
            paragraphMarkRunProperties40.Append(bold29);
            paragraphMarkRunProperties40.Append(italic21);
            paragraphMarkRunProperties40.Append(fontSize107);
            paragraphMarkRunProperties40.Append(fontSizeComplexScript107);

            paragraphProperties40.Append(paragraphMarkRunProperties40);

            Run run68 = new Run() { RsidRunProperties = "0077085F" };

            RunProperties runProperties68 = new RunProperties();
            RunFonts runFonts108 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold30 = new Bold();
            Italic italic22 = new Italic();
            FontSize fontSize108 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript108 = new FontSizeComplexScript() { Val = "24" };

            runProperties68.Append(runFonts108);
            runProperties68.Append(bold30);
            runProperties68.Append(italic22);
            runProperties68.Append(fontSize108);
            runProperties68.Append(fontSizeComplexScript108);
            Text text68 = new Text();
            text68.Text = "Ниже нормы:";

            run68.Append(runProperties68);
            run68.Append(text68);

            paragraph40.Append(paragraphProperties40);
            paragraph40.Append(run68);

            Paragraph paragraph41 = new Paragraph() { RsidParagraphAddition = "0077085F", RsidParagraphProperties = "0077085F", RsidRunAdditionDefault = "0077085F" };

            ParagraphProperties paragraphProperties41 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties41 = new ParagraphMarkRunProperties();
            RunFonts runFonts109 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize109 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript109 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties41.Append(runFonts109);
            paragraphMarkRunProperties41.Append(fontSize109);
            paragraphMarkRunProperties41.Append(fontSizeComplexScript109);

            paragraphProperties41.Append(paragraphMarkRunProperties41);

            Run run69 = new Run();

            RunProperties runProperties69 = new RunProperties();
            RunFonts runFonts110 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize110 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript110 = new FontSizeComplexScript() { Val = "24" };

            runProperties69.Append(runFonts110);
            runProperties69.Append(fontSize110);
            runProperties69.Append(fontSizeComplexScript110);
            Text text69 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            OverConcentrationCount = 0;
            foreach (int i in person.lbOverConcentrationAspects)
            {
                if (Person.getAspect(i) <= 8)
                {
                    text69.Text = text69.Text + (OverConcentrationCount == 0 ? "" : ", ") + Person.getAspectName(i);
                    OverConcentrationCount++;
                }
            }

            run69.Append(runProperties69);
            run69.Append(text69);
            ProofError proofError27 = new ProofError() { Type = ProofingErrorValues.GrammarStart };

            Run run70 = new Run();

            RunProperties runProperties70 = new RunProperties();
            RunFonts runFonts111 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize111 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript111 = new FontSizeComplexScript() { Val = "24" };

            runProperties70.Append(runFonts111);
            runProperties70.Append(fontSize111);
            runProperties70.Append(fontSizeComplexScript111);
            Text text70 = new Text();
            text70.Text = "";

            run70.Append(runProperties70);
            run70.Append(text70);
            ProofError proofError28 = new ProofError() { Type = ProofingErrorValues.GrammarEnd };

            Run run71 = new Run();

            RunProperties runProperties71 = new RunProperties();
            RunFonts runFonts112 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize112 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript112 = new FontSizeComplexScript() { Val = "24" };

            runProperties71.Append(runFonts112);
            runProperties71.Append(fontSize112);
            runProperties71.Append(fontSizeComplexScript112);
            Text text71 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            text71.Text = "";

            run71.Append(runProperties71);
            run71.Append(text71);
            ProofError proofError29 = new ProofError() { Type = ProofingErrorValues.SpellStart };

            Run run72 = new Run();

            RunProperties runProperties72 = new RunProperties();
            RunFonts runFonts113 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize113 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript113 = new FontSizeComplexScript() { Val = "24" };

            runProperties72.Append(runFonts113);
            runProperties72.Append(fontSize113);
            runProperties72.Append(fontSizeComplexScript113);
            Text text72 = new Text();
            text72.Text = "";

            run72.Append(runProperties72);
            run72.Append(text72);
            ProofError proofError30 = new ProofError() { Type = ProofingErrorValues.SpellEnd };

            Run run73 = new Run();

            RunProperties runProperties73 = new RunProperties();
            RunFonts runFonts114 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize114 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript114 = new FontSizeComplexScript() { Val = "24" };

            runProperties73.Append(runFonts114);
            runProperties73.Append(fontSize114);
            runProperties73.Append(fontSizeComplexScript114);
            Text text73 = new Text();
            text73.Text = "";

            run73.Append(runProperties73);
            run73.Append(text73);

            paragraph41.Append(paragraphProperties41);
            paragraph41.Append(run69);
            paragraph41.Append(proofError27);
            paragraph41.Append(run70);
            paragraph41.Append(proofError28);
            paragraph41.Append(run71);
            paragraph41.Append(proofError29);
            paragraph41.Append(run72);
            paragraph41.Append(proofError30);
            paragraph41.Append(run73);

            Paragraph paragraph42 = new Paragraph() { RsidParagraphMarkRevision = "0077085F", RsidParagraphAddition = "0077085F", RsidParagraphProperties = "0077085F", RsidRunAdditionDefault = "0077085F" };

            ParagraphProperties paragraphProperties42 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties42 = new ParagraphMarkRunProperties();
            RunFonts runFonts115 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold31 = new Bold();
            Italic italic23 = new Italic();
            FontSize fontSize115 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript115 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties42.Append(runFonts115);
            paragraphMarkRunProperties42.Append(bold31);
            paragraphMarkRunProperties42.Append(italic23);
            paragraphMarkRunProperties42.Append(fontSize115);
            paragraphMarkRunProperties42.Append(fontSizeComplexScript115);

            paragraphProperties42.Append(paragraphMarkRunProperties42);

            Run run74 = new Run() { RsidRunProperties = "0077085F" };

            RunProperties runProperties74 = new RunProperties();
            RunFonts runFonts116 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            Bold bold32 = new Bold();
            Italic italic24 = new Italic();
            FontSize fontSize116 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript116 = new FontSizeComplexScript() { Val = "24" };

            runProperties74.Append(runFonts116);
            runProperties74.Append(bold32);
            runProperties74.Append(italic24);
            runProperties74.Append(fontSize116);
            runProperties74.Append(fontSizeComplexScript116);
            Text text74 = new Text();
            text74.Text = "В норме";

            run74.Append(runProperties74);
            run74.Append(text74);

            paragraph42.Append(paragraphProperties42);
            paragraph42.Append(run74);

            Paragraph paragraph43 = new Paragraph() { RsidParagraphAddition = "0077085F", RsidParagraphProperties = "0077085F", RsidRunAdditionDefault = "0077085F" };

            ParagraphProperties paragraphProperties43 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties43 = new ParagraphMarkRunProperties();
            RunFonts runFonts117 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize117 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript117 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties43.Append(runFonts117);
            paragraphMarkRunProperties43.Append(fontSize117);
            paragraphMarkRunProperties43.Append(fontSizeComplexScript117);

            paragraphProperties43.Append(paragraphMarkRunProperties43);

            Run run75 = new Run();

            RunProperties runProperties75 = new RunProperties();
            RunFonts runFonts118 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize118 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript118 = new FontSizeComplexScript() { Val = "24" };

            runProperties75.Append(runFonts118);
            runProperties75.Append(fontSize118);
            runProperties75.Append(fontSizeComplexScript118);
            Text text75 = new Text() { Space = SpaceProcessingModeValues.Preserve };
            OverConcentrationCount = 0;
            foreach (int i in person.lbOverConcentrationAspects)
            {
                if ((Person.getAspect(i) > 8) && (Person.getAspect(i) < 18))
                {
                    text75.Text = text75.Text + (OverConcentrationCount == 0 ? "" : ", ") + Person.getAspectName(i);
                    OverConcentrationCount++;
                }
            }

            run75.Append(runProperties75);
            run75.Append(text75);
            ProofError proofError31 = new ProofError() { Type = ProofingErrorValues.GrammarStart };

            Run run76 = new Run();

            RunProperties runProperties76 = new RunProperties();
            RunFonts runFonts119 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize119 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript119 = new FontSizeComplexScript() { Val = "24" };

            runProperties76.Append(runFonts119);
            runProperties76.Append(fontSize119);
            runProperties76.Append(fontSizeComplexScript119);
            Text text76 = new Text();
            text76.Text = "";

            run76.Append(runProperties76);
            run76.Append(text76);
            ProofError proofError32 = new ProofError() { Type = ProofingErrorValues.GrammarEnd };

            Run run77 = new Run();

            RunProperties runProperties77 = new RunProperties();
            RunFonts runFonts120 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize120 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript120 = new FontSizeComplexScript() { Val = "24" };

            runProperties77.Append(runFonts120);
            runProperties77.Append(fontSize120);
            runProperties77.Append(fontSizeComplexScript120);
            Text text77 = new Text();
            text77.Text = "";

            run77.Append(runProperties77);
            run77.Append(text77);

            paragraph43.Append(paragraphProperties43);
            paragraph43.Append(run75);
            paragraph43.Append(proofError31);
            paragraph43.Append(run76);
            paragraph43.Append(proofError32);
            paragraph43.Append(run77);

            Paragraph paragraph44 = new Paragraph() { RsidParagraphMarkRevision = "005C2EF3", RsidParagraphAddition = "007A34DB", RsidParagraphProperties = "0077085F", RsidRunAdditionDefault = "007A34DB" };

            ParagraphProperties paragraphProperties44 = new ParagraphProperties();

            ParagraphMarkRunProperties paragraphMarkRunProperties44 = new ParagraphMarkRunProperties();
            RunFonts runFonts121 = new RunFonts() { Ascii = "Times New Roman", HighAnsi = "Times New Roman", ComplexScript = "Times New Roman" };
            FontSize fontSize121 = new FontSize() { Val = "24" };
            FontSizeComplexScript fontSizeComplexScript121 = new FontSizeComplexScript() { Val = "24" };

            paragraphMarkRunProperties44.Append(runFonts121);
            paragraphMarkRunProperties44.Append(fontSize121);
            paragraphMarkRunProperties44.Append(fontSizeComplexScript121);

            paragraphProperties44.Append(paragraphMarkRunProperties44);

            paragraph44.Append(paragraphProperties44);

            SectionProperties sectionProperties1 = new SectionProperties() { RsidRPr = "005C2EF3", RsidR = "007A34DB", RsidSect = "0044677F" };
            PageSize pageSize1 = new PageSize() { Width = (UInt32Value)11906U, Height = (UInt32Value)16838U };
            PageMargin pageMargin1 = new PageMargin() { Top = 1134, Right = (UInt32Value)850U, Bottom = 1134, Left = (UInt32Value)1701U, Header = (UInt32Value)708U, Footer = (UInt32Value)708U, Gutter = (UInt32Value)0U };
            Columns columns1 = new Columns() { Space = "708" };
            DocGrid docGrid1 = new DocGrid() { LinePitch = 360 };

            sectionProperties1.Append(pageSize1);
            sectionProperties1.Append(pageMargin1);
            sectionProperties1.Append(columns1);
            sectionProperties1.Append(docGrid1);

            body1.Append(paragraph1);
            body1.Append(paragraph2);
            body1.Append(paragraph3);
            body1.Append(paragraph4);
            body1.Append(paragraph5);
            body1.Append(paragraph6);
            body1.Append(paragraph7);
            body1.Append(paragraph8);
            body1.Append(paragraph9);
            body1.Append(paragraph10);
            body1.Append(paragraph11);
            body1.Append(paragraph12);
            body1.Append(paragraph13);
            body1.Append(paragraph14);
            body1.Append(paragraph15);
            body1.Append(paragraph16);
            body1.Append(paragraph17);
            body1.Append(paragraph18);
            body1.Append(paragraph19);
            body1.Append(paragraph20);
            body1.Append(paragraph21);
            body1.Append(paragraph22);
            body1.Append(paragraph23);
            body1.Append(paragraph24);
            body1.Append(paragraph25);
            body1.Append(paragraph26);
            body1.Append(paragraph27);
            body1.Append(paragraph28);
            body1.Append(paragraph29);
            body1.Append(paragraph30);
            body1.Append(paragraph31);
            body1.Append(paragraph32);
            body1.Append(paragraph33);
            body1.Append(paragraph34);
            body1.Append(paragraph35);
            body1.Append(paragraph36);
            body1.Append(paragraph37);
            body1.Append(paragraph38);
            body1.Append(paragraph39);
            body1.Append(paragraph40);
            body1.Append(paragraph41);
            body1.Append(paragraph42);
            body1.Append(paragraph43);
            body1.Append(paragraph44);
            body1.Append(sectionProperties1);

            document1.Append(body1);

            mainDocumentPart1.Document = document1;
        }

        // Generates content of themePart1.
        private void GenerateThemePart1Content(ThemePart themePart1)
        {
            A.Theme theme1 = new A.Theme() { Name = "Тема Office" };
            theme1.AddNamespaceDeclaration("a", "http://schemas.openxmlformats.org/drawingml/2006/main");

            A.ThemeElements themeElements1 = new A.ThemeElements();

            A.ColorScheme colorScheme1 = new A.ColorScheme() { Name = "Стандартная" };

            A.Dark1Color dark1Color1 = new A.Dark1Color();
            A.SystemColor systemColor1 = new A.SystemColor() { Val = A.SystemColorValues.WindowText, LastColor = "000000" };

            dark1Color1.Append(systemColor1);

            A.Light1Color light1Color1 = new A.Light1Color();
            A.SystemColor systemColor2 = new A.SystemColor() { Val = A.SystemColorValues.Window, LastColor = "FFFFFF" };

            light1Color1.Append(systemColor2);

            A.Dark2Color dark2Color1 = new A.Dark2Color();
            A.RgbColorModelHex rgbColorModelHex1 = new A.RgbColorModelHex() { Val = "1F497D" };

            dark2Color1.Append(rgbColorModelHex1);

            A.Light2Color light2Color1 = new A.Light2Color();
            A.RgbColorModelHex rgbColorModelHex2 = new A.RgbColorModelHex() { Val = "EEECE1" };

            light2Color1.Append(rgbColorModelHex2);

            A.Accent1Color accent1Color1 = new A.Accent1Color();
            A.RgbColorModelHex rgbColorModelHex3 = new A.RgbColorModelHex() { Val = "4F81BD" };

            accent1Color1.Append(rgbColorModelHex3);

            A.Accent2Color accent2Color1 = new A.Accent2Color();
            A.RgbColorModelHex rgbColorModelHex4 = new A.RgbColorModelHex() { Val = "C0504D" };

            accent2Color1.Append(rgbColorModelHex4);

            A.Accent3Color accent3Color1 = new A.Accent3Color();
            A.RgbColorModelHex rgbColorModelHex5 = new A.RgbColorModelHex() { Val = "9BBB59" };

            accent3Color1.Append(rgbColorModelHex5);

            A.Accent4Color accent4Color1 = new A.Accent4Color();
            A.RgbColorModelHex rgbColorModelHex6 = new A.RgbColorModelHex() { Val = "8064A2" };

            accent4Color1.Append(rgbColorModelHex6);

            A.Accent5Color accent5Color1 = new A.Accent5Color();
            A.RgbColorModelHex rgbColorModelHex7 = new A.RgbColorModelHex() { Val = "4BACC6" };

            accent5Color1.Append(rgbColorModelHex7);

            A.Accent6Color accent6Color1 = new A.Accent6Color();
            A.RgbColorModelHex rgbColorModelHex8 = new A.RgbColorModelHex() { Val = "F79646" };

            accent6Color1.Append(rgbColorModelHex8);

            A.Hyperlink hyperlink1 = new A.Hyperlink();
            A.RgbColorModelHex rgbColorModelHex9 = new A.RgbColorModelHex() { Val = "0000FF" };

            hyperlink1.Append(rgbColorModelHex9);

            A.FollowedHyperlinkColor followedHyperlinkColor1 = new A.FollowedHyperlinkColor();
            A.RgbColorModelHex rgbColorModelHex10 = new A.RgbColorModelHex() { Val = "800080" };

            followedHyperlinkColor1.Append(rgbColorModelHex10);

            colorScheme1.Append(dark1Color1);
            colorScheme1.Append(light1Color1);
            colorScheme1.Append(dark2Color1);
            colorScheme1.Append(light2Color1);
            colorScheme1.Append(accent1Color1);
            colorScheme1.Append(accent2Color1);
            colorScheme1.Append(accent3Color1);
            colorScheme1.Append(accent4Color1);
            colorScheme1.Append(accent5Color1);
            colorScheme1.Append(accent6Color1);
            colorScheme1.Append(hyperlink1);
            colorScheme1.Append(followedHyperlinkColor1);

            A.FontScheme fontScheme1 = new A.FontScheme() { Name = "Стандартная" };

            A.MajorFont majorFont1 = new A.MajorFont();
            A.LatinFont latinFont1 = new A.LatinFont() { Typeface = "Cambria" };
            A.EastAsianFont eastAsianFont1 = new A.EastAsianFont() { Typeface = "" };
            A.ComplexScriptFont complexScriptFont1 = new A.ComplexScriptFont() { Typeface = "" };
            A.SupplementalFont supplementalFont1 = new A.SupplementalFont() { Script = "Jpan", Typeface = "ＭＳ ゴシック" };
            A.SupplementalFont supplementalFont2 = new A.SupplementalFont() { Script = "Hang", Typeface = "맑은 고딕" };
            A.SupplementalFont supplementalFont3 = new A.SupplementalFont() { Script = "Hans", Typeface = "宋体" };
            A.SupplementalFont supplementalFont4 = new A.SupplementalFont() { Script = "Hant", Typeface = "新細明體" };
            A.SupplementalFont supplementalFont5 = new A.SupplementalFont() { Script = "Arab", Typeface = "Times New Roman" };
            A.SupplementalFont supplementalFont6 = new A.SupplementalFont() { Script = "Hebr", Typeface = "Times New Roman" };
            A.SupplementalFont supplementalFont7 = new A.SupplementalFont() { Script = "Thai", Typeface = "Angsana New" };
            A.SupplementalFont supplementalFont8 = new A.SupplementalFont() { Script = "Ethi", Typeface = "Nyala" };
            A.SupplementalFont supplementalFont9 = new A.SupplementalFont() { Script = "Beng", Typeface = "Vrinda" };
            A.SupplementalFont supplementalFont10 = new A.SupplementalFont() { Script = "Gujr", Typeface = "Shruti" };
            A.SupplementalFont supplementalFont11 = new A.SupplementalFont() { Script = "Khmr", Typeface = "MoolBoran" };
            A.SupplementalFont supplementalFont12 = new A.SupplementalFont() { Script = "Knda", Typeface = "Tunga" };
            A.SupplementalFont supplementalFont13 = new A.SupplementalFont() { Script = "Guru", Typeface = "Raavi" };
            A.SupplementalFont supplementalFont14 = new A.SupplementalFont() { Script = "Cans", Typeface = "Euphemia" };
            A.SupplementalFont supplementalFont15 = new A.SupplementalFont() { Script = "Cher", Typeface = "Plantagenet Cherokee" };
            A.SupplementalFont supplementalFont16 = new A.SupplementalFont() { Script = "Yiii", Typeface = "Microsoft Yi Baiti" };
            A.SupplementalFont supplementalFont17 = new A.SupplementalFont() { Script = "Tibt", Typeface = "Microsoft Himalaya" };
            A.SupplementalFont supplementalFont18 = new A.SupplementalFont() { Script = "Thaa", Typeface = "MV Boli" };
            A.SupplementalFont supplementalFont19 = new A.SupplementalFont() { Script = "Deva", Typeface = "Mangal" };
            A.SupplementalFont supplementalFont20 = new A.SupplementalFont() { Script = "Telu", Typeface = "Gautami" };
            A.SupplementalFont supplementalFont21 = new A.SupplementalFont() { Script = "Taml", Typeface = "Latha" };
            A.SupplementalFont supplementalFont22 = new A.SupplementalFont() { Script = "Syrc", Typeface = "Estrangelo Edessa" };
            A.SupplementalFont supplementalFont23 = new A.SupplementalFont() { Script = "Orya", Typeface = "Kalinga" };
            A.SupplementalFont supplementalFont24 = new A.SupplementalFont() { Script = "Mlym", Typeface = "Kartika" };
            A.SupplementalFont supplementalFont25 = new A.SupplementalFont() { Script = "Laoo", Typeface = "DokChampa" };
            A.SupplementalFont supplementalFont26 = new A.SupplementalFont() { Script = "Sinh", Typeface = "Iskoola Pota" };
            A.SupplementalFont supplementalFont27 = new A.SupplementalFont() { Script = "Mong", Typeface = "Mongolian Baiti" };
            A.SupplementalFont supplementalFont28 = new A.SupplementalFont() { Script = "Viet", Typeface = "Times New Roman" };
            A.SupplementalFont supplementalFont29 = new A.SupplementalFont() { Script = "Uigh", Typeface = "Microsoft Uighur" };
            A.SupplementalFont supplementalFont30 = new A.SupplementalFont() { Script = "Geor", Typeface = "Sylfaen" };

            majorFont1.Append(latinFont1);
            majorFont1.Append(eastAsianFont1);
            majorFont1.Append(complexScriptFont1);
            majorFont1.Append(supplementalFont1);
            majorFont1.Append(supplementalFont2);
            majorFont1.Append(supplementalFont3);
            majorFont1.Append(supplementalFont4);
            majorFont1.Append(supplementalFont5);
            majorFont1.Append(supplementalFont6);
            majorFont1.Append(supplementalFont7);
            majorFont1.Append(supplementalFont8);
            majorFont1.Append(supplementalFont9);
            majorFont1.Append(supplementalFont10);
            majorFont1.Append(supplementalFont11);
            majorFont1.Append(supplementalFont12);
            majorFont1.Append(supplementalFont13);
            majorFont1.Append(supplementalFont14);
            majorFont1.Append(supplementalFont15);
            majorFont1.Append(supplementalFont16);
            majorFont1.Append(supplementalFont17);
            majorFont1.Append(supplementalFont18);
            majorFont1.Append(supplementalFont19);
            majorFont1.Append(supplementalFont20);
            majorFont1.Append(supplementalFont21);
            majorFont1.Append(supplementalFont22);
            majorFont1.Append(supplementalFont23);
            majorFont1.Append(supplementalFont24);
            majorFont1.Append(supplementalFont25);
            majorFont1.Append(supplementalFont26);
            majorFont1.Append(supplementalFont27);
            majorFont1.Append(supplementalFont28);
            majorFont1.Append(supplementalFont29);
            majorFont1.Append(supplementalFont30);

            A.MinorFont minorFont1 = new A.MinorFont();
            A.LatinFont latinFont2 = new A.LatinFont() { Typeface = "Calibri" };
            A.EastAsianFont eastAsianFont2 = new A.EastAsianFont() { Typeface = "" };
            A.ComplexScriptFont complexScriptFont2 = new A.ComplexScriptFont() { Typeface = "" };
            A.SupplementalFont supplementalFont31 = new A.SupplementalFont() { Script = "Jpan", Typeface = "ＭＳ 明朝" };
            A.SupplementalFont supplementalFont32 = new A.SupplementalFont() { Script = "Hang", Typeface = "맑은 고딕" };
            A.SupplementalFont supplementalFont33 = new A.SupplementalFont() { Script = "Hans", Typeface = "宋体" };
            A.SupplementalFont supplementalFont34 = new A.SupplementalFont() { Script = "Hant", Typeface = "新細明體" };
            A.SupplementalFont supplementalFont35 = new A.SupplementalFont() { Script = "Arab", Typeface = "Arial" };
            A.SupplementalFont supplementalFont36 = new A.SupplementalFont() { Script = "Hebr", Typeface = "Arial" };
            A.SupplementalFont supplementalFont37 = new A.SupplementalFont() { Script = "Thai", Typeface = "Cordia New" };
            A.SupplementalFont supplementalFont38 = new A.SupplementalFont() { Script = "Ethi", Typeface = "Nyala" };
            A.SupplementalFont supplementalFont39 = new A.SupplementalFont() { Script = "Beng", Typeface = "Vrinda" };
            A.SupplementalFont supplementalFont40 = new A.SupplementalFont() { Script = "Gujr", Typeface = "Shruti" };
            A.SupplementalFont supplementalFont41 = new A.SupplementalFont() { Script = "Khmr", Typeface = "DaunPenh" };
            A.SupplementalFont supplementalFont42 = new A.SupplementalFont() { Script = "Knda", Typeface = "Tunga" };
            A.SupplementalFont supplementalFont43 = new A.SupplementalFont() { Script = "Guru", Typeface = "Raavi" };
            A.SupplementalFont supplementalFont44 = new A.SupplementalFont() { Script = "Cans", Typeface = "Euphemia" };
            A.SupplementalFont supplementalFont45 = new A.SupplementalFont() { Script = "Cher", Typeface = "Plantagenet Cherokee" };
            A.SupplementalFont supplementalFont46 = new A.SupplementalFont() { Script = "Yiii", Typeface = "Microsoft Yi Baiti" };
            A.SupplementalFont supplementalFont47 = new A.SupplementalFont() { Script = "Tibt", Typeface = "Microsoft Himalaya" };
            A.SupplementalFont supplementalFont48 = new A.SupplementalFont() { Script = "Thaa", Typeface = "MV Boli" };
            A.SupplementalFont supplementalFont49 = new A.SupplementalFont() { Script = "Deva", Typeface = "Mangal" };
            A.SupplementalFont supplementalFont50 = new A.SupplementalFont() { Script = "Telu", Typeface = "Gautami" };
            A.SupplementalFont supplementalFont51 = new A.SupplementalFont() { Script = "Taml", Typeface = "Latha" };
            A.SupplementalFont supplementalFont52 = new A.SupplementalFont() { Script = "Syrc", Typeface = "Estrangelo Edessa" };
            A.SupplementalFont supplementalFont53 = new A.SupplementalFont() { Script = "Orya", Typeface = "Kalinga" };
            A.SupplementalFont supplementalFont54 = new A.SupplementalFont() { Script = "Mlym", Typeface = "Kartika" };
            A.SupplementalFont supplementalFont55 = new A.SupplementalFont() { Script = "Laoo", Typeface = "DokChampa" };
            A.SupplementalFont supplementalFont56 = new A.SupplementalFont() { Script = "Sinh", Typeface = "Iskoola Pota" };
            A.SupplementalFont supplementalFont57 = new A.SupplementalFont() { Script = "Mong", Typeface = "Mongolian Baiti" };
            A.SupplementalFont supplementalFont58 = new A.SupplementalFont() { Script = "Viet", Typeface = "Arial" };
            A.SupplementalFont supplementalFont59 = new A.SupplementalFont() { Script = "Uigh", Typeface = "Microsoft Uighur" };
            A.SupplementalFont supplementalFont60 = new A.SupplementalFont() { Script = "Geor", Typeface = "Sylfaen" };

            minorFont1.Append(latinFont2);
            minorFont1.Append(eastAsianFont2);
            minorFont1.Append(complexScriptFont2);
            minorFont1.Append(supplementalFont31);
            minorFont1.Append(supplementalFont32);
            minorFont1.Append(supplementalFont33);
            minorFont1.Append(supplementalFont34);
            minorFont1.Append(supplementalFont35);
            minorFont1.Append(supplementalFont36);
            minorFont1.Append(supplementalFont37);
            minorFont1.Append(supplementalFont38);
            minorFont1.Append(supplementalFont39);
            minorFont1.Append(supplementalFont40);
            minorFont1.Append(supplementalFont41);
            minorFont1.Append(supplementalFont42);
            minorFont1.Append(supplementalFont43);
            minorFont1.Append(supplementalFont44);
            minorFont1.Append(supplementalFont45);
            minorFont1.Append(supplementalFont46);
            minorFont1.Append(supplementalFont47);
            minorFont1.Append(supplementalFont48);
            minorFont1.Append(supplementalFont49);
            minorFont1.Append(supplementalFont50);
            minorFont1.Append(supplementalFont51);
            minorFont1.Append(supplementalFont52);
            minorFont1.Append(supplementalFont53);
            minorFont1.Append(supplementalFont54);
            minorFont1.Append(supplementalFont55);
            minorFont1.Append(supplementalFont56);
            minorFont1.Append(supplementalFont57);
            minorFont1.Append(supplementalFont58);
            minorFont1.Append(supplementalFont59);
            minorFont1.Append(supplementalFont60);

            fontScheme1.Append(majorFont1);
            fontScheme1.Append(minorFont1);

            A.FormatScheme formatScheme1 = new A.FormatScheme() { Name = "Стандартная" };

            A.FillStyleList fillStyleList1 = new A.FillStyleList();

            A.SolidFill solidFill1 = new A.SolidFill();
            A.SchemeColor schemeColor1 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill1.Append(schemeColor1);

            A.GradientFill gradientFill1 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList1 = new A.GradientStopList();

            A.GradientStop gradientStop1 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor2 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint1 = new A.Tint() { Val = 50000 };
            A.SaturationModulation saturationModulation1 = new A.SaturationModulation() { Val = 300000 };

            schemeColor2.Append(tint1);
            schemeColor2.Append(saturationModulation1);

            gradientStop1.Append(schemeColor2);

            A.GradientStop gradientStop2 = new A.GradientStop() { Position = 35000 };

            A.SchemeColor schemeColor3 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint2 = new A.Tint() { Val = 37000 };
            A.SaturationModulation saturationModulation2 = new A.SaturationModulation() { Val = 300000 };

            schemeColor3.Append(tint2);
            schemeColor3.Append(saturationModulation2);

            gradientStop2.Append(schemeColor3);

            A.GradientStop gradientStop3 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor4 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint3 = new A.Tint() { Val = 15000 };
            A.SaturationModulation saturationModulation3 = new A.SaturationModulation() { Val = 350000 };

            schemeColor4.Append(tint3);
            schemeColor4.Append(saturationModulation3);

            gradientStop3.Append(schemeColor4);

            gradientStopList1.Append(gradientStop1);
            gradientStopList1.Append(gradientStop2);
            gradientStopList1.Append(gradientStop3);
            A.LinearGradientFill linearGradientFill1 = new A.LinearGradientFill() { Angle = 16200000, Scaled = true };

            gradientFill1.Append(gradientStopList1);
            gradientFill1.Append(linearGradientFill1);

            A.GradientFill gradientFill2 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList2 = new A.GradientStopList();

            A.GradientStop gradientStop4 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor5 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade1 = new A.Shade() { Val = 51000 };
            A.SaturationModulation saturationModulation4 = new A.SaturationModulation() { Val = 130000 };

            schemeColor5.Append(shade1);
            schemeColor5.Append(saturationModulation4);

            gradientStop4.Append(schemeColor5);

            A.GradientStop gradientStop5 = new A.GradientStop() { Position = 80000 };

            A.SchemeColor schemeColor6 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade2 = new A.Shade() { Val = 93000 };
            A.SaturationModulation saturationModulation5 = new A.SaturationModulation() { Val = 130000 };

            schemeColor6.Append(shade2);
            schemeColor6.Append(saturationModulation5);

            gradientStop5.Append(schemeColor6);

            A.GradientStop gradientStop6 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor7 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade3 = new A.Shade() { Val = 94000 };
            A.SaturationModulation saturationModulation6 = new A.SaturationModulation() { Val = 135000 };

            schemeColor7.Append(shade3);
            schemeColor7.Append(saturationModulation6);

            gradientStop6.Append(schemeColor7);

            gradientStopList2.Append(gradientStop4);
            gradientStopList2.Append(gradientStop5);
            gradientStopList2.Append(gradientStop6);
            A.LinearGradientFill linearGradientFill2 = new A.LinearGradientFill() { Angle = 16200000, Scaled = false };

            gradientFill2.Append(gradientStopList2);
            gradientFill2.Append(linearGradientFill2);

            fillStyleList1.Append(solidFill1);
            fillStyleList1.Append(gradientFill1);
            fillStyleList1.Append(gradientFill2);

            A.LineStyleList lineStyleList1 = new A.LineStyleList();

            A.Outline outline1 = new A.Outline() { Width = 9525, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

            A.SolidFill solidFill2 = new A.SolidFill();

            A.SchemeColor schemeColor8 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade4 = new A.Shade() { Val = 95000 };
            A.SaturationModulation saturationModulation7 = new A.SaturationModulation() { Val = 105000 };

            schemeColor8.Append(shade4);
            schemeColor8.Append(saturationModulation7);

            solidFill2.Append(schemeColor8);
            A.PresetDash presetDash1 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };

            outline1.Append(solidFill2);
            outline1.Append(presetDash1);

            A.Outline outline2 = new A.Outline() { Width = 25400, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

            A.SolidFill solidFill3 = new A.SolidFill();
            A.SchemeColor schemeColor9 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill3.Append(schemeColor9);
            A.PresetDash presetDash2 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };

            outline2.Append(solidFill3);
            outline2.Append(presetDash2);

            A.Outline outline3 = new A.Outline() { Width = 38100, CapType = A.LineCapValues.Flat, CompoundLineType = A.CompoundLineValues.Single, Alignment = A.PenAlignmentValues.Center };

            A.SolidFill solidFill4 = new A.SolidFill();
            A.SchemeColor schemeColor10 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill4.Append(schemeColor10);
            A.PresetDash presetDash3 = new A.PresetDash() { Val = A.PresetLineDashValues.Solid };

            outline3.Append(solidFill4);
            outline3.Append(presetDash3);

            lineStyleList1.Append(outline1);
            lineStyleList1.Append(outline2);
            lineStyleList1.Append(outline3);

            A.EffectStyleList effectStyleList1 = new A.EffectStyleList();

            A.EffectStyle effectStyle1 = new A.EffectStyle();

            A.EffectList effectList1 = new A.EffectList();

            A.OuterShadow outerShadow1 = new A.OuterShadow() { BlurRadius = 40000L, Distance = 20000L, Direction = 5400000, RotateWithShape = false };

            A.RgbColorModelHex rgbColorModelHex11 = new A.RgbColorModelHex() { Val = "000000" };
            A.Alpha alpha1 = new A.Alpha() { Val = 38000 };

            rgbColorModelHex11.Append(alpha1);

            outerShadow1.Append(rgbColorModelHex11);

            effectList1.Append(outerShadow1);

            effectStyle1.Append(effectList1);

            A.EffectStyle effectStyle2 = new A.EffectStyle();

            A.EffectList effectList2 = new A.EffectList();

            A.OuterShadow outerShadow2 = new A.OuterShadow() { BlurRadius = 40000L, Distance = 23000L, Direction = 5400000, RotateWithShape = false };

            A.RgbColorModelHex rgbColorModelHex12 = new A.RgbColorModelHex() { Val = "000000" };
            A.Alpha alpha2 = new A.Alpha() { Val = 35000 };

            rgbColorModelHex12.Append(alpha2);

            outerShadow2.Append(rgbColorModelHex12);

            effectList2.Append(outerShadow2);

            effectStyle2.Append(effectList2);

            A.EffectStyle effectStyle3 = new A.EffectStyle();

            A.EffectList effectList3 = new A.EffectList();

            A.OuterShadow outerShadow3 = new A.OuterShadow() { BlurRadius = 40000L, Distance = 23000L, Direction = 5400000, RotateWithShape = false };

            A.RgbColorModelHex rgbColorModelHex13 = new A.RgbColorModelHex() { Val = "000000" };
            A.Alpha alpha3 = new A.Alpha() { Val = 35000 };

            rgbColorModelHex13.Append(alpha3);

            outerShadow3.Append(rgbColorModelHex13);

            effectList3.Append(outerShadow3);

            A.Scene3DType scene3DType1 = new A.Scene3DType();

            A.Camera camera1 = new A.Camera() { Preset = A.PresetCameraValues.OrthographicFront };
            A.Rotation rotation1 = new A.Rotation() { Latitude = 0, Longitude = 0, Revolution = 0 };

            camera1.Append(rotation1);

            A.LightRig lightRig1 = new A.LightRig() { Rig = A.LightRigValues.ThreePoints, Direction = A.LightRigDirectionValues.Top };
            A.Rotation rotation2 = new A.Rotation() { Latitude = 0, Longitude = 0, Revolution = 1200000 };

            lightRig1.Append(rotation2);

            scene3DType1.Append(camera1);
            scene3DType1.Append(lightRig1);

            A.Shape3DType shape3DType1 = new A.Shape3DType();
            A.BevelTop bevelTop1 = new A.BevelTop() { Width = 63500L, Height = 25400L };

            shape3DType1.Append(bevelTop1);

            effectStyle3.Append(effectList3);
            effectStyle3.Append(scene3DType1);
            effectStyle3.Append(shape3DType1);

            effectStyleList1.Append(effectStyle1);
            effectStyleList1.Append(effectStyle2);
            effectStyleList1.Append(effectStyle3);

            A.BackgroundFillStyleList backgroundFillStyleList1 = new A.BackgroundFillStyleList();

            A.SolidFill solidFill5 = new A.SolidFill();
            A.SchemeColor schemeColor11 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };

            solidFill5.Append(schemeColor11);

            A.GradientFill gradientFill3 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList3 = new A.GradientStopList();

            A.GradientStop gradientStop7 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor12 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint4 = new A.Tint() { Val = 40000 };
            A.SaturationModulation saturationModulation8 = new A.SaturationModulation() { Val = 350000 };

            schemeColor12.Append(tint4);
            schemeColor12.Append(saturationModulation8);

            gradientStop7.Append(schemeColor12);

            A.GradientStop gradientStop8 = new A.GradientStop() { Position = 40000 };

            A.SchemeColor schemeColor13 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint5 = new A.Tint() { Val = 45000 };
            A.Shade shade5 = new A.Shade() { Val = 99000 };
            A.SaturationModulation saturationModulation9 = new A.SaturationModulation() { Val = 350000 };

            schemeColor13.Append(tint5);
            schemeColor13.Append(shade5);
            schemeColor13.Append(saturationModulation9);

            gradientStop8.Append(schemeColor13);

            A.GradientStop gradientStop9 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor14 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade6 = new A.Shade() { Val = 20000 };
            A.SaturationModulation saturationModulation10 = new A.SaturationModulation() { Val = 255000 };

            schemeColor14.Append(shade6);
            schemeColor14.Append(saturationModulation10);

            gradientStop9.Append(schemeColor14);

            gradientStopList3.Append(gradientStop7);
            gradientStopList3.Append(gradientStop8);
            gradientStopList3.Append(gradientStop9);

            A.PathGradientFill pathGradientFill1 = new A.PathGradientFill() { Path = A.PathShadeValues.Circle };
            A.FillToRectangle fillToRectangle1 = new A.FillToRectangle() { Left = 50000, Top = -80000, Right = 50000, Bottom = 180000 };

            pathGradientFill1.Append(fillToRectangle1);

            gradientFill3.Append(gradientStopList3);
            gradientFill3.Append(pathGradientFill1);

            A.GradientFill gradientFill4 = new A.GradientFill() { RotateWithShape = true };

            A.GradientStopList gradientStopList4 = new A.GradientStopList();

            A.GradientStop gradientStop10 = new A.GradientStop() { Position = 0 };

            A.SchemeColor schemeColor15 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Tint tint6 = new A.Tint() { Val = 80000 };
            A.SaturationModulation saturationModulation11 = new A.SaturationModulation() { Val = 300000 };

            schemeColor15.Append(tint6);
            schemeColor15.Append(saturationModulation11);

            gradientStop10.Append(schemeColor15);

            A.GradientStop gradientStop11 = new A.GradientStop() { Position = 100000 };

            A.SchemeColor schemeColor16 = new A.SchemeColor() { Val = A.SchemeColorValues.PhColor };
            A.Shade shade7 = new A.Shade() { Val = 30000 };
            A.SaturationModulation saturationModulation12 = new A.SaturationModulation() { Val = 200000 };

            schemeColor16.Append(shade7);
            schemeColor16.Append(saturationModulation12);

            gradientStop11.Append(schemeColor16);

            gradientStopList4.Append(gradientStop10);
            gradientStopList4.Append(gradientStop11);

            A.PathGradientFill pathGradientFill2 = new A.PathGradientFill() { Path = A.PathShadeValues.Circle };
            A.FillToRectangle fillToRectangle2 = new A.FillToRectangle() { Left = 50000, Top = 50000, Right = 50000, Bottom = 50000 };

            pathGradientFill2.Append(fillToRectangle2);

            gradientFill4.Append(gradientStopList4);
            gradientFill4.Append(pathGradientFill2);

            backgroundFillStyleList1.Append(solidFill5);
            backgroundFillStyleList1.Append(gradientFill3);
            backgroundFillStyleList1.Append(gradientFill4);

            formatScheme1.Append(fillStyleList1);
            formatScheme1.Append(lineStyleList1);
            formatScheme1.Append(effectStyleList1);
            formatScheme1.Append(backgroundFillStyleList1);

            themeElements1.Append(colorScheme1);
            themeElements1.Append(fontScheme1);
            themeElements1.Append(formatScheme1);
            A.ObjectDefaults objectDefaults1 = new A.ObjectDefaults();
            A.ExtraColorSchemeList extraColorSchemeList1 = new A.ExtraColorSchemeList();

            theme1.Append(themeElements1);
            theme1.Append(objectDefaults1);
            theme1.Append(extraColorSchemeList1);

            themePart1.Theme = theme1;
        }

        // Generates content of documentSettingsPart1.
        private void GenerateDocumentSettingsPart1Content(DocumentSettingsPart documentSettingsPart1)
        {
            Settings settings1 = new Settings() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14" } };
            settings1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            settings1.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
            settings1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            settings1.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
            settings1.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
            settings1.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
            settings1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            settings1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            settings1.AddNamespaceDeclaration("sl", "http://schemas.openxmlformats.org/schemaLibrary/2006/main");
            Zoom zoom1 = new Zoom() { Percent = "100" };
            ProofState proofState1 = new ProofState() { Spelling = ProofingStateValues.Clean, Grammar = ProofingStateValues.Clean };
            DefaultTabStop defaultTabStop1 = new DefaultTabStop() { Val = 708 };
            CharacterSpacingControl characterSpacingControl1 = new CharacterSpacingControl() { Val = CharacterSpacingValues.DoNotCompress };

            FootnoteDocumentWideProperties footnoteDocumentWideProperties1 = new FootnoteDocumentWideProperties();
            FootnoteSpecialReference footnoteSpecialReference1 = new FootnoteSpecialReference() { Id = -1 };
            FootnoteSpecialReference footnoteSpecialReference2 = new FootnoteSpecialReference() { Id = 0 };

            footnoteDocumentWideProperties1.Append(footnoteSpecialReference1);
            footnoteDocumentWideProperties1.Append(footnoteSpecialReference2);

            EndnoteDocumentWideProperties endnoteDocumentWideProperties1 = new EndnoteDocumentWideProperties();
            EndnoteSpecialReference endnoteSpecialReference1 = new EndnoteSpecialReference() { Id = -1 };
            EndnoteSpecialReference endnoteSpecialReference2 = new EndnoteSpecialReference() { Id = 0 };

            endnoteDocumentWideProperties1.Append(endnoteSpecialReference1);
            endnoteDocumentWideProperties1.Append(endnoteSpecialReference2);

            Compatibility compatibility1 = new Compatibility();
            CompatibilitySetting compatibilitySetting1 = new CompatibilitySetting() { Name = CompatSettingNameValues.CompatibilityMode, Uri = "http://schemas.microsoft.com/office/word", Val = "12" };

            compatibility1.Append(compatibilitySetting1);

            Rsids rsids1 = new Rsids();
            RsidRoot rsidRoot1 = new RsidRoot() { Val = "005C2EF3" };
            Rsid rsid1 = new Rsid() { Val = "003410AE" };
            Rsid rsid2 = new Rsid() { Val = "003E3AA4" };
            Rsid rsid3 = new Rsid() { Val = "0044677F" };
            Rsid rsid4 = new Rsid() { Val = "005A60EC" };
            Rsid rsid5 = new Rsid() { Val = "005C2EF3" };
            Rsid rsid6 = new Rsid() { Val = "0077085F" };
            Rsid rsid7 = new Rsid() { Val = "007A34DB" };
            Rsid rsid8 = new Rsid() { Val = "00851418" };
            Rsid rsid9 = new Rsid() { Val = "00867E42" };
            Rsid rsid10 = new Rsid() { Val = "00973DA3" };
            Rsid rsid11 = new Rsid() { Val = "00C55AF9" };
            Rsid rsid12 = new Rsid() { Val = "00CF6174" };
            Rsid rsid13 = new Rsid() { Val = "00DD4AEF" };
            Rsid rsid14 = new Rsid() { Val = "00E618F9" };
            Rsid rsid15 = new Rsid() { Val = "00FA21B7" };
            Rsid rsid16 = new Rsid() { Val = "00FC0C7C" };

            rsids1.Append(rsidRoot1);
            rsids1.Append(rsid1);
            rsids1.Append(rsid2);
            rsids1.Append(rsid3);
            rsids1.Append(rsid4);
            rsids1.Append(rsid5);
            rsids1.Append(rsid6);
            rsids1.Append(rsid7);
            rsids1.Append(rsid8);
            rsids1.Append(rsid9);
            rsids1.Append(rsid10);
            rsids1.Append(rsid11);
            rsids1.Append(rsid12);
            rsids1.Append(rsid13);
            rsids1.Append(rsid14);
            rsids1.Append(rsid15);
            rsids1.Append(rsid16);

            M.MathProperties mathProperties1 = new M.MathProperties();
            M.MathFont mathFont1 = new M.MathFont() { Val = "Cambria Math" };
            M.BreakBinary breakBinary1 = new M.BreakBinary() { Val = M.BreakBinaryOperatorValues.Before };
            M.BreakBinarySubtraction breakBinarySubtraction1 = new M.BreakBinarySubtraction() { Val = M.BreakBinarySubtractionValues.MinusMinus };
            M.SmallFraction smallFraction1 = new M.SmallFraction() { Val = M.BooleanValues.Zero };
            M.DisplayDefaults displayDefaults1 = new M.DisplayDefaults();
            M.LeftMargin leftMargin1 = new M.LeftMargin() { Val = (UInt32Value)0U };
            M.RightMargin rightMargin1 = new M.RightMargin() { Val = (UInt32Value)0U };
            M.DefaultJustification defaultJustification1 = new M.DefaultJustification() { Val = M.JustificationValues.CenterGroup };
            M.WrapIndent wrapIndent1 = new M.WrapIndent() { Val = (UInt32Value)1440U };
            M.IntegralLimitLocation integralLimitLocation1 = new M.IntegralLimitLocation() { Val = M.LimitLocationValues.SubscriptSuperscript };
            M.NaryLimitLocation naryLimitLocation1 = new M.NaryLimitLocation() { Val = M.LimitLocationValues.UnderOver };

            mathProperties1.Append(mathFont1);
            mathProperties1.Append(breakBinary1);
            mathProperties1.Append(breakBinarySubtraction1);
            mathProperties1.Append(smallFraction1);
            mathProperties1.Append(displayDefaults1);
            mathProperties1.Append(leftMargin1);
            mathProperties1.Append(rightMargin1);
            mathProperties1.Append(defaultJustification1);
            mathProperties1.Append(wrapIndent1);
            mathProperties1.Append(integralLimitLocation1);
            mathProperties1.Append(naryLimitLocation1);
            ThemeFontLanguages themeFontLanguages1 = new ThemeFontLanguages() { Val = "ru-RU" };
            ColorSchemeMapping colorSchemeMapping1 = new ColorSchemeMapping() { Background1 = ColorSchemeIndexValues.Light1, Text1 = ColorSchemeIndexValues.Dark1, Background2 = ColorSchemeIndexValues.Light2, Text2 = ColorSchemeIndexValues.Dark2, Accent1 = ColorSchemeIndexValues.Accent1, Accent2 = ColorSchemeIndexValues.Accent2, Accent3 = ColorSchemeIndexValues.Accent3, Accent4 = ColorSchemeIndexValues.Accent4, Accent5 = ColorSchemeIndexValues.Accent5, Accent6 = ColorSchemeIndexValues.Accent6, Hyperlink = ColorSchemeIndexValues.Hyperlink, FollowedHyperlink = ColorSchemeIndexValues.FollowedHyperlink };

            ShapeDefaults shapeDefaults1 = new ShapeDefaults();
            Ovml.ShapeDefaults shapeDefaults2 = new Ovml.ShapeDefaults() { Extension = V.ExtensionHandlingBehaviorValues.Edit, MaxShapeId = 1026 };

            Ovml.ShapeLayout shapeLayout1 = new Ovml.ShapeLayout() { Extension = V.ExtensionHandlingBehaviorValues.Edit };
            Ovml.ShapeIdMap shapeIdMap1 = new Ovml.ShapeIdMap() { Extension = V.ExtensionHandlingBehaviorValues.Edit, Data = "1" };

            shapeLayout1.Append(shapeIdMap1);

            shapeDefaults1.Append(shapeDefaults2);
            shapeDefaults1.Append(shapeLayout1);
            DecimalSymbol decimalSymbol1 = new DecimalSymbol() { Val = "," };
            ListSeparator listSeparator1 = new ListSeparator() { Val = ";" };

            settings1.Append(zoom1);
            settings1.Append(proofState1);
            settings1.Append(defaultTabStop1);
            settings1.Append(characterSpacingControl1);
            settings1.Append(footnoteDocumentWideProperties1);
            settings1.Append(endnoteDocumentWideProperties1);
            settings1.Append(compatibility1);
            settings1.Append(rsids1);
            settings1.Append(mathProperties1);
            settings1.Append(themeFontLanguages1);
            settings1.Append(colorSchemeMapping1);
            settings1.Append(shapeDefaults1);
            settings1.Append(decimalSymbol1);
            settings1.Append(listSeparator1);

            documentSettingsPart1.Settings = settings1;
        }

        // Generates content of fontTablePart1.
        private void GenerateFontTablePart1Content(FontTablePart fontTablePart1)
        {
            Fonts fonts1 = new Fonts() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14" } };
            fonts1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            fonts1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            fonts1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            fonts1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");

            Font font1 = new Font() { Name = "Calibri" };
            Panose1Number panose1Number1 = new Panose1Number() { Val = "020F0502020204030204" };
            FontCharSet fontCharSet1 = new FontCharSet() { Val = "CC" };
            FontFamily fontFamily1 = new FontFamily() { Val = FontFamilyValues.Swiss };
            Pitch pitch1 = new Pitch() { Val = FontPitchValues.Variable };
            FontSignature fontSignature1 = new FontSignature() { UnicodeSignature0 = "E00002FF", UnicodeSignature1 = "4000ACFF", UnicodeSignature2 = "00000001", UnicodeSignature3 = "00000000", CodePageSignature0 = "0000019F", CodePageSignature1 = "00000000" };

            font1.Append(panose1Number1);
            font1.Append(fontCharSet1);
            font1.Append(fontFamily1);
            font1.Append(pitch1);
            font1.Append(fontSignature1);

            Font font2 = new Font() { Name = "Times New Roman" };
            Panose1Number panose1Number2 = new Panose1Number() { Val = "02020603050405020304" };
            FontCharSet fontCharSet2 = new FontCharSet() { Val = "CC" };
            FontFamily fontFamily2 = new FontFamily() { Val = FontFamilyValues.Roman };
            Pitch pitch2 = new Pitch() { Val = FontPitchValues.Variable };
            FontSignature fontSignature2 = new FontSignature() { UnicodeSignature0 = "E0002AFF", UnicodeSignature1 = "C0007841", UnicodeSignature2 = "00000009", UnicodeSignature3 = "00000000", CodePageSignature0 = "000001FF", CodePageSignature1 = "00000000" };

            font2.Append(panose1Number2);
            font2.Append(fontCharSet2);
            font2.Append(fontFamily2);
            font2.Append(pitch2);
            font2.Append(fontSignature2);

            Font font3 = new Font() { Name = "Cambria" };
            Panose1Number panose1Number3 = new Panose1Number() { Val = "02040503050406030204" };
            FontCharSet fontCharSet3 = new FontCharSet() { Val = "CC" };
            FontFamily fontFamily3 = new FontFamily() { Val = FontFamilyValues.Roman };
            Pitch pitch3 = new Pitch() { Val = FontPitchValues.Variable };
            FontSignature fontSignature3 = new FontSignature() { UnicodeSignature0 = "E00002FF", UnicodeSignature1 = "400004FF", UnicodeSignature2 = "00000000", UnicodeSignature3 = "00000000", CodePageSignature0 = "0000019F", CodePageSignature1 = "00000000" };

            font3.Append(panose1Number3);
            font3.Append(fontCharSet3);
            font3.Append(fontFamily3);
            font3.Append(pitch3);
            font3.Append(fontSignature3);

            fonts1.Append(font1);
            fonts1.Append(font2);
            fonts1.Append(font3);

            fontTablePart1.Fonts = fonts1;
        }

        // Generates content of stylesWithEffectsPart1.
        private void GenerateStylesWithEffectsPart1Content(StylesWithEffectsPart stylesWithEffectsPart1)
        {
            Styles styles1 = new Styles() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 wp14" } };
            styles1.AddNamespaceDeclaration("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
            styles1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            styles1.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
            styles1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            styles1.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
            styles1.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
            styles1.AddNamespaceDeclaration("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
            styles1.AddNamespaceDeclaration("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
            styles1.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
            styles1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            styles1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            styles1.AddNamespaceDeclaration("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
            styles1.AddNamespaceDeclaration("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
            styles1.AddNamespaceDeclaration("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
            styles1.AddNamespaceDeclaration("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");

            DocDefaults docDefaults1 = new DocDefaults();

            RunPropertiesDefault runPropertiesDefault1 = new RunPropertiesDefault();

            RunPropertiesBaseStyle runPropertiesBaseStyle1 = new RunPropertiesBaseStyle();
            RunFonts runFonts170 = new RunFonts() { AsciiTheme = ThemeFontValues.MinorHighAnsi, HighAnsiTheme = ThemeFontValues.MinorHighAnsi, EastAsiaTheme = ThemeFontValues.MinorHighAnsi, ComplexScriptTheme = ThemeFontValues.MinorBidi };
            FontSize fontSize170 = new FontSize() { Val = "22" };
            FontSizeComplexScript fontSizeComplexScript170 = new FontSizeComplexScript() { Val = "22" };
            Languages languages2 = new Languages() { Val = "ru-RU", EastAsia = "en-US", Bidi = "ar-SA" };

            runPropertiesBaseStyle1.Append(runFonts170);
            runPropertiesBaseStyle1.Append(fontSize170);
            runPropertiesBaseStyle1.Append(fontSizeComplexScript170);
            runPropertiesBaseStyle1.Append(languages2);

            runPropertiesDefault1.Append(runPropertiesBaseStyle1);

            ParagraphPropertiesDefault paragraphPropertiesDefault1 = new ParagraphPropertiesDefault();

            ParagraphPropertiesBaseStyle paragraphPropertiesBaseStyle1 = new ParagraphPropertiesBaseStyle();
            SpacingBetweenLines spacingBetweenLines1 = new SpacingBetweenLines() { After = "200", Line = "276", LineRule = LineSpacingRuleValues.Auto };

            paragraphPropertiesBaseStyle1.Append(spacingBetweenLines1);

            paragraphPropertiesDefault1.Append(paragraphPropertiesBaseStyle1);

            docDefaults1.Append(runPropertiesDefault1);
            docDefaults1.Append(paragraphPropertiesDefault1);

            LatentStyles latentStyles1 = new LatentStyles() { DefaultLockedState = false, DefaultUiPriority = 99, DefaultSemiHidden = true, DefaultUnhideWhenUsed = true, DefaultPrimaryStyle = false, Count = 267 };
            LatentStyleExceptionInfo latentStyleExceptionInfo1 = new LatentStyleExceptionInfo() { Name = "Normal", UiPriority = 0, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo2 = new LatentStyleExceptionInfo() { Name = "heading 1", UiPriority = 9, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo3 = new LatentStyleExceptionInfo() { Name = "heading 2", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo4 = new LatentStyleExceptionInfo() { Name = "heading 3", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo5 = new LatentStyleExceptionInfo() { Name = "heading 4", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo6 = new LatentStyleExceptionInfo() { Name = "heading 5", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo7 = new LatentStyleExceptionInfo() { Name = "heading 6", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo8 = new LatentStyleExceptionInfo() { Name = "heading 7", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo9 = new LatentStyleExceptionInfo() { Name = "heading 8", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo10 = new LatentStyleExceptionInfo() { Name = "heading 9", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo11 = new LatentStyleExceptionInfo() { Name = "toc 1", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo12 = new LatentStyleExceptionInfo() { Name = "toc 2", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo13 = new LatentStyleExceptionInfo() { Name = "toc 3", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo14 = new LatentStyleExceptionInfo() { Name = "toc 4", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo15 = new LatentStyleExceptionInfo() { Name = "toc 5", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo16 = new LatentStyleExceptionInfo() { Name = "toc 6", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo17 = new LatentStyleExceptionInfo() { Name = "toc 7", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo18 = new LatentStyleExceptionInfo() { Name = "toc 8", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo19 = new LatentStyleExceptionInfo() { Name = "toc 9", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo20 = new LatentStyleExceptionInfo() { Name = "caption", UiPriority = 35, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo21 = new LatentStyleExceptionInfo() { Name = "Title", UiPriority = 10, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo22 = new LatentStyleExceptionInfo() { Name = "Default Paragraph Font", UiPriority = 1 };
            LatentStyleExceptionInfo latentStyleExceptionInfo23 = new LatentStyleExceptionInfo() { Name = "Subtitle", UiPriority = 11, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo24 = new LatentStyleExceptionInfo() { Name = "Strong", UiPriority = 22, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo25 = new LatentStyleExceptionInfo() { Name = "Emphasis", UiPriority = 20, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo26 = new LatentStyleExceptionInfo() { Name = "Table Grid", UiPriority = 59, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo27 = new LatentStyleExceptionInfo() { Name = "Placeholder Text", UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo28 = new LatentStyleExceptionInfo() { Name = "No Spacing", UiPriority = 1, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo29 = new LatentStyleExceptionInfo() { Name = "Light Shading", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo30 = new LatentStyleExceptionInfo() { Name = "Light List", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo31 = new LatentStyleExceptionInfo() { Name = "Light Grid", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo32 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo33 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo34 = new LatentStyleExceptionInfo() { Name = "Medium List 1", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo35 = new LatentStyleExceptionInfo() { Name = "Medium List 2", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo36 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo37 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo38 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo39 = new LatentStyleExceptionInfo() { Name = "Dark List", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo40 = new LatentStyleExceptionInfo() { Name = "Colorful Shading", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo41 = new LatentStyleExceptionInfo() { Name = "Colorful List", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo42 = new LatentStyleExceptionInfo() { Name = "Colorful Grid", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo43 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 1", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo44 = new LatentStyleExceptionInfo() { Name = "Light List Accent 1", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo45 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 1", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo46 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 1", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo47 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 1", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo48 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 1", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo49 = new LatentStyleExceptionInfo() { Name = "Revision", UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo50 = new LatentStyleExceptionInfo() { Name = "List Paragraph", UiPriority = 34, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo51 = new LatentStyleExceptionInfo() { Name = "Quote", UiPriority = 29, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo52 = new LatentStyleExceptionInfo() { Name = "Intense Quote", UiPriority = 30, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo53 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 1", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo54 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 1", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo55 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 1", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo56 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 1", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo57 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 1", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo58 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 1", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo59 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 1", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo60 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 1", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo61 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 2", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo62 = new LatentStyleExceptionInfo() { Name = "Light List Accent 2", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo63 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 2", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo64 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 2", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo65 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 2", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo66 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 2", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo67 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 2", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo68 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 2", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo69 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 2", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo70 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 2", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo71 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 2", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo72 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 2", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo73 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 2", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo74 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 2", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo75 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 3", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo76 = new LatentStyleExceptionInfo() { Name = "Light List Accent 3", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo77 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 3", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo78 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 3", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo79 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 3", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo80 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 3", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo81 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 3", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo82 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 3", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo83 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 3", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo84 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 3", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo85 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 3", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo86 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 3", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo87 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 3", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo88 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 3", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo89 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 4", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo90 = new LatentStyleExceptionInfo() { Name = "Light List Accent 4", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo91 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 4", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo92 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 4", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo93 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 4", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo94 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 4", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo95 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 4", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo96 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 4", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo97 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 4", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo98 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 4", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo99 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 4", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo100 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 4", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo101 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 4", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo102 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 4", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo103 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 5", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo104 = new LatentStyleExceptionInfo() { Name = "Light List Accent 5", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo105 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 5", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo106 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 5", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo107 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 5", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo108 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 5", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo109 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 5", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo110 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 5", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo111 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 5", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo112 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 5", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo113 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 5", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo114 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 5", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo115 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 5", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo116 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 5", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo117 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 6", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo118 = new LatentStyleExceptionInfo() { Name = "Light List Accent 6", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo119 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 6", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo120 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 6", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo121 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 6", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo122 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 6", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo123 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 6", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo124 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 6", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo125 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 6", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo126 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 6", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo127 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 6", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo128 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 6", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo129 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 6", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo130 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 6", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo131 = new LatentStyleExceptionInfo() { Name = "Subtle Emphasis", UiPriority = 19, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo132 = new LatentStyleExceptionInfo() { Name = "Intense Emphasis", UiPriority = 21, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo133 = new LatentStyleExceptionInfo() { Name = "Subtle Reference", UiPriority = 31, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo134 = new LatentStyleExceptionInfo() { Name = "Intense Reference", UiPriority = 32, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo135 = new LatentStyleExceptionInfo() { Name = "Book Title", UiPriority = 33, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo136 = new LatentStyleExceptionInfo() { Name = "Bibliography", UiPriority = 37 };
            LatentStyleExceptionInfo latentStyleExceptionInfo137 = new LatentStyleExceptionInfo() { Name = "TOC Heading", UiPriority = 39, PrimaryStyle = true };

            latentStyles1.Append(latentStyleExceptionInfo1);
            latentStyles1.Append(latentStyleExceptionInfo2);
            latentStyles1.Append(latentStyleExceptionInfo3);
            latentStyles1.Append(latentStyleExceptionInfo4);
            latentStyles1.Append(latentStyleExceptionInfo5);
            latentStyles1.Append(latentStyleExceptionInfo6);
            latentStyles1.Append(latentStyleExceptionInfo7);
            latentStyles1.Append(latentStyleExceptionInfo8);
            latentStyles1.Append(latentStyleExceptionInfo9);
            latentStyles1.Append(latentStyleExceptionInfo10);
            latentStyles1.Append(latentStyleExceptionInfo11);
            latentStyles1.Append(latentStyleExceptionInfo12);
            latentStyles1.Append(latentStyleExceptionInfo13);
            latentStyles1.Append(latentStyleExceptionInfo14);
            latentStyles1.Append(latentStyleExceptionInfo15);
            latentStyles1.Append(latentStyleExceptionInfo16);
            latentStyles1.Append(latentStyleExceptionInfo17);
            latentStyles1.Append(latentStyleExceptionInfo18);
            latentStyles1.Append(latentStyleExceptionInfo19);
            latentStyles1.Append(latentStyleExceptionInfo20);
            latentStyles1.Append(latentStyleExceptionInfo21);
            latentStyles1.Append(latentStyleExceptionInfo22);
            latentStyles1.Append(latentStyleExceptionInfo23);
            latentStyles1.Append(latentStyleExceptionInfo24);
            latentStyles1.Append(latentStyleExceptionInfo25);
            latentStyles1.Append(latentStyleExceptionInfo26);
            latentStyles1.Append(latentStyleExceptionInfo27);
            latentStyles1.Append(latentStyleExceptionInfo28);
            latentStyles1.Append(latentStyleExceptionInfo29);
            latentStyles1.Append(latentStyleExceptionInfo30);
            latentStyles1.Append(latentStyleExceptionInfo31);
            latentStyles1.Append(latentStyleExceptionInfo32);
            latentStyles1.Append(latentStyleExceptionInfo33);
            latentStyles1.Append(latentStyleExceptionInfo34);
            latentStyles1.Append(latentStyleExceptionInfo35);
            latentStyles1.Append(latentStyleExceptionInfo36);
            latentStyles1.Append(latentStyleExceptionInfo37);
            latentStyles1.Append(latentStyleExceptionInfo38);
            latentStyles1.Append(latentStyleExceptionInfo39);
            latentStyles1.Append(latentStyleExceptionInfo40);
            latentStyles1.Append(latentStyleExceptionInfo41);
            latentStyles1.Append(latentStyleExceptionInfo42);
            latentStyles1.Append(latentStyleExceptionInfo43);
            latentStyles1.Append(latentStyleExceptionInfo44);
            latentStyles1.Append(latentStyleExceptionInfo45);
            latentStyles1.Append(latentStyleExceptionInfo46);
            latentStyles1.Append(latentStyleExceptionInfo47);
            latentStyles1.Append(latentStyleExceptionInfo48);
            latentStyles1.Append(latentStyleExceptionInfo49);
            latentStyles1.Append(latentStyleExceptionInfo50);
            latentStyles1.Append(latentStyleExceptionInfo51);
            latentStyles1.Append(latentStyleExceptionInfo52);
            latentStyles1.Append(latentStyleExceptionInfo53);
            latentStyles1.Append(latentStyleExceptionInfo54);
            latentStyles1.Append(latentStyleExceptionInfo55);
            latentStyles1.Append(latentStyleExceptionInfo56);
            latentStyles1.Append(latentStyleExceptionInfo57);
            latentStyles1.Append(latentStyleExceptionInfo58);
            latentStyles1.Append(latentStyleExceptionInfo59);
            latentStyles1.Append(latentStyleExceptionInfo60);
            latentStyles1.Append(latentStyleExceptionInfo61);
            latentStyles1.Append(latentStyleExceptionInfo62);
            latentStyles1.Append(latentStyleExceptionInfo63);
            latentStyles1.Append(latentStyleExceptionInfo64);
            latentStyles1.Append(latentStyleExceptionInfo65);
            latentStyles1.Append(latentStyleExceptionInfo66);
            latentStyles1.Append(latentStyleExceptionInfo67);
            latentStyles1.Append(latentStyleExceptionInfo68);
            latentStyles1.Append(latentStyleExceptionInfo69);
            latentStyles1.Append(latentStyleExceptionInfo70);
            latentStyles1.Append(latentStyleExceptionInfo71);
            latentStyles1.Append(latentStyleExceptionInfo72);
            latentStyles1.Append(latentStyleExceptionInfo73);
            latentStyles1.Append(latentStyleExceptionInfo74);
            latentStyles1.Append(latentStyleExceptionInfo75);
            latentStyles1.Append(latentStyleExceptionInfo76);
            latentStyles1.Append(latentStyleExceptionInfo77);
            latentStyles1.Append(latentStyleExceptionInfo78);
            latentStyles1.Append(latentStyleExceptionInfo79);
            latentStyles1.Append(latentStyleExceptionInfo80);
            latentStyles1.Append(latentStyleExceptionInfo81);
            latentStyles1.Append(latentStyleExceptionInfo82);
            latentStyles1.Append(latentStyleExceptionInfo83);
            latentStyles1.Append(latentStyleExceptionInfo84);
            latentStyles1.Append(latentStyleExceptionInfo85);
            latentStyles1.Append(latentStyleExceptionInfo86);
            latentStyles1.Append(latentStyleExceptionInfo87);
            latentStyles1.Append(latentStyleExceptionInfo88);
            latentStyles1.Append(latentStyleExceptionInfo89);
            latentStyles1.Append(latentStyleExceptionInfo90);
            latentStyles1.Append(latentStyleExceptionInfo91);
            latentStyles1.Append(latentStyleExceptionInfo92);
            latentStyles1.Append(latentStyleExceptionInfo93);
            latentStyles1.Append(latentStyleExceptionInfo94);
            latentStyles1.Append(latentStyleExceptionInfo95);
            latentStyles1.Append(latentStyleExceptionInfo96);
            latentStyles1.Append(latentStyleExceptionInfo97);
            latentStyles1.Append(latentStyleExceptionInfo98);
            latentStyles1.Append(latentStyleExceptionInfo99);
            latentStyles1.Append(latentStyleExceptionInfo100);
            latentStyles1.Append(latentStyleExceptionInfo101);
            latentStyles1.Append(latentStyleExceptionInfo102);
            latentStyles1.Append(latentStyleExceptionInfo103);
            latentStyles1.Append(latentStyleExceptionInfo104);
            latentStyles1.Append(latentStyleExceptionInfo105);
            latentStyles1.Append(latentStyleExceptionInfo106);
            latentStyles1.Append(latentStyleExceptionInfo107);
            latentStyles1.Append(latentStyleExceptionInfo108);
            latentStyles1.Append(latentStyleExceptionInfo109);
            latentStyles1.Append(latentStyleExceptionInfo110);
            latentStyles1.Append(latentStyleExceptionInfo111);
            latentStyles1.Append(latentStyleExceptionInfo112);
            latentStyles1.Append(latentStyleExceptionInfo113);
            latentStyles1.Append(latentStyleExceptionInfo114);
            latentStyles1.Append(latentStyleExceptionInfo115);
            latentStyles1.Append(latentStyleExceptionInfo116);
            latentStyles1.Append(latentStyleExceptionInfo117);
            latentStyles1.Append(latentStyleExceptionInfo118);
            latentStyles1.Append(latentStyleExceptionInfo119);
            latentStyles1.Append(latentStyleExceptionInfo120);
            latentStyles1.Append(latentStyleExceptionInfo121);
            latentStyles1.Append(latentStyleExceptionInfo122);
            latentStyles1.Append(latentStyleExceptionInfo123);
            latentStyles1.Append(latentStyleExceptionInfo124);
            latentStyles1.Append(latentStyleExceptionInfo125);
            latentStyles1.Append(latentStyleExceptionInfo126);
            latentStyles1.Append(latentStyleExceptionInfo127);
            latentStyles1.Append(latentStyleExceptionInfo128);
            latentStyles1.Append(latentStyleExceptionInfo129);
            latentStyles1.Append(latentStyleExceptionInfo130);
            latentStyles1.Append(latentStyleExceptionInfo131);
            latentStyles1.Append(latentStyleExceptionInfo132);
            latentStyles1.Append(latentStyleExceptionInfo133);
            latentStyles1.Append(latentStyleExceptionInfo134);
            latentStyles1.Append(latentStyleExceptionInfo135);
            latentStyles1.Append(latentStyleExceptionInfo136);
            latentStyles1.Append(latentStyleExceptionInfo137);

            Style style1 = new Style() { Type = StyleValues.Paragraph, StyleId = "a", Default = true };
            StyleName styleName1 = new StyleName() { Val = "Normal" };
            PrimaryStyle primaryStyle1 = new PrimaryStyle();

            style1.Append(styleName1);
            style1.Append(primaryStyle1);

            Style style2 = new Style() { Type = StyleValues.Character, StyleId = "a0", Default = true };
            StyleName styleName2 = new StyleName() { Val = "Default Paragraph Font" };
            UIPriority uIPriority1 = new UIPriority() { Val = 1 };
            SemiHidden semiHidden1 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed1 = new UnhideWhenUsed();

            style2.Append(styleName2);
            style2.Append(uIPriority1);
            style2.Append(semiHidden1);
            style2.Append(unhideWhenUsed1);

            Style style3 = new Style() { Type = StyleValues.Table, StyleId = "a1", Default = true };
            StyleName styleName3 = new StyleName() { Val = "Normal Table" };
            UIPriority uIPriority2 = new UIPriority() { Val = 99 };
            SemiHidden semiHidden2 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed2 = new UnhideWhenUsed();

            StyleTableProperties styleTableProperties1 = new StyleTableProperties();
            TableIndentation tableIndentation1 = new TableIndentation() { Width = 0, Type = TableWidthUnitValues.Dxa };

            TableCellMarginDefault tableCellMarginDefault1 = new TableCellMarginDefault();
            TopMargin topMargin1 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            TableCellLeftMargin tableCellLeftMargin1 = new TableCellLeftMargin() { Width = 108, Type = TableWidthValues.Dxa };
            BottomMargin bottomMargin1 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            TableCellRightMargin tableCellRightMargin1 = new TableCellRightMargin() { Width = 108, Type = TableWidthValues.Dxa };

            tableCellMarginDefault1.Append(topMargin1);
            tableCellMarginDefault1.Append(tableCellLeftMargin1);
            tableCellMarginDefault1.Append(bottomMargin1);
            tableCellMarginDefault1.Append(tableCellRightMargin1);

            styleTableProperties1.Append(tableIndentation1);
            styleTableProperties1.Append(tableCellMarginDefault1);

            style3.Append(styleName3);
            style3.Append(uIPriority2);
            style3.Append(semiHidden2);
            style3.Append(unhideWhenUsed2);
            style3.Append(styleTableProperties1);

            Style style4 = new Style() { Type = StyleValues.Numbering, StyleId = "a2", Default = true };
            StyleName styleName4 = new StyleName() { Val = "No List" };
            UIPriority uIPriority3 = new UIPriority() { Val = 99 };
            SemiHidden semiHidden3 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed3 = new UnhideWhenUsed();

            style4.Append(styleName4);
            style4.Append(uIPriority3);
            style4.Append(semiHidden3);
            style4.Append(unhideWhenUsed3);

            Style style5 = new Style() { Type = StyleValues.Paragraph, StyleId = "a3" };
            StyleName styleName5 = new StyleName() { Val = "header" };
            BasedOn basedOn1 = new BasedOn() { Val = "a" };
            LinkedStyle linkedStyle1 = new LinkedStyle() { Val = "a4" };
            UIPriority uIPriority4 = new UIPriority() { Val = 99 };
            UnhideWhenUsed unhideWhenUsed4 = new UnhideWhenUsed();
            Rsid rsid17 = new Rsid() { Val = "00867E42" };

            StyleParagraphProperties styleParagraphProperties1 = new StyleParagraphProperties();

            Tabs tabs1 = new Tabs();
            TabStop tabStop1 = new TabStop() { Val = TabStopValues.Center, Position = 4677 };
            TabStop tabStop2 = new TabStop() { Val = TabStopValues.Right, Position = 9355 };

            tabs1.Append(tabStop1);
            tabs1.Append(tabStop2);
            SpacingBetweenLines spacingBetweenLines2 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            styleParagraphProperties1.Append(tabs1);
            styleParagraphProperties1.Append(spacingBetweenLines2);

            style5.Append(styleName5);
            style5.Append(basedOn1);
            style5.Append(linkedStyle1);
            style5.Append(uIPriority4);
            style5.Append(unhideWhenUsed4);
            style5.Append(rsid17);
            style5.Append(styleParagraphProperties1);

            Style style6 = new Style() { Type = StyleValues.Character, StyleId = "a4", CustomStyle = true };
            StyleName styleName6 = new StyleName() { Val = "Верхний колонтитул Знак" };
            BasedOn basedOn2 = new BasedOn() { Val = "a0" };
            LinkedStyle linkedStyle2 = new LinkedStyle() { Val = "a3" };
            UIPriority uIPriority5 = new UIPriority() { Val = 99 };
            Rsid rsid18 = new Rsid() { Val = "00867E42" };

            style6.Append(styleName6);
            style6.Append(basedOn2);
            style6.Append(linkedStyle2);
            style6.Append(uIPriority5);
            style6.Append(rsid18);

            Style style7 = new Style() { Type = StyleValues.Paragraph, StyleId = "a5" };
            StyleName styleName7 = new StyleName() { Val = "footer" };
            BasedOn basedOn3 = new BasedOn() { Val = "a" };
            LinkedStyle linkedStyle3 = new LinkedStyle() { Val = "a6" };
            UIPriority uIPriority6 = new UIPriority() { Val = 99 };
            UnhideWhenUsed unhideWhenUsed5 = new UnhideWhenUsed();
            Rsid rsid19 = new Rsid() { Val = "00867E42" };

            StyleParagraphProperties styleParagraphProperties2 = new StyleParagraphProperties();

            Tabs tabs2 = new Tabs();
            TabStop tabStop3 = new TabStop() { Val = TabStopValues.Center, Position = 4677 };
            TabStop tabStop4 = new TabStop() { Val = TabStopValues.Right, Position = 9355 };

            tabs2.Append(tabStop3);
            tabs2.Append(tabStop4);
            SpacingBetweenLines spacingBetweenLines3 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            styleParagraphProperties2.Append(tabs2);
            styleParagraphProperties2.Append(spacingBetweenLines3);

            style7.Append(styleName7);
            style7.Append(basedOn3);
            style7.Append(linkedStyle3);
            style7.Append(uIPriority6);
            style7.Append(unhideWhenUsed5);
            style7.Append(rsid19);
            style7.Append(styleParagraphProperties2);

            Style style8 = new Style() { Type = StyleValues.Character, StyleId = "a6", CustomStyle = true };
            StyleName styleName8 = new StyleName() { Val = "Нижний колонтитул Знак" };
            BasedOn basedOn4 = new BasedOn() { Val = "a0" };
            LinkedStyle linkedStyle4 = new LinkedStyle() { Val = "a5" };
            UIPriority uIPriority7 = new UIPriority() { Val = 99 };
            Rsid rsid20 = new Rsid() { Val = "00867E42" };

            style8.Append(styleName8);
            style8.Append(basedOn4);
            style8.Append(linkedStyle4);
            style8.Append(uIPriority7);
            style8.Append(rsid20);

            styles1.Append(docDefaults1);
            styles1.Append(latentStyles1);
            styles1.Append(style1);
            styles1.Append(style2);
            styles1.Append(style3);
            styles1.Append(style4);
            styles1.Append(style5);
            styles1.Append(style6);
            styles1.Append(style7);
            styles1.Append(style8);

            stylesWithEffectsPart1.Styles = styles1;
        }

        // Generates content of styleDefinitionsPart1.
        private void GenerateStyleDefinitionsPart1Content(StyleDefinitionsPart styleDefinitionsPart1)
        {
            Styles styles2 = new Styles() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14" } };
            styles2.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            styles2.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            styles2.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            styles2.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");

            DocDefaults docDefaults2 = new DocDefaults();

            RunPropertiesDefault runPropertiesDefault2 = new RunPropertiesDefault();

            RunPropertiesBaseStyle runPropertiesBaseStyle2 = new RunPropertiesBaseStyle();
            RunFonts runFonts171 = new RunFonts() { AsciiTheme = ThemeFontValues.MinorHighAnsi, HighAnsiTheme = ThemeFontValues.MinorHighAnsi, EastAsiaTheme = ThemeFontValues.MinorHighAnsi, ComplexScriptTheme = ThemeFontValues.MinorBidi };
            FontSize fontSize171 = new FontSize() { Val = "22" };
            FontSizeComplexScript fontSizeComplexScript171 = new FontSizeComplexScript() { Val = "22" };
            Languages languages3 = new Languages() { Val = "ru-RU", EastAsia = "en-US", Bidi = "ar-SA" };

            runPropertiesBaseStyle2.Append(runFonts171);
            runPropertiesBaseStyle2.Append(fontSize171);
            runPropertiesBaseStyle2.Append(fontSizeComplexScript171);
            runPropertiesBaseStyle2.Append(languages3);

            runPropertiesDefault2.Append(runPropertiesBaseStyle2);

            ParagraphPropertiesDefault paragraphPropertiesDefault2 = new ParagraphPropertiesDefault();

            ParagraphPropertiesBaseStyle paragraphPropertiesBaseStyle2 = new ParagraphPropertiesBaseStyle();
            SpacingBetweenLines spacingBetweenLines4 = new SpacingBetweenLines() { After = "200", Line = "276", LineRule = LineSpacingRuleValues.Auto };

            paragraphPropertiesBaseStyle2.Append(spacingBetweenLines4);

            paragraphPropertiesDefault2.Append(paragraphPropertiesBaseStyle2);

            docDefaults2.Append(runPropertiesDefault2);
            docDefaults2.Append(paragraphPropertiesDefault2);

            LatentStyles latentStyles2 = new LatentStyles() { DefaultLockedState = false, DefaultUiPriority = 99, DefaultSemiHidden = true, DefaultUnhideWhenUsed = true, DefaultPrimaryStyle = false, Count = 267 };
            LatentStyleExceptionInfo latentStyleExceptionInfo138 = new LatentStyleExceptionInfo() { Name = "Normal", UiPriority = 0, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo139 = new LatentStyleExceptionInfo() { Name = "heading 1", UiPriority = 9, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo140 = new LatentStyleExceptionInfo() { Name = "heading 2", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo141 = new LatentStyleExceptionInfo() { Name = "heading 3", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo142 = new LatentStyleExceptionInfo() { Name = "heading 4", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo143 = new LatentStyleExceptionInfo() { Name = "heading 5", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo144 = new LatentStyleExceptionInfo() { Name = "heading 6", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo145 = new LatentStyleExceptionInfo() { Name = "heading 7", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo146 = new LatentStyleExceptionInfo() { Name = "heading 8", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo147 = new LatentStyleExceptionInfo() { Name = "heading 9", UiPriority = 9, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo148 = new LatentStyleExceptionInfo() { Name = "toc 1", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo149 = new LatentStyleExceptionInfo() { Name = "toc 2", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo150 = new LatentStyleExceptionInfo() { Name = "toc 3", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo151 = new LatentStyleExceptionInfo() { Name = "toc 4", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo152 = new LatentStyleExceptionInfo() { Name = "toc 5", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo153 = new LatentStyleExceptionInfo() { Name = "toc 6", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo154 = new LatentStyleExceptionInfo() { Name = "toc 7", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo155 = new LatentStyleExceptionInfo() { Name = "toc 8", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo156 = new LatentStyleExceptionInfo() { Name = "toc 9", UiPriority = 39 };
            LatentStyleExceptionInfo latentStyleExceptionInfo157 = new LatentStyleExceptionInfo() { Name = "caption", UiPriority = 35, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo158 = new LatentStyleExceptionInfo() { Name = "Title", UiPriority = 10, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo159 = new LatentStyleExceptionInfo() { Name = "Default Paragraph Font", UiPriority = 1 };
            LatentStyleExceptionInfo latentStyleExceptionInfo160 = new LatentStyleExceptionInfo() { Name = "Subtitle", UiPriority = 11, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo161 = new LatentStyleExceptionInfo() { Name = "Strong", UiPriority = 22, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo162 = new LatentStyleExceptionInfo() { Name = "Emphasis", UiPriority = 20, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo163 = new LatentStyleExceptionInfo() { Name = "Table Grid", UiPriority = 59, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo164 = new LatentStyleExceptionInfo() { Name = "Placeholder Text", UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo165 = new LatentStyleExceptionInfo() { Name = "No Spacing", UiPriority = 1, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo166 = new LatentStyleExceptionInfo() { Name = "Light Shading", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo167 = new LatentStyleExceptionInfo() { Name = "Light List", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo168 = new LatentStyleExceptionInfo() { Name = "Light Grid", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo169 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo170 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo171 = new LatentStyleExceptionInfo() { Name = "Medium List 1", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo172 = new LatentStyleExceptionInfo() { Name = "Medium List 2", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo173 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo174 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo175 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo176 = new LatentStyleExceptionInfo() { Name = "Dark List", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo177 = new LatentStyleExceptionInfo() { Name = "Colorful Shading", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo178 = new LatentStyleExceptionInfo() { Name = "Colorful List", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo179 = new LatentStyleExceptionInfo() { Name = "Colorful Grid", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo180 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 1", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo181 = new LatentStyleExceptionInfo() { Name = "Light List Accent 1", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo182 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 1", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo183 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 1", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo184 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 1", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo185 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 1", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo186 = new LatentStyleExceptionInfo() { Name = "Revision", UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo187 = new LatentStyleExceptionInfo() { Name = "List Paragraph", UiPriority = 34, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo188 = new LatentStyleExceptionInfo() { Name = "Quote", UiPriority = 29, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo189 = new LatentStyleExceptionInfo() { Name = "Intense Quote", UiPriority = 30, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo190 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 1", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo191 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 1", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo192 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 1", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo193 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 1", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo194 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 1", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo195 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 1", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo196 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 1", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo197 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 1", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo198 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 2", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo199 = new LatentStyleExceptionInfo() { Name = "Light List Accent 2", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo200 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 2", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo201 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 2", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo202 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 2", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo203 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 2", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo204 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 2", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo205 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 2", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo206 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 2", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo207 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 2", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo208 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 2", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo209 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 2", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo210 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 2", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo211 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 2", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo212 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 3", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo213 = new LatentStyleExceptionInfo() { Name = "Light List Accent 3", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo214 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 3", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo215 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 3", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo216 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 3", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo217 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 3", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo218 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 3", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo219 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 3", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo220 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 3", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo221 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 3", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo222 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 3", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo223 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 3", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo224 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 3", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo225 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 3", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo226 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 4", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo227 = new LatentStyleExceptionInfo() { Name = "Light List Accent 4", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo228 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 4", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo229 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 4", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo230 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 4", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo231 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 4", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo232 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 4", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo233 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 4", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo234 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 4", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo235 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 4", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo236 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 4", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo237 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 4", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo238 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 4", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo239 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 4", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo240 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 5", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo241 = new LatentStyleExceptionInfo() { Name = "Light List Accent 5", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo242 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 5", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo243 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 5", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo244 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 5", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo245 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 5", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo246 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 5", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo247 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 5", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo248 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 5", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo249 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 5", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo250 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 5", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo251 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 5", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo252 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 5", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo253 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 5", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo254 = new LatentStyleExceptionInfo() { Name = "Light Shading Accent 6", UiPriority = 60, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo255 = new LatentStyleExceptionInfo() { Name = "Light List Accent 6", UiPriority = 61, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo256 = new LatentStyleExceptionInfo() { Name = "Light Grid Accent 6", UiPriority = 62, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo257 = new LatentStyleExceptionInfo() { Name = "Medium Shading 1 Accent 6", UiPriority = 63, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo258 = new LatentStyleExceptionInfo() { Name = "Medium Shading 2 Accent 6", UiPriority = 64, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo259 = new LatentStyleExceptionInfo() { Name = "Medium List 1 Accent 6", UiPriority = 65, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo260 = new LatentStyleExceptionInfo() { Name = "Medium List 2 Accent 6", UiPriority = 66, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo261 = new LatentStyleExceptionInfo() { Name = "Medium Grid 1 Accent 6", UiPriority = 67, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo262 = new LatentStyleExceptionInfo() { Name = "Medium Grid 2 Accent 6", UiPriority = 68, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo263 = new LatentStyleExceptionInfo() { Name = "Medium Grid 3 Accent 6", UiPriority = 69, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo264 = new LatentStyleExceptionInfo() { Name = "Dark List Accent 6", UiPriority = 70, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo265 = new LatentStyleExceptionInfo() { Name = "Colorful Shading Accent 6", UiPriority = 71, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo266 = new LatentStyleExceptionInfo() { Name = "Colorful List Accent 6", UiPriority = 72, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo267 = new LatentStyleExceptionInfo() { Name = "Colorful Grid Accent 6", UiPriority = 73, SemiHidden = false, UnhideWhenUsed = false };
            LatentStyleExceptionInfo latentStyleExceptionInfo268 = new LatentStyleExceptionInfo() { Name = "Subtle Emphasis", UiPriority = 19, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo269 = new LatentStyleExceptionInfo() { Name = "Intense Emphasis", UiPriority = 21, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo270 = new LatentStyleExceptionInfo() { Name = "Subtle Reference", UiPriority = 31, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo271 = new LatentStyleExceptionInfo() { Name = "Intense Reference", UiPriority = 32, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo272 = new LatentStyleExceptionInfo() { Name = "Book Title", UiPriority = 33, SemiHidden = false, UnhideWhenUsed = false, PrimaryStyle = true };
            LatentStyleExceptionInfo latentStyleExceptionInfo273 = new LatentStyleExceptionInfo() { Name = "Bibliography", UiPriority = 37 };
            LatentStyleExceptionInfo latentStyleExceptionInfo274 = new LatentStyleExceptionInfo() { Name = "TOC Heading", UiPriority = 39, PrimaryStyle = true };

            latentStyles2.Append(latentStyleExceptionInfo138);
            latentStyles2.Append(latentStyleExceptionInfo139);
            latentStyles2.Append(latentStyleExceptionInfo140);
            latentStyles2.Append(latentStyleExceptionInfo141);
            latentStyles2.Append(latentStyleExceptionInfo142);
            latentStyles2.Append(latentStyleExceptionInfo143);
            latentStyles2.Append(latentStyleExceptionInfo144);
            latentStyles2.Append(latentStyleExceptionInfo145);
            latentStyles2.Append(latentStyleExceptionInfo146);
            latentStyles2.Append(latentStyleExceptionInfo147);
            latentStyles2.Append(latentStyleExceptionInfo148);
            latentStyles2.Append(latentStyleExceptionInfo149);
            latentStyles2.Append(latentStyleExceptionInfo150);
            latentStyles2.Append(latentStyleExceptionInfo151);
            latentStyles2.Append(latentStyleExceptionInfo152);
            latentStyles2.Append(latentStyleExceptionInfo153);
            latentStyles2.Append(latentStyleExceptionInfo154);
            latentStyles2.Append(latentStyleExceptionInfo155);
            latentStyles2.Append(latentStyleExceptionInfo156);
            latentStyles2.Append(latentStyleExceptionInfo157);
            latentStyles2.Append(latentStyleExceptionInfo158);
            latentStyles2.Append(latentStyleExceptionInfo159);
            latentStyles2.Append(latentStyleExceptionInfo160);
            latentStyles2.Append(latentStyleExceptionInfo161);
            latentStyles2.Append(latentStyleExceptionInfo162);
            latentStyles2.Append(latentStyleExceptionInfo163);
            latentStyles2.Append(latentStyleExceptionInfo164);
            latentStyles2.Append(latentStyleExceptionInfo165);
            latentStyles2.Append(latentStyleExceptionInfo166);
            latentStyles2.Append(latentStyleExceptionInfo167);
            latentStyles2.Append(latentStyleExceptionInfo168);
            latentStyles2.Append(latentStyleExceptionInfo169);
            latentStyles2.Append(latentStyleExceptionInfo170);
            latentStyles2.Append(latentStyleExceptionInfo171);
            latentStyles2.Append(latentStyleExceptionInfo172);
            latentStyles2.Append(latentStyleExceptionInfo173);
            latentStyles2.Append(latentStyleExceptionInfo174);
            latentStyles2.Append(latentStyleExceptionInfo175);
            latentStyles2.Append(latentStyleExceptionInfo176);
            latentStyles2.Append(latentStyleExceptionInfo177);
            latentStyles2.Append(latentStyleExceptionInfo178);
            latentStyles2.Append(latentStyleExceptionInfo179);
            latentStyles2.Append(latentStyleExceptionInfo180);
            latentStyles2.Append(latentStyleExceptionInfo181);
            latentStyles2.Append(latentStyleExceptionInfo182);
            latentStyles2.Append(latentStyleExceptionInfo183);
            latentStyles2.Append(latentStyleExceptionInfo184);
            latentStyles2.Append(latentStyleExceptionInfo185);
            latentStyles2.Append(latentStyleExceptionInfo186);
            latentStyles2.Append(latentStyleExceptionInfo187);
            latentStyles2.Append(latentStyleExceptionInfo188);
            latentStyles2.Append(latentStyleExceptionInfo189);
            latentStyles2.Append(latentStyleExceptionInfo190);
            latentStyles2.Append(latentStyleExceptionInfo191);
            latentStyles2.Append(latentStyleExceptionInfo192);
            latentStyles2.Append(latentStyleExceptionInfo193);
            latentStyles2.Append(latentStyleExceptionInfo194);
            latentStyles2.Append(latentStyleExceptionInfo195);
            latentStyles2.Append(latentStyleExceptionInfo196);
            latentStyles2.Append(latentStyleExceptionInfo197);
            latentStyles2.Append(latentStyleExceptionInfo198);
            latentStyles2.Append(latentStyleExceptionInfo199);
            latentStyles2.Append(latentStyleExceptionInfo200);
            latentStyles2.Append(latentStyleExceptionInfo201);
            latentStyles2.Append(latentStyleExceptionInfo202);
            latentStyles2.Append(latentStyleExceptionInfo203);
            latentStyles2.Append(latentStyleExceptionInfo204);
            latentStyles2.Append(latentStyleExceptionInfo205);
            latentStyles2.Append(latentStyleExceptionInfo206);
            latentStyles2.Append(latentStyleExceptionInfo207);
            latentStyles2.Append(latentStyleExceptionInfo208);
            latentStyles2.Append(latentStyleExceptionInfo209);
            latentStyles2.Append(latentStyleExceptionInfo210);
            latentStyles2.Append(latentStyleExceptionInfo211);
            latentStyles2.Append(latentStyleExceptionInfo212);
            latentStyles2.Append(latentStyleExceptionInfo213);
            latentStyles2.Append(latentStyleExceptionInfo214);
            latentStyles2.Append(latentStyleExceptionInfo215);
            latentStyles2.Append(latentStyleExceptionInfo216);
            latentStyles2.Append(latentStyleExceptionInfo217);
            latentStyles2.Append(latentStyleExceptionInfo218);
            latentStyles2.Append(latentStyleExceptionInfo219);
            latentStyles2.Append(latentStyleExceptionInfo220);
            latentStyles2.Append(latentStyleExceptionInfo221);
            latentStyles2.Append(latentStyleExceptionInfo222);
            latentStyles2.Append(latentStyleExceptionInfo223);
            latentStyles2.Append(latentStyleExceptionInfo224);
            latentStyles2.Append(latentStyleExceptionInfo225);
            latentStyles2.Append(latentStyleExceptionInfo226);
            latentStyles2.Append(latentStyleExceptionInfo227);
            latentStyles2.Append(latentStyleExceptionInfo228);
            latentStyles2.Append(latentStyleExceptionInfo229);
            latentStyles2.Append(latentStyleExceptionInfo230);
            latentStyles2.Append(latentStyleExceptionInfo231);
            latentStyles2.Append(latentStyleExceptionInfo232);
            latentStyles2.Append(latentStyleExceptionInfo233);
            latentStyles2.Append(latentStyleExceptionInfo234);
            latentStyles2.Append(latentStyleExceptionInfo235);
            latentStyles2.Append(latentStyleExceptionInfo236);
            latentStyles2.Append(latentStyleExceptionInfo237);
            latentStyles2.Append(latentStyleExceptionInfo238);
            latentStyles2.Append(latentStyleExceptionInfo239);
            latentStyles2.Append(latentStyleExceptionInfo240);
            latentStyles2.Append(latentStyleExceptionInfo241);
            latentStyles2.Append(latentStyleExceptionInfo242);
            latentStyles2.Append(latentStyleExceptionInfo243);
            latentStyles2.Append(latentStyleExceptionInfo244);
            latentStyles2.Append(latentStyleExceptionInfo245);
            latentStyles2.Append(latentStyleExceptionInfo246);
            latentStyles2.Append(latentStyleExceptionInfo247);
            latentStyles2.Append(latentStyleExceptionInfo248);
            latentStyles2.Append(latentStyleExceptionInfo249);
            latentStyles2.Append(latentStyleExceptionInfo250);
            latentStyles2.Append(latentStyleExceptionInfo251);
            latentStyles2.Append(latentStyleExceptionInfo252);
            latentStyles2.Append(latentStyleExceptionInfo253);
            latentStyles2.Append(latentStyleExceptionInfo254);
            latentStyles2.Append(latentStyleExceptionInfo255);
            latentStyles2.Append(latentStyleExceptionInfo256);
            latentStyles2.Append(latentStyleExceptionInfo257);
            latentStyles2.Append(latentStyleExceptionInfo258);
            latentStyles2.Append(latentStyleExceptionInfo259);
            latentStyles2.Append(latentStyleExceptionInfo260);
            latentStyles2.Append(latentStyleExceptionInfo261);
            latentStyles2.Append(latentStyleExceptionInfo262);
            latentStyles2.Append(latentStyleExceptionInfo263);
            latentStyles2.Append(latentStyleExceptionInfo264);
            latentStyles2.Append(latentStyleExceptionInfo265);
            latentStyles2.Append(latentStyleExceptionInfo266);
            latentStyles2.Append(latentStyleExceptionInfo267);
            latentStyles2.Append(latentStyleExceptionInfo268);
            latentStyles2.Append(latentStyleExceptionInfo269);
            latentStyles2.Append(latentStyleExceptionInfo270);
            latentStyles2.Append(latentStyleExceptionInfo271);
            latentStyles2.Append(latentStyleExceptionInfo272);
            latentStyles2.Append(latentStyleExceptionInfo273);
            latentStyles2.Append(latentStyleExceptionInfo274);

            Style style9 = new Style() { Type = StyleValues.Paragraph, StyleId = "a", Default = true };
            StyleName styleName9 = new StyleName() { Val = "Normal" };
            PrimaryStyle primaryStyle2 = new PrimaryStyle();
            Rsid rsid21 = new Rsid() { Val = "0044677F" };

            style9.Append(styleName9);
            style9.Append(primaryStyle2);
            style9.Append(rsid21);

            Style style10 = new Style() { Type = StyleValues.Character, StyleId = "a0", Default = true };
            StyleName styleName10 = new StyleName() { Val = "Default Paragraph Font" };
            UIPriority uIPriority8 = new UIPriority() { Val = 1 };
            SemiHidden semiHidden4 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed6 = new UnhideWhenUsed();

            style10.Append(styleName10);
            style10.Append(uIPriority8);
            style10.Append(semiHidden4);
            style10.Append(unhideWhenUsed6);

            Style style11 = new Style() { Type = StyleValues.Table, StyleId = "a1", Default = true };
            StyleName styleName11 = new StyleName() { Val = "Normal Table" };
            UIPriority uIPriority9 = new UIPriority() { Val = 99 };
            SemiHidden semiHidden5 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed7 = new UnhideWhenUsed();

            StyleTableProperties styleTableProperties2 = new StyleTableProperties();
            TableIndentation tableIndentation2 = new TableIndentation() { Width = 0, Type = TableWidthUnitValues.Dxa };

            TableCellMarginDefault tableCellMarginDefault2 = new TableCellMarginDefault();
            TopMargin topMargin2 = new TopMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            TableCellLeftMargin tableCellLeftMargin2 = new TableCellLeftMargin() { Width = 108, Type = TableWidthValues.Dxa };
            BottomMargin bottomMargin2 = new BottomMargin() { Width = "0", Type = TableWidthUnitValues.Dxa };
            TableCellRightMargin tableCellRightMargin2 = new TableCellRightMargin() { Width = 108, Type = TableWidthValues.Dxa };

            tableCellMarginDefault2.Append(topMargin2);
            tableCellMarginDefault2.Append(tableCellLeftMargin2);
            tableCellMarginDefault2.Append(bottomMargin2);
            tableCellMarginDefault2.Append(tableCellRightMargin2);

            styleTableProperties2.Append(tableIndentation2);
            styleTableProperties2.Append(tableCellMarginDefault2);

            style11.Append(styleName11);
            style11.Append(uIPriority9);
            style11.Append(semiHidden5);
            style11.Append(unhideWhenUsed7);
            style11.Append(styleTableProperties2);

            Style style12 = new Style() { Type = StyleValues.Numbering, StyleId = "a2", Default = true };
            StyleName styleName12 = new StyleName() { Val = "No List" };
            UIPriority uIPriority10 = new UIPriority() { Val = 99 };
            SemiHidden semiHidden6 = new SemiHidden();
            UnhideWhenUsed unhideWhenUsed8 = new UnhideWhenUsed();

            style12.Append(styleName12);
            style12.Append(uIPriority10);
            style12.Append(semiHidden6);
            style12.Append(unhideWhenUsed8);

            Style style13 = new Style() { Type = StyleValues.Paragraph, StyleId = "a3" };
            StyleName styleName13 = new StyleName() { Val = "header" };
            BasedOn basedOn5 = new BasedOn() { Val = "a" };
            LinkedStyle linkedStyle5 = new LinkedStyle() { Val = "a4" };
            UIPriority uIPriority11 = new UIPriority() { Val = 99 };
            UnhideWhenUsed unhideWhenUsed9 = new UnhideWhenUsed();
            Rsid rsid22 = new Rsid() { Val = "00867E42" };

            StyleParagraphProperties styleParagraphProperties3 = new StyleParagraphProperties();

            Tabs tabs3 = new Tabs();
            TabStop tabStop5 = new TabStop() { Val = TabStopValues.Center, Position = 4677 };
            TabStop tabStop6 = new TabStop() { Val = TabStopValues.Right, Position = 9355 };

            tabs3.Append(tabStop5);
            tabs3.Append(tabStop6);
            SpacingBetweenLines spacingBetweenLines5 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            styleParagraphProperties3.Append(tabs3);
            styleParagraphProperties3.Append(spacingBetweenLines5);

            style13.Append(styleName13);
            style13.Append(basedOn5);
            style13.Append(linkedStyle5);
            style13.Append(uIPriority11);
            style13.Append(unhideWhenUsed9);
            style13.Append(rsid22);
            style13.Append(styleParagraphProperties3);

            Style style14 = new Style() { Type = StyleValues.Character, StyleId = "a4", CustomStyle = true };
            StyleName styleName14 = new StyleName() { Val = "Верхний колонтитул Знак" };
            BasedOn basedOn6 = new BasedOn() { Val = "a0" };
            LinkedStyle linkedStyle6 = new LinkedStyle() { Val = "a3" };
            UIPriority uIPriority12 = new UIPriority() { Val = 99 };
            Rsid rsid23 = new Rsid() { Val = "00867E42" };

            style14.Append(styleName14);
            style14.Append(basedOn6);
            style14.Append(linkedStyle6);
            style14.Append(uIPriority12);
            style14.Append(rsid23);

            Style style15 = new Style() { Type = StyleValues.Paragraph, StyleId = "a5" };
            StyleName styleName15 = new StyleName() { Val = "footer" };
            BasedOn basedOn7 = new BasedOn() { Val = "a" };
            LinkedStyle linkedStyle7 = new LinkedStyle() { Val = "a6" };
            UIPriority uIPriority13 = new UIPriority() { Val = 99 };
            UnhideWhenUsed unhideWhenUsed10 = new UnhideWhenUsed();
            Rsid rsid24 = new Rsid() { Val = "00867E42" };

            StyleParagraphProperties styleParagraphProperties4 = new StyleParagraphProperties();

            Tabs tabs4 = new Tabs();
            TabStop tabStop7 = new TabStop() { Val = TabStopValues.Center, Position = 4677 };
            TabStop tabStop8 = new TabStop() { Val = TabStopValues.Right, Position = 9355 };

            tabs4.Append(tabStop7);
            tabs4.Append(tabStop8);
            SpacingBetweenLines spacingBetweenLines6 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            styleParagraphProperties4.Append(tabs4);
            styleParagraphProperties4.Append(spacingBetweenLines6);

            style15.Append(styleName15);
            style15.Append(basedOn7);
            style15.Append(linkedStyle7);
            style15.Append(uIPriority13);
            style15.Append(unhideWhenUsed10);
            style15.Append(rsid24);
            style15.Append(styleParagraphProperties4);

            Style style16 = new Style() { Type = StyleValues.Character, StyleId = "a6", CustomStyle = true };
            StyleName styleName16 = new StyleName() { Val = "Нижний колонтитул Знак" };
            BasedOn basedOn8 = new BasedOn() { Val = "a0" };
            LinkedStyle linkedStyle8 = new LinkedStyle() { Val = "a5" };
            UIPriority uIPriority14 = new UIPriority() { Val = 99 };
            Rsid rsid25 = new Rsid() { Val = "00867E42" };

            style16.Append(styleName16);
            style16.Append(basedOn8);
            style16.Append(linkedStyle8);
            style16.Append(uIPriority14);
            style16.Append(rsid25);

            styles2.Append(docDefaults2);
            styles2.Append(latentStyles2);
            styles2.Append(style9);
            styles2.Append(style10);
            styles2.Append(style11);
            styles2.Append(style12);
            styles2.Append(style13);
            styles2.Append(style14);
            styles2.Append(style15);
            styles2.Append(style16);

            styleDefinitionsPart1.Styles = styles2;
        }

        // Generates content of endnotesPart1.
        private void GenerateEndnotesPart1Content(EndnotesPart endnotesPart1)
        {
            Endnotes endnotes1 = new Endnotes() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 wp14" } };
            endnotes1.AddNamespaceDeclaration("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
            endnotes1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            endnotes1.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
            endnotes1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            endnotes1.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
            endnotes1.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
            endnotes1.AddNamespaceDeclaration("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
            endnotes1.AddNamespaceDeclaration("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
            endnotes1.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
            endnotes1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            endnotes1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            endnotes1.AddNamespaceDeclaration("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
            endnotes1.AddNamespaceDeclaration("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
            endnotes1.AddNamespaceDeclaration("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
            endnotes1.AddNamespaceDeclaration("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");

            Endnote endnote1 = new Endnote() { Type = FootnoteEndnoteValues.Separator, Id = -1 };

            Paragraph paragraph60 = new Paragraph() { RsidParagraphAddition = "00E618F9", RsidParagraphProperties = "00867E42", RsidRunAdditionDefault = "00E618F9" };

            ParagraphProperties paragraphProperties60 = new ParagraphProperties();
            SpacingBetweenLines spacingBetweenLines7 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            paragraphProperties60.Append(spacingBetweenLines7);

            Run run111 = new Run();
            SeparatorMark separatorMark1 = new SeparatorMark();

            run111.Append(separatorMark1);

            paragraph60.Append(paragraphProperties60);
            paragraph60.Append(run111);

            endnote1.Append(paragraph60);

            Endnote endnote2 = new Endnote() { Type = FootnoteEndnoteValues.ContinuationSeparator, Id = 0 };

            Paragraph paragraph61 = new Paragraph() { RsidParagraphAddition = "00E618F9", RsidParagraphProperties = "00867E42", RsidRunAdditionDefault = "00E618F9" };

            ParagraphProperties paragraphProperties61 = new ParagraphProperties();
            SpacingBetweenLines spacingBetweenLines8 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            paragraphProperties61.Append(spacingBetweenLines8);

            Run run112 = new Run();
            ContinuationSeparatorMark continuationSeparatorMark1 = new ContinuationSeparatorMark();

            run112.Append(continuationSeparatorMark1);

            paragraph61.Append(paragraphProperties61);
            paragraph61.Append(run112);

            endnote2.Append(paragraph61);

            endnotes1.Append(endnote1);
            endnotes1.Append(endnote2);

            endnotesPart1.Endnotes = endnotes1;
        }

        // Generates content of footnotesPart1.
        private void GenerateFootnotesPart1Content(FootnotesPart footnotesPart1)
        {
            Footnotes footnotes1 = new Footnotes() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14 wp14" } };
            footnotes1.AddNamespaceDeclaration("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
            footnotes1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            footnotes1.AddNamespaceDeclaration("o", "urn:schemas-microsoft-com:office:office");
            footnotes1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            footnotes1.AddNamespaceDeclaration("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
            footnotes1.AddNamespaceDeclaration("v", "urn:schemas-microsoft-com:vml");
            footnotes1.AddNamespaceDeclaration("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
            footnotes1.AddNamespaceDeclaration("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
            footnotes1.AddNamespaceDeclaration("w10", "urn:schemas-microsoft-com:office:word");
            footnotes1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            footnotes1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            footnotes1.AddNamespaceDeclaration("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
            footnotes1.AddNamespaceDeclaration("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
            footnotes1.AddNamespaceDeclaration("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
            footnotes1.AddNamespaceDeclaration("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");

            Footnote footnote1 = new Footnote() { Type = FootnoteEndnoteValues.Separator, Id = -1 };

            Paragraph paragraph62 = new Paragraph() { RsidParagraphAddition = "00E618F9", RsidParagraphProperties = "00867E42", RsidRunAdditionDefault = "00E618F9" };

            ParagraphProperties paragraphProperties62 = new ParagraphProperties();
            SpacingBetweenLines spacingBetweenLines9 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            paragraphProperties62.Append(spacingBetweenLines9);

            Run run113 = new Run();
            SeparatorMark separatorMark2 = new SeparatorMark();

            run113.Append(separatorMark2);

            paragraph62.Append(paragraphProperties62);
            paragraph62.Append(run113);

            footnote1.Append(paragraph62);

            Footnote footnote2 = new Footnote() { Type = FootnoteEndnoteValues.ContinuationSeparator, Id = 0 };

            Paragraph paragraph63 = new Paragraph() { RsidParagraphAddition = "00E618F9", RsidParagraphProperties = "00867E42", RsidRunAdditionDefault = "00E618F9" };

            ParagraphProperties paragraphProperties63 = new ParagraphProperties();
            SpacingBetweenLines spacingBetweenLines10 = new SpacingBetweenLines() { After = "0", Line = "240", LineRule = LineSpacingRuleValues.Auto };

            paragraphProperties63.Append(spacingBetweenLines10);

            Run run114 = new Run();
            ContinuationSeparatorMark continuationSeparatorMark2 = new ContinuationSeparatorMark();

            run114.Append(continuationSeparatorMark2);

            paragraph63.Append(paragraphProperties63);
            paragraph63.Append(run114);

            footnote2.Append(paragraph63);

            footnotes1.Append(footnote1);
            footnotes1.Append(footnote2);

            footnotesPart1.Footnotes = footnotes1;
        }

        // Generates content of webSettingsPart1.
        private void GenerateWebSettingsPart1Content(WebSettingsPart webSettingsPart1)
        {
            WebSettings webSettings1 = new WebSettings() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "w14" } };
            webSettings1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            webSettings1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            webSettings1.AddNamespaceDeclaration("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            webSettings1.AddNamespaceDeclaration("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
            OptimizeForBrowser optimizeForBrowser1 = new OptimizeForBrowser();
            AllowPNG allowPNG1 = new AllowPNG();

            webSettings1.Append(optimizeForBrowser1);
            webSettings1.Append(allowPNG1);

            webSettingsPart1.WebSettings = webSettings1;
        }

        private void SetPackageProperties(OpenXmlPackage document)
        {
            document.PackageProperties.Creator = "Elp";
            document.PackageProperties.Revision = "5";
            document.PackageProperties.Created = System.Xml.XmlConvert.ToDateTime("2012-12-09T13:37:00Z", System.Xml.XmlDateTimeSerializationMode.RoundtripKind);
            document.PackageProperties.Modified = System.Xml.XmlConvert.ToDateTime("2012-12-25T12:51:00Z", System.Xml.XmlDateTimeSerializationMode.RoundtripKind);
            document.PackageProperties.LastModifiedBy = "Vadim";
        }


    }
}
