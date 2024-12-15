public class InsureeController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();

    // GET: Insuree/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: Insuree/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "FirstName,LastName,Email,CarYear,CarMake,CarModel,SpeedingTickets,HasDUI,CoverageType,DateOfBirth")] Insuree insuree)
    {
        if (ModelState.IsValid)
        {
            insuree.Quote = CalculateQuote(insuree);
            db.Insurees.Add(insuree);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        return View(insuree);
    }
}
