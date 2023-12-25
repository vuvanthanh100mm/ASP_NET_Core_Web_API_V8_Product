namespace ASP_NET_Core_Web_API_V8_Product.Data
{
    public class DonHangChiTiet
    {
        public Guid MaHH { get; set; }
        public Guid MaDH { get; set; }
        public int SoLuong { get; set; }
        public int DonGia { get; set; }
        public int GiamGia { get; set; }

        public DonHang DonHang { get; set; }
        public HangHoa HangHoa { get; set; }

    }
}
