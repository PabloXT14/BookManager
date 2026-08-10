using AutoMapper;
using BookManager.Communication.Requests;
using BookManager.Domain.Entities;

namespace BookManager.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    public void RequestToEntity()
    {
        CreateMap<RequestBookJson, Book>();
    }

    public void EntityToResponse()
    {

    }
}