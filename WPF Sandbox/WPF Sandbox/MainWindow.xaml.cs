using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WPF_Sandbox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public List<Flight> flights;
        public int chosenFlightId = 0;
        public Flight emptyFlight = new Flight(0, "0", "0", "0");
        private Flight _chosenFlight;
        public Flight ChosenFlight
        {
            get
            {
                return _chosenFlight;
            }
            set
            {
                _chosenFlight = value;
                OnPropertyChanged("ChosenFlight");
            }
        }

        public MainWindow()
        {
            ChosenFlight = emptyFlight;
            flights = new List<Flight>();
            flights.Add(new Flight(1, "israel", "USA", "flight1"));
            flights.Add(new Flight(2, "portugal", "UK", "flight2"));
            flights.Add(new Flight(3, "china", "india", "flight3"));
            InitializeComponent();
            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(TxtBox1.Text, out chosenFlightId);
            chosenFlightId--;
            if (chosenFlightId >= 0 && chosenFlightId < 3)
            {
                //chosenFlight.ID = flights[chosenFlightId].ID;
                //chosenFlight.From = flights[chosenFlightId].From;
                //chosenFlight.To = flights[chosenFlightId].To;
                //chosenFlight.Name = flights[chosenFlightId].Name;
                ChosenFlight = flights[chosenFlightId];
            }

            else
            {
                ChosenFlight = emptyFlight;
            }

        }
    }

    public class Flight : INotifyPropertyChanged
    {
        //private int _id;
        //public int ID
        //{
        //    get
        //    {
        //        return _id;
        //    }
        //    set
        //    {
        //        _id = value;
        //        OnPropertyChanged("ID");
        //    }
        //}
        //private string _from;
        //public string From
        //{
        //    get
        //    {
        //        return _from;
        //    }
        //    set
        //    {
        //        _from = value;
        //        OnPropertyChanged("From");
        //    }
        //}
        //private string _to;
        //public string To
        //{
        //    get
        //    {
        //        return _to;
        //    }
        //    set
        //    {
        //        _to = value;
        //        OnPropertyChanged("To");
        //    }
        //}

        //private string _name;
        //public string Name
        //{
        //    get
        //    {
        //        return this._name;
        //    }
        //    set
        //    {
        //        this._name = value;
        //        OnPropertyChanged("Name");
        //    }
        //}

        public int ID { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Name { get; set; }

        public Flight(int iD, string from, string to, string name)
        {
            ID = iD;
            From = from;
            To = to;
            Name = name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public override string ToString()
        {
            return $"id: {ID}, from: {From}, to: {To}, name: {Name}";
        }
    }
}
