using System;
using AutoMapper;
using Domain;
using Persistence;
namespace Application;

public class CommentService : ICommentService
{

    private ICommentRepo _repo;
    private IMapper _mapper;

    public CommentService(ICommentRepo repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReadCommentDto>> GetComments(Guid id)
    {
        var comments = await _repo.GetComments(id);
        var mappedComments = comments.Select(c => _mapper.Map<ReadCommentDto>(c)).ToList();
        return mappedComments;
    }


    public async Task<ReadCommentDto> CreateComment(CreateCommentDto c)
    {
        var mappedComment = _mapper.Map<Comment>(c);
        var comment = await _repo.CreateComment(mappedComment);
        var readComment = _mapper.Map<ReadCommentDto>(comment);
        return readComment;
    }
}
