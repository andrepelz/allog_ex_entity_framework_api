using Univali.Api.Entities;
using Univali.Api.Models;

namespace Univali.Api.Repositories;

public interface IPublisherRepository {
    // COURSE GET
    Task<Course?> GetCourseByIdAsync(int publisherId, int courseId); 
    Task<Course?> GetCourseWithAuthorsByIdAsync(int publisherId, int courseId); 
    // COURSE POST
    void AddCourse(Publisher publisher, Course course);
    // COURSE PUT
    void UpdateCourse(Course course, CourseForUpdateDto courseForUpdateDto);
    // COURSE DELETE
    void RemoveCourse(Course course);


    // AUTHOR GET
    Task<Author?> GetAuthorByIdAsync (int authorId);
    Task<Author?> GetAuthorWithCoursesByIdAsync (int authorId);
    // AUTHOR POST
    void AddAuthor (Author author);
    // AUTHOR PUT
    void UpdateAuthor(Author author, AuthorForUpdateDto authorForUpdateDto);
    // AUTHOR DELETE
    void RemoveAuthor (Author author);


    // PUBLISHER GET
    Task<Publisher?> GetPublisherByIdAsync (int publisherId);
    Task<Publisher?> GetPublisherWithCoursesByIdAsync (int publisherId);
    // PUBLISHER POST
    void AddPublisher (Publisher publisher);
    // PUBLISHER PUT
    public void UpdatePublisher(Publisher publisher, PublisherForUpdateDto publisherForUpdateDto);
    // PUBLISHER DELETE
    void RemovePublisher (Publisher publisher);
    

    // COURSE UTILS
    Task<bool> AuthorsExistAsync(List<int> authors);
    Task<List <Author>> GetAuthorsAsync(List<int> authors);


    // CONTEXT COMMIT
    Task<bool> SaveChangesAsync();
}