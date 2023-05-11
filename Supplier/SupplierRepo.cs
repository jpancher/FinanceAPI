using financeAPI.Data;
using financeAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace financeAPI.Repo
{
    public class SupplierRepo : IRepoGuid<Supplier>
    {
        private readonly DataContext _db;

        public SupplierRepo(DataContext db)
        {
            _db = db;
        }
        public async Task<IResult> Create(Supplier supplier)
        {
            if (supplier.Guid == Guid.Empty)
            {
                supplier.Guid = Guid.NewGuid();
            }

            _db.Supplier.Add(supplier);
            await _db.SaveChangesAsync();

            return TypedResults.Created($"/Supplier/{supplier.Guid}", supplier);
        }

        public async Task<IResult> Delete(Guid guid)
        {
            if (await _db.Supplier.FindAsync(guid) is Supplier supplier)
            {
                _db.Supplier.Remove(supplier);
                await _db.SaveChangesAsync();

                return TypedResults.Ok(supplier);
            }

            return TypedResults.NotFound();
        }

        public async Task<IResult> Get(Guid guid)
        {
            var supplier = await _db.Supplier.FindAsync(guid);
            return (supplier != null ? TypedResults.Ok(supplier) : TypedResults.NotFound());
        }

        public async Task<IResult> GetAll()
        {
            return TypedResults.Ok(await _db.Supplier.ToListAsync());
        }

        public async Task<IResult> Update(Guid guid, Supplier updatedSupplier)
        {
            var supplier = await _db.Supplier.FindAsync(guid);

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