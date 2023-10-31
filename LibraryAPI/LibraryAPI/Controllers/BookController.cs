using LibraryAPI.Models;
using LibraryAPI.Models.DTOModels;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers;

[ApiController]
[Route("[controller]/Api/")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    /// <summary>
    /// Get all books
    /// </summary>
    [HttpGet("Books")]
    public ActionResult<IQueryable<Book>> GetBooks() => Ok(_bookService.GetBooks());

    /// <summary>
    /// Get a book by ID
    /// </summary>
    [HttpGet("Book/Id/{id:guid}")]
    public ActionResult<Book> GetBookById(Guid id)
    {
        var book = _bookService.GetBookById(id);
        
        if (book == null)
            return BadRequest(book);

        return Ok(book);
    } 
    
    /// <summary>
    /// Get a book by ISBN
    /// </summary>
    [HttpGet("Book/Isbn/{isbn}")]
    public ActionResult<Book> GetBookByIsbn(string isbn)
    {
        var book = _bookService.GetBookByIsbn(isbn);
        
        if (book == null)
            return BadRequest(book);

        return Ok(book);
    } 
    
    /// <summary>
    /// Add a book
    /// </summary>
    [Authorize]
    [HttpPost("Book/Add")]
    public ActionResult<Book> AddBook(Book item)
    {
        var book = _bookService.AddBook(item);
        
        if (book == null)
            return BadRequest(book);

        return Ok(book);
    } 
    
    /// <summary>
    /// Edit a book
    /// </summary>
    [Authorize]
    [HttpPost("Book/Edit/{id:guid}")]
    public ActionResult<Book> EditBook(Guid id, Book item)
    {
        var book = _bookService.EditBook(id, item);
        
        if (book == null)
            return BadRequest(book);

        return Ok(book);
    } 
    
    /// <summary>
    /// Delete a book
    /// </summary>
    [Authorize]
    [HttpPost("Book/Delete/{id:guid}")]
    public ActionResult<string> DeleteBook(Guid id)
    {
        var book = _bookService.DeleteBook(id);
        
        if (book == "Book doesn't exist")
            return BadRequest(book);

        return Ok(book);
    } 
}