using SB.Application.Contracts;
using SB.Application.DTOs.BillItem.Messages;
using SB.Application.DTOs.BillItem.Representations;
using SB.Models;

namespace SB.Data.Repositories
{
    public class BillItemRepository : IBillItemRepository
    {
        public readonly ApiDbContext _apiDbContext;
        public BillItemRepository(ApiDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }
        public async Task<BillItemRepresentation> CreateBillItem(BillItem billItem)
        {
            var result =  _apiDbContext.BillItems.Add(billItem);
            await _apiDbContext.SaveChangesAsync();
            var product = _apiDbContext.Products.Find(result.Entity.ProductId);
            return new BillItemRepresentation
            {
                Id = result.Entity.Id,
                BillId = result.Entity.BillId,
                ProductName = product?.Name,
                TotalPrice = result.Entity.TotalPrice
            };
                
        }
        public async Task<BillItemDeletingMessage> DeleteBillItem(Guid billItemId)
        {
            var billItem = _apiDbContext.BillItems.Find(billItemId);
            if (billItem != null)
            {
                _apiDbContext.BillItems.Remove(billItem);
                await _apiDbContext.SaveChangesAsync();
                return new BillItemDeletingMessage { Succsess = true, Message = $"bill item: {billItem.Id} successfully deleted from bill: {billItem.BillId}" };
            }
            else
            {
                return new BillItemDeletingMessage { Succsess = false, Message = $"bill item: {billItemId} does not exist in data base" };
            }
        }
    }
}
