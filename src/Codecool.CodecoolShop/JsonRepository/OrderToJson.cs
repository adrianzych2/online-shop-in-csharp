using System;
using System.IO;
using System.Net.Mime;
using Codecool.CodecoolShop.Models;
using Newtonsoft.Json;

namespace Codecool.CodecoolShop.JsonRepository
{
    public class OrderToJson
    {
        private string path = Directory.GetCurrentDirectory();

        public void Save(Order order)
        {
            DateTime now = DateTime.Now;
            var jsonData = JsonConvert.SerializeObject(order);
            File.WriteAllText($"{path}/JsonFiles/Orders/{now.ToString("yy-MM-dd")}_{now.ToString("HH-mm-ss") + "_id_" + order.Id}.json",
                jsonData);
        }
    }
}
