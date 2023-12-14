
using System.ComponentModel.DataAnnotations;

namespace MyWebApiAppV8_HienLTH.Models
{
    public class LoaiModel 
    {
        [Required]
        [MaxLength(50)]
        public string TenLoai { get; set; }
    }
}
