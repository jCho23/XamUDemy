﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamUDemy.Models;

namespace XamUDemy.Navigations
{
    public partial class MasterDetailXaml : ContentPage
    {
        public MasterDetailXaml(Contact contact)
        {
            //Defensive Programming
            if (contact == null)
                throw new ArgumentNullException();

            BindingContext = contact;

            InitializeComponent();
        }
    }
}
