using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProveedoresAPI.Domain
{
    public class Proveedor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("nit")]
        public string NIT { get; set; }

        [BsonElement("razonSocial")]
        public string RazonSocial { get; set; }

        [BsonElement("direccion")]
        public string Direccion { get; set; }

        [BsonElement("ciudad")]
        public string Ciudad { get; set; }

        [BsonElement("departamento")]
        public string Departamento { get; set; }

        [BsonElement("correo")]
        public string Correo { get; set; }

        [BsonElement("activo")]
        public bool Activo { get; set; }

        [BsonElement("fechaCreacion")]
        public DateTime FechaCreacion { get; set; }

        [BsonElement("nombreContacto")]
        public string NombreContacto { get; set; }

        [BsonElement("correoContacto")]
        public string CorreoContacto { get; set; }
    }
}
