﻿using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Leaf.ViewModel
{
    class UserInfoModel : ViewModelBase
    {
        private List<Score> score;
        private string _points;
        public string Points
        {
            get { return _points; }
            set { Set(ref _points, value); }
        }
        private string _username;
        public string Username
        {
            get { return _username; }
            set { Set(ref _username, value); }
        }
        private string _admin;
        public string Admain
        {
            get { return _admin; }
            set { Set(ref _admin, value); }
        }
        private string _buildtime;
        public string BuildTime
        {
            get { return _buildtime; }
            set { Set(ref _buildtime, value); }
        }

        public void Init()
        {
            DrawPoint();
            ReadData();
        }
        public UserInfoModel()
        {
            Init();
        }

        private void ReadData()
        {
            Username = "用户名：" + ViewModelLocator.User.Username;
            if (ViewModelLocator.User.Admin == 1)
                Admain = "管理员账户";
            else
                Admain = "普通账户";
            BuildTime = "注册时间："+ViewModelLocator.User.BuildTime;
        }

        private void DrawPoint()
        {
            string point="";
            if (ViewModelLocator.User.Score == null || ViewModelLocator.User.Score == "")
            {
                Points = "";
                return;
            }
            score = JsonConvert.DeserializeObject<List<Score>>(ViewModelLocator.User.Score);
            var num = score.Count;
            for(int j=1,i= num-8>0?(num-8):0; i < num;i++,j++)
            {
                point = point + (j * 20).ToString() + "," + (100 - score[i].score).ToString() + ",";
            }
            point = point.Substring(0, point.Length - 1);
            Points = point;
        }

        struct Score
        {
            public int Paper { get; set; }
            public double score { get; set; }
            public string time { get; set; }
        }

    }
}