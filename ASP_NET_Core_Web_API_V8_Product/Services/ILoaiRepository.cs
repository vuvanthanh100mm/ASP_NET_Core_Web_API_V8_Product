using ASP_NET_Core_Web_API_V8_Product.Models;

namespace ASP_NET_Core_Web_API_V8_Product.Services
{
    public interface ILoaiRepository
    {
        List<LoaiVM> GetAll();
        LoaiVM Get(int id);
        LoaiVM Add(LoaiModel loai);
        void Update(LoaiVM loai);
        void Delete(int id);
        object? GetById(int id);
    }
}
