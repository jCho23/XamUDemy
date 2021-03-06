﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamUDemy.Models;

namespace XamUDemy.Lists
{
    public partial class ListViewXamlGrouping : ContentPage
    {
        public ListViewXamlGrouping()
        {
            InitializeComponent();

            listView.ItemsSource = new List<ContactGroup>{

                new ContactGroup("Basketball", "B"){
                   new Contact { Name = "Jordan", ImageURL = "http://lorempixel.com/100/100/people/2",
                    Status= "Hey, let's talk!"},
                },

                new ContactGroup("Music", "M"){
                    new Contact { Name = "Eminem", ImageURL = "http://lorempixel.com/100/100/people/1"},
                },

            };
		}

    }
}
