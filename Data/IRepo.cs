using financeAPI.Data;
using financeAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace financeAPI
{
    public interface IRepo<T>
    {
        public Task<IResult> GetAll();
        public Task<IResult> Get(int id);
        public Task<IResult> Create(T entity);
        public Task<IResult> Update(int id, T entity); 
        public Task<IResult> Delete(int id);
    }
}
