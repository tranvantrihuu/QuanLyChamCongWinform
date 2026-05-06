using QuanLyChamCong.DAL;
using System.Collections.Generic;
using System.Data;

namespace QuanLyChamCong.BLL
{
    public class NghiPhepNamBLL
    {
        NghiPhepNamDAL dal = new NghiPhepNamDAL();

        public DataTable GetAll()
        {
            return dal.GetAll();
        }

        public void Insert(Dictionary<string, object> param)
        {
            dal.Insert(param);
        }

        public void Update(Dictionary<string, object> param)
        {
            dal.Update(param);
        }

        public void Delete(List<int> ids)
        {
            dal.Delete(ids);
        }

        public DataTable GetNhanVien()
        {
            return dal.GetNhanVien();
        }
    }
}