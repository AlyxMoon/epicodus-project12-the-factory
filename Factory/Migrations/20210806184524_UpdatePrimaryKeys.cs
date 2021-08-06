using Microsoft.EntityFrameworkCore.Migrations;

namespace Factory.Migrations
{
    public partial class UpdatePrimaryKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EngineerMachine_engineers_EngineersId",
                table: "EngineerMachine");

            migrationBuilder.DropForeignKey(
                name: "FK_EngineerMachine_machines_MachinesId",
                table: "EngineerMachine");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "machines",
                newName: "MachineId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "engineers",
                newName: "EngineerId");

            migrationBuilder.RenameColumn(
                name: "MachinesId",
                table: "EngineerMachine",
                newName: "MachinesMachineId");

            migrationBuilder.RenameColumn(
                name: "EngineersId",
                table: "EngineerMachine",
                newName: "EngineersEngineerId");

            migrationBuilder.RenameIndex(
                name: "IX_EngineerMachine_MachinesId",
                table: "EngineerMachine",
                newName: "IX_EngineerMachine_MachinesMachineId");

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerMachine_engineers_EngineersEngineerId",
                table: "EngineerMachine",
                column: "EngineersEngineerId",
                principalTable: "engineers",
                principalColumn: "EngineerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerMachine_machines_MachinesMachineId",
                table: "EngineerMachine",
                column: "MachinesMachineId",
                principalTable: "machines",
                principalColumn: "MachineId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EngineerMachine_engineers_EngineersEngineerId",
                table: "EngineerMachine");

            migrationBuilder.DropForeignKey(
                name: "FK_EngineerMachine_machines_MachinesMachineId",
                table: "EngineerMachine");

            migrationBuilder.RenameColumn(
                name: "MachineId",
                table: "machines",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "EngineerId",
                table: "engineers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MachinesMachineId",
                table: "EngineerMachine",
                newName: "MachinesId");

            migrationBuilder.RenameColumn(
                name: "EngineersEngineerId",
                table: "EngineerMachine",
                newName: "EngineersId");

            migrationBuilder.RenameIndex(
                name: "IX_EngineerMachine_MachinesMachineId",
                table: "EngineerMachine",
                newName: "IX_EngineerMachine_MachinesId");

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerMachine_engineers_EngineersId",
                table: "EngineerMachine",
                column: "EngineersId",
                principalTable: "engineers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerMachine_machines_MachinesId",
                table: "EngineerMachine",
                column: "MachinesId",
                principalTable: "machines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
