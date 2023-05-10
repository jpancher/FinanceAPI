using financeAPI.Data;
using financeAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace financeAPI.Repo
{
    public class ChartOfAccountsRepo : IRepo<ChartOfAccounts>
    {
        private readonly DataContext _db;

        public ChartOfAccountsRepo(DataContext db)
        {
            _db = db;
        }
        public async Task<IResult> Create(ChartOfAccounts chartOfAccounts)
        {

            _db.ChartOfAccounts.Add(chartOfAccounts);
            await _db.SaveChangesAsync();

            return TypedResults.Created($"/ChartOfAccounts/{chartOfAccounts.Id}", chartOfAccounts);
        }

        public async Task<IResult> Delete(int id)
        {
            if (await _db.ChartOfAccounts.FindAsync(id) is ChartOfAccounts chartOfAccounts)
            {
                _db.ChartOfAccounts.Remove(chartOfAccounts);
                await _db.SaveChangesAsync();

                return TypedResults.Ok(chartOfAccounts);
            }

            return TypedResults.NotFound();
        }

        public async Task<IResult> Get(int id)
        {
            var chartOfAccounts = await _db.ChartOfAccounts.FindAsync(id);
            return (chartOfAccounts != null ? TypedResults.Ok(chartOfAccounts) : TypedResults.NotFound());
        }

        public async Task<IResult> GetAll()
        {
            return TypedResults.Ok(await _db.ChartOfAccounts.ToListAsync());
        }

        public async Task<IResult> Update(int id, ChartOfAccounts updatedChartOfAccounts)
        {
            var chartOfAccounts = await _db.ChartOfAccounts.FindAsync(id);

            if (chartOfAccounts is null)
                return TypedResults.NotFound();
            else
            {
                chartOfAccounts.Name = updatedChartOfAccounts.Name;
                chartOfAccounts.ShowIncomeStatement = updatedChartOfAccounts.ShowIncomeStatement;
            }
            await _db.SaveChangesAsync();
            return TypedResults.NoContent();
        }
    }
}