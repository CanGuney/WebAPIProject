using Microsoft.EntityFrameworkCore;
using WebAPIProject.Server.Data;
using WebAPIProject.Server.Models;

namespace WebAPIProject.Server.Repository
{
    public class ProductRepository
    {
        private readonly AppDbContext _appDbcontext;

        public ProductRepository(AppDbContext appDbcontext)
        {
            _appDbcontext = appDbcontext;
        }

        public async Task<List<Product>> GetPro()
        {
            return await _appDbcontext.Products.ToListAsync();
        }

        public async Task SavePro(Product product)
        {
            await _appDbcontext.Products.AddAsync(product);
            await _appDbcontext.SaveChangesAsync();
        }

        public async Task DeletePro(int id)
        {
            var product = await _appDbcontext.Products.FindAsync(id);
            if (product != null)
            {
                _appDbcontext.Products.Remove(product);
                await _appDbcontext.SaveChangesAsync();
            }
        }

        public async Task UpdatePro(Product product)
        {
            var existingPro = await _appDbcontext.Products.FindAsync(product.Id);
            if (existingPro != null)
            {
                existingPro.Name = product.Name;
                _appDbcontext.Products.Update(existingPro);
                await _appDbcontext.SaveChangesAsync();
            }
        }

        public async Task<Product> GetProById(int id)
        {
            return await _appDbcontext.Products.FindAsync(id);
        }
    }
}