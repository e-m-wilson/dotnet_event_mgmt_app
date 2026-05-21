using System;
using Domain;

namespace Application;

public interface ICommentService
{

    public Task<IEnumerable<ReadCommentDto>> GetComments(Guid id);

    public Task<ReadCommentDto> CreateComment(CreateCommentDto c);
}
