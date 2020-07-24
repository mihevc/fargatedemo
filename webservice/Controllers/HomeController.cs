using Microsoft.AspNetCore.Mvc;

public class HomeController: Controller 
{
    [HttpGet]
    public IActionResult Index() {
        return Ok(new {Page = "Home/Index", Success = true});
    }

    [HttpGet]
    public IActionResult Wait() 
    {
        var data = "";

        for (var i = 0; i < 10000; i++)
        {
            
            data += "0";
        }
        

        return Ok(new { Page = "Home/Wait", Success = true});
    }
}