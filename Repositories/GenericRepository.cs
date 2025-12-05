using QuestionPlatform2.Models;

public class GenericRepository<T> where T : class
{
    protected readonly AppDbContext _context;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<T> GetList() => _context.Set<T>().ToList();

    public T GetById(int id) => _context.Set<T>().Find(id);

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var ent = _context.Set<T>().Find(id);
        if (ent != null)
        {
            _context.Set<T>().Remove(ent);
            _context.SaveChanges();
        }
    }
}