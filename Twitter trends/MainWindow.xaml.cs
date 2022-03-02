using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Twitter_trends
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            mapControl.MapProvider = GMapProviders.GoogleMap;
            mapControl.MinZoom = 2;  //Минимальный зум
            mapControl.MaxZoom = 17; //Максимальный зум
            mapControl.Zoom = 5;     //Текущий зум
            mapControl.ShowCenter = false; //Не показывать центральный крест
            mapControl.DragButton = MouseButton.Left; //Щелкните левой кнопкой мыши, чтобы перетащить карту
            mapControl.Position = new PointLatLng(53.9, 27.5666);

            mapControl.MouseLeftButtonDown += new MouseButtonEventHandler(mapControl_MouseLeftButtonDown);
        }

        void mapControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point clickPoint = e.GetPosition(mapControl);
            PointLatLng point = mapControl.FromLocalToLatLng((int)clickPoint.X, (int)clickPoint.Y);
            GMapMarker marker = new GMapMarker(point);
            mapControl.Markers.Add(marker);
        }
    }
}
