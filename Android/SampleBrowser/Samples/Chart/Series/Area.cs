#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Com.Syncfusion.Charts;
using Com.Syncfusion.Charts.Enums;

namespace SampleBrowser
{

    public class Area : SamplePage
    {
        public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);
            chart.SetBackgroundColor(Color.White);
            chart.Title.Text = "Average Sales Comparison";
            chart.Title.TextSize = 15;
            chart.SetBackgroundColor(Color.White);
            chart.Legend.DockPosition = ChartDock.Bottom;
            chart.Legend.Visibility = Visibility.Visible;
			chart.Legend.IconHeight = 14;
			chart.Legend.IconWidth = 14;
            chart.Legend.ToggleSeriesVisibility = true;
            chart.ColorModel.ColorPalette = ChartColorPalette.Natural;

            NumericalAxis categoryaxis = new NumericalAxis();
            categoryaxis.Minimum = 1900;
            categoryaxis.Maximum = 2000;
            categoryaxis.Interval = 20;
            categoryaxis.EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift;
            categoryaxis.Title.Text = "Year";
            chart.PrimaryAxis = categoryaxis;

            NumericalAxis numericalaxis = new NumericalAxis();
            numericalaxis.Minimum = 2;
            numericalaxis.Maximum = 5;
            numericalaxis.Interval = 0.5;
            numericalaxis.Title.Text = "Sales Amount in Millions";
            chart.SecondaryAxis = numericalaxis;

            var areaSeries1 = new AreaSeries
            {
                Label = "Product A",
                Alpha = 0.5f,
				EnableAnimation= true,
				ItemsSource = MainPage.GetAreaData1(),
				XBindingPath = "XValue",
				YBindingPath = "YValue"
            };
            var areaSeries2 = new AreaSeries
            {
                Label = "Product B",
                Alpha = 0.5f,
				EnableAnimation = true,
				ItemsSource = MainPage.GetAreaData2(),
				XBindingPath = "XValue",
				YBindingPath = "YValue"
            };
            var areaSeries3 = new AreaSeries
            {
                Label = "Product C",
				EnableAnimation = true,
                Alpha = 0.5f,
				ItemsSource = MainPage.GetAreaData3(),
				XBindingPath = "XValue",
				YBindingPath = "YValue"
            };

            chart.Series.Add(areaSeries1);
            chart.Series.Add(areaSeries2);
            chart.Series.Add(areaSeries3);

            areaSeries1.TooltipEnabled = true;
            areaSeries2.TooltipEnabled = true;
            areaSeries3.TooltipEnabled = true;
            areaSeries1.EnableAnimation = true;
            areaSeries2.EnableAnimation = true;
            areaSeries3.EnableAnimation = true;

            return chart;
        }
    }
}
