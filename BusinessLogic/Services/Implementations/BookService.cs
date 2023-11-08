﻿using AutoMapper;
using BusinessLogic.DTOModels.BooksDto;
using BusinessLogic.Services.Interfaces;
using Entities.Models;
using Entities.Repositories.Interfaces;
using Entities.Repositories.Pagination;

namespace BusinessLogic.Services.Implementations;

public class BookService : IBookService
{
    private readonly ILibraryRepository<Book> _bookContext;
    private readonly IMapper _mapper;

    public BookService(ILibraryRepository<Book> bookContext, IMapper mapper)
    {
        _bookContext = bookContext;
        _mapper = mapper;
    }

    public IQueryable<Book> GetBooks(PaginationParameters paginationParameters) => 
        _bookContext.GetAllWithPagination(paginationParameters);

    public async Task<Book?> GetBookById(Guid id) => await _bookContext.GetItemById(id);

    public async Task<Book?> GetBookByIsbn(string isbn) => await _bookContext.GetBookByIsbn(isbn);

    public async Task<Book?> AddBook(BookAddDto bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);
        
        return await _bookContext.AddItem(book);
    }

    public async Task<Book?> EditBook(Guid id, BookEditDto bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);
        
        return await _bookContext.EditItem(id, book);
    }

    public async Task<Book?> DeleteBook(Guid id) => await _bookContext.DeleteItem(id);
}