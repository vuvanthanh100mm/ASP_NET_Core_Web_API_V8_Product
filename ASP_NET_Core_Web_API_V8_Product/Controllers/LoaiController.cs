using ASP_NET_Core_Web_API_V8_Product.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebApiAppV8_HienLTH.Models;

namespace ASP_NET_Core_Web_API_V8_Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private readonly MyDbContext _context;
        public LoaiController(MyDbContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() {
            try
            {
                var dsLoai = _context.loais.ToList();
                return Ok(dsLoai);
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var loai = _context.loais.SingleOrDefault(lo => lo.MaLoai == id);
            if (loai != null)
            {
                return Ok(loai);
            } else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLoaiById(int id)
        {
            var loai = _context.loais.SingleOrDefault(lo => lo.MaLoai == id);
            if (loai != null)
            {
                _context.Remove(loai);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateNew(LoaiModel model)
        {
            try
            {
                var loai = new Loai { 
                    TenLoai = model.TenLoai
                };
                _context.Add(loai);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, loai);
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLoaiById(int id, LoaiModel model)
        {
            var loai = _context.loais.SingleOrDefault(lo => lo.MaLoai == id);
            if (loai != null)
            {
                loai.TenLoai = model.TenLoai;
                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
