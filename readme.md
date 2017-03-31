# Sitecore.Support.154851
[Oracle]: Sitecore XP throws the &quot;ORA-00900: invalid SQL statement&quot; exceptions when you are trying to create or edit an item.

An example of the exception and its stack trace is:

```
ManagedPoolThread #8 13:33:51 ERROR Failed to save the item. Item ID: {44428794-05A4-4BE6-90D6-7D0BF128D17E}, database: master
Exception: System.Exception
Message: ORA-00900: invalid SQL statement
Source: Sitecore.Kernel
   at Sitecore.Data.DataProviders.Sql.DataProviderCommand.ExecuteNonQuery()
   at Sitecore.Data.DataProviders.Sql.SqlDataApi.<>c__DisplayClass15.<Execute>b__14()
   at Sitecore.Data.DataProviders.NullRetryer.Execute[T](Func`1 action, Action recover)
   at Sitecore.Data.DataProviders.Sql.SqlDataProvider.AddToPublishQueue(ID itemID, String action, DateTime date, String language, CallContext context)
   at Sitecore.Data.DataProviders.DataProvider.AddToPublishQueue(ID itemID, String action, DateTime date, String language, CallContext context, DataProviderCollection providers)
   at Sitecore.Publishing.DefaultPublishManager.AddToPublishQueue(Database database, ID itemId, String action, DateTime date, Boolean forceAddToPublishQueue, String language)
   at Sitecore.Publishing.DefaultPublishManager.AddToPublishQueue(Item item, String action, DateTime date, Boolean specificLanguage)
   at Sitecore.Publishing.DefaultPublishManager.AddToPublishQueue(Item item, ItemUpdateType updateType, Boolean specificLanguage)
   at Sitecore.Publishing.DefaultPublishManager.DataEngine_SavedItem(Object sender, ExecutedEventArgs`1 e)
   at System.EventHandler`1.Invoke(Object sender, TEventArgs e)
   at Sitecore.Data.Engines.EngineCommand`2.RaiseEvent[TArgs](EventHandler`1 handlers, Func`2 argsCreator)
   at Sitecore.Data.Engines.EngineCommand`2.Execute()
   at Sitecore.Data.Engines.DataEngine.SaveItem(Item item)

Nested Exception

Exception: System.Data.DataException
Message: Error executing SQL command: IF NOT EXISTS (SELECT * FROM "PublishQueue" WHERE "ItemID" = :p0 AND "Language" = :p1 AND "Date" = :p2 AND "Action" = :p3 ) INSERT INTO "PublishQueue" (     "ItemID", "Language", "Version", "Date", "Action"   )   VALUES(     :p4, :p5, :p6, :p7, :p8   )
```

## License  
This patch is licensed under the [Sitecore Corporation A/S License for GitHub](https://github.com/sitecoresupport/Sitecore.Support.154851/blob/master/LICENSE).  

## Download  
Downloads are available via [GitHub Releases](https://github.com/sitecoresupport/Sitecore.Support.154851/releases).  

[![Github All Releases](https://img.shields.io/github/downloads/SitecoreSupport/Sitecore.Support.154851/total.svg)](https://github.com/SitecoreSupport/Sitecore.Support.154851/releases)
