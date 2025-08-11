using Borrowing.Application.Commands;
using Borrowing.Application.Response;
using Borrowing.Domain.Entities;
using Borrowing.Domain.Repositories;
using FluentResults;

namespace Borrowing.Application.CommandHandler
{
    public class MemberCommands : IMemberCommands
    {
        private readonly IUnitOfWork _unitOfWork;

        public MemberCommands(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task AddAsync(string email, string name)
        {

            var newMember = Member.Create(name, email);
          
            await _unitOfWork.Members.AddAsync(newMember);
            await _unitOfWork.SaveChangesAsync(default);
        
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
