using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Twitter_trends
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Tweet tweet = TweetParser.Parse("[42.38884279, -83.33090463]	_	2014-02-16 03:14:30	@TheMattEspinosa: First poop in Cali oh yeah http://t.co/4G6xvUtSY5");
            tweet.Out();
            InitializeComponent();
        }
    }
}
