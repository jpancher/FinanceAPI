using financeAPI.Data;
using financeAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace financeAPI.Repo
{
    public class TransactionTypeRepo : IRepo<TransactionType>
    {
        private readonly DataContext _db;

        public TransactionTypeRepo(DataContext db)
        {
            _db = db;
        }

        public async Task<IResult> Create(TransactionType transactionType)
        {

            _db.TransactionType.Add(transactionType);
            await _db.SaveChangesAsync();

            return TypedResults.Created($"/TransactionType/{transactionType.Id}", transactionType);
        }

        public async Task<IResult> Delete(int id)
        {
            if (await _db.TransactionType.FindAsync(id) is TransactionType transactionType)
            {
                _db.TransactionType.Remove(transactionType);
                await _db.SaveChangesAsync();

                return TypedResults.Ok(transactionType);
            }

            return TypedResults.NotFound();
        }

        public async Task<IResult> Get(int id)
        {
            var transactionType = await _db.TransactionType.FindAsync(id);
            return (transactionType != null ? TypedResults.Ok(transactionType) : TypedResults.NotFound());
        }

        public async Task<IResult> GetAll()
        {
            return TypedResults.Ok(await _db.TransactionType.ToListAsync());
        }

        public async Task<IResult> Update(int id, TransactionType updatedTransactionType)
        {
            var transactionType = await _db.TransactionType.FindAsync(id);

            if (transactionType is null)
                return TypedResults.NotFound();
            else
            {
                transactionType.Name = updatedTransactionType.Name;
            }
            await _db.SaveChangesAsync();
            return TypedResults.NoContent();
        }
    }
}
