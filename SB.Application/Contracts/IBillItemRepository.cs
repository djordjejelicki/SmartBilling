using SB.Application.DTOs.BillItem.Messages;
using SB.Application.DTOs.BillItem.Representations;
using SB.Models;

namespace SB.Application.Contracts
{
    public interface IBillItemRepository
    {
        Task<BillItemRepresentation> CreateBillItem(BillItem billItem);
        Task<BillItemDeletingMessage> DeleteBillItem(Guid billItemId);
    }
}
