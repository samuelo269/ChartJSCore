using System.Collections.Generic;
using ChartJSCore.Helpers;
using ChartJSCore.Models;
using NUnit.Framework;

namespace ChartJSCoreTest
{
    [TestFixture]
    public class BarChartTests
    {
        private const string KNOWN_GOOD_CHART = "var barChartElement = document.getElementById(\"barChart\");\r\nvar barChart = new Chart(barChartElement, {\"type\":\"bar\",\"data\":{\"datasets\":[{\"type\":\"bar\",\"minBarLength\":2.0,\"barPercentage\":0.5,\"barThickness\":6.0,\"maxBarThickness\":8.0,\"backgroundColor\":[\"rgba(255, 99, 132, 0.2)\",\"rgba(54, 162, 235, 0.2)\",\"rgba(255, 206, 86, 0.2)\",\"rgba(75, 192, 192, 0.2)\",\"rgba(153, 102, 255, 0.2)\",\"rgba(255, 159, 64, 0.2)\"],\"borderColor\":[\"rgba(255, 99, 132, 1)\",\"rgba(54, 162, 235, 1)\",\"rgba(255, 206, 86, 1)\",\"rgba(75, 192, 192, 1)\",\"rgba(153, 102, 255, 1)\",\"rgba(255, 159, 64, 1)\"],\"borderWidth\":1,\"data\":[12.0,19.0,3.0,null,2.0,3.0],\"label\":\"# of Votes\"}],\"labels\":[\"Red\",\"Blue\",\"Yellow\",\"Green\",\"Purple\",\"Orange\"]},\"options\":{\"layout\":{\"padding\":{\"left\":10,\"right\":12}},\"scales\":{\"x\":{\"grid\":{\"offset\":true}},\"y\":{\"beginAtZero\":true}}}}\r\n);";

        [Test]
        public void Generate_BarChart_Generates_Valid_Chart()
        {
            string expected = KNOWN_GOOD_CHART;

            string actual = GenerateBarChart().CreateChartCode("barChart");

            string serialized = GenerateBarChart().SerializeBody();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Generate_BarChart_With_JsonSerializerSettings_Generates_Valid_Chart()
        {
            string expected = KNOWN_GOOD_CHART;

            string actual = GenerateBarChart().SerializeBody();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Check_ToolTip_Creating()
        {
            Assert.DoesNotThrow(() => GenerateToolTip());
        }
        private static Chart GenerateBarChart()
        {
            var chart = new Chart { Type = Enums.ChartType.Bar };

            var data = new Data
            {
                Labels = new List<string>
                {
                    "Red",
                    "Blue",
                    "Yellow",
                    "Green",
                    "Purple",
                    "Orange"
                }
            };

            var dataset = new BarDataset
            {
                Label = "# of Votes",
                Data = new List<double?> { 12, 19, 3, null, 2, 3 },
                BackgroundColor = new List<ChartColor>
                {
                    ChartColor.FromRgba(255, 99, 132, 0.2),
                    ChartColor.FromRgba(54, 162, 235, 0.2),
                    ChartColor.FromRgba(255, 206, 86, 0.2),
                    ChartColor.FromRgba(75, 192, 192, 0.2),
                    ChartColor.FromRgba(153, 102, 255, 0.2),
                    ChartColor.FromRgba(255, 159, 64, 0.2)
                },
                BorderColor = new List<ChartColor>
                {
                    ChartColor.FromRgb(255, 99, 132),
                    ChartColor.FromRgb(54, 162, 235),
                    ChartColor.FromRgb(255, 206, 86),
                    ChartColor.FromRgb(75, 192, 192),
                    ChartColor.FromRgb(153, 102, 255),
                    ChartColor.FromRgb(255, 159, 64)
                },
                BorderWidth = new List<int> { 1 },
                BarPercentage = 0.5,
                BarThickness = 6,
                MaxBarThickness = 8,
                MinBarLength = 2
            };

            data.Datasets = new List<Dataset> { dataset };

            chart.Data = data;

            var options = new Options
            {
                Scales = new Dictionary<string, Scale>()
            };

            var scales = new Dictionary<string, Scale>
            {
                {
                    "x", new Scale
                    {
                        Grid = new Grid()
                        {
                            Offset = true
                        },
                        Position = "bottom"
                    }
                },
                {
                    "y", new CartesianLinearScale
                    {
                        BeginAtZero = true
                    }
                }
            };

            options.Scales = scales;

            chart.Options = options;

            chart.Options.Layout = new Layout
            {
                Padding = new Padding
                {
                    PaddingObject = new PaddingObject
                    {
                        Left = 10,
                        Right = 12
                    }
                }
            };

            return chart;
        }

        private static ToolTip GenerateToolTip(){
            
            ToolTip tt = new ToolTip
            {
                Enabled = false,
                External = "function(context) { return 'Tooltip'; }",
                Mode = "nearest",
                Intersect = true,
                Position = "average",
                ItemSort = "function(a, b, data) { return b.datasetIndex - a.datasetIndex; }",
                Filter = "function(item, data) { return item.datasetIndex > 0; }",
                BackgroundColor = ChartColor.FromRgb(255, 255, 255),
                TitleColor = ChartColor.FromRgb(255, 255, 255),
                TitleFont = new Font
                {
                    Size = 14,
                    Style = "normal",
                    Family = "Helvetica Neue",
                    Weight = "bold"
                },
                TitleAlign = "left",
                BodyColor = ChartColor.FromRgb(255, 255, 255),
                BodyFont = new Font
                {
                    Size = 14,
                    Style = "normal",
                    Family = "Helvetica Neue",
                    Weight = "bold"
                },
                BodyAlign = "left",
                FooterColor = ChartColor.FromRgb(255, 255, 255),
                BodySpacing = 2,
                FooterSpacing = 2,
                FooterAlign = "left",
                FooterMarginTop = 6,
                TitleSpacing = 2,
                TitleMarginBottom = 6,
                Padding = new Padding
                {
                    PaddingInt = 2,
                    PaddingObject = new PaddingObject
                    {
                        Left = 2,
                        Right = 2,
                        Top = 2,
                        Bottom = 2,
                        X = 2,
                        Y = 2
                    }
                },
                CaretPadding = 2,
                CaretSize = 2,
                CornerRadius = 2,
                MultiKeyBackground = ChartColor.FromRgb(255, 255, 255),
                DisplayColors = true,
                BoxHeight = 2,
                BoxWidth = 2,
                UsePointStyle = true,
                BorderColor = ChartColor.FromRgb(255, 255, 255),
                BorderWidth = 2,
                Rtl = true,
                TextDirection = "ltr",
                XAlign = "left",
                YAlign = "left",
                Callbacks = new Callback 
                {
                    BeforeTitle = "function(tooltipItems, data) { return 'beforeTitle'; }",
                    Title = "function(tooltipItems, data) { return 'title'; }",
                    AfterTitle = "function(tooltipItems, data) { return 'afterTitle'; }",
                    BeforeBody = "function(tooltipItems, data) { return 'beforeBody'; }",
                    BeforeLabel = "function(tooltipItem, data) { return 'beforeLabel'; }",
                    Label = "function(tooltipItem, data) { return 'label'; }",
                    LabelColor = "function(tooltipItem, chart) { return 'labelColor'; }",
                    LabelTextColor = "function(tooltipItem, chart) { return 'labelTextColor'; }",
                    LabelPointStyle = "function(tooltipItem, chart) { return 'labelPointStyle'; }",
                    AfterLabel = "function(tooltipItem, data) { return 'afterLabel'; }",
                    AfterBody = "function(tooltipItem, data) { return 'afterBody'; }",
                    BeforeFooter = "function(tooltipItems, data) { return 'beforeFooter'; }",
                    Footer = "function(tooltipItems, data) { return 'footer'; }",
                    AfterFooter = "function(tooltipItems, data) { return 'afterFooter'; }"
                }
            };
            
            return tt;
        }
    }
}