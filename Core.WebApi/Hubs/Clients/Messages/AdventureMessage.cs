﻿namespace Core.WebApi.Hubs.Clients.Messages
{
	public class AdventureMessage : BaseMessage
	{
		public string User { get; set; }
		public string Message { get; set; }
	}
}
