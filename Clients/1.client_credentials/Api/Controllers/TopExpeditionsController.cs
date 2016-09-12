using System.Collections.Generic;
using System.Web.Http;

namespace Api.Controllers
{
    [Authorize]
    public class TopExpeditionsController : ApiController
    {
        public IHttpActionResult Get()
        {
            IList<Expedition> expeditions = new List<Expedition>();
            expeditions.Add(new Expedition() { Name = "Elbrus 2017", DurationInDays = "7-10"});
            expeditions.Add(new Expedition() { Name = "Mont Blanc 2017", DurationInDays = "5-7"});
            expeditions.Add(new Expedition() { Name = "Grossglockner 2017", DurationInDays = "5-7" });
            expeditions.Add(new Expedition() { Name = "Negoiu 2016", DurationInDays = "2-3"});
            expeditions.Add(new Expedition() { Name = "Piatra Craiului Tour", DurationInDays = "3-4" });
            expeditions.Add(new Expedition() { Name = "Retezat Winter School", DurationInDays = "5" });
            return Ok<IList<Expedition>>(expeditions);
        }

        public class Expedition
        {
            public string Name { set; get; }
            public string DurationInDays { set; get; }
        }
    }
}