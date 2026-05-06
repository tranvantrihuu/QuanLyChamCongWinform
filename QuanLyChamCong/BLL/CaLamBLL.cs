using QuanLyChamCong.DAL;
using System.Collections.Generic;
using System.Data;

namespace QuanLyChamCong.BLL
{
    public class CaLamBLL
    {
        CaLamDAL dal = new CaLamDAL();

        public DataTable GetAll()
        {
            return dal.GetAll();
        }

        public bool Insert(Dictionary<string, object> p)
        {
            return dal.Insert(p) > 0;
        }

        public bool Update(Dictionary<string, object> p)
        {
            return dal.Update(p) > 0;
        }

        public bool Delete(List<int> ids)
        {
            return dal.Delete(ids) > 0;
        }
    }
}