using Jacaranda.Domain.Exceptions;
using Jacaranda.Domain.Model;
using Jacaranda.Util;
using Jacaranda.UseCase.Interfaces.Repositories;

namespace Jacaranda.UseCase.DeleteTree;
public class DeleteTreeUseCase : IUseCase<DeleteTreeUseCaseInput, DeleteTreeUseCaseOutput>
{
    private readonly ITreeRepository _treeRepository;

    public DeleteTreeUseCase(ITreeRepository treeRepository)
    {
        _treeRepository = treeRepository;
    }

    public async Task<DeleteTreeUseCaseOutput> Run(DeleteTreeUseCaseInput Input)
    {
        var TreeToDelete = await _treeRepository.GetTreeById(Input.Id);

        if (TreeToDelete is null)
            throw new InvalidTreeIdException();

        if(TreeIsActive(TreeToDelete))
            await DeleteTree(TreeToDelete);

        return new DeleteTreeUseCaseOutput();
    }

    private bool TreeIsActive(Tree TreeToDelete)
        => TreeToDelete.Deleted == false;

    private async Task DeleteTree(Tree TreeToDelete)
    {
        TreeToDelete.UpdatedAt = DateHelper.BrazilDateTimeNow();
        TreeToDelete.Deleted = true;

        _treeRepository.Update(TreeToDelete);
    }
}
