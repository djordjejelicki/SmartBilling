using SB.Application.DTOs.Bill.Messages;
using SB.Models;

namespace SB.Application.Contracts
{
    public interface IBillRepository
    {
        Task<Bill> CreateBill(Bill bill);
        Task<BillDeletingMessage> DeleteBill(Guid billId);
        Task<Bill> GetBillById(Guid billId);
        Task<List<Bill?>> GetAllBills();
    }
}
