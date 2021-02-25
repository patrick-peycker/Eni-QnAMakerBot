// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.11.1

using Bot.Services;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.AI.QnA;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bot.Bots
{
	public class EchoBot : ActivityHandler
	{
		private readonly BotServices BotServices;
		public EchoBot(BotServices BotServices)
		{
			this.BotServices = BotServices ?? throw new ArgumentNullException($"{nameof(BotServices)} in Echo Bot Class !");
		}

		protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
		{
			var result = await BotServices.QnAMaker.GetAnswersAsync(turnContext, new QnAMakerOptions { Top = 1 });
			await turnContext.SendActivityAsync(result[0].Answer, cancellationToken: cancellationToken);
		}

		protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
		{
			var welcomeText = "Hello and welcome!";
			foreach (var member in membersAdded)
			{
				if (member.Id != turnContext.Activity.Recipient.Id)
				{
					await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
				}
			}
		}
	}
}
