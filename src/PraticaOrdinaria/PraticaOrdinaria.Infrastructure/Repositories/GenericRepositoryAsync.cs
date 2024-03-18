using Microsoft.EntityFrameworkCore;
using PraticaOrdinaria.Application.Interfaces;

namespace PraticaOrdinaria.Infrastructure.Persistence.Repositories
{
    /// <summary>
    /// Il Repository Pattern è uno schema progettuale basato su dominio ideato per mantenere problemi di
    /// persistenza al di fuori del modello di dominio del sistema. Una o più astrazioni di persistenza, 
    /// ovvero interfacce, sono definite nel modello di dominio e tali astrazioni presentano implementazioni 
    /// sotto forma di adapter specifici per la persistenza definiti altrove nell'applicazione.
    /// È possibile sfruttare i generics C# per ridurre il numero totale di classi concrete da gestire.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_dbContext"></param>
    public class GenericRepositoryAsync<T>(DbContext _dbContext) : IGenericRepositoryAsync<T> where T : class
    {
        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbContext
                .Set<T>()
                .FindAsync(id);
        }

        public virtual async Task<IReadOnlyList<T>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _dbContext
                .Set<T>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext
                 .Set<T>()
                 .ToListAsync();
        }
    }
}
