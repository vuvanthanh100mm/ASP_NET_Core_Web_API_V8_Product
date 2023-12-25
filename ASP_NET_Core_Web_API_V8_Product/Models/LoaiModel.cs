
using System.ComponentModel.DataAnnotations;

namespace ASP_NET_Core_Web_API_V8_Product.Models
{
    public class LoaiModel 
    {
        [Required]
        [MaxLength(50)]
        public string TenLoai { get; set; }
    }
}
