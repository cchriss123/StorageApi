using Microsoft.AspNetCore.Mvc;

namespace StorageApi.Controllers;


[ApiController]
[Route("api/products")]
public class ProductsController
{
    
    
    
    [HttpGet("ping")]
    public string GetUsers()
    {
        return "pong";
    }
    
}