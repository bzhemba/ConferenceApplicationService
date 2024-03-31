CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Applications" (
    "Id" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "Activity" integer NOT NULL,
    "Title" character varying(100) NOT NULL,
    "Description" character varying(300) NULL,
    "Outline" character varying(1000) NOT NULL,
    "WasSentStatus" boolean NOT NULL,
    CONSTRAINT "PK_Applications" PRIMARY KEY ("Id")
);

CREATE UNIQUE INDEX "IX_Applications_Id" ON "Applications" ("Id");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240331154944_Initial', '7.0.0');

COMMIT;

START TRANSACTION;

ALTER TABLE "Applications" ALTER COLUMN "Activity" TYPE text;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240331170404_AddActivityTable', '7.0.0');

COMMIT;

