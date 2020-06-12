using Packd.Common;
using Packd.Common.CommonModels;
using Packd.Models;
using System.Collections.Generic;
using System.Linq;

namespace Packd
{
    public class CommonQueries
    {
        // Get the raw content data of a list (defaults to DefaultList)
        public static List<ListContentDataRaw> GetListContentDataRaw(PackdContext aContext, int aListId = 1)
        {
            IQueryable<Lists> Lists = aContext.Lists;
            IQueryable<Category> Categories = aContext.Category;
            IQueryable<Items> Items = aContext.Items;
            IQueryable<ListContent> ListContent = aContext.ListContent;

            var DefaultListContentData = (from lc in ListContent
                                          join c in Categories on lc.CategoryId equals c.Id
                                          join i in Items on lc.ItemId equals i.Id
                                          join l in Lists on lc.ListId equals l.Id

                                          where lc.ListId == aListId
                                          select new ListContentDataRaw
                                          {
                                              ListId = lc.ListId,
                                              ListName = l.Name,
                                              CategoryId = c.Id,
                                              CategoryName = c.Name,
                                              ItemId = i.Id,
                                              ItemName = i.Name,
                                              IsPacked = lc.IsPacked == 1 ? true : false
                                          }).ToList();

            return DefaultListContentData;
        }

        // Get List Content Data by ListId
        public static ListContentData GetListContentData(PackdContext aContext, int aListId = 1)
        {
            IQueryable<Lists> Lists = aContext.Lists;

            return new ListContentData
            {
                ListId = aListId,
                ListName = Lists.Where(list => list.Id == aListId).FirstOrDefault().Name,
                Categories = GetCategoriesByListId(aContext, aListId)
            };
        }

        // Get Categories of a List by ListId
        public static List<CategoryDisplay> GetCategoriesByListId(PackdContext aContext, int aListId = 1)
        {
            List<ListContentDataRaw> ListData = GetListContentDataRaw(aContext, aListId);

            List<CategoryDisplay> Categories =
                ListData.Where(content => content.ListId == aListId)
                .Select(category => new CategoryDisplay
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                    Items = ListData.Where(content => content.CategoryName == category.CategoryName)
                                    .Select(item => new ItemDisplay
                                    {
                                        ItemId = item.ItemId,
                                        ItemName = item.ItemName,
                                        IsPacked = item.IsPacked
                                    }).Distinct().ToList()
                })
                .GroupBy(distinct => distinct.CategoryName)
                .Select(category => category.First())
                .ToList();

            return Categories;
        }

        // Checks if a Category exists in the Database
        public static bool CategoryExists(PackdContext aContext, string CategoryName)
        {
            return aContext.Category.Any(item => item.Name == CategoryName);
        }

        // Get CategoryId by CategoryName
        public static int GetCategoryId(PackdContext aContext, string CategoryName)
        {
            return aContext.Category.Where(item => item.Name == CategoryName).Select(category => category.Id).FirstOrDefault();
        }

        // Checks if an Item exists (is associated to) in a Category
        public static bool ItemExistsInCategory(PackdContext aContext, string ItemName, int CategoryId)
        {
            return aContext.Items.Any(item => item.Name == ItemName && item.CategoryId == CategoryId);
        }

        // Get ListId by ListName
        public static int GetListId(PackdContext aContext, string ListName)
        {
            return aContext.Lists.Where(item => item.Name == ListName).Select(item => item.Id).FirstOrDefault();
        }
        
        // Get ItemId by ItemName
        public static int GetItemId(PackdContext aContext, int CategoryId, string ItemName)
        {
            return aContext.Items.Where(item => item.CategoryId == CategoryId && item.Name == ItemName).Select(item => item.Id).FirstOrDefault();
        }
    }
}
