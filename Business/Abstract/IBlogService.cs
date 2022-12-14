using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBlogService
    {
        IResult AddBlog(Blog blog);
        IResult UpdateBlog(Blog blog);
        IResult DeleteBlog(int Id);
        IDataResult<Blog> GetById(int Id);
        IDataResult<List<Blog>> GetAllBlog();
    }
}
