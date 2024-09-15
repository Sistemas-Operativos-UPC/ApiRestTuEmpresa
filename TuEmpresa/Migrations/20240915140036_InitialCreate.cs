using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TuEmpresa.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "distritos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_distritos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "estados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "provincias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_provincias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tipos_documentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipos_documentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tipos_modalidad_empresarial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipos_modalidad_empresarial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tipos_persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipos_persona", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "notarias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TarifaSocial = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IdDepartamento = table.Column<int>(type: "int", nullable: false),
                    IdProvincia = table.Column<int>(type: "int", nullable: false),
                    IdDistrito = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_notarias_departamentos_IdDepartamento",
                        column: x => x.IdDepartamento,
                        principalTable: "departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_notarias_distritos_IdDistrito",
                        column: x => x.IdDistrito,
                        principalTable: "distritos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_notarias_provincias_IdProvincia",
                        column: x => x.IdProvincia,
                        principalTable: "provincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "negocios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoModalidad = table.Column<int>(type: "int", nullable: false),
                    IdDepartamento = table.Column<int>(type: "int", nullable: false),
                    IdProvincia = table.Column<int>(type: "int", nullable: false),
                    IdDistrito = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_negocios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_negocios_departamentos_IdDepartamento",
                        column: x => x.IdDepartamento,
                        principalTable: "departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_negocios_distritos_IdDistrito",
                        column: x => x.IdDistrito,
                        principalTable: "distritos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_negocios_provincias_IdProvincia",
                        column: x => x.IdProvincia,
                        principalTable: "provincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_negocios_tipos_modalidad_empresarial_IdTipoModalidad",
                        column: x => x.IdTipoModalidad,
                        principalTable: "tipos_modalidad_empresarial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimerNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SegundoNombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<int>(type: "int", nullable: false),
                    IdTipoDocumento = table.Column<int>(type: "int", nullable: false),
                    IdDepartamento = table.Column<int>(type: "int", nullable: false),
                    IdProvincia = table.Column<int>(type: "int", nullable: false),
                    IdDistrito = table.Column<int>(type: "int", nullable: false),
                    IdTipoPersona = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_personas_departamentos_IdDepartamento",
                        column: x => x.IdDepartamento,
                        principalTable: "departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personas_distritos_IdDistrito",
                        column: x => x.IdDistrito,
                        principalTable: "distritos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personas_provincias_IdProvincia",
                        column: x => x.IdProvincia,
                        principalTable: "provincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personas_tipos_documentos_IdTipoDocumento",
                        column: x => x.IdTipoDocumento,
                        principalTable: "tipos_documentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_personas_tipos_persona_IdTipoPersona",
                        column: x => x.IdTipoPersona,
                        principalTable: "tipos_persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "names",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Abreviatura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdNegocio = table.Column<int>(type: "int", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_names", x => x.Id);
                    table.ForeignKey(
                        name: "FK_names_estados_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_names_negocios_IdNegocio",
                        column: x => x.IdNegocio,
                        principalTable: "negocios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "solicitudes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaEnvio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaFinalizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    IdPersona = table.Column<int>(type: "int", nullable: false),
                    IdNegocio = table.Column<int>(type: "int", nullable: true),
                    IdNotaria = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_solicitudes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_solicitudes_estados_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_solicitudes_negocios_IdNegocio",
                        column: x => x.IdNegocio,
                        principalTable: "negocios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_solicitudes_notarias_IdNotaria",
                        column: x => x.IdNotaria,
                        principalTable: "notarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_solicitudes_personas_IdPersona",
                        column: x => x.IdPersona,
                        principalTable: "personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "comentarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contenido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdSolicitud = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comentarios_solicitudes_IdSolicitud",
                        column: x => x.IdSolicitud,
                        principalTable: "solicitudes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comentarios_IdSolicitud",
                table: "comentarios",
                column: "IdSolicitud");

            migrationBuilder.CreateIndex(
                name: "IX_names_IdEstado",
                table: "names",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_names_IdNegocio",
                table: "names",
                column: "IdNegocio");

            migrationBuilder.CreateIndex(
                name: "IX_negocios_IdDepartamento",
                table: "negocios",
                column: "IdDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_negocios_IdDistrito",
                table: "negocios",
                column: "IdDistrito");

            migrationBuilder.CreateIndex(
                name: "IX_negocios_IdProvincia",
                table: "negocios",
                column: "IdProvincia");

            migrationBuilder.CreateIndex(
                name: "IX_negocios_IdTipoModalidad",
                table: "negocios",
                column: "IdTipoModalidad");

            migrationBuilder.CreateIndex(
                name: "IX_notarias_IdDepartamento",
                table: "notarias",
                column: "IdDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_notarias_IdDistrito",
                table: "notarias",
                column: "IdDistrito");

            migrationBuilder.CreateIndex(
                name: "IX_notarias_IdProvincia",
                table: "notarias",
                column: "IdProvincia");

            migrationBuilder.CreateIndex(
                name: "IX_personas_IdDepartamento",
                table: "personas",
                column: "IdDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_personas_IdDistrito",
                table: "personas",
                column: "IdDistrito");

            migrationBuilder.CreateIndex(
                name: "IX_personas_IdProvincia",
                table: "personas",
                column: "IdProvincia");

            migrationBuilder.CreateIndex(
                name: "IX_personas_IdTipoDocumento",
                table: "personas",
                column: "IdTipoDocumento");

            migrationBuilder.CreateIndex(
                name: "IX_personas_IdTipoPersona",
                table: "personas",
                column: "IdTipoPersona");

            migrationBuilder.CreateIndex(
                name: "IX_solicitudes_IdEstado",
                table: "solicitudes",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_solicitudes_IdNegocio",
                table: "solicitudes",
                column: "IdNegocio");

            migrationBuilder.CreateIndex(
                name: "IX_solicitudes_IdNotaria",
                table: "solicitudes",
                column: "IdNotaria");

            migrationBuilder.CreateIndex(
                name: "IX_solicitudes_IdPersona",
                table: "solicitudes",
                column: "IdPersona");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comentarios");

            migrationBuilder.DropTable(
                name: "names");

            migrationBuilder.DropTable(
                name: "solicitudes");

            migrationBuilder.DropTable(
                name: "estados");

            migrationBuilder.DropTable(
                name: "negocios");

            migrationBuilder.DropTable(
                name: "notarias");

            migrationBuilder.DropTable(
                name: "personas");

            migrationBuilder.DropTable(
                name: "tipos_modalidad_empresarial");

            migrationBuilder.DropTable(
                name: "departamentos");

            migrationBuilder.DropTable(
                name: "distritos");

            migrationBuilder.DropTable(
                name: "provincias");

            migrationBuilder.DropTable(
                name: "tipos_documentos");

            migrationBuilder.DropTable(
                name: "tipos_persona");
        }
    }
}
