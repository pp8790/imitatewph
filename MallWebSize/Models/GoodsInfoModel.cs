using MallDataBase.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MallWebSize.Models
{
    public class GoodsInfoModel
    {
        public GoodsInfoModel() 
        {
            GoodsList = new List<Goods>();
            DirectoryList = new List<Directory>();
        }
        public List<Goods> GoodsList { get; set; }
        public List<Directory> DirectoryList { get; set; }
    }
}