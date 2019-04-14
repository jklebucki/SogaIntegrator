namespace SogaIntegratorWebApi.Configurations
{
    public class FirebaseConfig
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public string DataSource { get; set; }
        public string Port { get; set; }
        public string Dialect { get; set; }
        public string Charset { get; set; }
        public string Role { get; set; }
        public string ConnectionLifetime { get; set; }
        public string Pooling { get; set; }
        public string ConnectionString()
        {
            return
                        "User=" + User + ";" +
                        "Password=" + Password + ";" +
                        "Database=" + Database + ";" +
                        "DataSource=" + DataSource + ";" +
                        "Port=" + Port + ";" +
                        "Dialect=" + Dialect + ";" +
                        "Charset=" + Charset + ";" +
                        "Role=" + Role + ";" +
                        "Connection lifetime=" + ConnectionLifetime + ";" +
                        "Pooling=" + Pooling + ";";
        }
    }
}