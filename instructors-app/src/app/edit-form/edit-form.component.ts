import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { InstructorsService } from '../services/instructors.service';
import { MatDialogRef, MAT_DIALOG_DATA, MatSnackBar } from '@angular/material';
import { Instructor } from '../models/Instructor';

@Component({
  selector: 'app-edit-form',
  templateUrl: './edit-form.component.html',
  styleUrls: ['./edit-form.component.css']
})
export class EditFormComponent {
  isLoading: boolean;
  editInstructorForm = this.fb.group({
    id: [],
    firstName: [null, Validators.required],
    lastName: [null, Validators.required],
    middleName: [null],
  });

  constructor(private fb: FormBuilder, private instructorsService: InstructorsService,
    private dialogRef: MatDialogRef<EditFormComponent>, @Inject(MAT_DIALOG_DATA) public instructor: Instructor,
    private _snackBar: MatSnackBar) {
    this.editInstructorForm.setValue(instructor);
  }

  onSubmit() {
    if (!this.editInstructorForm.valid) {
      return;
    }
    let instructor = Object.assign({}, this.editInstructorForm.value);
    this.isLoading = true;
    this.instructorsService.update(instructor,
      (result) => {
        this._snackBar.open('Instructor updated successfully.', '', { duration: 3000 });
        this.dialogRef.close();
        this.isLoading = false
      },
      (result) => {
        this._snackBar.open(`Updating a instructor failed. ${result.message}`, '', { duration: 3000 });
        this.dialogRef.close();
        this.isLoading = false
      });
  }
}
