﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamUDemy.Models;
using XamUDemy.Services;

namespace XamUDemy.Pages
{
    public partial class AirBnbListViewPage : ContentPage
    {

        private SearchService _searchService;
        private List<SearchGroup> _searchGroups;

        public AirBnbListViewPage()
        {
            _searchService = new SearchService();

            InitializeComponent();

            PopulateListView(_searchService.GetRecentSearches());
        }

        private void OnSearchTextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            PopulateListView(_searchService.GetRecentSearches(e.NewTextValue));
        }

        private void PopulateListView (IEnumerable<Search> searches)
        {
            _searchGroups = new List<SearchGroup>
            {
                new SearchGroup("Recent Searches", searches)
            };

            listView.ItemsSource = _searchGroups;
        }

        private void OnDeleteClicked(object sender, System.EventArgs e)
        {
            var search = (sender as MenuItem).CommandParameter as Search;

            //Locally remove the search from search groups.
            //Since SearchGroup is an OberservableCollection, this will make the search item 
            //disapper from the ListView
            _searchGroups[0].Remove(search);

            //This updates the backend of the changes
            _searchService.DeleteSearch(search.Id);
        }


		private void OnRefreshing(object sender, System.EventArgs e)
		{
            PopulateListView(_searchService.GetRecentSearches(searchBar.Text));

            listView.EndRefresh();
		}
		
        private void OnSearchSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var search = e.SelectedItem as Search;
            DisplayAlert("Selected", search.Location, "OK");
        }

    }
}
