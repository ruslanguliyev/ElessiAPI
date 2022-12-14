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
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public IResult AddBlog(Blog blog)
        {
            try
            {
                _blogDal.Add(blog);
                return new SuccessResult(Message.Added);
            }
            catch (Exception)
            {

                return new ErrorResults(Message.NotAdded);
            }
        }

        public IResult DeleteBlog(int Id)
        {
            try
            {
                var blog = _blogDal.Get(x => x.Id == Id);
                _blogDal.Delete(blog);
                return new SuccessResult(Message.Deleted);

            }
            catch (Exception)
            {

                return new ErrorResults(Message.NotDeleted);
            }
        }

        public IDataResult<List<Blog>> GetAllBlog()
        {
            try
            {
                var blogs = _blogDal.GetAll();
                return new SuccessDataResult<List<Blog>>(blogs);
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Blog>>();

            }
        }

        public IDataResult<Blog> GetById(int Id)
        {
            try
            {
                var blog = _blogDal.Get(x => x.Id == Id);
                return new SuccessDataResult<Blog>(blog);
            }
            catch (Exception)
            {

                return new ErrorDataResult<Blog>();
            }
        }

        public IResult UpdateBlog(Blog blog)
        {
            try
            {
                _blogDal.Update(blog);
                return new SuccessDataResult<Blog>(blog);
            }
            catch (Exception)
            {

               return new ErrorDataResult<Blog>();
            }

        }
    }
}
