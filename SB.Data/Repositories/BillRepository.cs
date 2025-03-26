using Microsoft.EntityFrameworkCore;
using SB.Application.Contracts;
using SB.Application.DTOs.Bill.Messages;
using SB.Models;

namespace SB.Data.Repositories
{
    public class BillRepository : IBillRepository
    {
        public readonly ApiDbContext _apiDbContext;
        public BillRepository(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }

        public async Task<Bill> CreateBill(Bill bill)
        {
            var result = _apiDbContext.Bills.Add(bill);
            await _apiDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<BillDeletingMessage> DeleteBill(Guid billId)
        {
            var bill = _apiDbContext.Bills.Find(billId);
            if (bill != null)
            {
                _apiDbContext.Bills.Remove(bill);
                await _apiDbContext.SaveChangesAsync();
                return new BillDeletingMessage { Succsess = true, Message = $"bill: {bill.Id} successfully deleted" };
            }
            else
            {
                return new BillDeletingMessage { Succsess = false, Message = $"bill: {billId} does not exist in data base" };
            }
        }

        public Task<Bill?> GetBillById(Guid billId)
        {
            return _apiDbContext.Bills.FirstOrDefaultAsync(x => x!.Id == billId);
        }
    }
}
