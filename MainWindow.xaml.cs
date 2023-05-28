using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System;
using System.Collections.Generic;
using System.Windows;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using LiveChartsCore.Defaults;
using System.Collections.ObjectModel;

namespace ConsumptionHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            SqlContoller.Connect();

            InitializeComponent();
        }
    }

    public class ViewModel
    {
        private static readonly SKColor s_blue = new(25, 118, 210);
        private static readonly SKColor s_red = new(229, 57, 53);
        private static readonly SKColor s_yellow = new(246, 232, 21);

        public ISeries[] Series { get; set; } =
        {
            new LineSeries<DateTimePoint>
            {
                Name = "Electricity",
                TooltipLabelFormatter = (chartPoint) =>
                $"Electricity on {new DateTime((long) chartPoint.SecondaryValue):dd MMMM yyyy}: {chartPoint.PrimaryValue}",
                Values = DataController.MakeView(DataController.GetValues(), CommunalValue.Type.Electricity),
                Fill = null,
                ScalesYAt = 0,
                GeometryStroke = new SolidColorPaint(s_yellow, 2),
                Stroke = new SolidColorPaint(s_yellow, 2),
                LineSmoothness = 0

            },
            new LineSeries<DateTimePoint>
            {
                Name = "Gas",
                TooltipLabelFormatter = (chartPoint) =>
                $"Gas on {new DateTime((long) chartPoint.SecondaryValue):dd MMMM yyyy}: {chartPoint.PrimaryValue}",
                Values = DataController.MakeView(DataController.GetValues(), CommunalValue.Type.Gas),
                Fill = null,
                ScalesYAt = 0,
                GeometryStroke = new SolidColorPaint(s_red, 2),
                Stroke = new SolidColorPaint(s_red, 2),
                LineSmoothness = 0

            },
            new LineSeries<DateTimePoint>
            {
                Name = "Water",
                TooltipLabelFormatter = (chartPoint) =>
                $"Water on {new DateTime((long) chartPoint.SecondaryValue):dd MMMM yyyy}: {chartPoint.PrimaryValue}",
                Values = DataController.MakeView(DataController.GetValues(), CommunalValue.Type.Water),
                Fill = null,
                ScalesYAt = 0,
                GeometryStroke = new SolidColorPaint(s_blue, 2),
                Stroke = new SolidColorPaint(s_blue, 2),
                LineSmoothness = 0

            }
        };

        public Axis[] XAxes { get; set; } =
        {
            new Axis
            {
                Labeler = value => new DateTime((long) value).ToString("dd MMMM yyyy"),
                LabelsRotation = 15,

                // when using a date time type, let the library know your unit 
                UnitWidth = TimeSpan.FromDays(1).Ticks, 

                // if the difference between our points is in hours then we would:
                // UnitWidth = TimeSpan.FromHours(1).Ticks,

                // since all the months and years have a different number of days
                // we can use the average, it would not cause any visible error in the user interface
                // Months: TimeSpan.FromDays(30.4375).Ticks
                // Years: TimeSpan.FromDays(365.25).Ticks

                // The MinStep property forces the separator to be greater than 1 day.
                MinStep = TimeSpan.FromDays(1).Ticks
            }
        };
    }
}