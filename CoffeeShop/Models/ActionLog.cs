using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeShop.Models
{
    public class ActionLog
    {
        private int actionLogId;
        private string controller;
        private string action;
        private string IP;
        private DateTime dateTime;

        public int ActionLogId { get => actionLogId; set => actionLogId = value; }
        public string Controller { get => controller; set => controller = value; }
        public string Action { get => action; set => action = value; }
        public string IP1 { get => IP; set => IP = value; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
    }
}