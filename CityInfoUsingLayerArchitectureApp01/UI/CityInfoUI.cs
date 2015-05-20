using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CityInfoUsingLayerArchitectureApp01.BLL;

namespace CityInfoUsingLayerArchitectureApp01.UI
{
    public partial class CityInfoUI : Form
    {
        public CityInfoUI()
        {
            InitializeComponent();
        }
        Manager manager = new Manager();
        private void saveButton_Click(object sender, EventArgs e)
        {
            City aCity = new City();
            aCity.CityName = cityNameTextBox.Text;
            aCity.About = aboutTextBox.Text;
            aCity.Country = countryTextBox.Text;
            MessageBox.Show(manager.Save(aCity));
            LoadCitiesListView();

        }
        public void LoadCitiesListView()
        {
            int i = 0;
            cityListView.Items.Clear();
            foreach (City city in manager.ShowAllCities())
            {
                i++;
                ListViewItem item = new ListViewItem(i.ToString());
                item.SubItems.Add(city.CityName);
                item.SubItems.Add(city.About);
                item.SubItems.Add(city.Country);

                cityListView.Items.Add(item);
            }
        }

        private void CityInfoUI_Load(object sender, EventArgs e)
        {
            LoadCitiesListView();
        }
    }
}
