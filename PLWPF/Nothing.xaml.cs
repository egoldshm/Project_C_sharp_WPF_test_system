﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Nothing.xaml
    /// </summary>
    public partial class Nothing : UserControl
    {
        public Nothing()
        {
            InitializeComponent();
            cool.ItemsSourceType = typeof(BE.Trainee);
        }
    }
}
