using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonoLegal.Core.Entities
{
    public class TemplateEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Code { get; set; }
        public string Template { get; set; }
        public string Subject { get; set; }
        public string Type { get; set; }
    }
}
