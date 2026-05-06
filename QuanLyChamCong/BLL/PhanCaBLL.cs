using QuanLyChamCong.DAL;
using System;
using System.Data;

namespace QuanLyChamCong.BLL
{
    public class PhanCaBLL
    {
        PhanCaDAL dal = new PhanCaDAL();

        public DataTable GetByWeek(DateTime from, DateTime to)
        {
            return dal.GetByWeek(from, to);
        }

        public bool Insert(string nvId, int caId, DateTime ngay)
        {
            return dal.Insert(nvId, caId, ngay) > 0;
        }

        public bool Exists(string nvId, int caId, DateTime ngay)
        {
            return dal.Exists(nvId, caId, ngay);
        }

        public int Delete(string nvId, int caId, DateTime ngay)
        {
            return dal.Delete(nvId, caId, ngay);
        }
    }
}