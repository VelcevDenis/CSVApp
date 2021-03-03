using System.Linq;
using System.Threading.Tasks;
using CSVApp.Contract.Models.RequestModels;
using CSVApp.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CSVApp.Application.Contexts.Sales.Commands.Commands.DeleteSale;
using CSVApp.Application.Contexts.Sales.Commands.Commands.Update;
using CSVApp.Application.Contexts.Sales.Commands.ViewModels;
using CSVApp.Application.Contexts.Sales.Commands.Queries.GetAllSales;
using CSVApp.Application.Contexts.Sales.Commands.Commands.CreateSale;
using CSVApp.Application.Contexts.Sales.Commands.Queries.SearchSales;
using CSVApp.Application.Contexts.Sales.Commands.DeleteAllSales;
using Microsoft.AspNetCore.Authorization;

namespace CSVApp.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase {

        private readonly ApplicationDbContext _context;

        public SalesController(ApplicationDbContext context) {
            _context = context;
        }

        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        //GET : /api/Users/GetAllSales
        public async Task<ActionResult<IEnumerable<object>>> GetAllAsync([FromQuery] BaseSearchRequestModel request) {
            var getAllSales = new GetAllSalesQuery(_context);
            return Ok(await Task.Run(() => getAllSales.GetAllSales(request)));
        }

        [HttpPut]
        [Route("Update")]
        [Authorize]
        //PUT : /api/Users/Update
        public async Task<ActionResult<IEnumerable<object>>> Update([FromBody] UpdateSaleRequestModel request) {
            var update = new UpdateSaleCommand(_context);
            return Ok(await Task.Run(() => update.UpdateSale(request)));
        }

        [HttpDelete]
        [Route("Delete")]
        [Authorize]
        //DELETE : /api/Users/Delete
        public IActionResult Delete([FromQuery] long id) {
            var delete = new DeleteSaleCommand(_context);
            return Ok(delete.DeleteSale(id));
        }

        [HttpDelete]
        [Route("DeleteAll")]
        [Authorize]
        //DELETE : /api/Users/DeleteAll
        public async Task<ActionResult<bool>> DeleteAll() {
            var delete = new DeleteAllSalesCommand(_context);
            return Ok(await Task.Run(() => delete.DeleteAllSale()));
        }

        [HttpPost]
        [Route("Create")]
        [Authorize]
        //POST : /api/Users/Create
        public async Task<ActionResult<IEnumerable<object>>> Create([FromBody] SearchSaleRequestModel request) {
            var create = new CreateSaleCommand(_context);
            return Ok(await Task.Run(() => create.CreateSale(request)));
        }

        [HttpPost]
        [Route("Search")]
        [Authorize]
        //POST : /api/Users/Search
        public async Task<ActionResult<IEnumerable<object>>> Search([FromBody] SearchSaleRequestModel request) {
            var search = new SearchSalesQuery(_context);
            return Ok(await Task.Run(() => search.SearchSales(request)));
        }
    }
}