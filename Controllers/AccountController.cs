using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShortenUrl.Core;

namespace ShortenUrl.Controllers;

[Authorize]
public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private readonly IShortenDbContext _context;

    public AccountController(ILogger<AccountController> logger,IShortenDbContext context)
    {
        _logger = logger;
        _context = context;
    }

   
    [Authorize(Roles ="sysadmin,admin, user")]
    public IActionResult Index()
    {
        return View();
    }

    // [Authorize(Roles ="sysadmin,admin")]
    // public IActionResult Setting()
    // {
    //     return View();
    //
    // }
    // public IActionResult Customers()
    // {
    //     return View();
    // }
    // public IActionResult Agents()
    // {
    //     return View();
    // }
    // public IActionResult Expences()
    // {
    //     return View();
    // }
    //
    // public IActionResult Dairy()
    // {
    //     return View();
    // }
    //
    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }
    //
    //
    //
    // [HttpGet("admin/dashboard/counter")]
    // public async Task<ResponseObject<DashboardCounterViewModel>> GetCounter()
    // {
    //
    //     var _dairiesCount = await _context.Dairies.CountAsync(x => x.IsActive == true);
    //     var _customersCount = await _context.Customers.CountAsync(x => x.IsActive == true);
    //     var _totalRevenue = await _context.Dairies.Where(x => x.IsActive == true).SumAsync(f=>f.TotalAmount-f.TotalBalanceAmount);
    //     var _totalExpenses = await _context.Expenses.Where(x => x.IsActive == true).SumAsync(f=>f.Amount);
    //
    //
    //
    //     return new ResponseObject<DashboardCounterViewModel>(new DashboardCounterViewModel
    //     {
    //         Customers = _customersCount,
    //         Dairies = _dairiesCount,
    //         RevenueTotal = Convert.ToInt32(_totalRevenue),
    //         ExpensesTotal = Convert.ToInt32(_totalExpenses)
    //     });
    // }
    //
}