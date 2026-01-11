namespace HCAMiniEHR.Models
{
    public class AuditLog
    {
        public int AuditLogId { get; set; }
        public string TableName { get; set; }
        public string Operation { get; set; }
        public DateTime ChangedOn { get; set; }
    }

}
