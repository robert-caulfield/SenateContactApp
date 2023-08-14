using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SenateContactApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Private Variables

        // Collections
        private List<Senator> senatorListFull = new List<Senator>();
        private ObservableCollection<Senator> senatorList = new ObservableCollection<Senator>();
        private ObservableCollection<String> stateList = new ObservableCollection<String>();

        // Bindings
        private string nameSearchText = string.Empty;
        private string stateFilter = string.Empty;

        #endregion

        #region Properties

        // Filtered list of senators that are displayed in the list box
        public ObservableCollection<Senator> SenatorListFiltered { get { return senatorList; } private set { senatorList = value; OnPropertyChanged(); } }

        
        // List of states, used in state filter combobox
        public ObservableCollection<String> StateList
        {
            get { return stateList; }
            private set { stateList = value; OnPropertyChanged(); }
        }

        // String value of name search textbox 
        public string NameSearchText
        {
            get { return nameSearchText; }
            set
            {
                if (nameSearchText != value)
                {
                    nameSearchText = value;
                    OnPropertyChanged();
                    UpdateFilteredItems();
                }
            }
        }
        
        // String value of state filter combobox
        public string StateFilter
        {
            get { return stateFilter; }
            set
            {
                if (stateFilter != value)
                {
                    stateFilter = value;
                    OnPropertyChanged();
                    UpdateFilteredItems();
                }
            }
        }

        public ICommand ClearFilterCommand { get; }

        #endregion





        public MainViewModel()
        {
            // Initialize data for the view model
            Task.Run(InitializeAsync);

            // Link clear filter button command
            ClearFilterCommand = new RelayCommand(ClearFilter);

        }

        #region Private Methods

        /// <summary>
        /// Initializes the ViewModel asynchronously by retrieving senator data,
        /// populating filtered senator list and state filter combobox.
        /// </summary>
        private async Task InitializeAsync()
        {
            // Retrieve senator data and store it in list
            senatorListFull = await SenatorDataProvider.RetrieveSenatorData();
            // Update the filtered list
            SenatorListFiltered = new ObservableCollection<Senator>(senatorListFull);
            // Retrieve all unique state strings for state filter combobox
            StateList = new ObservableCollection<String>(SenatorListFiltered.Select(senator => senator.State).Distinct().OrderBy(state => state).ToList());
        }

        /// <summary>
        /// Clears all filter values
        /// </summary>
        private void ClearFilter()
        {
            // Clear the name and state filter
            NameSearchText = String.Empty;
            StateFilter = String.Empty;
        }

        /// <summary>
        /// Updates the list of filtered senators
        /// </summary>
        private void UpdateFilteredItems()
        {
            var filteredSenators = senatorListFull.Where(senator =>
              (string.IsNullOrWhiteSpace(nameSearchText) || senator.NameFull.Contains(nameSearchText, StringComparison.OrdinalIgnoreCase)) &&
            (string.IsNullOrWhiteSpace(stateFilter) || senator.State.Equals(stateFilter, StringComparison.OrdinalIgnoreCase))
        );
            // Update list of filtered senators
            SenatorListFiltered = new ObservableCollection<Senator>(filteredSenators);
        }

        #endregion



        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
