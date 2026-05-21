using System;
using Domain;

namespace Persistence;

public interface ICommentRepo
{

    public Task<IEnumerable<Comment>> GetComments(Guid id);

    public Task<Comment> CreateComment(Comment c);
}
