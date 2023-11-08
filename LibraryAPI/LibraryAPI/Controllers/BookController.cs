using BusinessLogic.DTOModels.BooksDto;
using BusinessLogic.Services;
using BusinessLogic.Services.Interfaces;
using Entities.Models;
using Entities.Repositories.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers;

[ApiController]
[Route("api/")]
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
    [HttpGet("books")]
    public ActionResult<IQueryable<Book>> GetBooks([FromQuery]PaginationParameters paginationParameters) => 
        Ok(_bookService.GetBooks(paginationParameters));

    /// <summary>
    /// Get a book by ID
    /// </summary>
    [HttpGet("book/id/{id:guid}")]
    public async Task<ActionResult<Book>> GetBookById(Guid id)
    {
        var book = await _bookService.GetBookById(id);
        
        if (book == null)
            return BadRequest(book);

        return Ok(book);
    } 
    
    /// <summary>
    /// Get a book by ISBN
    /// </summary>
    [HttpGet("book/isbn/{isbn}")]
    public async Task<ActionResult<Book>> GetBookByIsbn(string isbn)
    {
        var book = await _bookService.GetBookByIsbn(isbn);
        
        if (book == null)
            return BadRequest(book);

        return Ok(book);
    } 
    
    /// <summary>
    /// Add a book
    /// </summary>
    [Authorize]
    [HttpPost("book/add")]
    public async Task<ActionResult<Book>> AddBook(BookAddDto item)
    {
        var book = await _bookService.AddBook(item);
        
        if (book == null)
            return BadRequest(book);

        return Ok(book);
    } 
    
    /// <summary>
    /// Edit a book
    /// </summary>
    [Authorize]
    [HttpPost("book/edit/{id:guid}")]
    public async Task<ActionResult<Book>> EditBook(Guid id, BookEditDto item)
    {
        var book = await _bookService.EditBook(id, item);
        
        if (book == null)
            return BadRequest(book);

        return Ok(book);
    } 
    
    /// <summary>
    /// Delete a book
    /// </summary>
    [Authorize]
    [HttpPost("book/delete/{id:guid}")]
    public async Task<ActionResult<Book>> DeleteBook(Guid id)
    {
        var book = await _bookService.DeleteBook(id);
        
        if (book == null)
            return BadRequest(book);

        return Ok(book);
    } 
}