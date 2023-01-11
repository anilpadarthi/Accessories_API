using POS_Accessories.Business.Interfaces;
using POS_Accessories.Data.Repository.Interfaces;
using POS_Accessories.Models;
using POS_Accessories.Models.Request;

namespace POS_Accessories.Business.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;

        public SubCategoryService(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }
        public async Task<IEnumerable<string>> CreateSubCategoryAsync(SubCategory request)
        {
            return await _subCategoryRepository.CreateSubCategoryAsync(request);
        }

        public async Task<IEnumerable<string>> DeleteSubCategoryAsync(int categoryId)
        {
            return await _subCategoryRepository.DeleteSubCategoryAsync(categoryId);
        }

        public async Task<IEnumerable<string>> UpdateSubCategoryAsync(SubCategory request)
        {
            var subCategory = await _subCategoryRepository.GetSubCategoryAsync(request.SubCategoryId);
            subCategory.SubCategoryName = request.SubCategoryName;
            subCategory.Image = request.Image;
            subCategory.CategoryId = request.CategoryId;
            return await _subCategoryRepository.UpdateSubCategoryAsync(request);
        }

        public async Task<IEnumerable<SubCategory>> GetAllSubCategoriesAsync()
        {
            return await _subCategoryRepository.GetAllSubCategoriesAsync();
        }

        public async Task<SubCategory> GetSubCategoryAsync(int categoryId)
        {
            return await _subCategoryRepository.GetSubCategoryAsync(categoryId);
        }

        public async Task<IEnumerable<SubCategory>> GetPagedSubCategoriesAsync(GetPagedRequest request)
        {
            return await _subCategoryRepository.GetPagedSubCategoriesAsync(request);
        }
    }
}
