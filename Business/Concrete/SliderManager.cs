using Business.Abstract;
using Business.Constans;
using Core.Helpers.Results;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete.ErrorResult;
using Core.Helpers.Results.Concrete.SuccessResult;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderDal;

        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public IResult AddSlider(Slider slider)
        {
            try
            {
                _sliderDal.Add(slider);
                return new SuccessResult(Message.Added);
            }
            catch (Exception)
            {

                return new ErrorResults(Message.NotAdded);
            }
        }

        public IDataResult<List<Slider>> GetAllSlider()
        {
            try
            {
                var sliders = _sliderDal.GetAll();
                return new SuccessDataResult<List<Slider>>(sliders);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Slider>>();
            }
        }

        public IDataResult<Slider> GetByid(int Id)
        {
            try
            {
                var slider = _sliderDal.Get(x => x.Id == Id);
                return new SuccessDataResult<Slider>(slider);
            }
            catch (Exception)
            {

                return new ErrorDataResult<Slider>();
            }
        }

        public IResult RemoveSlider(int Id)
        {
            try
            {
                var slider = _sliderDal.Get(x => x.Id == Id);
                _sliderDal.Delete(slider);
                return new SuccessResult(Message.Deleted);
            }
            catch (Exception)
            {

                return new ErrorResults(Message.Deleted);
            }
        }

        public IResult UpdateSlider(Slider slider)
        {
            try
            {
                _sliderDal.Update(slider);
                return new SuccessDataResult<Slider>(slider);
            }
            catch (Exception)
            {

                return new ErrorDataResult<Slider>();
            }
        }
    }
}
