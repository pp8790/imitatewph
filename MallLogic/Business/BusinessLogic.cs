using MallDataBase.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallLogic
{
    public class BusinessLogic
    {
        public MallEntities MallDataContext;
        public BusinessLogic()
        {
            MallDataContext = new MallEntities();
        }
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="dt"></param>
        public void InsertData(DataTable dt) 
        {
            foreach (DataRow row in dt.Rows)
            {
                Goods good = new Goods();
                good.ID = Guid.NewGuid();
                good.GoodsName = row[1].ToString();
                good.Price = Convert.ToDecimal(row[2].ToString());
                good.Count = Convert.ToInt32(row[3].ToString());
                good.ImagePath = row[4].ToString();
                good.DirectoryGuid = GetDirectoryGuid(row[5].ToString());
                good.CreateTime = DateTime.Now;
                good.UpdateTime = DateTime.Now;
                MallDataContext.Goods.Add(good);
            }
            MallDataContext.SaveChanges();
        }
        /// <summary>
        /// 根据目录名称获取ID
        /// </summary>
        /// <param name="dName"></param>
        /// <returns></returns>
        public Guid GetDirectoryGuid(string dName) 
        {
            Guid dGuid = Guid.Empty;
            var directory = MallDataContext.Directory.FirstOrDefault(m => m.DirectoryName == dName);
            if (directory!=null)
            {
                dGuid = directory.ID;
            }
            return dGuid;
        }
    }
}
