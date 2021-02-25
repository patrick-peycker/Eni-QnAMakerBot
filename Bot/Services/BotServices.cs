using Microsoft.Bot.Builder.AI.QnA;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bot.Services
{
	public class BotServices
	{
		public QnAMaker QnAMaker { get; private set; }

		public BotServices(IConfiguration Configuration)
		{
			this.QnAMaker = new QnAMaker(new QnAMakerEndpoint { Host = Configuration["KB:Host"], KnowledgeBaseId = Configuration["KB:Id"], EndpointKey = Configuration["KB:EndpointKey"] });
		}
	}
}
