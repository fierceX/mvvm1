﻿using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leaf.Model;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight.Command;

namespace Leaf.ViewModel
{
    class MainModel:ViewModelBase
    {
        private string _hamburgTitle = "汉堡菜单";

        public string HamburgTitle
        {
            get { return _hamburgTitle; }
            set { Set(ref _hamburgTitle, value); }
        }

        private Boolean _isPaneOpen = false;

        public Boolean IsPaneOpen
        {
            get { return _isPaneOpen; }
            set { Set(ref _isPaneOpen, value); }
        }

        private void HamburgButton()
        {
            IsPaneOpen = !IsPaneOpen;
        }
        public ICommand HamburgCommand { get; set; }


        private ObservableCollection<NavLink> _menuItems = new ObservableCollection<NavLink>()
            {
                new NavLink() { Icon = Symbol.People, Text="People"},
                new NavLink() { Icon = Symbol.Phone,Text="Phone" },
                new NavLink() { Icon = Symbol.Message, Text="Message"},
                new NavLink() { Icon = Symbol.Mail,Text="Mail"},
                new NavLink() { Icon = Symbol.GoToStart,Text="Logout"}
            };

        public ObservableCollection<NavLink> MenuItems
        {
            get { return _menuItems; }
            set { Set(ref _menuItems, value); }
        }




        private string _username;
        public string Username
        {
            get { return _username; }
            set { Set(ref _username, value); }
        }
        private User _user;
        public User User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                Username = value.Username;
            }
        }
        public ICommand LogoffCommand { get; set; }
        private void Logoff()
        {
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Send<object>("确认注销吗");
        }
        public MainModel()
        {
            LogoffCommand = new RelayCommand(Logoff);
            HamburgCommand = new RelayCommand(HamburgButton);
        }
    }

    internal class NavLink : ViewModelBase
    {
        private String _text;
        public String Text
        {
            get { return _text; }
            set { Set(ref _text, value); }
        }
        private Symbol _Icon;
        public Symbol Icon
        {
            get { return _Icon; }
            set { Set(ref _Icon, value); }
        }
    }
}
