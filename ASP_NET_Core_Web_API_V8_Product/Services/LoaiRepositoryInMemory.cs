using ASP_NET_Core_Web_API_V8_Product.Data;
using ASP_NET_Core_Web_API_V8_Product.Models;

namespace ASP_NET_Core_Web_API_V8_Product.Services
{
    public class LoaiRepositoryInMemory: ILoaiRepository
    {
        private readonly MyDbContext _context;
        public LoaiRepositoryInMemory(MyDbContext context)
        {
            _context = context;
        }

        static List<LoaiVM> loais = new List<LoaiVM>
        {
            new LoaiVM { MaLoai = 1, TenLoai = "Tivi"},
            new LoaiVM { MaLoai = 2, TenLoai = "Tủ Lạnh"},
            new LoaiVM { MaLoai = 3, TenLoai = "Điều Hòa"},
            new LoaiVM { MaLoai = 4, TenLoai = "Máy Giặt"},
        };

        public List<LoaiVM> GetAll()
        {
            return loais.ToList();
        }

        public LoaiVM GetById(int id)
        {
            return loais.SingleOrDefault(loai => loai.MaLoai == id);
        }

        public void Update(LoaiVM loai)
        {
            var _loai = loais.SingleOrDefault(l => l.MaLoai == loai.MaLoai);
            if(_loai != null)
            {
                _loai.TenLoai = loai.TenLoai;
            }
        }

        public LoaiVM Add(LoaiModel loai)
        {
            var _loai = new LoaiVM
            {
                MaLoai = loais.Max(lo => lo.MaLoai) + 1,
                TenLoai = loai.TenLoai
            };

            loais.Add(_loai);
            return _loai;
        }

        public void Delete(int id)
        {
            var _loai = loais.SingleOrDefault(l => l.MaLoai == id);
            if (_loai != null)
            {
                loais.Remove(_loai);
            }
        }

        public LoaiVM Get(int id)
        {
            throw new NotImplementedException();
        }

        object? ILoaiRepository.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
