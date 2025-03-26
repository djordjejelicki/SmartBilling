using AutoMapper;
using SB.Application.DTOs.Bill.Reperesentations;
using SB.Models;

namespace SB.Application.Bills.Queries.GetAllBills
{
    public class GetAllBillsProfileMapper : Profile
    {
        public GetAllBillsProfileMapper()
        {
            CreateMap<Bill, BillRepresentation>(); //.reverseMap 
        }
    }
}
