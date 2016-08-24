using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using System.IO;
using survey_core_ms_fulldotnet.Repository;
using Microsoft.Azure.Documents;
using survey_core_ms_fulldotnet.Models;
using System.Net.Http;

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
            // Save the event
            Document document = await EventDBRepository<EnterpriseEvent>.CreateItemAsync(currentEvent);

            // Now, blast the event out to all subscribers
            var webhookUrls = await WebhooksDBRepository<WebhookURL>.GetItemsAsync(u => u.Url != string.Empty);

            foreach (WebhookURL webhookUrl in webhookUrls)
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        await client.PostAsJsonAsync(webhookUrl.Url, currentEvent);
                    }
                    catch (Exception exception)
                    {
                        // TODO: Log the error
                    }
                }
            }
            
            return new JsonResult(document);
        }
    }
}
