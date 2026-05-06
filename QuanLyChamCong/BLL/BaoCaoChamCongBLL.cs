using System;
using System.Data;
using QuanLyChamCong.DAL;

namespace QuanLyChamCong.BLL
{
    public class BaoCaoChamCongBLL
    {
        private BaoCaoChamCongDAL dal = new BaoCaoChamCongDAL();

        public DataTable BaoCaoTongHop(
            string nhanVienId,
            DateTime tuNgay,
            DateTime denNgay
        )
        {
            return dal.BaoCaoTongHop(
                nhanVienId,
                tuNgay,
                denNgay
            );
        }
    }
}