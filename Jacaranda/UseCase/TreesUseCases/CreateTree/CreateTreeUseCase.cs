using Jacaranda.Domain.Model;
using Jacaranda.UseCase.Interfaces.Repositories;
using Jacaranda.UseCase.Interfaces.Services;
using Jacaranda.Domain.Exceptions;
using Jacaranda.External.Repositories;
using Jacaranda.Helper;

namespace Jacaranda.UseCase.CreateTree
{
    public class CreateTreeUseCase : IUseCase<CreateTreeUseCaseInput, CreateTreeUseCaseOutput>
    {
        private readonly ITreeRepository _treeRepository;
        private readonly IBiomeRepository _biomeRepository;
        private readonly IStorageService _storageService;

        public CreateTreeUseCase(
            ITreeRepository treeRepository,
            IBiomeRepository biomeRepository,
            IStorageService storageService
            )
        {
            _treeRepository = treeRepository;
            _storageService = storageService;
            _biomeRepository = biomeRepository;
        }

        public async Task<CreateTreeUseCaseOutput> Run(CreateTreeUseCaseInput Input)
        {
            if (await VerifyTreeNameExists(Input.Name))
              throw new InvalidTreeNameException();

            await CreateTree(Input);
            return new CreateTreeUseCaseOutput();
        }

        private async Task CreateTree(CreateTreeUseCaseInput input)
        {

            var ImageUri = _storageService.UploadTreeImageInBase64(input.Base64Image);

            Biome biome = await _biomeRepository.GetBiomeByName(input.Biome);
            if (biome == null)
            {
                biome = new Biome { CreatedAt = DateHelper.BrazilDateTimeNow(), Name = input.Biome, Deleted = false };
                await _biomeRepository.Create(biome);
            }

            await _treeRepository.Create(new Tree
            {
                Name = input.Name,
                Description = input.Description,
                Image = ImageUri,
                Value = input.Value,
                Biome = biome,//to do
            });
        }

        private async Task<bool> VerifyTreeNameExists(string Name)
        {
            var treeFound = await _treeRepository.GetActiveTreeByName(Name);

            if(treeFound != null)
                return true;

            return false;
        }
    }
}
