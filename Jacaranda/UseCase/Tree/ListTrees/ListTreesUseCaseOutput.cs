using Jacaranda.UseCase.ListTrees.DTOS;

namespace Jacaranda.UseCase.ListTrees
{
    public class ListTreesUseCaseOutput
	{
		public int TotalPages { get; set; }
		public int CurrentPage { get; set; }
		public int ItemsPerPage { get; set; }
		public List<LightTree> Trees { get; set; }
	}
}