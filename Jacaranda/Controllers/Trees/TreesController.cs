using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Jacaranda.Controllers.Trees.DTOS;
using Jacaranda.Domain.Exceptions;
using Jacaranda.UseCase;
using Jacaranda.UseCase.UpdateTree;
using Jacaranda.UseCase.CreateTree;
using Jacaranda.UseCase.DeleteTree;
using Jacaranda.UseCase.GetTreeById;
using Jacaranda.UseCase.ListTrees;

namespace Jacaranda.Controllers.Trees;

[ApiController]
[Route("Trees")]

public class TreesController : ControllerBase
{
    private readonly ILogger<TreesController> _logger;
    private readonly IUseCase<CreateTreeUseCaseInput, CreateTreeUseCaseOutput> _createTreeUseCase;
    private readonly IUseCase<UpdateTreeUseCaseInput, UpdateTreeUseCaseOutput> _updateTreeUseCase;
    private readonly IUseCase<ListTreesUseCaseInput, ListTreesUseCaseOutput> _listTreesUseCase;
    private readonly IUseCase<GetTreeByIdUseCaseInput, GetTreeByIdUseCaseOutput> _getTreeByIdUseCase;
    private readonly IUseCase<DeleteTreeUseCaseInput, DeleteTreeUseCaseOutput> _deleteTreeUseCase;

    public TreesController(
        ILogger<TreesController> logger,
        IUseCase<CreateTreeUseCaseInput, CreateTreeUseCaseOutput> createTreeUseCase,
        IUseCase<UpdateTreeUseCaseInput, UpdateTreeUseCaseOutput> updateTreeUseCase,
        IUseCase<ListTreesUseCaseInput, ListTreesUseCaseOutput> listTreesUseCase,
        IUseCase<GetTreeByIdUseCaseInput, GetTreeByIdUseCaseOutput> getTreeById,
        IUseCase<DeleteTreeUseCaseInput, DeleteTreeUseCaseOutput> deleteTreeUseCase
        )
    {
        _logger = logger;
        _createTreeUseCase = createTreeUseCase;
        _updateTreeUseCase = updateTreeUseCase;
        _listTreesUseCase = listTreesUseCase;
        _getTreeByIdUseCase = getTreeById;
        _deleteTreeUseCase = deleteTreeUseCase;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ObjectResult> CreateTree([FromBody] CreateTreeInput Input)
    {
        _logger.LogInformation("Create Tree Called => {Name}", Input.Name);

        try
        {
            var Data = await _createTreeUseCase.Run(new CreateTreeUseCaseInput
            {
                Name = Input.Name,
                Description = Input.Description,
                Biome = Input.Biome,
                Value = Input.Value,
                Base64Image = Input.Image
            });
            return new ObjectResult(Data);
        }
        catch (BaseException e)
        {
            return new BadRequestObjectResult(e.Data);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<ObjectResult> UpdateTree([FromBody] UpdateTreeInput Input)
    {
        _logger.LogInformation("Update Tree Called => {Id}", Input.Id);
        try
        {
            var Data = await _updateTreeUseCase.Run(new UpdateTreeUseCaseInput
            {
                Id = Input.Id,
                Name = Input.Name,
                Description = Input.Description,
                Biome = new Domain.Model.Biome { Name = Input.Biome },
                Value = Input.Value,
                ImageBase64 = Input.Image
            });
            return new ObjectResult(Data);
        }
        catch (BaseException e)
        {
            return new BadRequestObjectResult(e.Data);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpGet("List")]
    [Authorize]
    public async Task<ObjectResult> GetTree([FromQuery] int Page)
    {
        _logger.LogInformation("Get Tree List, Page => {Page}", Page);

        Page = (Page < 1) ? 1 : Page;

        try
        {
            var Data = await _listTreesUseCase.Run(new ListTreesUseCaseInput
            {
                Page = Page
            });

            return new ObjectResult(Data);
        }
        catch (BaseException e)
        {
            return new BadRequestObjectResult(e.Data);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpGet("{Id}")]
    [Authorize]
    public async Task<ObjectResult> GetTreeById(int Id)
    {
        _logger.LogInformation("Get Tree By Id Called => {Id}", Id);
        try
        {
            var Data = await _getTreeByIdUseCase.Run(new GetTreeByIdUseCaseInput
            {
                Id = Id
            });

            return new ObjectResult(Data);
        }
        catch (BaseException e)
        {
            return new BadRequestObjectResult(e.Data);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpDelete("{Id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ObjectResult> DeleteTree(int Id)
    {
        _logger.LogInformation("Delete Tree Called => {Id}", Id);

        try
        {
            var Data = await _deleteTreeUseCase.Run(
                new DeleteTreeUseCaseInput
                {
                    Id = Id
                }
            );

            return new ObjectResult(Data);
        }
        catch (BaseException e)
        {
            return new BadRequestObjectResult(e.Data);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
}
