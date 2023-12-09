using Karma.DtoLayer.Dtos.CommentDto;
using Karma.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.BusinessLayer.Abstract
{
    public interface ICommentService:IGenericService<Comment,ResultCommentDto,CreateCommentDto,UpdateCommentDto>
    {
    }
}
