using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        [HttpGet("sliderList")]
        public IActionResult GetAllSlider()
        {
            var sliders = _sliderService.GetAllSlider();
            if (sliders != null)
                return Ok(new { status = 200, message = sliders });
            return BadRequest();
        }

        [HttpPost("addSlider")]
        public IActionResult AddSlider(Slider slider)
        {
            var addSlider = _sliderService.AddSlider(slider);
            if (addSlider.Success)
                return Ok(new { status = 200, message = slider });
            return BadRequest(new { status = 400, message = slider });    
        }

        [HttpGet("getById")]
        public IActionResult GetById(int Id)
        {
            var getSlider = _sliderService.GetByid(Id);
            if (getSlider.Success)
                return Ok(new { status = 200, message = getSlider });
            return BadRequest(new { status =400, message = getSlider });    
        }

        [HttpDelete("deleteSlider")]
        public IActionResult DeleteSlider(int Id)
        {
            var deleteSlider = _sliderService.RemoveSlider(Id);
            if (deleteSlider.Success)
                return Ok(new { status = 200, message = deleteSlider.Message });
            return BadRequest(new { status = 400, message = deleteSlider.Message });
        }

        [HttpPost("updateSlider")]
        public IActionResult UpdateSlider(Slider slider)
        {
            var updateSlider = _sliderService.UpdateSlider(slider); 
            if(updateSlider.Success)
                return Ok(new { status = 200, message = updateSlider.Message });
            return BadRequest(new { status = 400, message = updateSlider.Message });
        }
    }
}
