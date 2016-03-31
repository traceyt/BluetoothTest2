using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;
using WinRTXamlToolkit.Tools;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace BluetoothTest2
{
    public sealed partial class AccelerometerGraph : UserControl
    {
        private bool isInitialized;

        private Random _random = new Random();

        private EventThrottler _updateThrottler = new EventThrottler();

        private List<NameValueItem> _xItems = new List<NameValueItem>();
        private List<NameValueItem> _yItems = new List<NameValueItem>();
        private List<NameValueItem> _zItems = new List<NameValueItem>();



        //public String MyLabel
        //{
        //    get { return (String)GetValue(MyLabelProperty); }
        //    set { SetValue(MyLabelProperty, value); }
        //}

        //public static readonly DependencyProperty MyLabelProperty =
        //     DependencyProperty.Register("MyLabel", typeof(string),
        //        typeof(AccelerometerGraph), new PropertyMetadata(""));

        public MovementMeasurementValue movementMeasurementValue
        {
            set
            {
                UpdateCharts(value);
                //UpdateCharts_Test();
            }
        }

        public static readonly DependencyProperty movementMeasurementValueProperty =
             DependencyProperty.Register("", typeof(MovementMeasurementValue),
                typeof(AccelerometerGraph), new PropertyMetadata(""));


        public AccelerometerGraph()
        {
            this.InitializeComponent();
            this.isInitialized = true;
        }

        private void UpdateCharts(MovementMeasurementValue m)
        {
            if (!this.isInitialized)
            {
                return;
            }


            _xItems.Add(new NameValueItem { Name = _xItems.Count().ToString(), Value = m.Value.AccelX });
            _yItems.Add(new NameValueItem { Name = _yItems.Count().ToString(), Value = m.Value.AccelY });
            _zItems.Add(new NameValueItem { Name = _zItems.Count().ToString(), Value = m.Value.AccelZ });

            int start;
            int end;

            if (_xItems.Count() > 15)
            {
                start = _xItems.Count() - 15;
                end = _xItems.Count() - 1;
            }
            else
            {
                start = 0;
                end = _xItems.Count();
            }

            List<NameValueItem> itemsX = new List<NameValueItem>(15);
            List<NameValueItem> itemsY = new List<NameValueItem>(15);
            List<NameValueItem> itemsZ = new List<NameValueItem>(15);
            for (int i = start; i < end; i++)
            {
                itemsX.Add(_xItems[i]);
                itemsY.Add(_yItems[i]);
                itemsZ.Add(_zItems[i]);
            }

            double maxAccelX = itemsX.Max(t => t.Value);
            double minAccelX = itemsX.Min(t => t.Value);

            double maxAccelY = itemsX.Max(t => t.Value);
            double minAccelY = itemsX.Min(t => t.Value);

            double maxAccelZ = itemsX.Max(t => t.Value);
            double minAccelZ = itemsX.Min(t => t.Value);

            double max = Math.Max(maxAccelX, maxAccelY);
            max = Math.Max(max, maxAccelZ);
            max = Math.Max(max, .8);

            double min = Math.Min(minAccelX, minAccelY);
            min = Math.Min(min, maxAccelZ);
            min = Math.Min(min, -.2);

            ((LineSeries)LineChartWithAxes.Series[0]).ItemsSource = itemsX;
            ((LineSeries)LineChartWithAxes.Series[1]).ItemsSource = itemsY;
            ((LineSeries)LineChartWithAxes.Series[2]).ItemsSource = itemsZ;

            // setting up X values
            ((LineSeries)LineChartWithAxes.Series[0]).DependentRangeAxis =
                new LinearAxis
                {
                    Minimum = min,
                    Maximum = max,
                    Orientation = AxisOrientation.Y,
                    Interval = Math.Round((max - min) / 30, 2),
                    ShowGridLines = false,
                    Visibility = Visibility.Visible
                };

            // setting up Y values
            ((LineSeries)LineChartWithAxes.Series[1]).DependentRangeAxis =
                new LinearAxis
                {
                    // Visibility = Visibility.Collapsed,
                    Minimum = min,
                    Maximum = max,
                    Orientation = AxisOrientation.Y,
                    Interval = Math.Round((max - min) / 30, 2),
                    ShowGridLines = false,
                    Visibility = Visibility.Visible
                };

            // setting up Z values
            ((LineSeries)LineChartWithAxes.Series[2]).DependentRangeAxis =
            new LinearAxis
            {
                //Visibility = Visibility.Collapsed,
                Minimum = min,
                Maximum = max,
                Orientation = AxisOrientation.Y,
                Interval = Math.Round((max - min) / 30, 2),
                ShowGridLines = false,
                Visibility = Visibility.Visible
            };
        }


        private void UpdateCharts_Test()
        {
            if (!this.isInitialized)
            {
                return;
            }

            // x items
            List<NameValueItem> xItems = new List<NameValueItem>();

            for (int i = 0; i < 20; i++)
            {
                double _value = System.Convert.ToDouble(_random.Next(10, 100)) / 100;
                xItems.Add(new NameValueItem { Name = "P" + i, Value = _value });
            }


            ((LineSeries)LineChartWithAxes.Series[0]).ItemsSource = xItems;
            ((LineSeries)LineChartWithAxes.Series[0]).DependentRangeAxis =
                new LinearAxis
                {
                    Minimum = 0,
                    Maximum = 1,
                    Orientation = AxisOrientation.Y,
                    Interval = .04,
                    ShowGridLines = false
                };


            // y items
            List<NameValueItem> yItems = new List<NameValueItem>();

            for (int i = 0; i < 20; i++)
            {
                double _value = System.Convert.ToDouble(_random.Next(10, 100)) / 100;
                yItems.Add(new NameValueItem { Name = "P" + i, Value = _value });
            }

            ((LineSeries)LineChartWithAxes.Series[1]).ItemsSource = yItems;
            // setting up Y values
            //((LineSeries)LineChartWithAxes.Series[1]).DependentRangeAxis =
            //    new LinearAxis
            //    {
            //        // Visibility = Visibility.Collapsed,
            //        Minimum = 0,
            //        Maximum = 1,
            //        Orientation = AxisOrientation.Y,
            //        Interval = .04,
            //        ShowGridLines = false
            //    };


            // z items
            List<NameValueItem> zItems = new List<NameValueItem>();

            for (int i = 0; i < 20; i++)
            {
                double _value = System.Convert.ToDouble(_random.Next(10, 100)) / 100;
                zItems.Add(new NameValueItem { Name = "P" + i, Value = _value });
            }

            ((LineSeries)LineChartWithAxes.Series[2]).ItemsSource = zItems;
            // setting up Z values
            //((LineSeries)LineChartWithAxes.Series[2]).DependentRangeAxis =
            //    new LinearAxis
            //    {
            //        //Visibility = Visibility.Collapsed,
            //        Minimum = 0,
            //        Maximum = 1,
            //        Orientation = AxisOrientation.Y,
            //        Interval = .04,
            //        ShowGridLines = false
            //    };
        }

        public class NameValueItem
        {
            public string Name { get; set; }
            public double Value { get; set; }
        }

        public class MovementMeasurementValue
        {
            public string Name { get; set; }
            public MovementMeasurement Value { get; set; }
        }

        private void NumberOfIitemsNumericUpDown_ValueChanged(object sender, Windows.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {
            this.ThrottledUpdate();
        }

        private void ChartsList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.ThrottledUpdate();
        }

        private void OnUpdateButtonClick(object sender, RoutedEventArgs e)
        {
            this.ThrottledUpdate();
        }

        private void ThrottledUpdate()
        {
            _updateThrottler.Run(
                async () =>
                {
                    var sw = new Stopwatch();
                    sw.Start();
                    this.UpdateCharts_Test();
                    sw.Stop();
                    await Task.Delay(sw.Elapsed);
                });
        }
    }

    public class MovementMeasurement
    {
        /// <summary>
        /// Get/Set X accelerometer in units of 1 g (9.81 m/s^2).
        /// </summary>
        public double AccelX { get; set; }

        /// <summary>
        /// Get/Set Y accelerometer in units of 1 g (9.81 m/s^2).
        /// </summary>
        public double AccelY { get; set; }

        /// <summary>
        /// Get/Set Z accelerometer in units of 1 g (9.81 m/s^2).
        /// </summary>
        public double AccelZ { get; set; }

        /// <summary>
        /// Get/Set X twist in degrees per second.
        /// </summary>
        public double GyroX { get; set; }

        /// <summary>
        /// Get/Set Y twist in degrees per second.
        /// </summary>
        public double GyroY { get; set; }

        /// <summary>
        /// Get/Set Z twist in degrees per second.
        /// </summary>
        public double GyroZ { get; set; }

        /// <summary>
        /// Get/Set X direction in units of 1 micro tesla.
        /// </summary>
        public double MagX { get; set; }

        /// <summary>
        /// Get/Set Y direction in units of 1 micro tesla.
        /// </summary>
        public double MagY { get; set; }

        /// <summary>
        /// Get/Set Z direction in units of 1 micro tesla.
        /// </summary>
        public double MagZ { get; set; }

        public MovementMeasurement()
        {
        }

    }
}
