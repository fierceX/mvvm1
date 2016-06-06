﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace Leaf.View
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class InsertData : Page
    {
        public InsertData()
        {
            this.InitializeComponent();
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<int[]>(this, "InsertYes", MessageBox);
            GalaSoft.MvvmLight.Messaging.Messenger.Default.Register<string>(this, "Exception", ExceptionMessageBox);
        }

        private async void MessageBox(int[] msg)
        {
            await new MessageDialog("成功插入\n"+msg[0].ToString()+" 道选择题\n"+msg[1].ToString()+" 道填空题").ShowAsync();
        }

        private async void ExceptionMessageBox(string msg)
        {
            await new MessageDialog("引发异常："+msg).ShowAsync();
        }
    }
}
