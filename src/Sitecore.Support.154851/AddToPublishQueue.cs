using System;
using Sitecore.Data;
using Sitecore.Data.DataProviders;
using Sitecore.Data.DataProviders.Sql;
using Sitecore.Data.Oracle;
using Sitecore.Diagnostics;

namespace Sitecore.Support.Data.Oracle
{
    public class OracleDataProvider : Sitecore.Data.Oracle.OracleDataProvider
    {
        public OracleDataProvider(string connectionString) : base(connectionString)
        {
        }
        public override bool AddToPublishQueue(ID itemID, string action, DateTime date, string language, CallContext context)
        {
            OracleDataApi oracleDataApi = base.Api as OracleDataApi;
            Assert.IsNotNull(oracleDataApi, "Invalid Data API");
            //string sql = "INSERT INTO {0}PublishQueue{1} (     {0}ItemID{1}, {0}Language{1}, {0}Version{1}, {0}Date{1}, {0}Action{1}   )   VALUES(     {2}itemID{3}, {2}language{3}, {2}version{3}, {2}date{3}, {2}action{3}   )";
            string sql = "DECLARE cnt NUMBER;\nBEGIN  SELECT COUNT(*) INTO cnt    FROM {0}PublishQueue{1} WHERE ({0}ItemID{1} = {2}itemID{3} AND {0}Language{1} = {2}language{3} AND {0}Date{1} = {2}date{3} AND {0}Action{1} = {2}action{3});\n  IF( cnt = 0 )  THEN   INSERT INTO {0}PublishQueue{1} (     {0}ItemID{1}, {0}Language{1}, {0}Version{1}, {0}Date{1}, {0}Action{1}   ) VALUES(     {2}itemID{3}, {2}language{3}, {2}version{3}, {2}date{3}, {2}action{3}   );\n  END IF;\nEND;\n";
            oracleDataApi.Execute(sql, new object[]
            {
        "itemID",
        itemID,
        "language",
        language,
        "version",
        0,
        "date",
        date,
        "action",
        action
            });
            return true;
        }
    }
}