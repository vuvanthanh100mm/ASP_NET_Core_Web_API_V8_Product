using ASP_NET_Core_Web_API_V8_Product.Data;
using ASP_NET_Core_Web_API_V8_Product.Models;

namespace ASP_NET_Core_Web_API_V8_Product.Services
{
    public class LoaiRepository : ILoaiRepository
    {
        private readonly MyDbContext _context;
        public LoaiRepository(MyDbContext context)
        {
            _context = context;
        }
        public LoaiVM Add(LoaiModel loai)
        {
            var _loai = new Loai
            {
                TenLoai = loai.TenLoai,


            };
            _context.Add(_loai);
            _context.SaveChanges();
            return new LoaiVM
            {
                MaLoai = _loai.MaLoai,
                TenLoai = _loai.TenLoai
            };
        }

        public void Delete(int id)
        {
            var loai = _context.loais.SingleOrDefault(l => l.MaLoai == id);
            if (loai != null)
            {
                _context.Remove(loai);
                _context.SaveChanges();
            }
        }

        public LoaiVM GetById(int id)
        {
            var loai = _context.loais.SingleOrDefault(l => l.MaLoai == id);
            if(loai != null)
            {
                return new LoaiVM
                {
                    MaLoai = loai.MaLoai,
                    TenLoai = loai.TenLoai
                };
            }
            return null;
        }

        public List<LoaiVM> GetAll()
        {
            var loais = _context.loais.Select(loai => new LoaiVM
            {
                MaLoai = loai.MaLoai,
                TenLoai = loai.TenLoai
            });
            return loais.ToList();
        }

        public void Update(LoaiVM loai)
        {
            var _loai = _context.loais.SingleOrDefault(l => l.MaLoai == loai.MaLoai);
            _loai.TenLoai = loai.TenLoai;
            _context.SaveChanges();
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
