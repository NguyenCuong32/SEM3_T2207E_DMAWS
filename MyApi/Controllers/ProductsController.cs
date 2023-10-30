using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApi.Data;
using MyApi.Models;
using MyApi.Repositories;

namespace MyApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : Controller
{
    private readonly IBookRepository _bookRepository;

    public ProductsController(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBook()
    {
        try
        {
            var books = await _bookRepository.GetAllBookAsync();
            return Ok(books);
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById(int id)
    {
        var book = await _bookRepository.GetBookAsync(id);
        return book == null ? NotFound() : Ok();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddNewBook(BookModel model)
    {
        try
        {
            var newBookId = await _bookRepository.AddBookAsync(model); 
            var book = await _bookRepository.GetBookAsync(newBookId);
            return book == null ? NotFound() : Ok(book);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> UpdateBook(int id, BookModel model)
    {
        await _bookRepository.UpdateBookAsync(id, model);
        var book = await _bookRepository.GetBookAsync(id);
        return book == null ? NotFound() : Ok(book);
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteBook(int id)
    {
        try
        {
            await _bookRepository.DeleteBookAsync(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
       
    }

}