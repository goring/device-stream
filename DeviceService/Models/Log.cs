using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace DeviceService.Models
{
    public class Log
    {  
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int DeviceId { get; set; }
        [Required]
        public long SentTimestamp { get; set; }
        [Required]
        public long ReceivedTimestamp { get; set; }
        [Required]
        public string Message { get; set; }

        public Log()
        {

        }

        public Log(int deviceId, long sentTimestamp, long receivedTimestamp, string message)
        { 
            this.DeviceId = deviceId;
            this.SentTimestamp = sentTimestamp;
            this.ReceivedTimestamp = receivedTimestamp;
            this.Message = message;
        }

    }
}
