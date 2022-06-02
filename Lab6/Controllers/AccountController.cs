using Microsoft.AspNetCore.Mvc;
using Lab6.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Lab6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Lab6.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly DataContext _context;

        public AccountController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            if (_context.Account == null)
            {
                return Problem("DataContext.Account is null");
            }
            return View(await _context.Account.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Account account = await _context.Account.FirstOrDefaultAsync(account => account.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Account account = await _context.Account.FirstOrDefaultAsync(account => account.Id == id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Account account)
        {
            if (id != account.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Account account = await _context.Account.FirstOrDefaultAsync(account => account.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Account account = await _context.Account.FindAsync(id);
            _context.Account.Remove(account);
            await _context.SaveChangesAsync();
            if (account.Email == User.Claims.Select(x => x.Subject.Name).First())
            {
                await LogOut();
            }
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private bool AccountExists(int id)
        {
            return _context.Account.Any(account => account.Id == id);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn([Bind("Login,Password")] LogInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var account = await _context.Account.FirstOrDefaultAsync(a => a.Login == model.Login &&
                                                                         a.Password == model.Password);
                if (account != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, account.Email)
                    };
                    ClaimsIdentity identity = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Incorrect login/password.");
            }
            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)

        {
            if (ModelState.IsValid)
            {
                Account account = await _context.Account.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (account != null)
                {
                    ModelState.AddModelError("", "This login is taken.");
                    return View(model);
                }

                account = new Account
                {
                    Login = model.Login,
                    Email = model.Email,
                    Password = model.Password,
                    Age = model.Age,
                    Gender = model.Gender,
                    Level = model.Level.ToString(),
                    About = model.About,
                    Avatar = model.Avatar
                };
                _context.Account.Add(account);
                _context.SaveChanges();
                return RedirectToAction("LogIn");
            }
            return View(model);
        }
    }
}
