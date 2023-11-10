using AutoMapper;
using BusinessLogic.DTOModels.BooksDto;
using BusinessLogic.Exceptions;
using BusinessLogic.Services.Interfaces;
using Entities.Models;
using Entities.Pagination;
using Entities.Repositories.Interfaces;

namespace BusinessLogic.Services.Implementations;

public class BookService : IBookService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BookService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public IQueryable<Book> GetBooks(PaginationParameters paginationParameters) => 
        _unitOfWork.Books.GetAllWithPagination(paginationParameters);

    public async Task<Book?> GetBookById(Guid id)
    {
        var book = await _unitOfWork.Books.GetItemById(id);
        
        if (book == null)
            throw new ValidateException($"User with certain id:{id} didn't find.");
        
        return book;
    }

    public async Task<Book?> GetBookByIsbn(string isbn)
    {
        var book = await _unitOfWork.Books.GetBookByIsbn(isbn);
        
        if (book == null)
            throw new ValidateException($"User with certain ISBN:{isbn} didn't find.");
        
        return book;
    } 

    public async Task<Book?> AddBook(BookAddDto bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);

        book = await _unitOfWork.Books.AddItem(book);
        
        if (book == null)
            throw new ValidateException("Wrong input.");
        
        return book;
    }

    public async Task<Book?> EditBook(Guid id, BookEditDto bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);

        book = await _unitOfWork.Books.EditItem(id, book);
        
        if (book == null)
            throw new ValidateException("Wrong input.");
        
        return book;
    }

    public async Task<Book?> DeleteBook(Guid id)
    {
        var book = await _unitOfWork.Books.DeleteItem(id);
        
        if (book == null)
            throw new ValidateException($"User with certain id:{id} didn't find.");
        
        return book;
    }
}