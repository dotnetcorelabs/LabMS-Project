using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetCoreLabs.LabMS.Application.Interfaces;
using DotNetCoreLabs.LabMS.Application.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetCoreLabs.LabCMS.Web.Controllers
{
    public class ListController : Controller
    {
        private readonly IListAppService _listAppService;

        public ListController(IListAppService listAppService)
        {
            _listAppService = listAppService;
        }

        // GET: /<controller>/
        public async Task<IEnumerable<ListDefinitionViewModel>> Index()
        {
            return await _listAppService.GetAllAsync();
        }

        //[HttpGet("data/list/{title}/definition", Name = "Definition")]
        //public Task<ListDefinitionViewModel> Definition(string title)
        //{
        //    return _listService.GetAsync(title);
        //}

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ListDefinitionViewModel dataModel)
        {
            if (dataModel == null || !ModelState.IsValid) return BadRequest();

            await _listAppService.CreateAsync(dataModel);

            return CreatedAtRoute("Definition", new { title = dataModel.Title }, dataModel);
        }
    }
}
