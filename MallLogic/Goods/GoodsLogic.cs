using MallDataBase.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MallLogic
{
    public class GoodsLogic
    {
        public MallEntities MallDataContext;
        public GoodsLogic()
        {
            MallDataContext = new MallEntities();
        }
        /// <summary>
        /// 获取所有目录
        /// </summary>
        /// <returns></returns>
        public  List<Directory> GetCategory()
        {
            List<Directory> list = MallDataContext.Directory.ToList();
            return list;
        }
        /// <summary>
        /// 根据级别获取目录
        /// </summary>
        /// <returns></returns>
        public List<Directory> GetCategoryByRank(int rank)
        {
            List<Directory> list = MallDataContext.Directory.Where(m=>m.Rank==rank).ToList();
            return list;
        }
        /// <summary>
        /// 获取所有商品
        /// </summary>
        /// <returns></returns>
        public List<Goods> GetGoodsList()
        {
            List<Goods> list = MallDataContext.Goods.ToList();
            return list;
        }
        /// <summary>
        /// 根据根目录获取所有商品
        /// </summary>
        /// <returns></returns>
        public List<Goods> GetGoodsList(Guid guid)
        {
            List<Goods> list = (from m in MallDataContext.Directory
                                join n in MallDataContext.Goods on m.ID equals n.DirectoryGuid
                                where m.ParentDirectoryGuid == guid
                                select n).ToList();
            return list;
        }
        /// <summary>
        /// 根据商品ID获取商品详情
        /// </summary>
        /// <param name="goodGuid"></param>
        /// <returns></returns>
        public Goods GetGoodDetaile(Guid goodGuid)
        {
           return MallDataContext.Goods.FirstOrDefault(m=>m.ID==goodGuid);
        }

    }
}
