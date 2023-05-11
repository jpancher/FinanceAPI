using financeAPI.Data;
using financeAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections;
using System.Text.Json;

namespace financeAPI.Repo
{
    public class TransactionRepo : IRepoGuid<Transaction>
    {
        private readonly DataContext _db;

        public TransactionRepo(DataContext db)
        {
            _db = db;
        }
        public async Task<IResult> Create(Transaction transaction)
        {
            if (transaction.Guid == Guid.Empty)
            {
                transaction.Guid = Guid.NewGuid();
            }

            transaction.TransactionType = await _db.TransactionType.FindAsync(transaction.TransactionType.Id);
            transaction.BankAccount = await _db.BankAccount.FindAsync(transaction.BankAccount.Id);
            transaction.CostCenter = await _db.CostCenter.FindAsync(transaction.CostCenter.Id);
            transaction.Supplier = await _db.Supplier.FindAsync(transaction.Supplier.Guid);
            transaction.ChartOfAccounts= await _db.ChartOfAccounts.FindAsync(transaction.ChartOfAccounts.Id);
            
            _db.Transaction.Add(transaction);
            await _db.SaveChangesAsync();

            return TypedResults.Created($"/Transaction/{transaction.Guid}", transaction);
        }

        public async Task<IResult> Delete(Guid guid)
        {
            if (await _db.Transaction.FindAsync(guid) is Transaction transaction)
            {
                _db.Transaction.Remove(transaction);
                await _db.SaveChangesAsync();

                return TypedResults.Ok(transaction);
            }

            return TypedResults.NotFound();
        }

        public async Task<IResult> Get(Guid guid)
        {
            var transaction = await _db.Transaction.FindAsync(guid);
            return (transaction != null ? TypedResults.Ok(transaction) : TypedResults.NotFound());
        }

        public async Task<IResult> GetAll()
        {
            return TypedResults.Ok(await _db.Transaction.ToListAsync());
        }

        public async Task<IResult> Update(Guid guid, Transaction updatedTransaction)
        {
            var transaction = await _db.Transaction.FindAsync(guid);

            if (transaction is null)
                return TypedResults.NotFound();
            else
            {
                transaction.AccrualDate = updatedTransaction.AccrualDate;
                transaction.DueDate = updatedTransaction.DueDate;
                transaction.PaymentDate = updatedTransaction.PaymentDate;
                transaction.Status = updatedTransaction.Status;
                transaction.Value = updatedTransaction.Value;
                transaction.PenaltyAndInterestOrDiscount = updatedTransaction.PenaltyAndInterestOrDiscount;
                transaction.Description = updatedTransaction.Description;
                transaction.Supplier = updatedTransaction.Supplier;
                transaction.ChartOfAccounts = updatedTransaction.ChartOfAccounts;
                transaction.CostCenter = updatedTransaction.CostCenter;
                transaction.TransactionType = updatedTransaction.TransactionType;
                transaction.BankAccount = updatedTransaction.BankAccount;
                transaction.UpdatedDate = updatedTransaction.UpdatedDate;
                transaction.UpdatedUser = updatedTransaction.UpdatedUser;
            }
            await _db.SaveChangesAsync();
            return TypedResults.NoContent();
        }
    }
}
