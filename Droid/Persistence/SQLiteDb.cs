﻿using System;
using XamUDemy.Pages;
using SQLite;
using Xamarin.Forms;
using XamUDemy.Droid.Persistence;
using System.IO;

[assembly: Dependency(typeof(SQLiteDb))]

namespace XamUDemy.Droid.Persistence
{
	public class SQLiteDb : ISQLiteDb
	{
		public SQLiteAsyncConnection GetConnection()
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			var path = Path.Combine(documentsPath, "MySQLite.db3");

			return new SQLiteAsyncConnection(path);

		}
	}
}
