using QuanLyChamCong.DAL;
using System.Data;

namespace QuanLyChamCong.BLL
{
    public class DoiPinBLL
    {
        DoiPinDAL dal =
            new DoiPinDAL();

        public DataTable GetNhanVien()
        {
            return dal.GetNhanVien();
        }

        public bool DoiPin(
            string id,
            string pinMoi
        )
        {
            return dal.DoiPin(
                id,
                pinMoi
            );
        }
    }
}