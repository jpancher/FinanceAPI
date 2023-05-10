using financeAPI.Data;
using financeAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace financeAPI
{
    public interface IRepo
    {
        public Task<IResult> GetAll();
        public Task<IResult> Get(int id);
        public Task<IResult> Create(CostCenter costCenter);
        public Task<IResult> Update(int id, CostCenter costCenter); 
        public Task<IResult> Delete(int id);
    }
}
