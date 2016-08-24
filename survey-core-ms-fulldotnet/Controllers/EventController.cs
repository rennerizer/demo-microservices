using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using System.IO;
using survey_core_ms_fulldotnet.Repository;
using Microsoft.Azure.Documents;
using survey_core_ms_fulldotnet.Models;

namespace survey_core_ms_fulldotnet.Controllers
{
    [Route("act/")]
    public class EventController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var items = await EventDBRepository<EnterpriseEvent>.GetItemsAsync(e => e.role != string.Empty);

            return new JsonResult(items);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EnterpriseEvent currentEvent)
        {
            Document document = await EventDBRepository<EnterpriseEvent>.CreateItemAsync(currentEvent);

            return new JsonResult(document);
        }
    }
}
