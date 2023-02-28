using Jacaranda.Domain.Model;
using Jacaranda.UseCase.Interfaces.Repositories;
using Jacaranda.Domain.Exceptions;
using Jacaranda.UseCase.Interfaces.Services;

namespace Jacaranda.UseCase.UpdateTree;
public class UpdateTreeUseCase : IUseCase<UpdateTreeUseCaseInput, UpdateTreeUseCaseOutput>
{
    private readonly ITreeRepository _treeRepository;
    private readonly IStorageService _storageService;

    public UpdateTreeUseCase(
        ITreeRepository treeRepository,
        IStorageService storageService
        )
    {
        _treeRepository = treeRepository;
        _storageService = storageService;
    }

    public async Task<UpdateTreeUseCaseOutput> Run(UpdateTreeUseCaseInput Input)
    {
        var TreeToUpdate = await _treeRepository.GetTreeById(Input.Id);

        if(TreeToUpdate is null)
            throw new InvalidTreeIdException();

        await ValidateTreeUpdate(TreeToUpdate, Input);
        await UpdateTree(TreeToUpdate, Input);

        return new UpdateTreeUseCaseOutput();
    }

    private async Task UpdateTree(Tree Tree, UpdateTreeUseCaseInput Input)
    {
        var ImageUri = Tree.Image;

        if (!string.IsNullOrEmpty(Input.ImageBase64))
            ImageUri = UploadNewTreeImage(Input.ImageBase64, ImageUri);

        Tree.Name = Input.Name;
        Tree.Description = Input.Description;
        Tree.Value = Input.Value;
        Tree.Biome = Input.Biome;
        Tree.Image = ImageUri;
        _treeRepository.Update(Tree);
    }

    private string UploadNewTreeImage(string Base64Image, string imageUri)
    {
        return string.IsNullOrEmpty(imageUri)
            ? _storageService.UploadTreeImageInBase64(Base64Image)
            : _storageService.UploadTreeImageInBase64(Base64Image, imageUri);
    }

    private async Task<bool> ValidateTreeUpdate(Tree Tree, UpdateTreeUseCaseInput NewTree)
    {
        var TreeWithSameName = await _treeRepository.GetTreeByName(NewTree.Name);

        if(!TreeWithSameName?.Id.Equals(Tree.Id) == true)
            throw new InvalidTreeNameException();

        return true;    
    }
}
