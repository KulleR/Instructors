import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { AppComponent } from './app.component';
import { DataTableComponent } from './data-table/data-table.component';
import {
  MatTableModule, MatPaginatorModule, MatSortModule,
  MatIconModule, MatInputModule, MatButtonModule, MatSelectModule,
  MatRadioModule, MatCardModule, MatDialogModule, MatToolbarModule
} from '@angular/material';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { InstructorsService } from './services/instructors.service';
import { AddFormComponent } from './add-form/add-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { EditFormComponent } from './edit-form/edit-form.component';

@NgModule({
  declarations: [
    AppComponent,
    DataTableComponent,
    AddFormComponent,
    EditFormComponent
  ],
  imports: [
    HttpClientModule,
    BrowserAnimationsModule,
    BrowserModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatIconModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    MatRadioModule,
    MatCardModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatToolbarModule,
    MatSnackBarModule
  ],
  providers: [InstructorsService],
  bootstrap: [AppComponent],
  entryComponents: [AddFormComponent, EditFormComponent]
})
export class AppModule { }
