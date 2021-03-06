﻿using System.Threading.Tasks;
using Core.WebApi.Hubs.Clients.Messages;

namespace Core.WebApi.Hubs.Clients.Interfaces
{
	public interface IAdventureClient
	{
		Task ReceiveMessage(string user, AdventureMessage messgae);
		Task ReceiveMessage(AdventureMessage message);
	}
}
