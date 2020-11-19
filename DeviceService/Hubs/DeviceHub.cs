using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using DeviceService.Entities;
using AutoMapper;
using DeviceService.Models;

namespace DeviceService.Hubs
{
    public class DeviceHub : Hub
    {
        private readonly IPostgresqlRepo _repository;
        public DeviceHub(IPostgresqlRepo repository)
        {
            _repository = repository;
        }

        public long GetEpoch()
        {
            return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds;
        }

        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "DEVICE");
            await base.OnConnectedAsync();
            Debug.WriteLine(string.Format("{0} has connected.", Context.GetHttpContext().Connection.RemoteIpAddress));
        }

        public async Task Send(int deviceId, long sentTimestamp, string message)
        {
            long receivedTimestamp = GetEpoch();
            _repository.CreateLog(new Log(deviceId, sentTimestamp, receivedTimestamp, message));
            _repository.SaveChanges();
            await Clients.All.SendAsync("broadcastMessage", "request", "received");
        }
    }
}
