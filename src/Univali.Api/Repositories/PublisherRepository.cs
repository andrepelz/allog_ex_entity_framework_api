using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Univali.Api.DbContexts;
using Univali.Api.Entities;
using Univali.Api.Models;

namespace Univali.Api.Repositories;

public class PublisherRepository : IPublisherRepository {
    private readonly PublisherContext _context;
    private readonly IMapper _mapper;

    public PublisherRepository(PublisherContext context, IMapper mapper) {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    

    public async Task<Course?> GetCourseByIdAsync(int publisherId, int courseId) {
        var publisherFromDatabase = await GetPublisherWithCoursesByIdAsync(publisherId);
        var courseFromDatabase = publisherFromDatabase
            ?.Courses
            .FirstOrDefault(c => c.CourseId == courseId);

        return courseFromDatabase;
    }

    public async Task<Course?> GetCourseWithAuthorsByIdAsync(int publisherId, int courseId) {
        var publisherFromDatabase = await GetPublisherWithCoursesByIdAsync(publisherId);

        return publisherFromDatabase != null
            ? await _context.Courses
                .Include(c => c.Authors)
                .FirstOrDefaultAsync(c => c.CourseId == courseId)
            : null;
    }

    public void AddCourse(Publisher publisher, Course course) {
        publisher.Courses.Add(course);
    }

    public void UpdateCourse(Course course, CourseForUpdateDto courseForUpdateDto) {
        _mapper.Map(courseForUpdateDto, course);
    }

    public void RemoveCourse(Course course) {
        _context.Courses.Remove(course);
    }



    public async Task<Author?> GetAuthorByIdAsync(int authorId) {
        return await _context.Authors
            .FirstOrDefaultAsync(a => a.AuthorId == authorId);
    }

    public async Task<Author?> GetAuthorWithCoursesByIdAsync(int authorId) {
        return await _context.Authors
            .Include(a => a.Courses)
            .FirstOrDefaultAsync(a => a.AuthorId == authorId);
    }

    public void AddAuthor (Author author) {
        _context.Authors.Add(author);
    }

    public void UpdateAuthor(Author author, AuthorForUpdateDto authorForUpdateDto) {
        _mapper.Map(authorForUpdateDto, author);
    }

    public void RemoveAuthor(Author author) {
        _context.Authors.Remove(author);
    }



    public async Task<Publisher?> GetPublisherByIdAsync(int publisherId) {
        return await _context.Publishers
            .FirstOrDefaultAsync(p => p.PublisherId == publisherId);
    }

    public async Task<Publisher?> GetPublisherWithCoursesByIdAsync(int publisherId) {
        return await _context.Publishers
            .Include(p => p.Courses)
            .FirstOrDefaultAsync(p => p.PublisherId == publisherId);
    }

    public void AddPublisher(Publisher publisher) {
        _context.Publishers.Add(publisher);
    }

    public void UpdatePublisher(Publisher publisher, PublisherForUpdateDto publisherForUpdateDto) {
        _mapper.Map(publisherForUpdateDto, publisher);
    }

    public void RemovePublisher(Publisher publisher) {
        _context.Publishers.Remove(publisher);
    }



    public async Task<bool> AuthorsExistAsync(List<int> authors) {
        foreach(var authorId in authors) {
            if(!await _context.Authors.AnyAsync(a => a.AuthorId == authorId))
                return false;
        }

        return true;
    }

    public async Task<List <Author>> GetAuthorsAsync(List<int> authors) {
        var authorsFromDatabase = await _context.Authors
            .Where(a => authors.Contains(a.AuthorId))
            .ToListAsync();

        return authorsFromDatabase;
    }



    public async Task<bool> SaveChangesAsync() {
        return await _context.SaveChangesAsync() > 0;
    }
}
