using System.Data;

namespace Ead2808.Data
{
    public static class DbExtensions
    {
        public static void AddParameter(this IDbCommand cmd, string name, object? value, DbType? dbType = null)
        {
            var param = cmd.CreateParameter();
            param.ParameterName = name;
            if (dbType.HasValue) ((IDbDataParameter)param).DbType = dbType.Value;
            param.Value = value ?? DBNull.Value; 
            cmd.Parameters.Add(param);
        }
    }
}
