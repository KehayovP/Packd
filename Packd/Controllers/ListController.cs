using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Packd.Common.CommonModels;
using Packd.Models;
using System.Collections.Generic;

namespace Packd.Controllers
{
    public class ListController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PackdContext _context;

        public ListController(ILogger<HomeController> logger, PackdContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult MyLists()
        {
            ViewBag.Lists = _context.Lists;
            return View();
        }

        public IActionResult Export()
        {
            ViewBag.Lists = _context.Lists;
            return View();
        }


        public IActionResult NewList()
        {
            ListContentData DefaultListContent = CommonQueries.GetListContentData(_context);
            ViewBag.DefaultListContent = DefaultListContent;

            return View();
        }

        [HttpPost]
        public IActionResult SaveList(string NewListName, List<string[]> NewListCategories)
        {
            // Execute stored procedure to create new list
            _context.Database.ExecuteSqlRaw("EXECUTE Packd.CreateNewList_StoredProcedure {0}", NewListName);

            foreach (var item in NewListCategories)
            {
                var CategoryToSave = item[0];

                // Save Category to Category table in the database (if not already there)
                if (!CommonQueries.CategoryExists(_context, CategoryToSave))
                {
                    _context.Database.ExecuteSqlRaw("EXECUTE Packd.CreateNewCategory_StoredProcedure {0}", CategoryToSave);
                }

                var CategoryId = CommonQueries.GetCategoryId(_context, CategoryToSave);
                var ListId = CommonQueries.GetListId(_context, NewListName);

                for (var i = 1; i < item.Length; i++)
                {
                    // Save Item to Items table in the database (if not already there)
                    if (!CommonQueries.ItemExistsInCategory(_context, item[i], CategoryId))
                    {
                        _context.Database.ExecuteSqlRaw("EXECUTE Packd.CreateNewItem_StoredProcedure {0}, {1}", item[i], CategoryId);
                    }

                    var ItemId = CommonQueries.GetItemId(_context, CategoryId, item[i]);

                    // Save Item to ListContent table in the database
                    _context.Database.ExecuteSqlRaw("EXECUTE Packd.CreateNewListContent_StoredProcedure {0}, {1}, {2}", ListId, CategoryId, ItemId);
                }
            }

            return RedirectToAction("MyLists");
        }

        [HttpGet("{controller}/{action}/{Id}")]
        public IActionResult DisplayList(int Id)
        {
            ListContentData DisplayListContent = CommonQueries.GetListContentData(_context, Id);
            ViewBag.DisplayListContent = DisplayListContent;

            return View();
        }

        public IActionResult SetPacked(int IsPacked, int ListContentId)
        {
            // Update IsPacked value of Item in ListContent table in the Database.
            _context.Database.ExecuteSqlRaw("EXECUTE Packd.UpdateItemIsPacked_StoredProcedure {0}, {1}", IsPacked, ListContentId);

            return View();
        }

        [HttpGet("{controller}/{action}/{ListId}")]
        public IActionResult DeleteList(int ListId)
        {
            // Delete list by List Id
            _context.Database.ExecuteSqlRaw("EXECUTE Packd.DeleteList_StoredProcedure {0}", ListId);

            return RedirectToAction("MyLists");
        }

        [HttpGet("{controller}/{action}/{ListId}")]
        public IActionResult Edit(int ListId)
        {
            // Don't edit if default list
            if(ListId == 1)
            {
                return RedirectToAction("MyLists");
            }
            
            ListContentData DefaultListContent = CommonQueries.GetListContentData(_context);
            ListContentData ListToEditListContent = CommonQueries.GetListContentData(_context, ListId);

            ViewBag.DefaultListContent = DefaultListContent;
            ViewBag.ListToEditListContent = ListToEditListContent;

            return View();
        }

        [HttpPost]
        public IActionResult UpdateList(int ListId, string ListName, List<string[]> ListCategories)
        {
            if (ListId != 1)
            {
                // Delete List Information
                _context.Database.ExecuteSqlRaw("EXECUTE Packd.DeleteListContentInfo_StoredProcedure {0}", ListId);

                // Insert New Information
                foreach (var item in ListCategories)
                {
                    var CategoryToSave = item[0];

                    // Save Category to Category table in the database (if not already there)
                    if (!CommonQueries.CategoryExists(_context, CategoryToSave))
                    {
                        _context.Database.ExecuteSqlRaw("EXECUTE Packd.CreateNewCategory_StoredProcedure {0}", CategoryToSave);
                    }

                    var CategoryId = CommonQueries.GetCategoryId(_context, CategoryToSave);

                    for (var i = 1; i < item.Length; i++)
                    {
                        // Save Item to Items table in the database (if not already there)
                        if (!CommonQueries.ItemExistsInCategory(_context, item[i], CategoryId))
                        {
                            _context.Database.ExecuteSqlRaw("EXECUTE Packd.CreateNewItem_StoredProcedure {0}, {1}", item[i], CategoryId);
                        }

                        var ItemId = CommonQueries.GetItemId(_context, CategoryId, item[i]);

                        // Save Item to ListContent table in the database
                        _context.Database.ExecuteSqlRaw("EXECUTE Packd.CreateNewListContent_StoredProcedure {0}, {1}, {2}", ListId, CategoryId, ItemId);
                    }
                }
            }

            return RedirectToAction("MyLists");
        }
    }
}
