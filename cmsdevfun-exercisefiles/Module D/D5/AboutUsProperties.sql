SELECT pkID, fkContentID, Date, LongString 
FROM tblContentProperty 
WHERE fkContentID =
  (SELECT fkContentID FROM tblContentLanguage WHERE Name = 'About us')