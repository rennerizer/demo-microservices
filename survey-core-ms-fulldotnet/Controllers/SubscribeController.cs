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
    [Route("api/[controller]")]
    public class SubscribeController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var items = await WebhooksDBRepository<WebhookURL>.GetItemsAsync(u => u.Url != string.Empty);

            return new JsonResult(items);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] WebhookURL url)
        {
            Document document = await WebhooksDBRepository<WebhookURL>.CreateItemAsync(url);

            return new JsonResult(document);
        }
    }
}
