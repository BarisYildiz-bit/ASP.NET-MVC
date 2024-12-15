public class AdminController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();

    // GET: Admin
    public ActionResult Index()
    {
        var insurees = db.Insurees.ToList();
        return View(insurees);
    }
}
