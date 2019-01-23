using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Xml;
using System.Diagnostics;
using System.Xml.Linq;
using System.IO;

namespace lab2
{
    public partial class Form1 : Form
    {
        public static Stopwatch watch;
        public long elapsedAllTime;
        private Task<Decimal> taskQuote;
        private Task<ServiceResolve.IPInformation> taskResolve;
        private Task<string> taskTime;
        private Task<string> taskEcho;
        private string taskTemperature;

        public Form1()
        {
            InitializeComponent();
        }

        private void startTimer()
        {
            watch = new Stopwatch();
            watch.Start();
        }


        private void calculateTime(TextBox txtOutput)
        {
            watch.Stop();
            txtOutput.Text = watch.ElapsedMilliseconds.ToString() + "ms";
            elapsedAllTime = elapsedAllTime + watch.ElapsedMilliseconds;
        }




        private void btnQuotes_Click(object sender, EventArgs e)
        {
            startTimer();
            // cos nie dziala....
            var serviceClient = new ServiceReferenceQuotes.DelayedStockQuoteSoapClient("DelayedStockQuoteSoap");
            txtQuotesOutput.Text = serviceClient.GetQuickQuote(txtQuotesInput.Text,
           "0").ToString("N2");

            calculateTime(btnQuotesTime);
        }


        private void resolve_Click(object sender, EventArgs e)
        {
            startTimer();

            var serviceClient = new ServiceResolve.P2GeoSoapClient("IP2GeoSoap");
            var ipData = serviceClient.ResolveIP(txtResolveInput.Text, "0");
            txtResolveOutput.Text = ipData.Country;

            calculateTime(resolveTime);
        }
        // https://www.bbc.com/news  151.101.0.81 - United States
        // wp.pl 212.77.98.9 poland
        // http://angryjoeshow.com/ajsa/ 67.225.176.169 United States
        // https://www.mi.com/global/ 58.83.160.156 China
        // https://www.referat.ru/ 91.212.151.161 Russian Federation



        private void time_Click(object sender, EventArgs e)
        {
            startTimer();

            var serviceClient = new ServiceTime.ServiceSoapClient("ServiceSoap");
            txtTimeOutput.Text = serviceClient.GetTime().ToString();

            calculateTime(timeTime);
        }

        private void echo_Click(object sender, EventArgs e)
        {
            startTimer();

            var serviceClient = new ServiceEcho.ServiceSoapClient("ServiceSoap1");
            var asciiData = serviceClient.Echo(txtEchoInput.Text);
            txtEchoOutput.Text = asciiData.ToString();

            calculateTime(echoTime);
        }

        private void weather_Click(object sender, EventArgs e)
        {
            startTimer();

            using (WebClient client = new WebClient())
            {


                string xmlContent = client.DownloadString("http://api.openweathermap.org/data/2.5/weather?q=" + txtWeatherInput.Text + "&mode=xml&appid=714329f613c83cfa729591a7ceac291d");

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xmlContent);

                var xdoc = XDocument.Load(new StringReader(xmlContent));

                

                //var entry = from x in xdoc.Descendants("current")
                //          select new
                //            {
                //                Location = (string)x.Element("city"),
                //                Time = (string)x.Element("Time"),
                //                Wind = (string)x.Element("Wind"),
                //                Visibility = (string)x.Element("Visibility"),
                //                SkyConditions = (string)x.Element("SkyConditions"),
                //                //Temperature = (string)x.Element("Temperature"),
                //                DewPoint = (string)x.Element("DewPoint"),
                //                //RelativeHumidity = (string)x.Element("RelativeHumidity"),
                //                Pressure = (string)x.Element("Pressure")
                //            };


                XmlNode temp_node = xmlDocument.SelectSingleNode("//temperature");
                XmlAttribute temp_value = temp_node.Attributes["value"];

                double temperature = double.Parse(temp_value.Value, System.Globalization.CultureInfo.InvariantCulture);
                temperature = temperature - 273.15; // kelvin to celcius conversion

                //txtWaetherOutputLocation.Text = entry.First().Location;
                //txtWaetherOutputTime.Text = entry.First().Time;
                //txtWaetherOutputWind.Text = entry.First().Wind;
                //txtWaetherOutputVisibility.Text = entry.First().Visibility;
                //txtWaetherOutputSkyConditions.Text = entry.First().SkyConditions;
                txtWeatherOutputTemperature.Text = temperature.ToString("N2");

                if (temperature < 0)
                    txtWeatherOutputTemperature.BackColor = Color.Red;
                else if (temperature >= 0 && temperature <= 5)
                    txtWeatherOutputTemperature.BackColor = Color.Blue;
                else
                    txtWeatherOutputTemperature.BackColor = Color.Green;

                //txtWaetherOutputDewPoint.Text = entry.First().DewPoint;
                //txtWaetherOutputPressure.Text = entry.First().Pressure;


                


            }

            calculateTime(weatherTime);
        }


        private void btnAllFunctions_Click(object sender, EventArgs e)
        {
            elapsedAllTime = 0;


            if (txtQuotesInput.Text == "")
            {
                MessageBox.Show("Nie wypełnione pole ze wskazaniem akcji (btnQuotes)", "Brak danych", MessageBoxButtons.OK);
                return;
            }
            else
            {
                btnQuotes_Click(sender, e);
            }

            if (txtResolveInput.Text == "")
            {
                MessageBox.Show("Nie wypełnione pole ze wskazaniem akcji (resolve)", "Brak danych", MessageBoxButtons.OK);
                return;
            }
            else
            {
                resolve_Click(sender, e);
            }

            time_Click(sender, e);

            if (txtEchoInput.Text == "")
            {
                MessageBox.Show("Nie wypełnione pole ze wskazaniem akcji (echo)", "Brak danych", MessageBoxButtons.OK);
                return;
            }
            else
            {
                echo_Click(sender, e);
            }

            if (txtWeatherInput.Text == "")
            {
                MessageBox.Show("Nie wypełnione pole ze wskazaniem akcji (weather)", "Brak danych", MessageBoxButtons.OK);
                return;
            }
            else
            {
                weather_Click(sender, e);
            }

            txtElapsedAllWatch.Text = elapsedAllTime.ToString() + "ms";


        }







        private async void StartTasksAsync()
        {
            var clientQuote = new ServiceReferenceQuotes.DelayedStockQuoteSoapClient("DelayedStockQuoteSoap");
            taskQuote = clientQuote.GetQuickQuoteAsync(txtQuotesInput.Text,"0");

            var clientResolve = new ServiceResolve.P2GeoSoapClient("IP2GeoSoap");
            taskResolve = clientResolve.ResolveIPAsync(txtResolveInput.Text, "0");


            var clientTime = new ServiceTime.ServiceSoapClient("ServiceSoap");
            taskTime = clientTime.GetTimeAsync();

            var clientEcho = new ServiceEcho.ServiceSoapClient("ServiceSoap1");
            taskEcho = clientEcho.EchoAsync(txtEchoInput.Text);


            using (WebClient client = new WebClient())
            {

                Uri uri1 = new Uri("http://api.openweathermap.org/data/2.5/weather?q=" + txtWeatherInput.Text + "&mode=xml&appid=714329f613c83cfa729591a7ceac291d");

                taskTemperature = await client.DownloadStringTaskAsync(uri1);

                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(taskTemperature);

                XmlNode temp_node = xmlDocument.SelectSingleNode("//temperature");
                XmlAttribute temp_value = temp_node.Attributes["value"];

                double temperature = double.Parse(temp_value.Value, System.Globalization.CultureInfo.InvariantCulture);
                temperature = temperature - 273.15; // kelvin to celcius conversion

                txtWeatherOutputTemperature.Text = temperature.ToString("N2");

                if (temperature < 0)
                    txtWeatherOutputTemperature.BackColor = Color.Red;
                else if (temperature >= 0 && temperature <= 5)
                    txtWeatherOutputTemperature.BackColor = Color.Blue;
                else
                    txtWeatherOutputTemperature.BackColor = Color.Green;

            }
        }


        private void FinishTasks()
        {
            txtQuotesOutput.Text = taskQuote.Result.ToString();
            txtResolveOutput.Text = taskResolve.Result.Country.ToString();
            txtTimeOutput.Text = taskTime.Result.ToString();
            txtEchoOutput.Text= taskEcho.Result.ToString();
            txtWeatherOutputTemperature.Text = taskTemperature;

        }



        private void async_Click(object sender, EventArgs e)
        {

            var watch = new Stopwatch();
            watch.Start();
            StartTasksAsync();
            FinishTasks();
            watch.Stop();
            txtAsyncWatch.Text = watch.ElapsedMilliseconds.ToString() + "ms";
        }
    }
}
