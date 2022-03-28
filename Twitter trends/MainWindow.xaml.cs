using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
using Twitter_trends.Data;
using Twitter_trends.Models;
using WpfAnimatedGif;
using Brushes = System.Windows.Media.Brushes;
using Path = System.Windows.Shapes.Path;
using Point = Twitter_trends.Models.Point;

namespace Twitter_trends
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		const int MAP_MAX_ZOOM = 20, MAP_MIN_ZOOM = 3, MAP_ZOOM = 3,
				  START_LATITUDE = 50, START_LONGTITUDE = -90, MARKER_WIDTH = 5,
				  MARKER_HEIGHT = 5;
		const double STROKE_POLYGON_THICKNESS = 1.5;

		Country country;
		DataBase dataBase = new DataBase();
		public MainWindow()
		{
			InitializeComponent();
			this.Loaded += MainWindow_Loaded;
		}
		private void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			//загрузка вьюмодел для кнопок меню
			ListView viewModel = new ListView();
			this.DataContext = viewModel;
		}
		private void Loaded_gmap(object sender, RoutedEventArgs e)
		{
			gmap.Bearing = 0;
			gmap.CanDragMap = true;
			gmap.DragButton = MouseButton.Left;


			gmap.MaxZoom = MAP_MAX_ZOOM;
			gmap.MinZoom = MAP_MIN_ZOOM;

			gmap.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;

			gmap.ShowTileGridLines = false;
			gmap.Zoom = MAP_ZOOM;
			gmap.ShowCenter = false;

			gmap.MapProvider = GMapProviders.BingMap;
			GMaps.Instance.Mode = AccessMode.ServerOnly;
			gmap.Position = new PointLatLng(START_LATITUDE, START_LONGTITUDE);


			GMapProvider.WebProxy = WebRequest.GetSystemWebProxy();
			GMapProvider.WebProxy.Credentials = CredentialCache.DefaultCredentials;
		}
		private async void DrawStates()
		{
			gmap.Markers.Clear();
			foreach (var state in DataBase.states)
			{
				foreach (var polygon in state.Polygons)
				{
					List<PointLatLng> pointlatlang = new List<PointLatLng>();
					GMapPolygon pol = new GMapPolygon(pointlatlang);
					foreach (var point in polygon.Points)
					{
						pointlatlang.Add(new PointLatLng(point.X, point.Y));
					}
					pol.Points = pointlatlang;
					gmap.RegenerateShape(pol);
					(pol.Shape as Path).Fill = GetColorByMood(state);
					(pol.Shape as Path).Stroke = Brushes.Blue;
					(pol.Shape as Path).StrokeThickness = STROKE_POLYGON_THICKNESS;
					(pol.Shape as Path).Effect = null;
					gmap.Markers.Add(pol);
				}

			}

			DrawMarkers();

		}

		private SolidColorBrush GetColorByMood(State currentState)
		{
			double? temp = dataBase.getStateHappiness(currentState);
			if (currentState.isMoodDefined)
			{
				if (temp == null) return Brushes.Black;
				else if (temp == 0) return Brushes.White;
				else if (temp > 0)
				{
					if (temp <= 0.05) return Brushes.GreenYellow;
					else if (temp <= 0.075) return Brushes.LimeGreen;
					else return Brushes.ForestGreen;
				}
				else
				{
					if (temp >= -0.05) return Brushes.Yellow;
					else if (temp >= -0.075) return Brushes.Orange;
					else return Brushes.Red;
				}
			}
			return Brushes.Gray;
		}
		private SolidColorBrush GetColorByTweet(Tweet tweet)
		{
			double temp = tweet.happiness;

			if (temp == 0) { return Brushes.White; }
			else if (temp > 0)
			{
				if (temp <= 0.5) { return Brushes.GreenYellow; }
				else if (temp <= 0.75) { return Brushes.LimeGreen; }
				else { return Brushes.ForestGreen; }
			}
			else
			{
				if (temp >= -0.5) { return Brushes.Yellow; }
				else if (temp >= -0.75) { return Brushes.Orange; }
				else { return Brushes.Red; }
			}


		}
		private async void DrawMarkers()
		{
			List<Tweet> tweets = dataBase.tweets;
			foreach (var tweet in tweets)
			{
				GMapMarker marker = new GMapMarker(new PointLatLng(tweet.location.latitude, tweet.location.longtitude));
				marker.Shape = new Ellipse
				{
					Width = MARKER_WIDTH,
					Height = MARKER_HEIGHT,
					Fill = GetColorByTweet(tweet),
					ToolTip = "Tweet : " + tweet + "\n" +
							  "Date : " + tweet.timeOfCreation + "\n" +
							  "Happiness : " + tweet.happiness
				};
				gmap.Markers.Add(marker);
			}
		}

		private async void ComboBox_Selected(object sender, SelectionChangedEventArgs e)

		{
			string path = null;
			ComboBoxItem selectedItem = (ComboBoxItem)ComboBoxChooseCountry.SelectedItem;
			string response = selectedItem.Content.ToString();
			switch (response)
			{

				case "Cali":
					{
						path = @"../../Data/Resources/tweets/cali_tweets2014.txt";
						break;
					}
				case "Family":
					{
						path = @"../../Data/Resources/tweets/family_tweets2014.txt";
						break;
					}
				case "Football":
					{
						path = @"../../Data/Resources/tweets/football_tweets2014.txt";
						break;
					}
				case "School":
					{
						path = @"../../Data/Resources/tweets/high_school_tweets2014.txt";
						break;
					}
				case "Movie":
					{
						path = @"../../Data/Resources/tweets/movie_tweets2014.txt";
						break;
					}
				case "Shopping":
					{
						path = @"../../Data/Resources/tweets/shopping_tweets2014.txt";
						break;
					}
				case "Snow":
					{
						path = @"../../Data/Resources/tweets/snow_tweets2014.txt";
						break;
					}
				case "Texas":
					{
						path = @"../../Data/Resources/tweets/texas_tweets2014.txt";
						break;
					}
				case "Weekend":
					{
						path = @"../../Data/Resources/tweets/weekend_tweets2014.txt";
						break;
					}
			}

			TwitterLogoImage.Visibility = Visibility.Collapsed;
			var controller = ImageBehavior.GetAnimationController(RightLogoImage);
			controller.Play();

			dataBase.Path = path;
			await Task.Run(dataBase.StartDatabase);
			country = dataBase.country;
			DrawStates();

			controller.Pause();
			controller.GotoFrame(0);
			TwitterLogoImage.Visibility = Visibility.Visible;
		}

		private void MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{

			PointLatLng clickpoint = new PointLatLng();
			clickpoint = gmap.FromLocalToLatLng((int)Mouse.GetPosition(this).X, (int)Mouse.GetPosition(this).Y);
			Location location = new Location(clickpoint.Lat, clickpoint.Lng);
			Tweet tweet = new Tweet(location);

			foreach (var state in DataBase.states)
			{
				foreach (var polygon in state.Polygons)
				{
					if (Models.Polygon.IsInside(polygon, tweet.location))
					{
						//TODO
						if (state.Tweets.Count == 0)
						{
							mostNegativeBlock.Text = "NaN";
							mostPositiveBlock.Text = "NaN";
							indexBlock.Text = state.Name.ToString();

						}
						else
						{
							indexBlock.Text = state.Name.ToString();
							mostNegativeBlock.Text = state.Tweets.Min(u => u.happiness).ToString();
							mostPositiveBlock.Text = state.Tweets.Max(u => u.happiness).ToString();
						}

					}
				}

			}

		}
	}
}
