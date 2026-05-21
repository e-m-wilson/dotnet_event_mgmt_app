using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class CommentRepo : ICommentRepo
{

    private AppDbContext _context;

    public CommentRepo(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Comment>> GetComments(Guid id)
    {
        return await _context.Comments.Where(c => c.ActivityId == id).ToListAsync();
    }

    public async Task<Comment> CreateComment(Comment c)
    {
        _context.Comments.Add(c);
        await _context.SaveChangesAsync();
        return c;
    }
}
