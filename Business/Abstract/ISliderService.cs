using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISliderService
    {
        IResult AddSlider(Slider slider);
        IResult RemoveSlider(int Id);
        IResult UpdateSlider(Slider slider);
        IDataResult<Slider> GetByid(int Id);
        IDataResult<List<Slider>> GetAllSlider();

    }
}
