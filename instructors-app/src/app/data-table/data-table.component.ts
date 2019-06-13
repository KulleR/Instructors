import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTable, MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material';
import { DataTableDataSource } from './data-table-datasource';
import { InstructorsService } from '../services/instructors.service';
import { Instructor } from '../models/Instructor';
import { AddFormComponent } from '../add-form/add-form.component';
import { EditFormComponent } from '../edit-form/edit-form.component';

@Component({
  selector: 'app-data-table',
  templateUrl: './data-table.component.html',
  styleUrls: ['./data-table.component.css']
})
export class DataTableComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatTable) table: MatTable<Instructor>;

  dataSource: DataTableDataSource;

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['firstName', 'lastName', 'delete'];

  constructor(private instructorsService: InstructorsService, private dialog: MatDialog) { }

  ngOnInit() {
    this.reloadData();
  }

  private onDelete(instructor: Instructor) {
    this.instructorsService.delete(instructor);
    this.refreshTable();
  }

  private onCreate() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    this.dialog.open(AddFormComponent, dialogConfig);
  }

  private onEdit(instructor: Instructor) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.data = instructor;
    this.dialog.open(EditFormComponent, dialogConfig);
  }

  private refreshTable() {
    this.paginator._changePageSize(this.paginator.pageSize);
  }

  private reloadData(){
    this.instructorsService.getAll().subscribe((result: Instructor[]) => {
      this.dataSource = new DataTableDataSource(result);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
      this.table.dataSource = this.dataSource;
    });
  }
}
