﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Enterspeed.Source.SitecoreCms.V8.Data.Models;
using Sitecore.Configuration;

namespace Enterspeed.Source.SitecoreCms.V8.Data.Repositories
{
    public class EnterspeedJobRepository : IEnterspeedJobRepository
    {
        private readonly string _connectionString;
        private readonly string _schemaName = "EnterspeedJobs";

        public EnterspeedJobRepository()
        {
            var connectionstringName = ConfigurationManager.AppSettings["Enterspeed.QueueSQLConnectionstringName"] ?? "Master";
            _connectionString = Settings.GetConnectionString(connectionstringName);
        }

        public IList<EnterspeedJob> GetFailedJobs()
        {
            var result = new List<EnterspeedJob>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = $@"SELECT * FROM {_schemaName} WHERE JobState = {EnterspeedJobState.Failed.GetHashCode()} ORDER BY CreatedAt DESC";
                using (var command = new SqlCommand(sql, connection))
                {
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        foreach (var record in GetFromReader(reader))
                        {
                            result.Add(EnterspeedJob.Map(record));
                        }
                    }

                    reader.Dispose();
                }
            }

            return result;
        }

        public IList<EnterspeedJob> GetPendingJobs(int count)
        {
            var result = new List<EnterspeedJob>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = $@"SELECT TOP {count} * FROM {_schemaName} WHERE JobState = {EnterspeedJobState.Pending.GetHashCode()} ORDER BY CreatedAt DESC";
                using (var command = new SqlCommand(sql, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foreach (var record in GetFromReader(reader))
                        {
                            result.Add(EnterspeedJob.Map(record));
                        }
                    }

                    reader.Dispose();
                }
            }

            return result;
        }

        public IList<EnterspeedJob> GetOldProcessingTasks(int olderThanMinutes = 60)
        {
            var dateThreshhold = DateTime.UtcNow.AddMinutes(olderThanMinutes * -1);

            var result = new List<EnterspeedJob>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sql = $@"SELECT * FROM {_schemaName} WHERE JobState = {EnterspeedJobState.Processing.GetHashCode()} && UpdatedAt <= {dateThreshhold}";
                using (var command = new SqlCommand(sql, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foreach (var record in GetFromReader(reader))
                        {
                            result.Add(EnterspeedJob.Map(record));
                        }
                    }

                    reader.Dispose();
                }
            }

            return result;
        }

        public void Save(IList<EnterspeedJob> jobs)
        {
            if (jobs == null || !jobs.Any())
            {
                return;
            }

            foreach (var job in jobs)
            {
                var sql = $@"INSERT INTO Id ( EntityId, Culture, JobType, JobState, Exception, CreatedAt, UpdatedAt, EntityType, ContentState) 
                    VALUES('{job.EntityId}', '{job.Culture}', '{job.JobType}', '{job.JobState}', '{job.Exception}', '{job.CreatedAt}','{job.UpdatedAt}','{job.EntityType}','{job.ContentState}' ); ";

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }
            }
        }

        public void Delete(IList<int> ids)
        {
            var arrayOfIds = ids.Select(i => i.ToString()).ToArray();
            var stringOfIds = string.Join(",", arrayOfIds);

            var sql = $@"DELETE from `{_schemaName}` WHERE `Id` IN ({stringOfIds}));";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
            throw new NotImplementedException();
        }

        IEnumerable<IDataRecord> GetFromReader(IDataReader reader)
        {
            while (reader.Read()) yield return reader;
        }

    }
}