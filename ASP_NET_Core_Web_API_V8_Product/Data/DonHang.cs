namespace ASP_NET_Core_Web_API_V8_Product.Data
{
    public enum TinhTrangDonHang
    {
        New = 0, Payment = 1, Complete = 2, Cancel = -1
    }
    public class DonHang
    {
        public Guid MaDH { get; set; }
        public DateTime NgatDat { get; set; }
        public DateTime? NgayGiao { get; set; }
        public TinhTrangDonHang TinhTrangDonHang { get; set; }
        public string DiaChiGiao { get; set; }
        public string NguoiNhan { get; set; }
        public string SoDienThoai { get; set; }

        public ICollection<DonHangChiTiet> DonHangChiTiets { get; set; }

        public DonHang()
        {
            DonHangChiTiets = new List<DonHangChiTiet>();
        }
    }
}
