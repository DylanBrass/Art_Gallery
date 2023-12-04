using Art_Gallery_Project.Data;
using Art_Gallery_Project.Models.Cart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Art_Gallery_Project.Controllers;

public class CartController : Controller
{
    private readonly Art_Gallery_ProjectContext _context;

    public CartController(Art_Gallery_ProjectContext context)
    {
        _context = context;
    }


    // GET
    [Authorize]
    public IActionResult Index()
    {
        Cart myCart = HttpContext.Session.GetJson<Cart>("mycart") ?? new Cart();

        HttpContext.Session.SetJson("mycart", myCart);

        return View(myCart);
    }

    [Authorize]
    [HttpPost]
    public IActionResult AddToCart(int id)
    {
        Cart myCart;
        var artwork = _context.ArtWork.FirstOrDefault(a => a.Id == id);
        myCart = HttpContext.Session.GetJson<Cart>("mycart") ?? new Cart();
        if (artwork != null)
        {
            myCart.AddItem(artwork, 1);
        }

        HttpContext.Session.SetJson("mycart", myCart);
        return RedirectToAction("Index", "ArtWork");
    }

    [Authorize]
    [HttpPost]
    public IActionResult RemoveFromCart(int id)
    {
        Cart myCart;
        var artwork = _context.ArtWork.FirstOrDefault(a => a.Id == id);
        myCart = HttpContext.Session.GetJson<Cart>("mycart") ?? new Cart();
        if (artwork != null)
        {
            myCart.RemoveLine(artwork);
        }

        HttpContext.Session.SetJson("mycart", myCart);
        return RedirectToAction("Index", "Cart");
    }
}