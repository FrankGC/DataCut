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

namespace DataCut
{
    /// <summary>
    /// Interaction logic for pg_perfil.xaml
    /// </summary>
    public partial class pg_perfil : Page
    {
        Frame Fm;
        public pg_perfil(Frame fm)
        {
            InitializeComponent();
            Fm = fm;
        }
    }
}
