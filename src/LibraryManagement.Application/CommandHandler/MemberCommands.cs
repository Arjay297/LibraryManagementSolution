using FluentResults;
using LibraryManagement.Application.Commands;
using LibraryManagement.Application.Response;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Repositories;

namespace LibraryManagement.Application.CommandHandler
{
    public class MemberCommands : IMemberCommands
    {
        private readonly IMemberRepository _memberRepository;


        public MemberCommands(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;

        }


        public async Task<MemberResponse> AddAsync(string email, string name)
        {

            //var newMember = new Member()
            //{
            //    Id = Guid.NewGuid(),
            //    Email = email,
            //    Name = name,
            //    MaxBook = 3
            //};
            //await _memberRepository.AddAsync(newMember);

            //var response = _mapper.Map<MemberResponse>(newMember);
            //return await Task.FromResult(response);
            return null;
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            //Member? member = await _memberRepository.GetByIdAsync(id);
            //if (member is null)
            //    return Result.Fail(new EntityNotFoundError($"user with id = {id} not found"));

            //bool notSaule = true;

            //if (notSaule)
            //    return Result.Fail(new DeleteNotPermittenHindiPaNagsasauli("Balik mona"));

            //await _memberRepository.Delete(member);
            return Result.Ok();
        }

        public async Task<MemberResponse?> GetMemberAsync(Guid id)
        {
            //Member? member = await _memberRepository.GetByIdAsync(id);
            //if (member is null)
            //    return null;

            //MemberResponse response = _mapper.Map<MemberResponse>(member);

            //return await Task.FromResult(response);
            return null;
        }

      
    }
}
