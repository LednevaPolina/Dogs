using Dogs.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Dogs.ViewComponents
{
    public class PaginationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int currentPage, int totalPages, int limit,int? tagId,int?fciCategoriId)
        {
            
            PaginationViewModel paginationViewModel = new PaginationViewModel()
            {
                TotalPages = totalPages,
                CurrentPage = currentPage,
                LimitItem=limit,
                TagId=tagId,
                FciCategoryId=fciCategoriId
            };
            return View("Pagination",paginationViewModel); 
        }
    }
}
