using financeAPI.Data;
using financeAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace financeAPI.Repo
{
    public class SupplierRepo : IRepo<Supplier>
    {
        private readonly DataContext _db;

        public SupplierRepo(DataContext db)
        {
            _db = db;
        }
        public async Task<IResult> Create(Supplier supplier)
        {

            _db.Supplier.Add(supplier);
            await _db.SaveChangesAsync();

            return TypedResults.Created($"/Supplier/{supplier.Guid}", supplier);
        }

        public async Task<IResult> Delete(int id)
        {
            if (await _db.Supplier.FindAsync(id) is Supplier supplier)
            {
                _db.Supplier.Remove(supplier);
                await _db.SaveChangesAsync();

                return TypedResults.Ok(supplier);
            }

            return TypedResults.NotFound();
        }

        public async Task<IResult> Get(int id)
        {
            var supplier = await _db.Supplier.FindAsync(id);
            return (supplier != null ? TypedResults.Ok(supplier) : TypedResults.NotFound());
        }

        public async Task<IResult> GetAll()
        {
            return TypedResults.Ok(await _db.Supplier.ToListAsync());
        }

        public async Task<IResult> Update(int id, Supplier updatedSupplier)
        {
            var supplier = await _db.Supplier.FindAsync(id);

            if (supplier is null)
                return TypedResults.NotFound();
            else
            {
                supplier.Name = updatedSupplier.Name;
                supplier.Document = updatedSupplier.Document;
                supplier.Phone = updatedSupplier.Phone;
                supplier.Address = updatedSupplier.Address;
                supplier.PostalCode = updatedSupplier.PostalCode;
                supplier.City = updatedSupplier.City;
                supplier.County = updatedSupplier.County;
                supplier.State = updatedSupplier.State;
                supplier.Country = updatedSupplier.Country;
            }
            await _db.SaveChangesAsync();
            return TypedResults.NoContent();
        }
    }
}