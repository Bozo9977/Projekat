﻿using OsnovnaSkolaPL.IntermediaryModels;
using OsnovnaSkolaUI.ViewModel;
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
using System.Windows.Shapes;

namespace OsnovnaSkolaUI.Views
{
    /// <summary>
    /// Interaction logic for OblasUcioniceWindow.xaml
    /// </summary>
    public partial class OblasUcioniceWindow : Window
    {
        public OblasUcioniceWindow(int predmetID)
        {
            InitializeComponent();
            DataContext = new OblastUcioniceViewModel(predmetID) { Window = this };
        }
    }
}
