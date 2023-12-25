using ASP_NET_Core_Web_API_V8_Product.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApiAppV8_HienLTH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hanghoas = new List<HangHoa>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hanghoas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
         
            try
            {
                // LINQ
                var hanghoa = hanghoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }

                return Ok(hanghoa);
            } 
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(string id, HangHoa hanghoamoi)
        {

            try
            {
                // LINQ
                var hanghoa = hanghoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                if (id != hanghoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                // Update
                hanghoa.TenHangHoa = hanghoamoi.TenHangHoa;
                hanghoa.DonGia = hanghoamoi.DonGia;
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Create(HangHoaVM hangHoaVM)
        {
            var hanghoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(),
                TenHangHoa = hangHoaVM.TenHangHoa,
                DonGia = hangHoaVM.DonGia
            };

            hanghoas.Add(hanghoa);

            // Redirect to a different action or view after successfully adding the item
            return Ok(new
            {
                Success = true,
                Data = hanghoa
            }); 
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(string id)
        {

            try
            {
                // LINQ
                var hanghoa = hanghoas.SingleOrDefault(hh => hh.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                if (id != hanghoa.MaHangHoa.ToString())
                {
                    return BadRequest();
                }
                // Remove
                hanghoas.Remove(hanghoa);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
