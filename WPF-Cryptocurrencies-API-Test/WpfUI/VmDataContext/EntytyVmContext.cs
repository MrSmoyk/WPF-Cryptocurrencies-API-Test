using Domain.DTOs;
using Microsoft.VisualBasic;
using Services.Implementations;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfUI.VmDataContext
{
    public class EntytyVmContext : INotifyPropertyChanged
    {
        public ObservableCollection<data> Entyties { get; set; }

        private IAssertsInfoService Service { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public EntytyVmContext()
        {
            Service = new AssertsInfoService();
            Entyties = new ObservableCollection<data>();


        }
    }
}
