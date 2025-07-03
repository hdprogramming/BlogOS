using Microsoft.AspNetCore.Mvc;
using BlogOS.Web.Models; // Project modelinizin namespace'ini ekleyin (örn: using YourProjectName.Models;)
using BlogOS.Web.Data; // DbContext'inizin namespace'ini ekleyin (örn: using YourProjectName.Data;)
using Microsoft.EntityFrameworkCore; // ToListAsync ve diğer EF Core metodları için

namespace BlogOS.Web.Controllers // Kendi projenizin namespace'ini kullanın (örn: YourProjectName.Controllers)
{
    public class ProjectsController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return View();
            }
            else
            {
                // Detay görünümü
                var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
                if (project == null)
                    return NotFound();
                return View("Details", project);
            }
        }
        public async Task<IActionResult> GetProjectsPartial()
{
    var projects = await _context.Projects.ToListAsync();
    return PartialView("_ProjectsTable", projects);
}
        public IActionResult Manage()
        {        
            return View("Manage");
        }
        private readonly ApplicationDbContext _context; // Veritabanı bağlamımız

        // Constructor Injection: DbContext örneğini buraya enjekte ediyoruz
        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Frontend'den gelen Ajax isteğini karşılayacak Action metodu
        [HttpGet]
        public async Task<IActionResult> GetSortedProjects(string sortBy = "default")
        {
            IQueryable<Project> query = _context.Projects;

            switch (sortBy)
            {
                case "date-desc":
                    query = query.OrderByDescending(p => p.CompletionDate);
                    break;
                case "date-asc":
                    query = query.OrderBy(p => p.CompletionDate);
                    break;
                case "name-asc":
                    query = query.OrderBy(p => p.Name);
                    break;
                case "name-desc":
                    query = query.OrderByDescending(p => p.Name);
                    break;
                default:
                    query = query.OrderBy(p => p.Id);
                    break;
            }

            var sortedProjects = await query.ToListAsync();
            // Normal View yerine Partial View döndürüyoruz
            return PartialView("_ProjectListPartial", sortedProjects);
        }
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
                return NotFound();

            return Json(new
            {
                id = project.Id,
                name = project.Name,
                category=project.Category,
                technologies=project.Technologies,
                description = project.Description,
                details = project.Details,
                completionDate = project.CompletionDate.ToString("yyyy-MM-dd")
            });
        }
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Save(Project project)
{
           
   if (!ModelState.IsValid)
{
    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
    var errorList = string.Join(", ", errors);
    Console.WriteLine("Model validation errors: " + errorList);
    return BadRequest(errorList);
}


    if (project.Id == 0)
    {
        _context.Projects.Add(project);
    }
    else
    {
        _context.Projects.Update(project);
    }

    await _context.SaveChangesAsync();

    return Ok();
}
        [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Delete(int id)
{
    var project = await _context.Projects.FindAsync(id);

    if (project == null)
        return NotFound();

    _context.Projects.Remove(project);
    await _context.SaveChangesAsync();

    return Ok();
}
    }
}